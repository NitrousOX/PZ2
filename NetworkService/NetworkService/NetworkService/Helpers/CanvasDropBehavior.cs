using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shapes;

namespace NetworkService.Helpers
{
    public static class CanvasDropBehavior
    {
        public static readonly DependencyProperty DropEnabledProperty =
          DependencyProperty.RegisterAttached("DropEnabled", typeof(bool), typeof(CanvasDropBehavior),
              new UIPropertyMetadata(false, OnDropEnabledChanged));

        public static bool GetDropEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(DropEnabledProperty);
        }

        public static void SetDropEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(DropEnabledProperty, value);
        }

        private static void OnDropEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Canvas canvas)
            {
                if ((bool)e.NewValue)
                {
                    canvas.AllowDrop = true;
                    canvas.Drop += Canvas_Drop;
                }
                else
                {
                    canvas.AllowDrop = false;
                    canvas.Drop -= Canvas_Drop;
                }
            }
        }
        private static Point startPoint;

        private static void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Capture the mouse
            var border = sender as Border;
            startPoint = e.GetPosition(border);
            border.CaptureMouse();
        }

        private static void Border_MouseMove(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (border.IsMouseCaptured)
            {
                var canvas = VisualTreeHelper.GetParent(border) as Canvas;
                var currentPosition = e.GetPosition(canvas);

                double left = currentPosition.X - startPoint.X;
                double top = currentPosition.Y - startPoint.Y;

                // Ensure that the item stays within the boundaries of the canvas
                left = Math.Max(0, Math.Min(left, canvas.ActualWidth - border.ActualWidth));
                top = Math.Max(0, Math.Min(top, canvas.ActualHeight - border.ActualHeight));

                Canvas.SetLeft(border, left);
                Canvas.SetTop(border, top);
            }
        }

        private static void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            border.ReleaseMouseCapture();
        }
        private static void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ReactorTemp)))
            {
                var droppedItem = e.Data.GetData(typeof(ReactorTemp)) as ReactorTemp;

                // Determine drop position
                Point dropPosition = e.GetPosition((IInputElement)sender);

                // Create a new Border element
                var border = new Border
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Background = Brushes.White
                };

                // Create a StackPanel to hold the content
                var stackPanel1 = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                var stackPanel2 = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };


                // Create an Image element
                var imagePath = droppedItem.Type.ImgPath;
                var imageUri = new Uri(imagePath, UriKind.Relative);
                var image = new Image
                {
                    Source = new BitmapImage(imageUri),
                    Width = 100,
                    Height = 100
                };

                // Create a TextBlock for the title
                var titleTextBlock = new TextBlock
                {
                    Text = droppedItem.Title,
                    FontSize = 30
                };

                // Create a TextBlock for the value
                var valueTextBlock = new TextBlock
                {
                    FontSize = 35
                };

                // Set up the binding for the Text property of the valueTextBlock
                var valueBinding = new Binding
                {
                    Path = new PropertyPath("Value")
                };
                valueTextBlock.SetBinding(TextBlock.TextProperty, valueBinding);

                // Set up the binding for the Foreground property of the valueTextBlock
                var binding = new Binding
                {
                    Path = new PropertyPath("Value"),
                    Converter = new ValueToColorConverter()
                };
                valueTextBlock.SetBinding(TextBlock.ForegroundProperty, binding);

                // Add the title and value TextBlocks to the stackPanel
                stackPanel1.Children.Add(image);
                stackPanel1.Children.Add(stackPanel2);
                stackPanel2.Children.Add(titleTextBlock);
                stackPanel2.Children.Add(valueTextBlock);

                // Set the DataContext of the border to the dropped item for data binding
                border.DataContext = droppedItem;

                // Set the content of the border to the stackPanel
                border.Child = stackPanel1;

                // Set the position of the dropped item on the canvas
                Canvas.SetLeft(border, dropPosition.X);
                Canvas.SetTop(border, dropPosition.Y);

                // Add event handlers for mouse events to enable dragging
                border.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border.MouseMove += Border_MouseMove;
                border.MouseLeftButtonUp += Border_MouseLeftButtonUp;

                // Add the dropped item to the canvas
                var canvas = sender as Canvas;
                canvas.Children.Add(border);
            }
        }
    }
}

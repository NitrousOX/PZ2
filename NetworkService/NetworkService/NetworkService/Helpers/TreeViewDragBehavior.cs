using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using NetworkService.Model;
using NetworkService.ViewModel;

namespace NetworkService.Helpers
{
    public static class TreeViewDragBehavior
    {
        public static readonly DependencyProperty DragEnabledProperty =
           DependencyProperty.RegisterAttached("DragEnabled", typeof(bool), typeof(TreeViewDragBehavior),
               new UIPropertyMetadata(false, OnDragEnabledChanged));

        public static bool GetDragEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(DragEnabledProperty);
        }

        public static void SetDragEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(DragEnabledProperty, value);
        }

        private static void OnDragEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TreeView treeView)
            {
                if ((bool)e.NewValue)
                {
                    treeView.PreviewMouseLeftButtonDown += TreeView_PreviewMouseLeftButtonDown;
                }
                else
                {
                    treeView.PreviewMouseLeftButtonDown -= TreeView_PreviewMouseLeftButtonDown;
                }
            }
        }

        private static void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject);

            if (item != null)
            {
                var data = item.DataContext as ReactorTemp;
                var treeView = sender as TreeView;
                var viewModel = treeView.DataContext as NetworkDisplayViewModel;

                if (data != null && viewModel != null)
                {
                    // Remove the item from copyCollection
                    viewModel.RemoveEntityFromCopyCollection(data);

                    // Start the drag-and-drop operation
                    DragDrop.DoDragDrop(item, data, DragDropEffects.Move);
                }
            }
        }

        private static T VisualUpwardSearch<T>(DependencyObject source)
            where T : DependencyObject
        {
            while (source != null && source.GetType() != typeof(T))
            {
                source = VisualTreeHelper.GetParent(source);
            }

            return source as T;
        }
    }
}

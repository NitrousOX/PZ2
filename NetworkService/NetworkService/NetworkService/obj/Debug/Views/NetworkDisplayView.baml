   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      ;"clr-namespace:NetworkService.ModelNetworkService.Model  5      ?$clr-namespace:NetworkService.HelpersNetworkService.Helpers  5      ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5	      -    'NetworkService.Views.NetworkDisplayView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      4model"clr-namespace:NetworkService.Model     5      8helpers$clr-namespace:NetworkService.Helpers     5      4local"clr-namespace:NetworkService.Views     5	        � DataContext  5      6   0NetworkService.ViewModel.NetworkDisplayViewModel  5   
    � 	Resources 5      0   *NetworkService.Model.ValueToColorConverter   ValueToColor �� DataType-  'System.Windows.Data.CollectionViewGroup 9� 
IsExpanded&    NetworkService.Model.ReactorTemp �� Orientation �� 	Converter��%g  &	        (��      5   #   *, +)(�� �     5      *, +)7     5   
   6&   �� 5   
   "  6#   .R�5      9�  . ��5      �� 5      $
��Bold"�66   ��6    �� *Name+66   .��5      �� 5      5      �� 5   
   "  6   .R�5       �� $��1q�6   
���   �._�5!      �� $ 
Horizontal=�6   .+�5"      �� $	��100��6<   $	��100��6H   ��6   �� *Type.ImgPath+6W   �� 5#      .+�5$      �� $��30(�6;   ��6$   �� *Title+6;   �� 5%      $��35(�6;   ��6$   �� *Value+��6J   �� *Value+8   5&      5'      5(      5)      5+      .��5,      �  � ColumnDefinitions 5-   
   �� 5.      $
��217* �6   �� 5/      $
��383* �6   .+�52   
   R�  � ToolTip$( "Drag from treeView to right screen��6   $��0��6@   1   +NetworkService.Helpers.TreeViewDragBehavior   DragEnabled . ��6P   �� *ReactorTempsView+53      �� 55   
   $��1��6   $ Drag elements��6!   /   )NetworkService.Helpers.CanvasDropBehavior	   DropEnabled	 . ��56      �� 57      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��58      �  � Color$ Black��6#    � Offset$ 0Q�61   � 59      $ 	#FFA9E3FB��6#   $ 1Q�65   � 5:      $ 	#FF7198A8��6#   $ 0.036Q�65   5;      5>      5@      5B      
   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetworkService.ModelNetworkService.Model  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      ?$clr-namespace:NetworkService.HelpersNetworkService.Helpers  5      ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5	      .    (NetworkService.Views.MeasurmentGraphView   5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4model"clr-namespace:NetworkService.Model     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      8helpers$clr-namespace:NetworkService.Helpers     5      4local"clr-namespace:NetworkService.Views     5	        � DataContext  5      7   1NetworkService.ViewModel.MeasurmentGraphViewModel  5   
    � 	Resources 5      0   *NetworkService.Model.ValueToColorConverter   ValueToColor��%   &	          5   
   6&   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $	��23* �6   .+�5   
   �� $��Center=�6   $��Entity��6-   $��	0,18,0,47q�6>   $��20(�6Q   $
��Bold"�6_   �� 5   
    � ToolTip$ Select and entity to show��6   $	��200��67   $��30��6C   $��0,50,0,0q�6O   $��Center=�6a   $��17(�6~   ��5      �� *EntityNames+ �� SelectedItem 5       �� *SelectedEntity+5!      �� 5"   
   $��1��6    �� Orientation$ Vertical=�6%   $��Center=�6<   $��Center=�6W   .+�5#      �� $��Color��6   $��Center=�6$   $
��Bold"�6A   ���	#FF0027FF$��20(�6j   �� 5$      $ 
Horizontal=�6   $��1��62   .+�5%      �� $��Valid color��6   $
��Bold"�6.   #  Xceed.Wpf.Toolkit.ColorPicker  5&      $% Choose a color for valid values��6#   $��50��6M   $��20��6X      SelectedColor 6d   �� *SelectedGoodColor+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�5'      �� 5(      $ 
Horizontal=�6   $��1��62   .+�5)      �� $��Nonvalid color��6   $
��Bold"�61     5*      $( "Choose a color for nonvalid values��6#   $��50��6Q   $��20��6\    6h   �� *SelectedBadColor+$ TwoWay=�$	 PropertyChanged=�5+      5,      �� 5.   
   $&  Grph showing the selected entity��6   $��1��6<   $��2��6I   ���	#FF8EABC5.+�50      �� 	
 �� X1$	
 100��6   	 �� Y1$ 50��6   	 �� X2$	 100��6$   	 �� Y2$	 300��6-   
���   �$��2��6E   �� 51      $	
 250��6   $ 50��6   $	 250��6$   $	 300��6-   
���   �$��2��6E   �� 52      $	
 400��6   $ 50��6   $	 400��6$   $	 300��6-   
���   �$��2��6E   �� 53      $	
 550��6   $ 50��6   $	 550��6$   $	 300��6-   
���   �$��2��6E   �� 54      $	
 700��6   $ 50��6   $	 700��6$   $	 300��6-   
���   �$��2��6E   A� 57       �� Left$ 65��6   $��70��6A   $��70��6L   
���   �$��2��6�   
 �� Top 6'   �� *Y1+��6X   �� *Value1+ �� 	Converter# [  6�   �� 58      $ 80��6   $
��Bold"�6\   $��20(�6n   $��Center=�6|   $��Center=�6�    6)   �� *Y1t+��6D   �� *Value1+6�   A� 5:      $	 215��6   $��70��6B   $��70��6M   
���   �$��2��6�    6(   �� *Y2+��6Y   �� *Value2+# [  6�   �� 5;      $	 230��6   $
��Bold"�6]   $��20(�6o   $��Center=�6}   $��Center=�6�    6*   �� *Y2t+��6E   �� *Value2+6�   A� 5=      $	 365��6   $��70��6B   $��70��6M   
���   �$��2��6�    6(   �� *Y3+��6Y   �� *Value3+# [  6�   �� 5>      $	 380��6   $
��Bold"�6]   $��20(�6o   $��Center=�6}   $��Center=�6�    6*   �� *Y3t+��6E   �� *Value3+6�   A� 5@      $	 515��6   $��70��6B   $��70��6M   
���   �$��2��6�    6(   �� *Y4+��6Y   �� *Value4+# [  6�   �� 5A      $	 530��6   $
��Bold"�6^   $��20(�6p   $��Center=�6~   $��Center=�6�    6+   �� *Y4t+��6F   �� *Value4+6�   A� 5C      $	 665��6   $��70��6B   $��70��6M   
���   �$��2��6�    6(   �� *Y5+��6Y   �� *Value5+# [  6�   �� 5D      $	 680��6   $
��Bold"�6^   $��20(�6p   $��Center=�6~   $��Center=�6�    6+   �� *Y5t+��6F   �� *Value5+6�   �� 5G      $ 71��6   $	 305��6)   $��31��6Q   $��60��6]   $
��Bold"�6h   $��20(�6z   ��6:   �� *Time1+6z   �� 5H      $	 221��6   $	 305��6*   $��31��6R   $��60��6^   $
��Bold"�6i   $��20(�6{   ��6;   �� *Time2+6{   �� 5I      $	 371��6   $	 305��6*   $��31��6R   $��60��6^   $
��Bold"�6i   $��20(�6{   ��6;   �� *Time3+6{   �� 5J      $	 521��6   $	 305��6*   $��31��6R   $��60��6^   $
��Bold"�6i   $��20(�6{   ��6;   �� *Time4+6{   �� 5K      $	 671��6   $	 305��6*   $��31��6R   $��60��6^   $
��Bold"�6i   $��20(�6{   ��6;   �� *Time5+6{   5L      5M      5N      
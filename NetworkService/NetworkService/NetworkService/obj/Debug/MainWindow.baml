   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5   	   C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5   	   ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5   	       NetworkService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NetworkService     5   	   <	viewModel&clr-namespace:NetworkService.ViewModel     5   	   4views"clr-namespace:NetworkService.Views     5   	     � Title$  
MainWindow��5
   	    � DataContext 5      2   ,NetworkService.ViewModel.MainWindowViewModel  5   
    J� InputBindings 5      �� 5   
    �� Gesture$ CTRL+1��6    �� CommandParameter$ entity��6E    �� Command 6&   �� *
NavCommand+6E   �� 5   
   
 �� Key$ D2��6    �� 	Modifiers$ Controlf�6   $ display��6Q    62   �� *
NavCommand+6Q   �� 5   
   $ D3��6   $ Controlf�6   $ graph��6Q    62   �� *
NavCommand+6Q   �� 5   
   $ F1��6    6   �� *HelpCommand+�� 5   
   $ H��6   $
 Ctrlf�6    6.   �� *HelpCommand+ � 	Resources 5      	 �� DataType7   1NetworkService.ViewModel.NetworkEntitiesViewModel.   (NetworkService.Views.NetworkEntitiesView6   0NetworkService.ViewModel.NetworkDisplayViewModel-   'NetworkService.Views.NetworkDisplayView7   1NetworkService.ViewModel.MeasurmentGraphViewModel.   (NetworkService.Views.MeasurmentGraphView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5   
   "	  6   .R�5        5      �� 5   
   "	  6   .R�5        5      �� 5   
   "	  6   .R�5         5!      5"      .��5#      � 
 � RowDefinitions
 5$   
   �� 5%      $
��Auto �6   �� 5&      $��* �6   .+�5)   
   o� $��0��5*      $��5,5,5,5q�5+      ���	#FF5F5D5D��5-      �� 5.   
   .R�5/      ]� $��Stretch=�6   50      .@�52      m� $��30��53       m� CommandParameter$ entity��55      $��_Entity��56       m� Command 54      �� *
NavCommand+56      m� 57      $��30��58      $ display��5:      $��Display��5;       59      �� *
NavCommand+5;      m� 5<      $��30��5=      $ graph��5?      $��_Graph��5@       5>      �� *
NavCommand+5@      m� 5A      $��30��5B      $
��Help��5D      $��Right=�6   $��0,0,7,0q�6;    5C      �� *HelpCommand+5D   ;   5F      �� 5G   
   $��1��6   ��6&   �� *CurrentViewModel+5H      5I      
   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF_TESTWPF_TEST  5   	   7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5
   	       WPF_TEST.Configuration   5   	   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WPF_TEST     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   1
viewmodels clr-namespace:WPF_TEST.ViewModel  5
   	      CFGMain  � DataContext#  [  5   	    � Title$ Configuration��5   	   $
��1080��6   $
��1920��6-   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��230 �6   5      �� 5      $
��1720 �6   .+�5   
   �� $
��auto��6?   $��1��6L   ��6   �� *SelectedViewModel+6L   �� 5   
   $��0��6    �� Orientation$ Vertical=�6%   $
��Left=�6<   .+�5      9� $	��230��6   $��Stretch=�5      ���#29b6f6
���   �$��Medium"�5   9   $��	DashBoard��5      .��5      �� $ Vertical=�6   .+�5      �� $	��230��6   $��50��5       ���#29b6f6
���   �$��AMDashBoard��5#      ��5"      �� *UpdateViewCommand+��5$      �� 5%      5'      .��5)      �� $ 
Horizontal=�6%   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChartBox=�66   $��25��6F   $��25��6R   �� 5+      $��AM DashBoard��6(   $��14(�6<   $	��0,3q�6J   6Y   5,      5.      �� 5/      $	��230��6   $��50��50      ���#29b6f6
���   ���53      �� 54      56      .��58      �� $ 
Horizontal=�6%   .+�59        $ ChartBox=�66   $��25��6F   $��25��6R   �� 5:      $��PM DashBoard��6(   $��14(�6<   $	��0,3q�6J   6Y   5;      5=      �� 5>      $	��230��6   $��50��5?      ���#29b6f6
���   ���5B      �� 5C      5E      .��5G      �� $ 
Horizontal=�6%   $	��120��6>   .+�5H        $ ChartBox=�66   $��26��6F   $��27��6R   $	��0,0q�6]    J� RenderTransformOrigin$ 
-0.24,0.52&�6j   �� 5I      $��My Approvals��6(   $��14(�6<   $	��0,3q�6J   5J      5K      5L      5M      9� 5O      $	��230��6   $��Stretch=�5P      ���#29b6f6
���   �$��Medium"�5Q   9   $��Configuration��5R      .��5T      �� $ Vertical=�6   5V      5W      � 5X      .+�5Y      9� $��Stretch=�5Z      ���#29b6f6
���   �$��Medium"�5[   9   $��Configuration��5\      5_      5a      � 5b      .+�5c      9� $��Stretch=�5d      ���#29b6f6
���   �$��Medium"�5e   9   $��	Checklist��5f      5i      5k      5m      5o      5p      
   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF_TESTWPF_TEST  5   	   7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5
   	       WPF_TEST.MainWindow   5   	   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WPF_TEST     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   1
viewmodels clr-namespace:WPF_TEST.ViewModel  5
   	    
  MainVM  � DataContext#  [  5   	    � Title$ 
MainWindow��5   	   $
��1080��6   $
��1920��6*    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+5      .��5      � ���#f4f5f9 � RowDefinitions 5   
   �� 5      $	��150 �6   6+   �� 5      $	��900 �6   6+   .+�5   
   � $
��auto��6   $	��150��6   $	��Top=�6*   $��0��6B   ��5      �� 5       �� 
StartPoint$ 0.5 0&�6&   	 �� EndPoint$	 0.5 1&�69   .��5      � 
 � Color$
 	#FF2281D1��6#   � 5      $
 	#FF1166E0��6#    � Offset$ 1Q�65   � 5      $
 	#FF189CE8��6#   $ 0.645Q�65   5        J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         
BlurRadius$ 20Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 2Q�6Y      Color$ Purple��6i   .+�5%      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5'      �� $
��USER��6   $��Center=�6(   $��30(�6C   
�������6Q   '  !MaterialDesignThemes.Wpf.PopupBox  5)         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  $��10,10,10,10q�6e      PopupContent. 5*      �� $	��200��6!   .+�5,      �� $
��Home��6!   $��20(�60   5-      �� 5.      $��
My Profile��6!   $��20(�66   �� 5/      $��Tasks��6!   $��20(�61   �� 50      �� 51      $��Log out��6!   $��20(�63   52      53      55      58      � 5:   
   $	��Top=�6   $	��900��6)   $��1��66   .+�5;      � $	��700��6   $	��200��6   $	��Top=�6,   $
��Left=�6D   $��150,80,400,0q�6_   .+�5<      �� -   5         ��Name$ btn_OpenConfiguration��5=        MaterialDesignRaisedButton#��[ 5>      $	��200��5?      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5@      ���#f36a5a��5B      �� *LoadConfiguration+5E      �� 5F      $��CONFIGURATION��6   $��Right=�60   $	��Top=�6L   $��30q�6d   $��50(�6p   
�������6~   �� 5G      $*��$Partten, Profile & Checklist Builder��6   $��Right=�6K   $��0,100,10,40q�6g   
�������$��30(�6�   5H      � 5J      $	��700��6   $	��200��6   $	��Top=�6,   $��Right=�6D   $��
0,80,130,0q�6`   .+�5K      �� -   5        $ btn_OpenFloor��5L      #��[ 5M      $	��200��5N      $	��700��5O      $ 20��5P      ���#9a59b55S      �� 5T      $��
FLOOR VIEW��6   $��Right=�6-   $	��Top=�6I   $��30q�6a   $��50(�6m   
�������6{   �� 5U      $��Area wise Machine Status��6   $��Right=�6;   $��0,100,10,40q�6W   
�������$��30(�6�   5V      � 5X      $	��700��6   $	��200��6   $	��Top=�6,   $��Right=�6D   $��0,340,130,0q�6`   .+�5Y      �� -   5        $ btn_OpenDashBoard��5Z      #��[ 5[      $	��200��5\      $ 20��5]      ���#5b9ad05a      �� 5b      $��	DASHBOARD��6   $��Right=�6,   $	��Top=�6H   $��30q�6`   $��50(�6l   
�������6z   �� 5c      $��AM/PM List & Extensions��6   $��Right=�6>   $��0,100,10,40q�6Z   
�������$��30(�6�   5d      � 5f      $	��700��6   $	��200��6   $	��Top=�6,   $
��Left=�6D   $��150,340,60,0q�6_   .+�5g      �� #��[ 5h      $	��200��5i      $ 20��5j      ���#25c1805m      �� 5n      $��
SCHEDULING��6   $��Right=�6-   $	��Top=�6I   $��30q�6a   $��50(�6m   
�������6{   �� 5o      $��AM/PM Scheduling��6   $��Right=�63   $��0,100,10,40q�6O   
�������$��30(�6}   5p      � 5r      $	��700��6   $	��200��6   $	��Top=�6,   $
��Left=�6D   $��150,600,60,0q�6_   .+�5s      �� #��[ 5t      $	��200��5u      $ 20��5v      ���#e77d035y      �� 5z      $��REPORT CENTER��6   $��Right=�60   $	��Top=�6L   $��30q�6d   $��50(�6p   
�������6~   �� 5{      $��AM/PM Checklist Reports��6   $��Right=�6:   $��0,100,10,40q�6V   
�������$��30(�6�   5|      � 5~      $	��700��6   $	��200��6   $	��Top=�6,   $��Right=�6D   $��0,600,130,0q�6`   .+�5      �� #��[ 5�      $	��200��5�      $ 20��5�      5�      �� 5�      $��REPORT CENTER��6   $��Right=�60   $	��Top=�6L   $��30q�6d   $��50(�6p   
�������6~   �� 5�      $��AM/PM Checklist Reports��6   $��Right=�6:   $��0,100,10,40q�6V   
�������$��30(�6�   5�      5�      5�      5�      
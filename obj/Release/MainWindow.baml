   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF_TESTWPF_TEST  7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel      WPF_TEST.MainWindow   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:WPF_TEST     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  1
viewmodels clr-namespace:WPF_TEST.ViewModel   
  MainVM  � DataContext#  [   � Title$ 
MainWindow��$
��1080��$
��1920�� � WindowStartupLocation$ CenterScreen=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadedWindowCommand+.��� ���#f4f5f9 � RowDefinitions �� $	��150 ��� $	��900 �.+�� $
��auto��$	��150��$	��Top=�$��0������  �� 
StartPoint$ 0.5 0&�	 �� EndPoint$	 0.5 1&�.��� 
 � Color$
 	#FF2281D1��� $
 	#FF1166E0�� � Offset$ 1Q�� $
 	#FF189CE8��$ 0.645Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   	Direction$ 0Q�   RenderingBias$ Quality=�   ShadowDepth$ 2Q�   Color$ Purple��.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� $
��USER��$��Center=�$��30(�
�������'  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�   	StaysOpen .  $��10,10,10,10q�   PopupContent. �� $	��200��.+��� $
��Home��$��20(��� $��
My Profile��$��20(��� $��Tasks��$��20(��� �� $��Log out��$��20(�� $	��Top=�$	��900��$��1��.+�� $	��700��$	��200��$	��Top=�$
��Left=�$��150,80,400,0q�.+��� -    ��Name$ btn_OpenConfiguration��  MaterialDesignRaisedButton#��[ $	��200��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20�����#f36a5a���� *LoadConfiguration+�� $��CONFIGURATION��$��Right=�$	��Top=�$��30q�$��50(�
��������� $*��$Partten, Profile & Checklist Builder��$��Right=�$��0,100,10,40q�
�������$��30(�� $	��700��$	��200��$	��Top=�$��Right=�$��
0,80,130,0q�.+��� -   $ btn_OpenFloor��#��[ $	��200��$	��700��$ 20�����#9a59b5�� $��
FLOOR VIEW��$��Right=�$	��Top=�$��30q�$��50(�
��������� $��Area wise Machine Status��$��Right=�$��0,100,10,40q�
�������$��30(�� $	��700��$	��200��$	��Top=�$��Right=�$��0,340,130,0q�.+��� -   $ btn_OpenDashBoard��#��[ $	��200��$ 20�����#5b9ad0�� $��	DASHBOARD��$��Right=�$	��Top=�$��30q�$��50(�
��������� $��AM/PM List & Extensions��$��Right=�$��0,100,10,40q�
�������$��30(�� $	��700��$	��200��$	��Top=�$
��Left=�$��150,340,60,0q�.+��� #��[ $	��200��$ 20�����#25c180�� $��
SCHEDULING��$��Right=�$	��Top=�$��30q�$��50(�
��������� $��AM/PM Scheduling��$��Right=�$��0,100,10,40q�
�������$��30(�� $	��700��$	��200��$	��Top=�$
��Left=�$��150,600,60,0q�.+��� #��[ $	��200��$ 20�����#e77d03�� $��REPORT CENTER��$��Right=�$	��Top=�$��30q�$��50(�
��������� $��AM/PM Checklist Reports��$��Right=�$��0,100,10,40q�
�������$��30(�� $	��700��$	��200��$	��Top=�$��Right=�$��0,600,130,0q�.+��� #��[ $	��200��$ 20���� $��REPORT CENTER��$��Right=�$	��Top=�$��30q�$��50(�
��������� $��AM/PM Checklist Reports��$��Right=�$��0,100,10,40q�
�������$��30(�
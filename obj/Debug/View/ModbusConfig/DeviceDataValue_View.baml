   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5      (    "WPF_TEST.View.DeviceDataValue_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  a ]DevExpress.Xpf.Grid.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v19.2.Core, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   6Q   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      7
DisplayLed clr-namespace:WPF_TEST.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      b	 ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5       
  Modbus  � DataContext#  [  5	      $	��768��5      $
��1366��6   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *RuntimeLoaded+5       � 	Resources 5        tbl �� 
TargetType �� Property �� Value  tb#   WPF_TEST.ViewModel.LedRunning 
 LedRun!   WPF_TEST.ViewModel.LedPause  LedPause!   WPF_TEST.ViewModel.LedError  LedError&    WPF_TEST.ViewModel.ArrayToString  
ShowString  GridVisible��%%  &	       &	 �     &	 �    &	 �    &	 �    &	 �    &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ DemiBold"�6+   �� 5       � ��$ Center=�62   �� 5       � ��$	 150��6&   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ DemiBold"�6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Right=�6/   5         5!   
   6      5"   
   6     5#   
   6     5$   
   6#   �� 5%   
   6'   5&      .��5'      � 	 � ColumnDefinitions	 5(   
   �� 5)      �� 5*      .+�5-   
   � $��0��6   .+�5.      �� $��0��6   
 �� Orientation$
 Vertical=�6&   .+�5/      �� $�� Data Subscription��6   .��50      �� $
 Vertical=�6!   .+�51      �� $
 
Horizontal=�6%   .+�52      �� $��Tên Thiết Bị:��6(   #��[ 6=   �� 53      #��[ 6L   ��6&   �� *ValueTemp.DeviceName+6L   54      �� 55      $
 
Horizontal=�6%   .+�56      �� $��Read Time Out(ms):��6(   #��[ 6B   �� 57      #��[ 6O   ��6&   �� *ValueTemp.Read_Time_Out+6O   58      �� 59      $
 
Horizontal=�6%   .+�5:      �� $��Update Rate(ms):��6(   #��[ 6@   �� 5;      #��[ 6M   ��6&   �� *ValueTemp.Update_Rate+6M   5<      �� 5=      $
 
Horizontal=�6%   .+�5>      �� $��Địa chỉ:��6(   #��[ 68   �� 5?      #��[ 6R   ��6&   �� *ValueTemp.Register_Address+6R   5@      �� 5A      $
 
Horizontal=�6%   .+�5B      �� $��Số Lượng:��6(   #��[ 69   �� 5C      #��[ 6J   ��6&   �� *ValueTemp.Quantity+6J   5D      5E      5F      �� 5G      $��Trạng Thái Kết Nối��6   .��5H      � $	��350��5I      $	��150��5J      $��Center=�5K      $��Center=�5L      	 5M      �� 5N      �� 5O      �� 5P      .+�5R      �� $	��350��6$   $	��150��5S        �� RadiusX$ 20��5T       $��3��5U   $    �� RadiusY$ 20��5V       +	 	 %MaterialDesignThemes.Wpf.ShadowAssist 	  ShadowDepth$ Depth3=�5W       ��5X      
� 5Y   "   .��5Z   &   �  � Color$
 Gray��63    � Offset$ 0Q�6@   � 5[   &   $ Black��63   $	 1.1Q�6A   5\   #   5_      �� 5`      $��0��5a      $ 40��5b      $ 40��5c      $��80��5d      $��80��5e      ��5f      
� 5g   "   .��5h   &   � $ Black��63   $ 1Q�6A   � 5i   &   $
 Gray��63   $	 0.9Q�6@   � 5j   &   -   5        
LedRun��$	 0.8Q�5j   �    6C   �� *LastItemRuntimeValue.Stage+ �� 	Converter# [ 6�   5k   #   5m      �� 5n      $��1��5o      $ 40��5p      $ 40��5q      $��80��5r      $��80��5s      ��5t      
� 5u   "   .��5v   &   � $ Black��63   $ 1Q�6A   � 5w   &   $
 Gray��63   $	 0.9Q�6@   � 5x   &   $	 0.8Q�6�    63   �� *LastItemRuntimeValue.Stage+# [ 5z   '   5{   #   5}      �� 5~      $��2��5      $ 40��5�      $ 40��5�      $��80��5�      $��80��5�      ��5�      
� 5�   "   .��5�   &   � $ Black��63   $ 1Q�6A   � 5�   &   $
 Gray��63   $	 0.9Q�6@   � 5�   &   -   5        LedError��$	 0.8Q�5�   �    6E   �� *LastItemRuntimeValue.Stage+# [ 6�   5�   #   5�      5�      5�      �� 5�      $
 
Horizontal=�6   $��0,20,0,0q�66   .+�5�      �� $��20,0,0,0q�5�      
����  �$��2q�5�      $��50��5�      $	��120��5�      +
 	 %MaterialDesignThemes.Wpf.ButtonAssist 
  CornerRadius$ 5��5�        MaterialDesignFlatButton#��[ 5�      ��5�      �� *Cancel_Excute+.��5�      �� $
 
Horizontal=�6%   .+�5�      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��25��5�   !   $��35��5�   !      Kind$ ArrowBackCircle=�5�   !   $��Center=�5�   !   �� 5�      $��4,0,0,0q�6(   $��
Quay Lại��69   $��Center=�6I   5�      5�      �� 5�      $��20,0,0,0q�5�      
����  �$��2q�5�      $��50��5�      $	��140��5�      $ 5��5�      #��[ 5�      .��5�      �� $
 
Horizontal=�6%   .+�5�      �� $��25��5�   !   $��25��5�   !   $��UniformToFill=�5�   !   $!��/ImageSource/Disconnect.png��5�   !   �� 5�      $��4,0,0,0q�6(   $��
Disconnect��69   $��Center=�6K   5�      5�      � 5�      $��50��6   $��25,0,0,0q�6&   y�68   �� *Cansee+# [ .+�5�      � $��Center=�5�      $��Center=�5�      $��45��5�      $��45��5�       � Maximum$	 100Q�5�       � Minimum$ 0Q�5�       %	 !MaterialDesignCircularProgressBar#��[	 5�      y�5�      �� *Cansee+# [  � Value 5�      �� *ProcesPercent+5�      �� 5�      $��DemiBold"�5�      $��Center=�5�      $��Center=�5�      y�5�      �� *Cansee+# [ �� 5�      �6"   �� *ProcesPercent+ �� 5�      $�%��6"   5�      5�      5�      5�      5�      � 5�   
   $��1��6   .+�5�      �� ��6   �� *Select_PLCVALUE.Data+ �� View 5�      �� 5�      .P�5�      �� $��Thời Gian��6)    �� CellTemplate 5�      �� 5�   "   .R�5�   &   �� ��60   �� *CurrentTime+5�   #   5�      �� 5�      $��
Giá trị��6)    5�      �� 5�   "   .R�5�   &   �� ��60   ��  �� Path$ 
ArrayValue�# [ 5�   #   5�      5�      5�      5�      5�      5�      
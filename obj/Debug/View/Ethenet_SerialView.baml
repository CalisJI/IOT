   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      G(clr-namespace:WPF_TEST.SerialCommunicateWPF_TEST.SerialCommunicate  5      "    WPF_TEST.View.Ethenet_Serial   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      =Connvert(clr-namespace:WPF_TEST.SerialCommunicate     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 	Resources  5      ;   5WPF_TEST.SerialCommunicate.BoolToIsConnectedConverter   boolconvert��%   &	          5   
   6.   5      .��5      � .+�5   
   ��  �� TabStripPlacement$ Bottom=�5       ) %MaterialDesignNavigatilRailTabControl#��[ 5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�5      .@�5      �� $��4q�5      ��5      �� 5      
�������$
��auto��5      $
��auto��5      .+�5      �� $��Ethernet Communication��5      $��Center=�5      $��35(�5      $��DemiBold"�5      5       5#      �� 5$      $��4q�5%      ��5&      �� 5'      
�������$
��auto��5(      $
��auto��5)      .+�5*      �� $��Serial Communication��5+      $��Center=�5,      $��35(�5-      $��DemiBold"�5.      5/      .��52      ��  �� Orientation$ 
Horizontal=�6   .+�53      � $
��auto��54      $
��auto��55      .+�56      � $	��Top=�57      $
��Left=�58      $��50,20q�59      $	��150��5:      $��80��5;      .+�5<      ��   DataStr � DataContext# [ 5=        MaterialDesignRaisedButton#��[ 5>      $��60��5?      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5@       � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��5A      ��5B      �� *
DataStream+.��5C   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ StepBackward2=�6:   $��40��6O   $��80��6[   5D      5E      �� 5F      $	��900��5H      $	��500��5I      $	��Top=�5J      $
��Left=�5K      $��60,100q�5L        Ethernet_Serial# [ 5M      .+�5O      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ COM Port��5P      $��20(�5Q      $��72��5R      $��45��5S      $	��Top=�5W      $��20q�5X      ��5U      �� *$"SerialPort.Settings.AvaliablePorts+	 �� Mode$	 OneTime=�
 �� SelectedItem
 5V      �� *%#SerialPort.Settings.SelectedCOMPort+ �� UpdateSourceTrigger$ PropertyChanged=���5[   "   �� 5\   &   .R�5]   *   $� 5^   '   5`      �� 5a      $ 	Baud Rate��5b      $��20(�5c      $��72��5d      $��45��5e      $	��Top=�5h      $��20q�5i      ��5f      �� *SerialPort.Settings.Baud_rate+$	 OneTime=�
 5g      �� *&$SerialPort.Settings.SelectedBaudRate+$ PropertyChanged=���5k   "   �� 5l   &   .R�5m   *   $� 5n   '   5p      �� 5q      $ Parity��5r      $��20(�5s      $��72��5t      $��45��5u      $	��Top=�5x      $��20q�5y      ��5v      �� *SerialPort.Settings.Paritys+$	 OneTime=�
 5w      �� *$"SerialPort.Settings.SelectedParity+$ PropertyChanged=���5{   "   �� 5|   &   .R�5}   *   $� 5~   '   5�      �� 5�      $ 	Stop Bits��5�      $��20(�5�      $��72��5�      $��45��5�      $	��Top=�5�      $��20q�5�      ��5�      �� *SerialPort.Settings.Stop_bits+
 5�      �� *&$SerialPort.Settings.SelectedStopBits+$ PropertyChanged=���5�   "   �� 5�   &   .R�5�   *   $� 5�   '   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Read Time Out (ms):��5�      $��20(�5�      $	��180��5�      $
��Left=�5�      $��
20,10,5,15q�5�      �� 5�   "   $	��500��5�      $��20(�5�      $	��350��5�      $��
20,10,5,15q�5�      5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Update Rate (ms):��5�   %   $��20(�5�   %   $	��180��5�   %   $
��Left=�5�   %   $��	20,15,5,5q�5�   %   �� 5�   "   $
��1000��5�   %   $��20(�5�   %   $	��350��5�   %   $��	20,15,5,5q�5�   %   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   � $	��Top=�5�   %   $
��Left=�5�   %   $��24,20q�5�   %   $	��150��5�   %   $��80��5�   %   .+�5�   &   �� #��[ 5�   )   $��60��5�   )   $ 10��5�   )   $ Connect��5�   )   {�5�   )   �� *SerialPort.everIsConnected+$ PropertyChanged=� �� 	Converter# [  ��5�   )   �� *)'SerialPort.AutoConnectDisconnectCommand+$	 OneTime=�.��5�   *     $ PowerPlugOutline=�6B   $��40��6Z   $��80��6f   5�   '   5�   #   � 5�   "   $��Center=�5�   %   $��Center=�5�   %   .+�5�   &   �� #��[ 5�   )   $��60��5�   )   $ 10��5�   )   $ 
Disconnect��5�   )   ��5�   )   �� *)'SerialPort.Settings.RefreshPortsCommand+$	 Default=�.��5�   *     $ Refresh=�6B   $��40��6Q   $��80��6]   5�   '   5�   #   � 5�   "   $	��Top=�5�   %   $
��Left=�5�   %   $��20,20q�5�   %   $	��150��5�   %   $��80��5�   %   .+�5�   &   �� #��[ 5�   )   $��60��5�   )   $ 10��5�   )   $ 
Disconnect��5�   )   {�5�   )   �� *SerialPort.IsConnected+$ PropertyChanged=�# [  ��5�   )   �� *)'SerialPort.AutoConnectDisconnectCommand+$	 OneTime=�.��5�   *     $ PowerPlugOffOutline=�6B   $��40��6]   $��80��6i   5�   '   5�   #   5�      � 5�      $	��Top=�5�   %   $��Center=�5�   %   $��50,20q�5�   %   $	��150��5�   %   $��80��5�   %   .+�5�   "   �� #��[ 5�   )   $��60��5�   )   $ 10��5�   )   $
 Send��5�   )   ��5�   )   �� .��5�   &     $
 Send=�6>   $��40��6J   $��80��6V   5�   #   5�      5�      5�      � 5�      # [ 6   $
��1250��6J   .+�5�      �� -   5         ��Name$ RCVtb��5�   &   $��20(�5�   &    �� TextWrapping$
 Wrap=�5�   &   " �� VerticalScrollBarVisibility$
 Auto=�5�   &    �� AcceptsReturn .  �� 
IsReadOnly . ���#ffffff$��0,100,0,100q�5�   &   ��5�   &   �� *Messages.MessagesText+$ PropertyChanged=�5�   ;   5�      5�      5      5     5     5     
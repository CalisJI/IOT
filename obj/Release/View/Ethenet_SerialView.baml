   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  G(clr-namespace:WPF_TEST.SerialCommunicateWPF_TEST.SerialCommunicate  "    WPF_TEST.View.Ethenet_Serial   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WPF_TEST.View     =Connvert(clr-namespace:WPF_TEST.SerialCommunicate     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � 	Resources  ;   5WPF_TEST.SerialCommunicate.BoolToIsConnectedConverter   boolconvert��%   &	          .��� .+���  �� TabStripPlacement$ Bottom=� ) %MaterialDesignNavigatilRailTabControl#��[ .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�.@��� $��4q����� 
�������$
��auto��$
��auto��.+��� $��Ethernet Communication��$��Center=�$��35(�$��DemiBold"��� $��4q����� 
�������$
��auto��$
��auto��.+��� $��Serial Communication��$��Center=�$��35(�$��DemiBold"�.����  �� Orientation$ 
Horizontal=�.+�� $
��auto��$
��auto��.+�� $	��Top=�$
��Left=�$��50,20q�$	��150��$��80��.+���   DataStr � DataContext# [   MaterialDesignRaisedButton#��[ $��60��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10�� � ToolTip$3 -MaterialDesignRaisedButton with Round Corners������ *
DataStream+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ StepBackward2=�$��40��$��80���� $	��900��$	��500��$	��Top=�$
��Left=�$��60,100q�  Ethernet_Serial# [ .+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ COM Port��$��20(�$��72��$��45��$	��Top=�$��20q����� *$"SerialPort.Settings.AvaliablePorts+	 �� Mode$	 OneTime=�
 �� SelectedItem
 �� *%#SerialPort.Settings.SelectedCOMPort+ �� UpdateSourceTrigger$ PropertyChanged=����� .R�$� �� $ 	Baud Rate��$��20(�$��72��$��45��$	��Top=�$��20q����� *SerialPort.Settings.Baud_rate+$	 OneTime=�
 �� *&$SerialPort.Settings.SelectedBaudRate+$ PropertyChanged=����� .R�$� �� $ Parity��$��20(�$��72��$��45��$	��Top=�$��20q����� *SerialPort.Settings.Paritys+$	 OneTime=�
 �� *$"SerialPort.Settings.SelectedParity+$ PropertyChanged=����� .R�$� �� $ 	Stop Bits��$��20(�$��72��$��45��$	��Top=�$��20q����� *SerialPort.Settings.Stop_bits+
 �� *&$SerialPort.Settings.SelectedStopBits+$ PropertyChanged=����� .R�$� �� $ 
Horizontal=�.+��� $��Read Time Out (ms):��$��20(�$	��180��$
��Left=�$��
20,10,5,15q��� $	��500��$��20(�$	��350��$��
20,10,5,15q��� $ 
Horizontal=�.+��� $��Update Rate (ms):��$��20(�$	��180��$
��Left=�$��	20,15,5,5q��� $
��1000��$��20(�$	��350��$��	20,15,5,5q��� $ 
Horizontal=�.+�� $	��Top=�$
��Left=�$��24,20q�$	��150��$��80��.+��� #��[ $��60��$ 10��$ Connect��{��� *SerialPort.everIsConnected+$ PropertyChanged=� �� 	Converter# [  ���� *)'SerialPort.AutoConnectDisconnectCommand+$	 OneTime=�.��  $ PowerPlugOutline=�$��40��$��80��� $��Center=�$��Center=�.+��� #��[ $��60��$ 10��$ 
Disconnect������ *)'SerialPort.Settings.RefreshPortsCommand+$	 Default=�.��  $ Refresh=�$��40��$��80��� $	��Top=�$
��Left=�$��20,20q�$	��150��$��80��.+��� #��[ $��60��$ 10��$ 
Disconnect��{��� *SerialPort.IsConnected+$ PropertyChanged=�# [  ���� *)'SerialPort.AutoConnectDisconnectCommand+$	 OneTime=�.��  $ PowerPlugOffOutline=�$��40��$��80��� $	��Top=�$��Center=�$��50,20q�$	��150��$��80��.+��� #��[ $��60��$ 10��$
 Send������ .��  $
 Send=�$��40��$��80��� # [ $
��1250��.+��� -    ��Name$ RCVtb��$��20(� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=� �� AcceptsReturn .  �� 
IsReadOnly . ���#ffffff$��0,100,0,100q����� *Messages.MessagesText+$ PropertyChanged=�
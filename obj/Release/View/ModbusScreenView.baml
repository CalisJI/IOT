   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  $    WPF_TEST.View.ModbusScreenView   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WPF_TEST.View     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   
  Modbus  � DataContext#  [  .���  � ColumnDefinitions �� �� ��  � RowDefinitions �� �� $
��0.2* �.+��� $��0��$��0��.+��� $��30,40,30,10q�$��Controller Name�� �� TextAlignment$ Center=�$��26(�.���� -    ��Name$ Modbus_list��$	��692��$��Visible=�#  [  ���� *ModbusDevices+���� .R��� ���� *
DeviceName+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *Display_Type+	   CommandParameter	 �� 
 �� ElementName$
 Modbus_list�� �� Path$ SelectedItem���  �� Orientation$ Vertical=�$��1��$��0��.+��� $��30,40,30,10q�$��Controller Details��$ Center=�$��26(�.���� $ Vertical=�$��0,10,0,0q�.+�� $	��380��#  [  $��Visible=�.+��� ���� *DisplayType+�� $��
30,20,30,0q�$��Data Exportation��$ Center=�.���� $ Vertical=�.+�� .+��� $��Export Rate (ms):��$��20(�$
��Left=�$��5q��� $��	190,0,0,0q�$
��Left=�$��20(�$	��N/A��� $��0,10,0,0q�.+��� $��Data Delimiter:��$��20(�$
��Left=�$��5q��� $��	190,0,0,0q�$
��Left=�$��20(�$	��N/A��� $��0,10,0,0q�.+��� $��Extraction Method:��$��20(�$
��Left=�$��5q��� $��	190,0,0,0q�$
��Left=�$��20(�$	��N/A��� $��0,10,0,0q�.+��� $��Export Directory:��$��20(�$
��Left=�$��5q��� $��	190,0,0,0q�$
��Left=�$��20(�$	��N/A��� $��0,10,0,0q�.+��� $��
File Path:��$��20(�$
��Left=�$��5q���  �� TextWrapping$
 Wrap=�$
��Auto=�$��	190,0,0,0q�$
��Left=�$��20(�$	��N/A���� $��0��$��1��$ 
Horizontal=�$��0,0,0,55q�.+��� $��80��$��80��$��70,0,0,0q�  MaterialDesignIconButton#��[  � ToolTip$ Start�� ( $MaterialDesignTextFieldBoxBackground#���  ���� *Start+���� $
 Modbus_list��$ SelectedItem�.��'  !MaterialDesignThemes.Wpf.PackIcon  $��80��
��� ���$��80��   Kind$
 Play=��� $��80��$��80��$��70,0,0,0q�#��[ $
 Stop��#���  ���� *Stop+.��  $��80�����#f6236e$��80��$
 Stop=��� #  [  $��80��$��80��$��70,0,0,0q�#��[ $ Start Service��#���  ���� *Start_Service+.��  $��80��
��� � �$��80��$
 Play=��� $��80��$��80��$��70,0,0,0q�#��[ #���  ���� *Stop_Service+.��  
���  ��$��80��$��80��$
 Stop=��� $��76��$ 
Horizontal=�$��Bottom=�$��1��$��0��.+��� $��Start��$��20(�$��90,0,0,0q��� $
��Stop��$��20(�$��	108,0,0,0q��� $��Start Service��$��20(�$��80,0,0,0q��� $��Stop Service��$��20(�$��40,0,0,0q��� $��2��$��1��$ 
Horizontal=�$��0,0,0,55q�.+��� $��80��$��80��$��70,0,0,0q�#��[ $ Start��#���  ���� *
NewConnect+.��  $��80��
��� ���$��80��$ 
PlusCircle=��� $��80��$��80��$��70,0,0,0q�#��[ $
 Stop��#���  ���� *EditConnect+���� $
 Modbus_list��$ SelectedItem�.��  $��80�����#f6236e$��80��$ FileEdit=��� $��80��$��80��$��70,0,0,0q�#��[ $ Delete��#���  ���� *DeleteConnect+���� $
 Modbus_list��$ SelectedItem�.��  $��80��
���  ��$��80��$ Delete=��� $��80��$��80��$��70,0,0,0q�#��[ $ Connect��#���  ���� *ConnectionExcute+.��  
��� � �$��80��$��80��$ 
Connection=��� $��66��$ 
Horizontal=�$��Bottom=�$��1��$��2��.+��� $	��Add��$��20(�$��92,0,0,0q��� $
��Edit��$��20(�$��	112,0,0,0q��� $��Delete��$��20(�$��	106,0,0,0q��� $��Connect��$��20(�$��85,0,0,0q��� $ Vertical=�$��0��$��2��.+��� $��30,40,30,10q�$��Modbus Item��$
 Left=�$��26(�.���� #  [   �� View �� .P��� $��ID�� �� DisplayMemberBinding �� $
 Modbus_list��$ SelectedItem.ID��� $��Register�� �� $
 Modbus_list��$# SelectedItem.Register_Address��� $��Value��.@��� $y�	Collapsed=�$��Right=�� $��1��$��1��$��Center=�$��Center=�$��50,20q�$	��150��$��80��.+��� -    ��Name$ Home_button��  MenuMainAll#  [   MaterialDesignRaisedButton#��[ $��80��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��$
 Back������ *
DataStream+.��  $ StepBackward2=�$��60��$	��100��� $��1��$��1��$��Center=�$��Center=�$��50,20q�$	��150��$��80��.+��� -   $��
update_btn��$y�Hidden=�#  [  #��[ $��80��$ 10��$
 Back������ *Update_Data+.��  $ StepBackward2=�$��60��$	��100��
   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      %    WPF_TEST.View.TCP_IP_Frame_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5       
  Modbus  � DataContext#  [  5      .��5
      �� 
������� �� Orientation$ Vertical=�6(   .+�5   
   � .+�5      �� $��Name:��5      $��20(�5      $
��Left=�5      $��5q�5      �� 5       �� 
IsReadOnly . $��	190,0,0,0q�5      $
��Left=�5      $��20(�5      ��5      ��  �� ElementName$ Modbus_list�� �� Path$ SelectedItem.DeviceName�5      � 5   
   $��0,10,0,0q�6   .+�5      �� $��IP Address:��5      $��20(�5      $
��Left=�5      $��5q�5      �� 5       . $��	190,0,0,0q�5!      $
��Left=�5"      $��20(�5#      ��5$      �� $ Modbus_list��$ SelectedItem.IP_Address�5%      � 5&   
   $��0,10,0,0q�6   .+�5'      �� $��IP Port:��5(      $��20(�5)      $
��Left=�5*      $��5q�5+      �� 5,       . $��	190,0,0,0q�5.      $
��Left=�5/      $��20(�50      ��51      �� $ Modbus_list��$ SelectedItem.TCP_IP_Port�52      � 54   
   $��0,10,0,0q�6   .+�55      �� $��Read Time Out (ms):��56      $��20(�57      $
��Left=�58      $��5q�59      �� 5:       . $��	190,0,0,0q�5<      $
��Left=�5=      $��20(�5>      ��5?      �� $ Modbus_list��$  SelectedItem.Read_Time_Out�5@      � 5A   
   $��0,10,0,0q�6   .+�5B      �� $��Update Rate (ms):��5C      $��20(�5D      $
��Left=�5E      $��5q�5F      �� 5G       . $��	190,0,0,0q�5I      $
��Left=�5J      $��20(�5K      ��5L      �� $ Modbus_list��$ SelectedItem.Update_Rate�5M      5N      5O      
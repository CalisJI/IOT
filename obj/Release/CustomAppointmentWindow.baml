   M S B A M L   `   `   `  ����   WPF_TEST&     WPF_TEST.CustomAppointmentWindow   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  g cDevExpress.Xpf.Scheduling.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aDdxsch8http://schemas.devexpress.com/winfx/2008/xaml/scheduling  OdxschtBhttp://schemas.devexpress.com/winfx/2008/xaml/scheduling/themekeys  c _DevExpress.Xpf.Ribbon.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ] YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ag	 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   	 b
 ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 
 j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   &   DevExpress.Xpf.Core.ThemedWindow   Name$  window��   ScheduleViewModel � DataContext# [  2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors -  'DevExpress.Mvvm.UI.CurrentWindowService     ClosingCommand �� *WindowClosingCommand+%  DevExpress.Mvvm.UI.KeyToCommand     
KeyGesture$	 Esc���  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   	EventName$ KeyDown��+  %DevExpress.Mvvm.UI.EventToCommandBase    MarkRoutedEventsAsHandled .    Command 1  +DevExpress.Xpf.DXBinding.DXCommandExtension     Execute$ @e(window).Close()��.��� .+�� 	 � ColumnDefinitions	 �� �� 
 � RowDefinitions
 �� $��5* ��� $
��0.2* �.+��� $��0��$��0��$��Visible=�.���� $��0��$
��1000��  EditJob# [  �� Orientation$ Vertical=�.+��� $��Scheduler Creating��$��50(�$��DemiBold"�
�������$��
50,30,0,30q��� $ 
Horizontal=�.+��� $��Sales Order #*��$��22(�$
��Bold"�$��	50,10,0,0q�
��������� $��30(�$��	20,0,10,0q�
�������$	��723��
����������� *SelectedJob.SalesOrder+�   WorkFlow# [ .+��� 
���   �._��� $��
300,0,20,0q�.+��� $��Customer��
�������$��22(�.���� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��
Custommer*��
���   �$
��Bold"�$��20,5,0,0q��� -   $��Customer_cbb��$��	52,5,10,0q�$	��420��$��20(� �� SelectedItem �� *SelectedJob.Customer+���� *CustomerInfo+���� .R��� ���� *Customer_Info+�� $ 
Horizontal=�.+��� $��Customer Details��$��	20,10,0,0q��� $��20,0,0,0q� �� TextWrapping$
 Wrap=� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�$	��420��$	��170������ *SelectedJob.Customer_Details+�� $>��8Check to change delivery details if different from above�� d� 	IsChecked$ FalseY�$��12(�$��	190,0,0,0q�� 
�������$��0,0,20,0q�	 �� $��1* ��� $
��2.2* �.+��� $ Vertical=�$��0��.+��� $��Quotation #��$��22(�$��	50,0,0,30q�$
��auto���� $��Customer PO #��$��22(�$��	50,0,0,30q�$
��auto���� $��Requested Start*��$��22(�$��	50,0,0,30q�$
��auto��$
��Bold"��� $��Requested End*��$��22(�$��	50,0,0,30q�$
��auto��$
��Bold"��� $��Requested Report Date*��$��22(�$��	50,0,0,30q�$
��auto���� $��	*Priority��$��20(�$��
50,10,0,30q�$
��auto��$
��Bold"��� $��*Required Fields��$��20(�$��
50,10,0,30q�$
��auto��$
��Bold"��� $ Vertical=�$��1��.+��� $��50��$��25(�$��	20,0,0,10q����� *SelectedJob.Quotation+�� $��50��$��25(�$��	20,0,0,10q����� *SelectedJob.Customer_PO+(  "System.Windows.Controls.DatePicker  
���  ��$��50��   Text$
 Demo��$��25(�$��	20,0,0,10q�   SelectedDate �� *" SelectedJob.Requested_Start.Date+  
���  ��$��50��$
 Demo��$��25(�$��	20,0,0,10q� �� * SelectedJob.Requested_End.Date+  
���  ��$��50��$
 Demo��$��25(�$��	20,0,0,10q� �� *(&SelectedJob.Requested_Report_Date.Date+�� $��50�� �� Text$
 Demo��$��25(�$��	20,0,0,10q�� $��1��.+�� .+���  # MaterialDesignRaisedLightButton#��[ $��70��# [ +	 
 %MaterialDesignThemes.Wpf.ShadowAssist 	  ShadowDepth$ Depth3=�$��80��$��Right=�$��Bottom=�$��	0,0,20,30q����#673ab7+
 
 %MaterialDesignThemes.Wpf.ButtonAssist 
  CornerRadius$ 8��.���� $ Vertical=�$��Center=�.+�' 
 !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=�$��40��$��50��
��� � ��� $
��Save��$��15(�$��Center=�
���   ��� #��[ $��70��$ Depth3=�$��80��$��Right=�$��Bottom=�$��
0,0,20,150q����#673ab7$ 8��.���� $ Vertical=�$��Center=�.+�  $��Center=�$ CloseCircle=�$��40��$��40��
���  ���� $��Cancel��$��15(�$��Center=�
���   �� $��10,140,110,30q�.+��� $
��Work��$��22(�.���� 
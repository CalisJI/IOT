   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  $    WPF_TEST.View.EditJobModelView   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WPF_TEST.View     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     WorkFlow  � DataContext#  [  .���  � ColumnDefinitions �� ��  � RowDefinitions �� $��5* ��� $
��0.8* �.+��� $��0�� �� Orientation$ Vertical=�.+��� $��Edit Job��$��50(�$��DemiBold"�
�������$��
50,30,0,30q��� $��Visible=�$��Visible=�.���� $ Vertical=�$	��700��.+��� $ 
Horizontal=�.+��� $��Sales Order #*��$��22(�$
��Bold"�$��	50,10,0,0q�
��������� $��30(�$��	20,0,10,0q�
�������$	��723��
����������� *SelectedJob.SaleOrder+� .+��� 
���   �._��� $��
300,0,20,0q�.+��� $��Customer��
�������$��22(�.���� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��
Custommer*��
���   �$
��Bold"�$��20,5,0,0q��� -   $��Customer_cbb��$��	52,5,10,0q�$	��420��$��20(� �� SelectedItem �� *SelectedJob.Customer+���� *CustomerInfo+���� .R��� ���� *Customer_Info+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *ChangeCustomer+	   CommandParameter	 �� 
 �� ElementName$
 Customer_cbb�� �� Path$ SelectedItem��� $ 
Horizontal=�.+��� $��Customer Details��$��	20,10,0,0q��� $��20,0,0,0q� �� TextWrapping$
 Wrap=� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�$	��420��$	��170������ *SelectedJob.Customer_Details+�� $>��8Check to change delivery details if different from above�� d� 	IsChecked$ FalseY�$��12(�$��	190,0,0,0q�� 
�������$��0,0,20,0q� �� $��1* ��� $
��2.2* �.+��� $ Vertical=�$��0��.+��� $��Quotation #��$��22(�$��	50,0,0,30q�$
��auto���� $��Customer PO #��$��22(�$��	50,0,0,30q�$
��auto���� $��Requested Start*��$��22(�$��	50,0,0,30q�$
��auto��$
��Bold"��� $��Requested End*��$��22(�$��	50,0,0,30q�$
��auto��$
��Bold"��� $��Requested Report Date*��$��22(�$��	50,0,0,30q�$
��auto���� $��*Required Fields��$��20(�$��
50,10,0,30q�$
��auto��$
��Bold"��� $ Vertical=�$��1��.+��� $��50��$��25(�$��	20,0,0,10q����� *SelectedJob.Quotation+�� $��50��$��25(�$��	20,0,0,10q����� *SelectedJob.Customer_PO+(  "System.Windows.Controls.DatePicker  
���  ��$��50��   Text$
 Demo��$��25(�$��	20,0,0,10q�   SelectedDate �� *" SelectedJob.Requested_Start.Date+  
���  ��$��50��$
 Demo��$��25(�$��	20,0,0,10q� �� * SelectedJob.Requested_End.Date+  
���  ��$��50��$
 Demo��$��25(�$��	20,0,0,10q� �� *(&SelectedJob.Requested_Report_Date.Date+� $��1��.+�� .+���  # MaterialDesignRaisedLightButton#��[ $	��100��+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�$	��250��$��Right=�$	��Top=�$��	0,30,70,0q����#673ab7+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8������ *	WorKScope+.���� $ 
Horizontal=�.+��� $��
Work Scope��$��25(�
�������'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
ArrowRight=�$��35��$��30��
�������$��50,0,0,0q�� .+��� #��[ $��70��  EditJob#  [ $ Depth3=�$��70��$��Right=�$��Bottom=�$��	0,0,20,30q����#673ab7$ 8������ *Save_EditJob+.���� $ Vertical=�.+�  $ ContentSaveOutline=�$��40��$��40��
��������� $
��Save��$��15(�$��Center=�
��������� #��[ $��70��$ Depth3=�$��70��$��Right=�$��Bottom=�$��
0,0,20,150q����#673ab7$ 8������ *Goback+ �� UpdateSourceTrigger$ PropertyChanged=�.���� $ Vertical=�.+�  $ ArrowLeftCircle=�$��40��$��40��
��������� $
��Back��$��15(�$��Center=�
�������� $��10,140,110,30q�.+��� $
��Work��$��22(�.���� $
��Auto=����� *	WorksList+���� .R�#	  MaterialDesignThemes.Wpf.Card	  $	��780��$	��160��.���  �� $��2* ��� $
��0.6* �.+��� $��0��$ Vertical=�$��Stretch=�$
��Auto��$��33,0,0,0q�.+�� $��5q�.+��� $��Work Order Name:��$��22(��� $��22(�$��	220,0,0,0q����� *WorkOrderName+� $��5q�.+��� $��Work Order Name:��$��22(��� $��22(�$��	220,0,0,0q����� *	Product+� $��5q�.+��� $��Work Order Name:��$��22(��� $��22(�$��	220,0,0,0q����� *Remark+� $��1��.+��� $	��200��$
��Fill=�$��10q�$��Right=����� *ImageProduct+� $��0��$��2��$��1��.+��� #��[ $	��100��$ Depth3=�$	��250��$��Center=����#673ab7$ 10��.���� $ Vertical=�.+��� $��	Main Menu��$��25(�
�������$��Center=�  $
 Home=�$��50��$��50��
�������$��Center=�
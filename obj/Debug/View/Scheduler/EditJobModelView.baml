   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      $    WPF_TEST.View.EditJobModelView   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      3local1 clr-namespace:WPF_TEST.ViewModel     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      3System&clr-namespace:System;assembly=mscorlib  5
      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         EditJob  � DataContext#  [  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+5        5   
   $ Unloaded��6   . 5         6$   �� *Unload+5       � 	Resources 5      <   6WPF_TEST.ViewModel.TaskPriorityToIconFilenameConverter  ImageConvert  Template �� 	Converter  dataFromEnum S� 
MethodName S� 
ObjectType  System.Enum	 S� MethodParameters
 M� TypeName  tb �� 
TargetType �� Property �� Value��%#  &	       &	      7  &	     &	 �      5   
   65   �� 5   
   .R�5      �� 
������ $��40��6.   $��40��6:   $��Center=�6E   ._�5      �� $
��Fill=�5      $��30��5       $��30��5!      $��Center=�5"      ��5      �� *TaskPriority+8   5"      5#      5%      S� 5&   
   $ 	GetValues��5(      "  5)      	 5*      M� 5+      $
 local1:TaskPriority��6   5.      �� 5/   
   " ��6   .�50      ��  � ��$ 22(�6)   �� 51       � ��$ DemiBold"�6+   52      53      .��54      �   ScheduleViewModel#  [ 6    � ColumnDefinitions 55   
   �� 56      �� 57       � RowDefinitions 59   
   �� 5:      $��5* �6   �� 5;      $
��0.8* �6   .+�5=   
   �� $��0��6    �� Orientation$ Vertical=�5>      .+�5?      �� $��Chỉnh Sửa Đơn Hàng��6   $��50(�5@      $��DemiBold"�5A      
�������$��
50,30,0,30q�5C      �� 5D      $��Visible=�6   $��Visible=�6A   .��5E      �� $ Vertical=�6   $	��800��64   .+�5F      �� $ 
Horizontal=�6!   .+�5G      �� $��Mã Đơn Hàng*��6$   $��22(�5H      $
��Bold"�5I      $��	50,10,0,0q�5J      
�������5K      �� 5L      $��30(�5M      $��	20,0,10,0q�5N      
�������$	��720��5P      
���������5L   "   �� *SelectedJob.BarCode+5Q      5S      � 5T      .+�5U      �� 
���   �._�5V      �� $��0,0,20,0q�6)   $ 
Horizontal=�6;   .+�5v   "   �� $��Customer��6+   $��50,0,0,0q�5w   +   
�������$��22(�5y   #   .��5z   &   �� $ Vertical=�61   .+�5{   *   �� $ 
Horizontal=�65   .+�5|   .   �� $��Khách Hàng*��5}   1   
���   �$
��Bold"�5   1   $��20,5,0,0q�5�   1   �� 5�   .   -   5         ��Name$ Customer_cbb��5�   1   $��	52,5,10,0q�5�   7   $	��420��5�   1   $��20(�5�   1   ��5�   1   �� *CustomerInfo+ �� SelectedItem 5�   1   �� *SingleCustomer+��5�   2   �� 5�   6   .R�5�   :   �� ��6D   �� *Customer_Info+5�   7    5�   2     5�   6   $ SelectionChanged��6E   . 5�   :      5�   =   �� *ChangeCustomer+   CommandParameter 5�   =   �� *SelectedItem+ �� ElementName$ Customer_cbb��5�   7   5�   /   5�   +   �� 5�   *   $ 
Horizontal=�65   .+�5�   .   �� $��Thông tin khách hàng��5�   )   $��	20,10,0,0q�5�   )   �� 5�   .   $��20,0,0,0q�5�   )    �� TextWrapping$
 Wrap=�5�   )    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5�   )   $	��420��5�   )   $	��170��5�   )   ��5�   )   �� *!SingleCustomer.Customer_Details+5�   )   5�   +   �� 5�   *   $>��8Check to change delivery details if different from above��63    d� 	IsChecked$ FalseY�5�   /   $��12(�5�   /   $��	190,0,0,0q�5�   +   5�   '   5�   #   5�      5�      5�      � 5�      
�������$��0,0,20,0q�6.    5�      �� 5�      $��1* �6/   �� 5�      $
��2.2* �6/   .+�5�      �� $ Vertical=�6%   $��0��6<   .+�5�      �� $��Chú Thích #��5�   !   #��[ 5�   !   $��	50,0,0,30q�5�   !   $
��auto��5�   !   �� 5�      $��Customer PO #��5�      #��[ 5�      $��	50,0,0,30q�5�      $
��auto��5�      �� 5�      #��[ 5�      $��	50,0,0,30q�5�      $
��auto��5�      $
��Bold"�5�      �� 5�   "   $�Ngày Bắt Đầu*��6&    �� 5�   "   $�(mm/dd/yyy)��6&   $��15(�69   $��Normal"�6G   5�      �� 5�      $��22(�5�      $��	50,0,0,30q�5�      $
��auto��5�      $
��Bold"�5�      �� 5�   "   $�Ngày Kết Thúc*��6&    �� 5�   "   $�(mm/dd/yyy)��6&   $��15(�69   $��Normal"�6G   5�      �� 5�      $��Ngày Nhập*��5�      #��[ 5�      $��	50,0,0,30q�5�      $
��auto��5�      �� 5�      $��Độ ưu tiên:��5�      #��[ 5�      $��	50,0,0,30q�5�      $
��auto��5�      �� 5�      $&�� *Yêu cầu không để trống��5�      $��20(�5�      $��
50,10,0,30q�5�      $
��auto��5�      $
��Bold"�5�      5�      �� 5�      $ Vertical=�6%   $��1��6<   .+�5�      �� $��50��5�      $��25(�5�      $��	20,0,0,10q�5�      ��5�      �� *SelectedJob.Quotation+5�      �� 5�      $��50��5�      $��25(�5�      $��	20,0,0,10q�5�      ��5�      �� *SelectedJob.Customer_PO+5�      �� 5�      $ 
Horizontal=�5�   !   $��40��5�   !   $��	20,0,0,15q�5�   !   .+�5�   "   (  "System.Windows.Controls.DatePicker  -   5        $��Start_Piker��5�   %      DisplayDateStart$ 
01/01/2019X�5�   %   
���  ��$��40��5�   %   $	��260��5�   %   $��20(�5�   %      SelectedDate 5�   %   �� *SelectedJob.Requested_Start+5�   %   )  #MaterialDesignThemes.Wpf.TimePicker  5�   "   $��20,0,0,0q�5�   %   $��40��5�   &      	Is24Hours . $	��260��5�   %   $��20(�5�   %      SelectedTime 5   %   �� *SelectedJob.Requested_Start+5     �� 5     $ 
Horizontal=�5  !   $��40��5  !   $��	20,0,0,15q�5  !   .+�5  "     $ 
01/01/2019X�5	  %   
���  ��$��40��5  %   $	��260��5  %   $��20(�5  %    5  %   �� *SelectedJob.Requested_End+5  #     5  "   $��20,0,0,0q�5  %   $��40��5  &   $	��260��5  %    . $��20(�5  %    5  %   �� *SelectedJob.Requested_End+5     �� 5     $ 
Horizontal=�5  !   $��40��5  !   $��	20,0,0,15q�5  !   .+�5  "     $ 
01/01/2019X�5!  %   {�.  
���  ��$��40��5$  %   $	��260��5%  %   $��20(�5&  %    5   %   �� *#!SelectedJob.Requested_Report_Date+5)  #   52     )	  #DevExpress.Xpf.Editors.ComboBoxEdit	  53     -   5        $��cbbPrioriry��59  !   $��1��54  !   +
  %DevExpress.Xpf.Editors.LookUpEditBase& 
  ApplyItemTemplateToSelectedItem . '  !DevExpress.Xpf.Editors.ButtonEdit   IsTextEditable$ FalseX�57  !   {�.    AllowDefaultButton$ FalseX�5;  !   $��Stretch=�5<  !     
  ItemTemplate#  [ 5=  !   $��	20,0,0,10q�5>  !   $��40��5?  !   ! 
  ItemsSource! 55  !   ,  &DevExpress.Xpf.Editors.EnumItemsSource  "   EnumType$" local1:TaskPriorityL�#   AllowImages# . $ 
  SelectedItem$ 5:  !   �� *SelectedJob.Priority+ 5@  "     5A  &   $ SelectedIndexChanged��65   . 5B  *      5C  -   �� *selectpriority+ 5D  -   �� $ cbbPrioriry��% �� Path$% SelectedItem�5E  '   5G     5f     5g     5h     5i     5k     � 5l  
   $��1��6   .+�5�     � .+�5�     ��   MaterialDesignFlatButton#��[ 5�     $��70��5�       Planner#  [ 5�     +  %MaterialDesignThemes.Wpf.ShadowAssist&   ShadowDepth$& Depth3=�5�     $��80��5�     
����  �$��2q�5�     $��Right=�5�     $��Bottom=�5�     $��	0,0,20,30q�5�     
�������+  %MaterialDesignThemes.Wpf.ButtonAssist'   CornerRadius$' 8��5�     ��5�     �� *Save_EditJob+.��5�     �� $ Vertical=�6!   $��Center=�68   .+�5�     '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�5�     (   Kind$( ContentSaveOutline=�5�     $��35��5�     $��35��5�     
�����_�5�     �� 5�     $
��Lưu��5�     $��15(�5�     $��Center=�5�     
���   �5�     5�     5�     �� 5�     #��[ 5�     $��70��5�     
����  �$��2q�5�     $& Depth3=�5�     $��80��5�     $��Right=�5�     $��Bottom=�5�     $��
0,0,20,270q�5�     
�������$' 8��5�     ��5�     �� *Goback+) �� UpdateSourceTrigger$) PropertyChanged=�.��5�     �� $ Vertical=�6!   .+�5�       $( ArrowLeftCircle=�5�     $��Center=�5�     $��35��5�     $��35��5�     
���� ��5�     �� 5�     $��Trở Lại��5�     $��15(�5�     $��Center=�5�     
���   �5�     5�     5�     �� 5�     #��[ 5�     $��70��5�     $& Depth3=�5�     $��80��5�     
����  �$��2q�5�     $��Right=�5�     $��Bottom=�5�     $��
0,0,20,150q�5�     
�������$' 8��5�     ��5�     �� *StartSchedule+$) PropertyChanged=�.��5�     �� $ Vertical=�6!   $��Center=�5�  !   $��Center=�5�  !   .+�5�       $��Center=�5�     $( 
AlarmClock=�5�     $��35��5�     $��35��5�     
��� � �5�     �� 5�     $��Lịch��5�     $��15(�5�     $��Center=�5�     
���   �5�     5�     5�     5�     � 5�     $��10,140,110,30q�6   .+�5�     �� $��Sản Phẩm��6   $��22(�6-   .��5�     �� $
��Auto=�5�     .@�5�     �� .��5�     #  MaterialDesignThemes.Wpf.Card  $	��750��62   $	��160��6>   .��5�  "   �  5�  &   �� 5�  *   $��2* �6;   �� 5�  *   $
��0.6* �6;   �� 5�  *   $
��0.2* �6;   .+�5�  &   �� $��0��5�  -   $ Vertical=�5�  -   $��Stretch=�5�  -   $
��Auto��6K   $��33,0,0,0q�6X   .+�5�  *   � $��5,10,0,0q�6/   .+�5�  .   �� $��DemiBold"�5�  =   $��Mã Sản Phẩm:��5�  =   $��20(�5�  =   �� 5�  .   $��20(�5�  =   $��DemiBold"�5�  =   $��	220,0,0,0q�5  >   ��5   =   �� *SelectedJob.ProductCode+5  >   5  +   � 5  *   $��5,10,0,0q�6/   .+�5  .   �� $��Tên Sản Phẩm:��68   $��20(�6M   $��DemiBold"�5  D   �� 5  .   $��DemiBold"�5  5   $��20(�5  5   $��	220,0,0,0q�5
  5   ��5	  5   �� *SelectedJob.Product+5
  5   5  +   � 5  *   $��5,10,0,0q�6/   .+�5  .   �� $��Số lượng:��68   $��20(�6I   $��DemiBold"�5  D   �� 5  .   $��20(�5  5   $��DemiBold"�5  5   $��	220,0,0,0q�5  5   ��5  5   �� *SelectedJob.Quantity+5  5   5  +   5  '   54  #   55     56     ��57     �� 58     5�     5�     5�     5�     5�     � 5�  
   $��0��6   $��2��6   $��1��63   .+�5�     ��   MenuMainAll#  [ 5�     #��[ 5�     $	��100��5�     $& Depth3=�5�     $	��250��5�     $��Center=�5�     
����  �$��2q�5�     $' 10��5�     ��5�     �� *Home+.��5�     �� $ Vertical=�6   .+�5�     �� $��	Main Menu��5�     $��25(�5�     $��Center=�5�       5�     $
( Home=�5�     $��50��5�     $��50��5�     $��Center=�5�     5�     5�     5�     5�     5�     
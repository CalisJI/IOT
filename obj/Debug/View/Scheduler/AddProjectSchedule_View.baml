   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5	      7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5
      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      +    %WPF_TEST.View.AddProjectSchedule_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  5	      -local1 clr-namespace:WPF_TEST.ViewModel  5
      c	 _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 5      b
 ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 
 5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      3System&clr-namespace:System;assembly=mscorlib  5         AddJobProject  � DataContext#  [  5      . 	 (System.Windows.Interactivity.Interaction   Triggers 5      / 	 )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ GotFocus��6   . 	 (System.Windows.Interactivity.TriggerBase   Actions. 5      6 	 0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Focus+5       � 	Resources 5      <   6WPF_TEST.ViewModel.TaskPriorityToIconFilenameConverter  ImageConvert  Template �� 	Converter  dataFromEnum S� 
MethodName S� 
ObjectType  System.Enum	 S� MethodParameters
 M� TypeName  tb �� 
TargetType �� Property �� Value 
 Cansee��%@  &	       &	      7  &	     &	 �    &	 �      5   
   65   �� 5   
   .R�5      �� 
������ $��40��6.   $��40��6:   $��Center=�6E   ._�5      �� $
��Fill=�5      $��30��5      $��30��5       $��Center=�5!      ��5      �� *TaskPriority+8   5!      5"      5$      S� 5%   
   $ 	GetValues��5'      "  5(      	 5)      M� 5*      $
 local1:TaskPriority��6   5-      �� 5.   
   " ��6   .�5/      ��  � ��$ 20(�6)   �� 50       � ��$ DemiBold"�6+   52      �� 53   
   6'   54      .��5�     �  � ColumnDefinitions 5�  
   �� 5�     �� 5�      � RowDefinitions 5�  
   �� 5�     $��5* �6   �� 5�     $
��0.8* �6   .+�5�  
   �� $��0��6    �� Orientation$ Vertical=�5�     .+�5�     �� $��Add Job��6   $��50(�5�     $��DemiBold"�5�     
�������$��
50,30,0,30q�5�     �� 5�     $��Visible=�6   $��Visible=�6A   .��5�     �� $ Vertical=�6   $	��700��64   .+�5�     �� $ 
Horizontal=�6!   .+�5�     �� $��Mã Đơn Hàng #*��6$   $��22(�5�     $
��Bold"�5�     $��	50,10,0,0q�5�     
�������5�     �� 5�     $��30(�5�     $��	20,0,10,0q�5�     
�������$	��723��5�      �� MaxValue �� 
CaretIndex# Z 5�  "   
���������5�  "   �� *
ID_Barcode+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�     5�     � 5�     .+�5�     �� 
���   �._�5�     � .+�5�  "   �� #  [  5�  %   $	��100��5�  %   $	��200��5�  %   $
��Left=�5�  %   $��	20,0,0,70q�5�  %   + 
 %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5�  %   + 
 %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5�  %     MaterialDesignFlatButton#��[ 5�  %   
����  �$��2q�5�  %   ��5�  %   �� *OpenBarCode+.��5�  &   �� $ Vertical=�61   $��Center=�6H   $��Center=�6e   .+�5�  *   �� $4��.pack://application:,,,/ImageSource/Barcode.png��5�  -   $
��Fill=�5�  -   $	��150��5�  -   $��75��5�  -   �� 5�  *   
���   �$��Barcode��5�  -   $��Center=�5�  -   5�  '   5�  #   �� 5�  "   -   5        $��
Barcodetbx��5�  %   #  [  5�  %   $
��Left=�5�  %   $��
10,110,0,0q�5�  %   $	��220��5�  %   $��40��5�  %   $��20(�5�  %   $��DemiBold"�63   ��5�  %   �� *
ID_Barcode+$ PropertyChanged=�$ TwoWay=�5�  3   �� 5�  "   $��Customer��5   %   $��
250,0,20,0q�5  %   
�������$��20(�5  %   .��5  &   �� $ Vertical=�61   .+�5  *   �� $ 
Horizontal=�65   .+�5  .   �� $��
Custommer*��5  %   
���   �$
��Bold"�5	  %   $��20,5,0,0q�5
  %   �� 5  .   -   5        $��Customeradd_cbb��5  /   $��	52,5,10,0q�5  7   $	��420��5  /   $��20(�5  /    �� SelectedItem 5  /   �� *SingleCustomer+$ TwoWay=�$ PropertyChanged=���5  /   �� *CustomerInfor+��5  2   �� 5  6   .R�5  :   �� ��6D   �� *Customer_Info+$ PropertyChanged=�5  7    5  2     5  6   $ SelectionChanged��6E   . 5  :      5  =   �� *ChooseCustomer+   CommandParameter 5  =   ��  �� ElementName$ Customeradd_cbb�� �� Path$ SelectedValue�5  ;   5  7   5!  /   5#  +   �� 5$  *   $ 
Horizontal=�65   .+�5%  .   �� $��Customer Details��5'  )   $��	20,10,0,0q�5(  )   �� 5)  .   $��20,0,0,0q�5,  -    �� TextWrapping$
 Wrap=�5-  -    �� AcceptsReturn .  �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�50  -   $	��420��51  -   $	��120��52  -   ��5+  -   �� *Customer_Infor+$ PropertyChanged=� �� NotifyOnSourceUpdated . 52  -   54  +   �� 55  *   $>��8Check to change delivery details if different from above��63     d� 	IsChecked$  FalseY�56  /   $��12(�57  /   $��	190,0,0,0q�58  +   59  '   5:  #   5;     5<     5=     � 5>     
�������$��0,0,20,0q�6.    5?     �� 5@     $��1* �6/   �� 5A     $
��2.2* �6/   .+�5C     �� $ Vertical=�6%   $��0��6<   .+�5D     �� $��Chú Thích ��5E  !   #��[ 5F  !   $��	50,0,0,30q�5G  !   $
��auto��5H  !   �� 5I     $��Customer PO #��5J  !   #��[ 5K  !   $��	50,0,0,30q�5L  !   $
��auto��5M  !   �� 5N     #��[ 5P  !   $��	50,0,0,30q�5Q  !   $
��auto��5R  !   $
��Bold"�5S  !   �� 5T  "   $�Ngày Bắt Đầu*��6&    �� 5U  "   $�(mm/dd/yyy)��6&   $��15(�69   $��Normal"�6G   5V     �� 5X     $��22(�5Z  !   $��	50,0,0,30q�5[  !   $
��auto��5\  !   $
��Bold"�5]  !   �� 5^  "   $�Ngày Kết Thúc*��6&    �� 5_  "   $�(mm/dd/yyy)��6&   $��15(�69   $��Normal"�6G   5`     �� 5b     $��Ngày Nhập*��5c     #��[ 5d     $��	50,0,0,30q�5e     $
��auto��5f     �� 5h     $��Độ ưu tiên:��5i     #��[ 5j     $��	50,0,0,30q�5k     $
��auto��5l     �� 5m     $&�� *Yêu cầu không để trống��5n     $��20(�5o     $��
50,10,0,30q�5p     $
��auto��5q     $
��Bold"�5r     5s     �� 5t     $ Vertical=�6%   $��1��6<   .+�5u     �� # Z 5v  !   $��40��5x     $��20(�5y     $��	20,0,0,15q�5z     ��5w     �� *	Quotation+$ PropertyChanged=�5z     �� 5{     # Z 5|  !   $��40��5~     $��25(�5     $��	20,0,0,15q�5�     ��5}     �� *Customer_PO+$ PropertyChanged=�5�     �� 5�     $ 
Horizontal=�5�  !   $��40��5�  !   $��	20,0,0,15q�5�  !   .+�5�  "   (	  "System.Windows.Controls.DatePicker	  
���  ��$��40��5�  %   $	��260��5�  %   $��25(�5�  %   ! 	  SelectedDate! 5�  %   �� *Request_Start+$ PropertyChanged=�5�  %   )
 
 #MaterialDesignThemes.Wpf.TimePicker
  5�  "   $��20,0,0,0q�5�  %   $��40��5�  &   " 
  	Is24Hours" . $	��260��5�  %   $��25(�5�  %   # 
  SelectedTime# 5�  %   �� *Request_Start+$ PropertyChanged=�5�     �� 5�     $ 
Horizontal=�5�  !   $��40��5�  !   $��	20,0,0,15q�5�  !   .+�5�  "   	  $ 	  DisplayDateStart$$ 
2020/01/01X�5�  %   % 	  DisplayDateEnd$% 
2050/01/01X�5�  %   & 	  IsTodayHighlighted& . |�. 
���  ��$��40��5�  %   $	��260��5�  %   $��25(�5�  %   ! 5�  %   �� *Request_End+$ PropertyChanged=�5�  #   
  5�  "   $��20,0,0,0q�5�  %   $��40��5�  %   $	��260��5�  %   " . $��25(�5�  %   ' � UseLayoutRounding' .  # 5�  %   �� *Request_End+$ PropertyChanged=�5�     	  5�     
���  ��$��40��5�     ( 	  Text$
( Demo��5�     $��25(�5�     $��	20,0,0,10q�5�     ! 5�     �� *#!SelectedJob.Requested_Report_Date+5�     )  #DevExpress.Xpf.Editors.ComboBoxEdit  5�     -   5        $��cbbPrioriry��5�  !   $��1��5�  !   +  %DevExpress.Xpf.Editors.LookUpEditBase&)   ApplyItemTemplateToSelectedItem) . '  !DevExpress.Xpf.Editors.ButtonEdit*   IsTextEditable$* FalseX�5�  !   {�. +   AllowDefaultButton$+ FalseX�5�  !   $��Stretch=�5�  !   ,   ItemTemplate#, [ 5�  !   $��	20,0,0,10q�5�  !   $��40��5�  !   -   ItemsSource- 5�  !   ,  &DevExpress.Xpf.Editors.EnumItemsSource  .   EnumType$. local1:TaskPriorityL�/   AllowImages/ .  5�  "     5�  &   $ SelectedIndexChanged��65   . 5�  *      5�  -   �� *selectpriority+ 5�  -   �� $ cbbPrioriry��$ SelectedItem�5�  '   5�     5�     5�     5�     5�     5�     � 5�  
   $��1��6   .+�5�     � 5     � 5     .+�5.     �� #��[ 5/     $��70��50     #  [  51     $ Depth3=�52     $��80��53     
����  �$��2q�55     $��Right=�56     $��Bottom=�57     $��
0,0,20,150q�58     
�������$ 8��5;     ��59     �� *AddJob+.��5<     �� $ Vertical=�6!   $��Center=�68   .+�5>     ' 
 !MaterialDesignThemes.Wpf.PackIcon  $��Center=�5?     0   Kind$0 ContentSaveOutline=�5@     $��35��5A     $��35��5B     
����iA�5C     �� 5D     $
��Save��5E     $��15(�5F     $��Center=�5G     
���   �5H     5I     5K     �� 5M       ScheduleViewModel#  [ 5N     #��[ 5O     $��70��5P     
����  �$��2q�5R     $ Depth3=�5S     $��80��5T     $��Right=�5V     $��Bottom=�5W     $��	0,0,20,30q�5X     
�������$ 8��5[     ��5Y     �� *Goback+$ PropertyChanged=�.��5\     �� $ Vertical=�6!   $��Center=�68   .+�5^       $0 ArrowBackCircle=�5_     $��Center=�5`     $��35��5a     $��35��5b     
���  ��5c     �� 5d     $
��Back��5e     $��15(�5f     $��Center=�5g     
���   �5h     5i     5k     5m     � 5n     $��10,140,110,30q�6   .+�5o     �� $
��Work��6   $��22(�6)   .��5p     �� #  [  5q     $
��Auto=�5r     .@�5s     �� .��5t     # 
 MaterialDesignThemes.Wpf.Card  $	��780��62   $	��160��6>   .��5u  "   �  5v  &   �� 5w  *   $��2* �6;   �� 5x  *   $
��0.6* �6;   .+�5z  &   �� $��0��5{  -   $ Vertical=�5|  -   $��Stretch=�5}  -   $
��Auto��6K   $��33,0,0,0q�6X   .+�5~  *   � $��5q�6/   .+�5  .   �� $��DemiBold"�5�  1   $��Mã Sản Phẩm:��5�  1   $��22(�6E   �� 5�  .   $��22(�5�  1   $��	220,0,0,0q�5�  1   ��5�  1   �� *Product_Code+$ PropertyChanged=�5�  1   5�  +   � 5�  *   $��5q�6/   .+�5�  .   �� $��DemiBold"�5�  1   $��Tên Sản Phẩm:��5�  1   $��22(�6F   �� 5�  .   $��22(�5�  1   $��	220,0,0,0q�5�  1   ��5�  1   �� *	Product+$ PropertyChanged=�5�  1   5�  +   � 5�  *   $��5q�6/   .+�5�  .   �� $��DemiBold"�5�  1   $��Số Lượng:��5�  1   $��22(�6B   �� 5�  .   $��22(�5�  1   $��	220,0,0,0q�5�  1   ��5�  1   �� *ProDuctQuantity+$ PropertyChanged=�5�  1   5�  +   5�  '   5�  #   5�     5�     ��5�     �� 5�     5�     5�     5�     5�     5�     � 5�  
   $��0��6   $��2��6   $��1��63   .+�5�     ��   MenuMainAll#  [ 5�     #��[ 5�     $	��100��5�     $ Depth3=�5�     $	��250��5�     $��Center=�5�     ���#673ab7$ 10��5�     ��5�     �� *Home+.��5�     �� $ Vertical=�6   .+�5�     �� $��	Main Menu��5�     $��25(�5�     
�������$��Center=�5�       5�     $
0 Home=�5�     $��50��5�     $��50��5�     
�������$��Center=�5�     5�     5�     5      5     5     
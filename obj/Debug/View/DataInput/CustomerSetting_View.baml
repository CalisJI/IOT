   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      (    "WPF_TEST.View.CustomerSetting_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      a ]DevExpress.Xpf.Grid.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v19.2.Core, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5
      c	 _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 5      b
 ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 
 5      .��5      �   � RowDefinitions  5   
   �� 5      $
��0.5* �6   �� 5      $��4* �6   .+�5   
   � $��0��6   .+�5      �� 
����  �$��2q�6(   $	��500��6<   $	��100��6H   ._�5      ��  �� Orientation$ 
Horizontal=�5      $	��500��5      $��Stretch=�5      .+�5      �� $��50,0,0,0q�5      $��80��5      $��80��5      $2��,pack://application:,,,/ImageSource/User1.png��5      �� 5       $��Center=�5!      $��50,0,0,0q�5"      $��Customer��5#      $��60(�5$      $��DemiBold"�5%      5&      5'      �� 5(      $��0��5*         MaterialDesignFlatButton#��[  5+      $��80��5,        MenuMainAll � DataContext# [ 5-      + 
 %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5.      $	��150��5/      
����  �$��2q�51      $
��Left=�52      $��Center=�53      $��	100,0,0,0q�54      
�������+ 
 %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��57      ��55      �� *Home+.��58      �� $ Vertical=�6   $��Center=�64   .+�5:      ' 
 !MaterialDesignThemes.Wpf.PackIcon  $��Center=�5;         Kind$ ArrowBackCircle=�5<      $��50��5=      $��50��5>      
���� ��5?      �� 5@      $��Back to Home��5A      $��16(�5B      $��Center=�5C      
���   �5D      5E      5G      5H      � 5I   
   $��1��6    � ColumnDefinitions 5J      �� 5K      �� 5L      $
��0.4* �6#   .+�5O      %  DevExpress.Xpf.Grid.GridControl  $
��1000��5P      $
��1400��5Q        CustomerSetting# [ 5R      )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$ AddNew=�5T      #   EnableSmartColumnsGeneration .  $��Stretch=�5W      $��Stretch=�5X      	   ItemsSource	 5S      �� *Customer_Storage+
   View
 5Y      #  DevExpress.Xpf.Grid.TableView  5Z      $
��1000��5[      $
��1400��5\      &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  5]   1      Columns 5_      $	  DevExpress.Xpf.Grid.GridColumn	  5`      $
  DevExpress.Xpf.Grid.BaseColumn 
  Header)  #DevExpress.Xpf.Core.ObjectConverter$ Tên Công Ty 5a      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ Customer_Info��5b      5d      	  5e      $ Người liên hệ 5f      $ Contact_Person��5g      5i      	  5j      $ Số điện thoại 5k      $ PhoneNumber��5l      5n      	  5o      $ Số điện thoại 2 5p      $ PhonNumer_2��5q      5s      	  5t      $ Email 5u      $ Email��5v      5x      	  5y      $ Địa chỉ 5z      $ Address��5{      5}      	  5~      $ Customer Requirement 5      $ Customer_Requirement��5�      5�      5�      �� 5�      $��1��6   $ Vertical=�6)   # [ 6@   .+�5�      �� $��Thêm Khách Hàng Mới��5�      $��30(�5�      $��Center=�5�      $��DemiBold"�5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��Tên Công Ty*:��62   $��20(�6G   $
��Bold"�6U   $	��180��6g   �� 5�      $��10,0,0,0q�5�      $��22(�5�      $	��280��5�      {�5�      �� *
Enable_Add+��5�      �� *CompanyName+5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $ ��Tên Người Liên hệ*:��62   $��20(�6M   $
��Bold"�6[   $	��180��6m   �� 5�      $��10,0,0,0q�5�      $��22(�6+   $	��280��69   {�5�      �� *
Enable_Add+��5�      �� *ContactName+5�   9   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��Số điện thoại*:��62   $��20(�6I   $
��Bold"�6W   $	��180��6i   �� 5�      $��10,0,0,0q�5�      $��22(�6+   $	��280��69   {�5�      �� *
Enable_Add+��5�      �� *PhomeNumber+5�   9   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��Số điện thoại 2:��62   $��20(�6J   $	��180��6Y   �� 5�      $��10,0,0,0q�5�      $��22(�6+   $	��280��69   {�5�      �� *
Enable_Add+��5�      �� *PhomeNumber2+5�   9   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��Email:��62   $��20(�6@   $	��180��6O   �� 5�      $��10,0,0,0q�5�      $��22(�6+   $	��280��69   {�5�      �� *
Enable_Add+��5�      �� *Email+5�   9   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��Địa chỉ giao hàng*:��62   $��20(�6M   $
��Bold"�6[   $	��180��6m   �� 5�      $��10,0,0,0q�5�      $��22(�6+   $	��280��69   {�5�      �� *
Enable_Add+��5�      �� *	Address+5�   9   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��Yêu cầu:��62   $��20(�6B   $	��180��6Q   �� 5�      $��10,0,0,0q�5�      $��22(�6+   $	��280��69   {�5�      �� *
Enable_Add+��5�      �� *Requirements+5�   9   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20,0,0,0q�6    $��(*) Không bỏ trống��62   $��20(�6L   $
��Bold"�6Z   $	��180��6l   5�      �� 5�      $ 
Horizontal=�6   $��0,50,0,0q�66   .+�5�      �� #��[  5�      $��80��5�      # [ 5�      $ Depth3=�5�      $��80��5�      
����  �$��2q�5�      $
��Left=�5�      $��Center=�5�      $��	100,0,0,0q�5�      
�������$ 8��5�      ��5�      �� *	EnableAdd+.��5�      �� $ Vertical=�6%   $��Center=�6<   .+�5�        $��Center=�5�      $ 
PlusCircle=�5�      $��50��5�      $��50��5�      
��� ���5�      �� 5�      $��Thêm��5�      $��16(�5�      $��Center=�5�      
���   �5�      5�      5�      �� 5�      #��[  5�      $��80��5�      # [ 5�      $ Depth3=�5�      $��80��5�      
����  �$��2q�5�      $
��Left=�5�      $��Center=�5�      $��50,0,0,0q�5�      
�������$ 8��5�      {�5�      �� *
Enable_Add+��5�      �� *Save_Contact+.��5�      �� $ Vertical=�6%   $��Center=�6<   .+�5�        $��Center=�5�      $ ContentSave=�5�      $��50��5�      $��50��5�      
����iA�5      �� 5     $
��Lưu��5     $��16(�5     $��Center=�5     
���   �5     5     5     �� 5
     #��[  5     $��80��5     # [ 5     $ Depth3=�5     $��80��5     
����  �$��2q�5     $
��Left=�5     $��Center=�5     $��50,0,0,0q�5     
�������$ 8��5     ��5     �� *Delete_Contact+.��5     �� $ Vertical=�6%   $��Center=�6<   .+�5       $��Center=�5     $ Delete=�5     $��50��5     $��50��5      
���  ��5!     �� 5"     $
��Xóa��5#     $��16(�5$     $��Center=�5%     
���   �5&     5'     5)     5*     5+     5,     5.     5/     
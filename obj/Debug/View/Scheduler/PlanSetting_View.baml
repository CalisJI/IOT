   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      $    WPF_TEST.View.PlanSetting_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
         PlanConfiguration  � DataContext#  [  5      $
��1000��5      $
��1920��5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+5        5   
   $ Unloaded��6   . 5         6$   �� *
Unloaded+5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.2* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��1��6,   $��0��69   .+�5       �� -   5         ��Name$ Listmachine��5!      $��	30,20,0,0q�5"      {�5#      �� *
IsEnable+��5$      �� *
PlanConfig+��5%      �� 5&      .R�5'      �� $ 
Horizontal=�5(      .+�5)      �� $��Center=�5+   !   $��DemiBold"�5-   !   $��25(�5.   !   $��Máy:��5/   !   �� 50      $��Center=�52   !   $��20,0,0,0q�53   !   $	��100��54   !   $��25(�55   !   $��DemiBold"�57   !   ��56   !   �� *TenMay+57   !   �� 58      $��20,0,0,0q�59   !   $��
Mã Hàng:��5:   !   $��25(�5;   !   $��DemiBold"�5<   !   $��Center=�5=   !   �� 5>      $��20,0,0,0q�5?   !   $	��400��5A   !   $��25(�5B   !   $��DemiBold"�5C   !   $��Center=�5D   !   ��5@   !   �� *
BarCodes+5D   !   5E      5F      5H      5J      �� 5K   
   $ 
Horizontal=�6   $��2��6.   .+�5L      �� $��30,0,0,0q�5M       # MaterialDesignFlatLightBgButton#��[ 5N      $��80��5O      +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth3=�5Q      $��80��5R      
����  �$��2q�5T      $��Center=�5V      
�������+  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 8��5Z      ��5P      �� *AddNew+.��5[      �� $ Vertical=�6   $��Center=�64   .+�5]      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�5^         Kind$ 
PlusCircle=�5_      $��50��5`      $��50��5a      
��� �|�5b      �� 5c      $��Thêm��5d      $��15(�5e      $��Center=�5f      
���   �5r      5s      5u      �� 5v      $��30,0,0,0q�5w      #��[ 5x      $��80��5y      $	 Depth3=�5z      $��80��5{      
����  �$��2q�5}      $��Center=�5~      
�������$
 8��5�      ��5�      �� *
Editting+.��5�      �� $ Vertical=�6   $��Center=�64   .+�5�        $��Center=�5�      $ EditOutline=�5�      $��50��5�      $��50��5�      
���� ��5�      �� 5�      $��Sửa��5�      $��15(�5�      $��Center=�5�      
���   �5�      5�      5�      �� 5�      $��30,0,0,0q�5�      #��[ 5�      $��80��5�      $	 Depth3=�5�      $��80��5�      
����  �$��2q�5�      $��Center=�5�      
�������$
 8��5�      ��5�      �� *Delete+��5�      ��  �� ElementName$ Listmachine�� �� Path$ SelectedItem�.��5�      �� $ Vertical=�6   $��Center=�64   .+�5�        $��Center=�5�      $ RemoveCircle=�5�      $��50��5�      $��50��5�      
���  ��5�      �� 5�      $
��Xóa��5�      $��15(�5�      $��Center=�5�      
���   �5�      5�      5�      �� 5�      $��30,0,0,0q�5�      #��[ 5�      $��80��5�      $	 Depth3=�5�      $��80��5�      
����  �$��2q�5�      $��Right=�5�      $��Center=�5�      
�������$
 8��5�      ��5�      �� *
SaveConfig+.��5�      �� $ Vertical=�6   $��Center=�64   .+�5�        $��Center=�5�      $ ContentSave=�5�      $��50��5�      $��50��5�      
����  �5�      �� 5�      $
��Lưu��5�      $��15(�5�      $��Center=�5�      
���   �5�      5�      5�      5�      � 5�   
   $��2��6   $��1��6     MenuMainAll#  [ 6,   .+�5�      �� $��0,0,30,0q�5�      #��[ 5�      $��80��5�      $	 Depth3=�5�      $��80��5�      
����  �$��2q�5�      $��Center=�5�      $��Right=�5�      
�������$
 8��5�      ��5�      �� *Home+.��5�      �� $ Vertical=�6   $��Center=�64   .+�5        $��Center=�5     $ ArrowBackCircle=�5     $��50��5     $��50��5     
���� ��5     �� 5     $��Trở Lại��5     $��15(�5     $��Center=�5	     
���   �5     5     5     5     5     5     
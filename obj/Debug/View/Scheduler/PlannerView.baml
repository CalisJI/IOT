   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5          WPF_TEST.View.PlannerView   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5	      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5
      a ]DevExpress.Xpf.Grid.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v19.2.Core, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      /local1 clr-namespace:WPF_TEST.ViewModel   5      g	 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]
 YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 
 5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5      -   5           Planner  � DataContext#  [  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+5        5   
   $ Unloaded��6   . 5         6$   �� *
Unloaded+5       � 	Resources 5      <   6WPF_TEST.ViewModel.TaskPriorityToIconFilenameConverter  ImageConvert2   ,WPF_TEST.ViewModel.NameToBackgroundConverter  ColorConvert  Template �� 	Converter  
Cell_color%  DevExpress.Xpf.Grid.GridControl   Columns$  DevExpress.Xpf.Grid.GridColumn$	  DevExpress.Xpf.Grid.ColumnBase 	  	CellStyle	 �� 
TargetType/
  )DevExpress.Xpf.Grid.LightweightCellEditor
 �� Property �� Value  LB2  ,DevExpress.Xpf.LayoutControl.LayoutItemLabel��%�  &	       &	      &	 &     7  &	 6    7  &	 �      5   
   65     5   
   6+   �� 5    
   .R�5!      �� 
������ $��40��6.   $��40��6:   $��Center=�6E   ._�5"      �� $
��Fill=�5$      $��30��5%      $��30��5&      $��Center=�5'      $��Center=�5(      ��5#      �� *TaskPriority+8   5(      5)      5+      �� 5,   
   .R�5-        . 5.         5/      �� 50      "	 
 6    .�51      �� 
 �@
 
Background 6;   �� *Status+8   52      55      56      57      �� 59   
   "	  6   .�5:      �� 
 � ��$ 30(�6)   66   �� 5;      
 � ��$ DemiBold"�6+   5<      5>      .��5@      �� $
��Auto=�6   .��5A   
   ]� .+�5B      9� $
��Left=�6    9� ExpandDirection$
 Left=�5C      $
��0,23q�6,   ��5D      '  !MaterialDesignThemes.Wpf.PackIcon  5E      $��0,0,-6,0q�6.      Kind$ ChevronDoubleRight=�5F      $��50��5G      $
��Auto��5H       J� RenderTransformOrigin$ 0.5,0.5&�6*   $��Stretch=�6J   5K      .��5M      ��  �� Orientation$ Vertical=�5N        MaterialDesignBody#���  5O      $��
8,24,16,24q�5P      .+�5Q      #  MaterialDesignThemes.Wpf.Card  -   5        
�����_� ! PrimaryHueDarkForegroundBrush#���  5S      $	��250��5T      $��8q�5U         UniformCornerRadius$ 6Q�5W      .��5X      �� $ 
Horizontal=�6%   .+�5Y      �� $ Vertical=�6)   .+�5Z   "     $ CogTransfer=�6:   $	��135��5[   >   $��50��5\   >   �� 5]   "   $��All Process��6,   $��25(�6?   5_      �� 5`      $��30(�5a   ,   $��Right=�5b   ,   $	��Top=�5c   ,   $��	0,5,-70,0q�5d   ,   ��5`   (   �� *JobOrders.Count+ �� UpdateSourceTrigger$ PropertyChanged=�5d   ,   5e      5f        5g      -   5        
�����_�#���  5i      $	��250��5j      $��8q�5k      $��0,10,0,0q�5m      $ 6Q�5n      .��5o      �� $ 
Horizontal=�6%   .+�5p      �� $ Vertical=�6)   .+�5q   "     $ ProgressClock=�6:   $	��135��5r   >   $��50��5s   >   �� 5t   "   $��
In Process��6,   $��25(�6>   5v      �� 5w      $��30(�5x   ,   $��Right=�5y   ,   $	��Top=�5z   ,   $��	0,5,-70,0q�5{   ,   ��5w   (   �� *
Runnings+$ PropertyChanged=�5{   ,   5|      5}        5~      -   5        
�����_�#���  5�      $	��250��5�      $��8q�5�      $��0,10,0,0q�5�      $ 6Q�5�      .��5�      �� $ 
Horizontal=�6%   .+�5�      �� $ Vertical=�6)   .+�5�   "     $ Update=�6:   $	��135��5�   >   $��50��5�   >   �� 5�   "   $��Not Scheduled��6,   $��25(�5�   0   5�      �� 5�      $��30(�5�   ,   $��Right=�5�   ,   $	��Top=�5�   ,   $��	0,5,-40,0q�5�   ,   ��5�   (   �� *Plans+$ PropertyChanged=�5�   ,   5�      5�        5�      -   5        
�����_�#���  5�      $	��250��5�      $��8q�5�      $��0,10,0,0q�5�      $ 6Q�5�      .��5�      �� $ 
Horizontal=�6%   .+�5�      �� $ Vertical=�6)   .+�5�   "     $ TimerOutline=�6:   $	��135��5�   >   $��50��5�   >   �� 5�   "   $��Queued��6,   $��25(�6:   5�      �� 5�      $��30(�5�   ,   $��Right=�5�   ,   $	��Top=�5�   ,   $��	0,5,-70,0q�5�   ,   ��5�   (   �� *	Queueds+$ PropertyChanged=�5�   ,   5�      5�        5�      -   5        
�����_�#���  5�      $	��250��5�      $��8q�5�      $��0,10,0,0q�5�      $ 6Q�5�      .��5�      �� $ 
Horizontal=�6%   .+�5�      �� $ Vertical=�6)   .+�5�   "     $ ClockCheckOutline=�6:   $	��135��5�   >   $��50��5�   >   �� 5�   "   $��	Completed��6,   $��25(�6=   5�      �� 5�      $��30(�5�   ,   $��Right=�5�   ,   $	��Top=�5�   ,   $��	0,5,-70,0q�5�   ,   ��5�   (   �� *Dones+$ PropertyChanged=�5�   ,   5�      5�      5�      5�      0  *DevExpress.Xpf.LayoutControl.LayoutControl  5�      $	��Top=�5�      $
��1600��5�      .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�5�      $��17(�5�      .+�5�        $ 
Horizontal=�5�      $
��1000��5�      $
��1600��5�      4  .DevExpress.Xpf.LayoutControl.DockLayoutControl   Dock$
 Left=�5�      .+�5�      -  'DevExpress.Xpf.LayoutControl.LayoutItem     Label$ Project��5�         
LabelStyle# [ 5�         LabelPosition$	 Top=�5�      $
��Left=�5�      $
��auto��5�         Content. 5�        -   5          Name$ 	Grid_data��5�      $
��1000��5�      $
��1600��6+   $
 Left=�5�      )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5�      ��  �� Path$ 	JobOrders�   View 5�      #  DevExpress.Xpf.Grid.TableView  5�   "   &   DevExpress.Xpf.Grid.DataViewBase   AllowEditing .     ShowTotalSummary . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     ShowSearchPanelMode$ Always=�5�   %   '     ShowSearchPanelNavigationButtons  .  !   ShowSearchPanelFindButton! . "   ShowSearchPanelMRUButton" . !#   ShowSearchPanelCloseButton# . 5�   %    5�        5�   "   $ 	  	FieldName$$ BarCode��5�   %   $  DevExpress.Xpf.Grid.BaseColumn%   Header)  #DevExpress.Xpf.Core.ObjectConverter$% Bar Code 5�   %   &   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	& 160 5�   %   5�   #     5�   "   $$ 	SaleOrder��5�   !   $
% Name 5�   !   $	& 160 5   !   5  #     5  "   $% Posting Date 5  !   $$ Requested_Report_Date��5  !   $	& 160 5	  !   5  #     5  "   $$ Requested_Start��61   $% 
Start Date 6M   $	& 200 6a   5  #     5  "   $$ Requested_End��61   $% Due Date 6K   $	& 200 6]   5  #     5  "   $$ Priority��61   $% Priority Level 6F   $	& 110 6^   '   
FixedWidth' . ( 	  EditSettings( 5  &   :  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings  5  *   <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase&)   ApplyItemTemplateToSelectedItem) .  8  2DevExpress.Xpf.Editors.Settings.ButtonEditSettings*   IsTextEditable$* FalseX�5  -   3  -DevExpress.Xpf.Core.DXFrameworkContentElement+   	IsEnabled+ . 6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!,   HorizontalContentAlignment$, Stretch=�5  -   -   ItemTemplate#- [ 5  -   .   ItemsSource. 5  -   ,  &DevExpress.Xpf.Editors.EnumItemsSource  /   EnumType$/ local1:TaskPriorityL�0   AllowImages0 . 5  -   5"  #     5#  "   $$ ActualvsPlan��61   $"% Actual vs Plan Lifetime/Days 6J   $	& 230 6p   5%  #     5&  "   $$ Complete��61   $% 
% Complete 6F   ( 5'  &   =  7DevExpress.Xpf.Editors.Settings.ProgressBarEditSettings  5(  *   1   ContentDisplayMode$1 Value=�5)  %   2   DisplayFormat$2 p0��5*  %   3   	IsPercent3 . 5+  %   5-  #     5.  "   -   5        4  Name$4 Grid2Filter��5.  1   5 	  AllowAutoFilter5 . $$ Current_Stage��50  %   $% Current Stage 51  %   $	& 400 52  %   6 	  	SortOrder] YDevExpress.Data.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a9   3DevExpress.Data.Design.ColumnSortOrderTypeConverter$6 	Ascending  61   7 	  	SortIndex$7 0��6G    54  &   �� 55  *   "	 
 6�   8 �� BasedOn8 60   �� *9!  3DevExpress.Xpf.Grid.Themes.GridRowThemeKeyExtension!  �"  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Grid.Themes.GridRowThemeKeys, DevExpress.Xpf.Grid.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]9 "  ResourceKey$9 LightweightCellStyle=�+.�56  .   �� 
 �@
 
Background 6K   �� *Value+# [ 57  +   5:  #   5<     5>     5B     5E     � 5F     $
��auto��6   $��Right=�6!   : � RowDefinitions: 5G     �� 5H     �� 5I     �� 5J     �� 5K     �� 5L     �� 5M     �� 5N     �� 5O     �� 5P     .+�5R     � $��4��6   .+�5S     ��  # MaterialDesignFlatLightBgButton#��[ 5U     $��80��5V      	 ScheduleViewModel#  [	 5W     +#  %MaterialDesignThemes.Wpf.ShadowAssist; #  ShadowDepth$; Depth3=�5X     $	��105��5Y     
����  �$��2q�5[     $��Center=�5\     $��Center=�5]     
�������+$  %MaterialDesignThemes.Wpf.ButtonAssist< $  CornerRadius$< 8��5a     ��5_     �� *Add_Project+.��5b     �� $ Vertical=�6%   $��Center=�6<   .+�5d       $��Center=�5e     $ 
PlusCircle=�5f     $��50��5g     $��50��5h     
��� �|�5i     �� 5j     $��Nhập��5k     $��15(�5l     $��Center=�5m     
���   �5y     5z     5|     5}     � 5~     $��80��5     $	��120��5�     $��5��5�     $��Center=�5�     .+�5�     �� #  [	 5�     $��80��5�     $; Depth3=�5�     $	��105��5�     $��Center=�5�     
����  �$��2q�5�      
 MaterialDesignFlatButton#��[
 5�     
�������$< 8��5�     ��5�     �� *GotoEditJob+��5�     �� = �� ElementName$= 	Grid_data��$ SelectedItem�.��5�     �� $ Vertical=�6%   .+�5�       $ PlaylistEdit=�5�  !   $��50��5�  !   $��50��5�  !   $��Center=�5�  !   
���� ��5�  !   �� 5�     $��Chỉnh Sửa��5�  !   $��15(�5�  !   $��Center=�5�  !   
���   �5�     5�     5�     5�     � 5�     $��80��5�     $	��120��5�     $��6��5�     $��Center=�5�     .+�5�     �� #  [  5�     $��80��5�     $; Depth3=�5�     $	��105��5�     $��Center=�5�     
����  �$��2q�5�     #��[
 5�     
�������$< 8��5�     ��5�     �� *	DeleteJob+��5�     �� $= 	Grid_data��$ SelectedItem�.��5�     �� $ Vertical=�6%   .+�5�       $ Delete=�5�  !   $��40��5�  !   $��50��5�  !   $��Center=�5�  !   
���  ��5�  !   �� 5�     $
��Xóa��5�  !   $��15(�5�  !   $��Center=�5�  !   
���   �5�     5�     5�     5�     � 5�     $��80��5�     $	��120��5�     $��7��5�     $��Center=�5�     .+�5�     �� #  [	 5�     #��[ 5�     $��80��5�     $; Depth3=�5�     $	��105��5�     $��Center=�5�     
����  �$��2q�5�     
�������$< 8��5�     ��5�     �� *ViewSchedule+.��5�     �� $ Vertical=�6%   .+�5�       $ CalendarClockOutline=�5�     $��50��5�     $��50��5�     $��Center=�5�     
��� � �5�     �� 5�     $��15(�5�     $��Center=�5�     
���   ���5�  "   �� 5�  &   "	 ��6,   > �� Triggers> 5�  *   :� 5�  .   ? :� RoutedEvent$? UserControl.Loaded��6;   .[�5�  2   ��   KeHoach#��[ 6B   5�  /   5   '   5     5     5     5     � 5     $��80��5     $	��120��5	     $��8��5
     $��Center=�5     .+�5     ��   MenuMainAll#  [ 5     #��[
 5     $��80��5     $; Depth3=�5     $	��105��5     $��Center=�5     
�������
����  �$��2q�5     $< 8��5     ��5     �� *Home+.��5     �� $ Vertical=�6%   .+�5       $
 Home=�5     $��50��5     $��50��5     $��Center=�5     
����� �5     �� 5      $��Trang Chủ��5!  !   $��15(�5"  !   $��Center=�5#  !   
���   ���5%  "   �� 5&  &   "	 ��6,   > 5'  *   :� 5(  .   $? UserControl.Loaded��6;   .[�5)  2   ��   TrangChu#��[ 6B   5*  /   5,  '   5.     5/     51     52     53     54     55     57     
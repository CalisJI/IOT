   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel      WPF_TEST.View.PlannerView   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WPF_TEST.View     j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  a ]DevExpress.Xpf.Grid.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v19.2.Core, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   /local1 clr-namespace:WPF_TEST.ViewModel   ]	 YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ag
 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 
 b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  -      Planner  � DataContext#  [   � 	Resources <   6WPF_TEST.ViewModel.TaskPriorityToIconFilenameConverter  ImageConvert2   ,WPF_TEST.ViewModel.NameToBackgroundConverter  ColorConvert  Template �� 	Converter  
Cell_color%  DevExpress.Xpf.Grid.GridControl   Columns$  DevExpress.Xpf.Grid.GridColumn$  DevExpress.Xpf.Grid.ColumnBase   	CellStyle �� 
TargetType/  )DevExpress.Xpf.Grid.LightweightCellEditor �� Property �� Value  LB2  ,DevExpress.Xpf.LayoutControl.LayoutItemLabel��%1  &	       &	      &	 
     7  &	 a     7  &	 �         �� .R��� 
������ ._��� $
��None=�$��Center=����� *TaskPriority+8   �� .R�  .    �� "  .���  �@ 
Background �� *Status+8   �� "  .���  � ��$ 30(���  � ��$ DemiBold"�.���� $��Visible=�.��]� .+�9� $
��Left=� 9� ExpandDirection$
 Left=�$
��0,23q���'  !MaterialDesignThemes.Wpf.PackIcon  $��	0,0,-10,0q�	   Kind$	 ChevronDoubleRight=�$��50��$��30��
 J� RenderTransformOrigin$
 0.5,0.5&�.����  �� Orientation$ Vertical=�  MaterialDesignBody#���  $��
8,24,16,24q�.+�#	  MaterialDesignThemes.Wpf.Card	  -   
�����_� ! PrimaryHueDarkForegroundBrush#���  $	��250��$��8q� 	  UniformCornerRadius$ 6Q�.���� $ 
Horizontal=�.+��� $ Vertical=�.+�  $	 CogTransfer=�$	��135��$��50���� $��All Process��$��25(��� $��30(�$��Right=�$	��Top=�$��	0,5,-70,0q����� *AssignedTask.Count+ �� UpdateSourceTrigger$ PropertyChanged=�	  -   
�����_�#���  $	��250��$��8q�$��0,10,0,0q�$ 6Q�.���� $ 
Horizontal=�.+��� $ Vertical=�.+�  $	 ProgressClock=�$	��135��$��50���� $��
In Process��$��25(��� $��30(�$��Right=�$	��Top=�$��	0,5,-70,0q����� *
Runnings+$ PropertyChanged=�	  -   
�����_�#���  $	��250��$��8q�$��0,10,0,0q�$ 6Q�.���� $ 
Horizontal=�.+��� $ Vertical=�.+�  $	 Update=�$	��135��$��50���� $��Not Scheduled��$��25(��� $��30(�$��Right=�$	��Top=�$��	0,5,-40,0q����� *	Pauseds+$ PropertyChanged=�	  -   
�����_�#���  $	��250��$��8q�$��0,10,0,0q�$ 6Q�.���� $ 
Horizontal=�.+��� $ Vertical=�.+�  $	 TimerOutline=�$	��135��$��50���� $��Queued��$��25(��� $��30(�$��Right=�$	��Top=�$��	0,5,-70,0q����� *	Queueds+$ PropertyChanged=�	  -   
�����_�#���  $	��250��$��8q�$��0,10,0,0q�$ 6Q�.���� $ 
Horizontal=�.+��� $ Vertical=�.+�  $	 ClockCheckOutline=�$	��135��$��50���� $��	Completed��$��25(��� $��30(�$��Right=�$	��Top=�$��	0,5,-70,0q����� *Dones+$ PropertyChanged=�0
  *DevExpress.Xpf.LayoutControl.LayoutControl
  $	��Top=�$
��auto��.  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�$��17(�.+�  $ 
Horizontal=�$
��1046��$
��auto��4  .DevExpress.Xpf.LayoutControl.DockLayoutControl   Dock$
 Left=�.+�-  'DevExpress.Xpf.LayoutControl.LayoutItem     Label$ Project��   
LabelStyle# [    LabelPosition$	 Top=�$
��Left=�$
��auto��   Content.   -     Name$ 	Grid_data��$
��1000��$
��auto��$
 Left=�)  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource ��  �� Path$ AssignedTask�   SelectedItem �� *PlannerTask+$ PropertyChanged=�      	FieldName$
 Name��$  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$
 Name    Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 300   $ Posting Date $ Posting_Time��$	 160   $ 	StartDate��$ 
Start Date $	 200   $ DueDate��$ Due Date $	 200   $ Priority��$ Priority    
FixedWidth .    EditSettings :  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings  <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase&   ApplyItemTemplateToSelectedItem . 8  2DevExpress.Xpf.Editors.Settings.ButtonEditSettings   IsTextEditable$ FalseX�   AllowDefaultButton$ FalseX�6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!    HorizontalContentAlignment$  Stretch=�!   ItemTemplate#! [ "   ItemsSource" ,  &DevExpress.Xpf.Editors.EnumItemsSource  #   EnumType$# local1:TaskPriorityL�$   AllowImages$ .   $ Actual_vs_Liftime��$" Actual vs Plan Lifetime/Days   $ 
Completion��$ 
% Complete  =  7DevExpress.Xpf.Editors.Settings.ProgressBarEditSettings  %   ContentDisplayMode$% Value=�&   DisplayFormat$& p0��'   	IsPercent' .   -   (  Name$( Grid2Filter��)   AllowAutoFilter) . $ Current_Stage��$ Current Stage $	 400 *   	SortOrder] YDevExpress.Data.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a9  3DevExpress.Data.Design.ColumnSortOrderTypeConverter$* 	Ascending +   	SortIndex$+ 0�� �� "  , �� BasedOn, �� *9  3DevExpress.Xpf.Grid.Themes.GridRowThemeKeyExtension  �  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Grid.Themes.GridRowThemeKeys, DevExpress.Xpf.Grid.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]-   ResourceKey$- LightweightCellStyle=�+.���  �@ 
Background �� *Value+# [ � $
��auto��$��Right=�. � RowDefinitions. �� �� �� �� �� �� �� .+�� $��80��$	��120��$��5��$��Center=�.+���   WorkFlow#  [  #	 MaterialDesignRaisedLightButton#��[	 $��80��+  %MaterialDesignThemes.Wpf.ShadowAssist/   ShadowDepth$/ Depth3=�$	��120��$��Center=����#673ab7+  %MaterialDesignThemes.Wpf.ButtonAssist0   CornerRadius$0 8������ *GotoEditJob+���� 1 �� ElementName$1 	Grid_data��$ SelectedItem�.���� $ Vertical=�.+�  $	 PlaylistEdit=�$��50��$��50��
��������� $
��Edit��$��20(�$��Center=�
�������� $��80��$	��120��$��4��$��Center=�.+��� #  [ #��[	 $��80��$/ Depth3=�$	��120��$��Center=����#673ab7$0 8������ *
Schedule+.���� $ Vertical=�.+�  $	 CalendarClockOutline=�$��50��$��50��$��Center=�
��������� $��Schedule��$��20(�$��Center=�
�������� $��80��$	��120��$��6��$��Center=�.+���  
 MenuMainAll#  [
 #��[	 $��80��$/ Depth3=�$	��120��$��Center=����#673ab7$0 8������ *
GotoHome+.���� $ Vertical=�.+�  $
	 Home=�$��50��$��50��$��Center=�
��������� $
��Home��$��20(�$��Center=�
�������
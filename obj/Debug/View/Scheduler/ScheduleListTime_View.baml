   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      #clr-namespace:WPF_TESTWPF_TEST  5
      )    #WPF_TEST.View.ScheduleListTime_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      #customclr-namespace:WPF_TEST  5
      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      g cDevExpress.Xpf.Scheduling.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aDdxsch8http://schemas.devexpress.com/winfx/2008/xaml/scheduling  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j	 fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 	 5      g
 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  
  5      .��5      ]� .+�5   
   �� $	��155��5       
  Ribbon#��[  5      $	��Top=�5      0  *DevExpress.Xpf.Scheduling.SchedulerControl    	Scheduler  5      ��  �� ElementName$ schedule��5      �� 5   
   $��Right=�6   .+�5      9�  9� ExpandDirection$ Right=�5      ��5      �� 5      $��	Navigator��6    $��20(�61   $
��Bold"�6?   $��28��6Q   $��-17,0,-19,0q�6]    � LayoutTransform 5      V� 5       .~�5!   "   �� �� 5"   "   �� 5#   "    �� Angle$ 90Q�62   T� 5$   "   5%      5)      .��5-      0 	 *DevExpress.Xpf.LayoutControl.LayoutControl  $��Right=�5/      -  'DevExpress.Xpf.Core.ScrollBarExtensions   ScrollBarMode$ TouchOverlap=�50      . 	 (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�51      4 	 .DevExpress.Xpf.LayoutControl.LayoutControlBase   Padding$ 0q�52      .+�53      8  2DevExpress.Xpf.Editors.DateNavigator.DateNavigator  $	��200��54      $��Right=�55         ShowTodayButton .  	   ShowWeekNumbers	 .  
   IsMultiSelect
 . $	��Top=�59         AllowVerticalSizing .    StyleSettings 5;      C  =DevExpress.Xpf.Scheduling.SchedulerDateNavigatorStyleSettings  5<         	Scheduler 6H   �� $ schedule��5?      5B      5D      5F      �� 5G   
   $
��Left=�6   
�������.+�5H      9� $ Right=�5I      ��5J      �� 5K      $��Tool Box��5L      $��16(�5M      $��DemiBold"�5N       J� RenderTransformOrigin$ .5,.5&�5O       5P      �� 5Q      $ 90Q�5R      5T      .��5V      �� $	��150��6   .+�5W      ��   ScheduleViewModel � DataContext# [ 5X      $��Right=�5Y      
����  �$��2q�5\        MaterialDesignFlatButton#��[ 5]      $	��150��5_      $��50��5`      ��5Z      �� *Goback+.��5a      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�5b      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5c   !   $��30��5d   !      Kind$ ArrowBackCircle=�5e   !   
���� ��$��Center=�5g   !   �� 5h      $
��Back��5i   !   $��DemiBold"�5j   !   $��Center=�5k   !   $��20(�5l   !   $��20,0,5,2q�6/   5m      5n      �� 5o      $��0,30,0,0q�5p      $ 
Horizontal=�5q      .+�5r      �� $
��Left=�5s      $��10,0,0,0q�5t      ���#808080$��20��5v      $��20��6(   5x      �� 5y      $��10,0,0,0q�5z      $��20(�5{      $��DemiBold"�5|      $��Queued��5}      5~      �� 5      $��0,5,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� $
��Left=�5�      $��10,0,0,0q�5�      ���#ffa204$��20��5�      $��20��6(   5�      �� 5�      $��10,0,0,0q�5�      $��20(�5�      $��DemiBold"�5�      $
��Plan��5�      5�      �� 5�      $��0,5,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� $
��Left=�5�      $��10,0,0,0q�5�      ���#05fd00$��20��5�      $��20��6(   5�      �� 5�      $��10,0,0,0q�5�      $��20(�5�      $��DemiBold"�5�      $��Running��5�      5�      �� 5�      $��0,5,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� $
��Left=�5�      $��10,0,0,0q�5�      ���#fefe00$��20��5�      $��20��6(   5�      �� 5�      $��10,0,0,0q�5�      $��20(�5�      $��DemiBold"�5�      $��Pause��5�      5�      �� 5�      $��0,5,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� $
��Left=�5�      $��10,0,0,0q�5�      ���#fd0000$��20��5�      $��20��6(   5�      �� 5�      $��10,0,0,0q�5�      $��20(�5�      $��DemiBold"�5�      $��Delayed��5�      5�      �� 5�      $��0,5,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� $
��Left=�5�      $��10,0,0,0q�5�      ���#6495e5$��20��5�      $��20��6(   5�      �� 5�      $��10,0,0,0q�5�      $��20(�5�      $��DemiBold"�5�      $
��Done��5�      5�      �� 5�      $��0,5,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� $
��Left=�5�      $��10,0,0,0q�5�      ���#7c0080$��20��5�      $��20��6(   5�      �� 5�      $��10,0,0,0q�5�      $��20(�5�      $��DemiBold"�5�      $��Ready��5�      5�      5�      5�      5�        5�   
   -   5          Name$ schedule��5�      $
��1920��5�         AllowAppointmentResize . $	��920��5�      4	  .System.Windows.Automation.AutomationProperties 	  AutomationId$
 True��5�         	GroupType$ Resource=�5�         FirstDayOfWeek$ Monday=�5�      $
��Left=�5�      $	��Top=�5�         
LabelItems 5�      4
  .DevExpress.Xpf.Scheduling.AppointmentLabelItem
  5�       
  Brush
 ����� 
  Caption$ Queued��6:   .  (DevExpress.Xpf.Scheduling.DefaultItemIds   	LabelNone5  /DevExpress.Xpf.Scheduling.SourceObjectContainer	   Id# Z 6K   
  5�      
 �� ��$ Ready��6@      LabelImportant# Z 6P   
  5�      
 � � �$ Running��6:      LabelBusiness# Z 6L   
  5�      
 � ���$ Paused��6<      LabelPersonal# Z 6M   
  5�      
 �  ��$ Delayed��69      LabelVacation# Z 6K   
  5      
 ��ح�$
 Done��6?       LabelMustAttend# Z  6N   
  5     
 � ���$
 Plan��6<   !   LabelTravelRequired# Z! 6K   "   
DataSource" 5     *  $DevExpress.Xpf.Scheduling.DataSource  5       Planner# � DataContext## [ 5     $   AppointmentsSource$ 5     �� *	JobOrders+%   AppointmentMappings% 5     3  -DevExpress.Xpf.Scheduling.AppointmentMappings  5	     &   Subject7  1DevExpress.Xpf.Scheduling.Common.MappingConverter$& BarCode 5
     9  3DevExpress.Xpf.Scheduling.SchedulerItemBaseMappings'   Start$' Requested_Start 5     
(   End$( Requested_End 5     )   LabelId$) LabelId 5     *   ResourceMappings* 5     0  *DevExpress.Xpf.Scheduling.ResourceMappings  5     	+   Id$+ ID 5     ,   Group$, Customer 5     -   Caption$- Customer_Details 5     5     56     58     59     
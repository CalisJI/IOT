   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  #clr-namespace:WPF_TESTWPF_TEST      WPF_TEST.SchedulerMain   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  g cDevExpress.Xpf.Scheduling.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aDdxsch8http://schemas.devexpress.com/winfx/2008/xaml/scheduling  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ] YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ag	 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   	 b
 ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 
 c _DevExpress.Xpf.Ribbon.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ,local clr-namespace:WPF_TEST.ViewModel  #customclr-namespace:WPF_TEST  OdxschtBhttp://schemas.devexpress.com/winfx/2008/xaml/scheduling/themekeys     ScheduleViewModel  � DataContext#  [   � Title$ SchedulerMain��$
��1000��$
��1920�� � WindowStartupLocation$ CenterScreen=�.��]� .+���  
 Ribbon#��[ $	��Top=����� 0  *DevExpress.Xpf.Scheduling.SchedulerControl   	Scheduler ��  �� ElementName$ schedule���� $��Right=�.+�9�  9� ExpandDirection$ Right=����� $��	Navigator��$��20(�$
��Bold"�$��28��$��-17,0,-19,0q� � LayoutTransform V� .~��� �� ��  �� Angle$ 90Q�T� .��0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Right=�-  'DevExpress.Xpf.Core.ScrollBarExtensions   ScrollBarMode$ TouchOverlap=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup	   Orientation$	 Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase
   Padding$
 0q�.+�8  2DevExpress.Xpf.Editors.DateNavigator.DateNavigator  $	��200��$��Right=�   ShowTodayButton .     ShowWeekNumbers .     IsMultiSelect . $	��Top=�   AllowVerticalSizing .    StyleSettings C  =DevExpress.Xpf.Scheduling.SchedulerDateNavigatorStyleSettings     	Scheduler �� $ schedule��  -     Name$ schedule��4  .System.Windows.Automation.AutomationProperties   AutomationId$
 True��   	GroupType$ Resource=�   FirstDayOfWeek$ Monday=�$
��Left=�$	��Top=�2	  ,DevExpress.Mvvm.UI.Interactivity.Interaction 	  	Behaviors '
  !DevExpress.Mvvm.UI.EventToCommand
  �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   	EventName$ AppointmentAdded��+  %DevExpress.Mvvm.UI.EventToCommandBase   Command �� *SaveCommand+ �� RelativeSource ��  �� AncestorType$ dxb:BarButtonItemL�
  $ AppointmentAdded�� �� *SaveCommand+
  $ AppointmentEdited�� �� *SaveCommand+
  $ AppointmentRemoved�� �� *SaveCommand+
  $ AppointmentRestored�� �� *SaveCommand+   OptionsWindows .  (DevExpress.Xpf.Scheduling.OptionsWindows     AppointmentWindowType&    WPF_TEST.CustomAppointmentWindow"     
LabelItems 4  .DevExpress.Xpf.Scheduling.AppointmentLabelItem     Brush
 �����   Caption$ Queued��.  (DevExpress.Xpf.Scheduling.DefaultItemIds   	LabelNone5  /DevExpress.Xpf.Scheduling.SourceObjectContainer	    Id#  Z   
 �� ��$ Ready��!   LabelImportant#  Z!   
 � � �$ Running��"   LabelBusiness#  Z"   
 � ���$ Paused��#   LabelPersonal#  Z#   
 �  ��$ Delayed��$   LabelVacation#  Z$   
 ��ح�$
 Done��%   LabelMustAttend#  Z%   
 � ���$
 Plan��&   LabelTravelRequired#  Z& '   
DataSource' *  $DevExpress.Xpf.Scheduling.DataSource    EditJob( � DataContext#( [ )   AppointmentsSource) �� *	JobOrders+*   AppointmentMappings* 3  -DevExpress.Xpf.Scheduling.AppointmentMappings  +   Subject7  1DevExpress.Xpf.Scheduling.Common.MappingConverter$+ 	SaleOrder 9  3DevExpress.Xpf.Scheduling.SchedulerItemBaseMappings,   Start$, Requested_Start 
-   End$- Requested_End 
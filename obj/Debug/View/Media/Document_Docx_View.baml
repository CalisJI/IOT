   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  5      7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  5      &     WPF_TEST.View.Document_Docx_View   5      a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_TEST.View     5      3local1 clr-namespace:WPF_TEST.ViewModel     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5	      c _DevExpress.Xpf.Ribbon.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   5
      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      e aDevExpress.Xpf.RichEdit.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxre6http://schemas.devexpress.com/winfx/2008/xaml/richedit   5      g	 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]
 YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 
 5        � 	Resources  5         statisticsTemplate+  %DevExpress.Xpf.LayoutControl.GroupBox  Name4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header,  &DevExpress.Xpf.Core.ContentControlBase   Content � ColumnDefinitions � RowDefinitions ��Name&   DevExpress.Xpf.Editors.CheckEdit   Content)  #DevExpress.Xpf.Core.ObjectConverter   	IsChecked��%[  &	        �� 5   
   .R�5        $ gcStatistics��6   $��0,6,0,6q�63   $ 
Statistics��6D   . 5      �  5      �� 5      $
��Auto �6+   �� 5      $��* �6+   �� 5      $
��Auto �6+    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5!      �� $��Words��6    $��0,6,6,6q�6-   $
��Left=�6>   $	��Top=�6Y   $��0��6q   $��0��6~   �� 5"      $��0,6,6,6q�6    $
��Left=�61   $	��Top=�6L   $��0��6d   $��2��6q   ��6�   �� *Statistics.WordCount+�� 5#      $��Characters (no spaces)��6    $��0,6,6,6q�6>   $
��Left=�6O   $	��Top=�6j   $��1��6�   $��0��6�   �� 5$      $��0,6,6,6q�6    $
��Left=�61   $	��Top=�6L   $��1��6d   $��2��6q   ��6�   �� *#!Statistics.NoSpacesCharacterCount+�� 5%      $��Characters (with spaces)��6    $��0,6,6,6q�6@   $
��Left=�6Q   $	��Top=�6l   $��2��6�   $��0��6�   �� 5&      $! tbWithSpacesCharactersCount��6    $��0,6,6,6q�6E   $
��Left=�6V   $	��Top=�6q   $��2��6�   $��2��6�   ��6�   �� *%#Statistics.WithSpacesCharacterCount+�� 5'      $��
Paragraphs��6    $��0,6,6,6q�62   $
��Left=�6C   $	��Top=�6^   $��3��6v   $��0��6�   �� 5(      $��0,6,6,6q�6    $
��Left=�61   $	��Top=�6L   $��3��6d   $��2��6q   ��6�   �� *Statistics.ParagraphCount+  5)      $��0,6,6,6q�6$   $ Include textboxes 65   $	��Top=�6Q   $
��Left=�6i   $��4��6�   $��0��6�    6�   �� *IncludeTextboxes+5*      5+      5,      5-      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction	   	Behaviors	 5.      '  !DevExpress.Xpf.Core.DialogService  5/   
   -   5        
  Name$
 dialogService��5/      "   DialogWindowStartupLocation$ CenterOwner=�62   (  "DevExpress.Mvvm.UI.ViewServiceBase   ViewTemplate# [  6\      DialogStyle 50      �� 51       �� 
TargetType(	  "DevExpress.Xpf.Core.DXDialogWindow" 	 6   .�52      ��  �� Property �@�SizeToContent �� Value$ WidthAndHeight=�66   �� 53       �@�WindowStyle$ 
ToolWindow=�64   �� 54       � ��$	 300��61   55      57      .��59      �  5:   
   �� 5;      $��* �6   �� 5<      $
��Auto �6   .+�5>   
   -
  'DevExpress.Xpf.RichEdit.RichEditControl
  -   5         
 Name$ richedit��5?       
  CommandBarStyle$ Ribbon=�5@       
  
ShowBorder .   
  DocumentSource$  ��5B      $	��Top=�5I      $
��1057��6%   $��2��63   5K      2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5L   
   $��1��6%      IsSizeGripVisible .    5M      *   $WPF_TEST.ViewModel.PageInfoConverter  PageInfoConverter��%   &	         5N      6+   5O         	LeftItems 5P      '  !DevExpress.Xpf.Bars.BarStaticItem  5Q      !  DevExpress.Xpf.Bars.BarItem   Content 5R      `� 5S       `� 	Converter# [ 6'    `� Mode$ OneWay=�6V   .1�5T      ��  �� Path$ ActivePageNumber�6&    �� ElementName$ FirstLookModule��6>   �� 5U      $ 	PageCount�6&   $ FirstLookModule��67   5V      5X      '  !DevExpress.Xpf.Bars.BarButtonItem  5Y         ContentTemplate 5Z      �� 5[      .R�5\      �� ��6(   �� $ 	WordCount�$ FirstLookModule�� �� StringFormat$ 	{0} WORDS��5]      5_         
RightItems 5a      %  DevExpress.Xpf.Bars.BarEditItem  5b      -   5         �Name$ edZoom��5b   "       	EditWidth$	  150X�5c   "   !   ShowScreenTip! .   5e   "   1  +DevExpress.Xpf.DXBinding.DXBindingExtension  *?=$string.Format(`{0:f0}%`, @e(FirstLookModule).ActiveViewZoom)+"   Mode$" OneWay=�#   EditTemplate# 5f      �� 5g      .R�5h      )  #DevExpress.Xpf.Editors.TrackBarEdit  $	��150��6/   	 5i   "   7  1DevExpress.Xpf.Editors.OfficeZoomTrackBarBehavior  5j   &   $   Minimum$$ 10Q�6�   %   Maximum$	% 500Q�6�   &   Value& 6E   �� $ FirstLookModule��$ ActiveViewZoom�' �� Mode$' TwoWay=�6�   (   StyleSettings( 5l   "   6  0DevExpress.Xpf.Editors.TrackBarZoomStyleSettings  5m   &   5o      5p      5r      5t      5v      5w      
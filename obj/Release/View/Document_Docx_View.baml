   M S B A M L   `   `   `  ���� C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_TEST.ViewWPF_TEST.View  7 clr-namespace:WPF_TEST.ViewModelWPF_TEST.ViewModel  &     WPF_TEST.View.Document_Docx_View   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WPF_TEST.View     3local1 clr-namespace:WPF_TEST.ViewModel     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  j fDevExpress.Xpf.LayoutControl.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  c _DevExpress.Xpf.Ribbon.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  e aDevExpress.Xpf.RichEdit.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxre6http://schemas.devexpress.com/winfx/2008/xaml/richedit   ]	 YDevExpress.Mvvm.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ag
 cDevExpress.Mvvm.v19.2.ViewModel, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 
   � 	Resources     statisticsTemplate+  %DevExpress.Xpf.LayoutControl.GroupBox  Name4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header,  &DevExpress.Xpf.Core.ContentControlBase   Content � ColumnDefinitions � RowDefinitions ��Name&   DevExpress.Xpf.Editors.CheckEdit   Content)  #DevExpress.Xpf.Core.ObjectConverter   	IsChecked��%+  &	        �� .R�  $ gcStatistics��$��0,6,0,6q�$ 
Statistics��. �  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��Words��$��0,6,6,6q�$
��Left=�$	��Top=�$��0��$��0���� $��0,6,6,6q�$
��Left=�$	��Top=�$��0��$��2������ *Statistics.WordCount+�� $��Characters (no spaces)��$��0,6,6,6q�$
��Left=�$	��Top=�$��1��$��0���� $��0,6,6,6q�$
��Left=�$	��Top=�$��1��$��2������ *#!Statistics.NoSpacesCharacterCount+�� $��Characters (with spaces)��$��0,6,6,6q�$
��Left=�$	��Top=�$��2��$��0���� $! tbWithSpacesCharactersCount��$��0,6,6,6q�$
��Left=�$	��Top=�$��2��$��2������ *%#Statistics.WithSpacesCharacterCount+�� $��
Paragraphs��$��0,6,6,6q�$
��Left=�$	��Top=�$��3��$��0���� $��0,6,6,6q�$
��Left=�$	��Top=�$��3��$��2������ *Statistics.ParagraphCount+  $��0,6,6,6q�$ Include textboxes $	��Top=�$
��Left=�$��4��$��0�� �� *IncludeTextboxes+2  ,DevExpress.Mvvm.UI.Interactivity.Interaction	   	Behaviors	 '  !DevExpress.Xpf.Core.DialogService  -   
  Name$
 dialogService��"   DialogWindowStartupLocation$ CenterOwner=�(  "DevExpress.Mvvm.UI.ViewServiceBase   ViewTemplate# [     DialogStyle ��  �� 
TargetType(	  "DevExpress.Xpf.Core.DXDialogWindow" 	 .���  �� Property �@�SizeToContent �� Value$ WidthAndHeight=���  �@�WindowStyle$ 
ToolWindow=���  � ��$	 300��.���  �� $��* ��� $
��Auto �.+�-
  'DevExpress.Xpf.RichEdit.RichEditControl
  -    
 Name$ richedit�� 
  CommandBarStyle$ Ribbon=� 
  
ShowBorder .   
  DocumentSource$  ��$	��Top=�2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  $��1��   IsSizeGripVisible .    *   $WPF_TEST.ViewModel.PageInfoConverter  PageInfoConverter��%   &	            	LeftItems '  !DevExpress.Xpf.Bars.BarStaticItem  !  DevExpress.Xpf.Bars.BarItem   Content `�  `� 	Converter# [  `� Mode$ OneWay=�.1���  �� Path$ ActivePageNumber� �� ElementName$ FirstLookModule���� $ 	PageCount�$ FirstLookModule��'  !DevExpress.Xpf.Bars.BarButtonItem     ContentTemplate �� .R��� ���� $ 	WordCount�$ FirstLookModule�� �� StringFormat$ 	{0} WORDS��   
RightItems %  DevExpress.Xpf.Bars.BarEditItem  -    �Name$ edZoom��    	EditWidth$	  150X�!   ShowScreenTip! .   1  +DevExpress.Xpf.DXBinding.DXBindingExtension  *?=$string.Format(`{0:f0}%`, @e(FirstLookModule).ActiveViewZoom)+"   Mode$" OneWay=�#   EditTemplate# �� .R�)  #DevExpress.Xpf.Editors.TrackBarEdit  $	��150��	 7  1DevExpress.Xpf.Editors.OfficeZoomTrackBarBehavior  $   Minimum$$ 10Q�%   Maximum$	% 500Q�&   Value& �� $ FirstLookModule��$ ActiveViewZoom�' �� Mode$' TwoWay=�(   StyleSettings( 6  0DevExpress.Xpf.Editors.TrackBarZoomStyleSettings  
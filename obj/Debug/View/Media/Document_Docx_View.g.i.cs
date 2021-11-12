﻿#pragma checksum "..\..\..\..\View\Media\Document_Docx_View.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9D453336A0641FA182F0092FD1D5544499B25A1C70BF2FCCC0E04EC867A00F0C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Office.UI;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.RichEdit;
using DevExpress.Xpf.RichEdit.Menu;
using DevExpress.Xpf.RichEdit.UI;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Menu;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPF_TEST.View;
using WPF_TEST.ViewModel;


namespace WPF_TEST.View {
    
    
    /// <summary>
    /// Document_Docx_View
    /// </summary>
    public partial class Document_Docx_View : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\View\Media\Document_Docx_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.DialogService dialogService;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\Media\Document_Docx_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.RichEdit.RichEditControl richedit;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\View\Media\Document_Docx_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarEditItem edZoom;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF_TEST;component/view/media/document_docx_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dialogService = ((DevExpress.Xpf.Core.DialogService)(target));
            return;
            case 2:
            this.richedit = ((DevExpress.Xpf.RichEdit.RichEditControl)(target));
            
            #line 67 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            this.richedit.InvalidFormatException += new DevExpress.XtraRichEdit.RichEditInvalidFormatExceptionEventHandler(this.RichEditControl_InvalidFormatException);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            this.richedit.DocumentClosing += new System.ComponentModel.CancelEventHandler(this.RichEditControl_DocumentClosing);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            this.richedit.VisiblePagesChanged += new System.EventHandler(this.RichEditControl_VisiblePagesChanged);
            
            #line default
            #line hidden
            
            #line 70 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            this.richedit.SelectionChanged += new System.EventHandler(this.RichEditControl_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            this.richedit.ContentChanged += new System.EventHandler(this.RichEditControl_ContentChanged);
            
            #line default
            #line hidden
            
            #line 72 "..\..\..\..\View\Media\Document_Docx_View.xaml"
            this.richedit.ZoomChanged += new System.EventHandler(this.RichEditControl_ZoomChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.edZoom = ((DevExpress.Xpf.Bars.BarEditItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\CustomAppointmentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C041CC6DE997766A86C004A0A30BD34A3D29A4CB2DEA4E7AACF682E70882B027"
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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.Common;
using DevExpress.Xpf.Scheduling.Editors;
using DevExpress.Xpf.Scheduling.Themes;
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
using System.Windows.Interactivity;
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
using WPF_TEST.ViewModel;


namespace WPF_TEST {
    
    
    /// <summary>
    /// CustomAppointmentWindow
    /// </summary>
    public partial class CustomAppointmentWindow : DevExpress.Xpf.Core.ThemedWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPF_TEST.CustomAppointmentWindow window;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem toolbar_barItemSave;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem toolbar_barItemPrevious;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem toolbar_barItemNext;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem toolbar_barItemDelete;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem barItemSaveAndClose;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem barItemDelete;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutControl validationContainer;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit editorSubject;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutItem layoutStartTime;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.DateEdit editorStartDate;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit editorStartTime;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutItem layoutEndTime;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.DateEdit editorEndDate;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit editorEndTime;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\CustomAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit editorDescription;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_TEST;component/customappointmentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomAppointmentWindow.xaml"
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
            this.window = ((WPF_TEST.CustomAppointmentWindow)(target));
            return;
            case 2:
            this.toolbar_barItemSave = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            return;
            case 3:
            this.toolbar_barItemPrevious = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            return;
            case 4:
            this.toolbar_barItemNext = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            return;
            case 5:
            this.toolbar_barItemDelete = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            return;
            case 6:
            this.barItemSaveAndClose = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            return;
            case 7:
            this.barItemDelete = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            return;
            case 8:
            this.validationContainer = ((DevExpress.Xpf.LayoutControl.LayoutControl)(target));
            return;
            case 9:
            this.editorSubject = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 10:
            this.layoutStartTime = ((DevExpress.Xpf.LayoutControl.LayoutItem)(target));
            return;
            case 11:
            this.editorStartDate = ((DevExpress.Xpf.Editors.DateEdit)(target));
            return;
            case 12:
            this.editorStartTime = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 13:
            this.layoutEndTime = ((DevExpress.Xpf.LayoutControl.LayoutItem)(target));
            return;
            case 14:
            this.editorEndDate = ((DevExpress.Xpf.Editors.DateEdit)(target));
            return;
            case 15:
            this.editorEndTime = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 16:
            this.editorDescription = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

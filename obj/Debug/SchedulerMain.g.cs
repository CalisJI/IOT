﻿#pragma checksum "..\..\SchedulerMain.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "489DC05F4A3212CBE3E7C8412E62F167A93BB42130E4703CF6D67DFB78535FF9"
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
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.Common;
using DevExpress.Xpf.Scheduling.Editors;
using DevExpress.Xpf.Scheduling.Themes;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using WPF_TEST;
using WPF_TEST.ViewModel;


namespace WPF_TEST {
    
    
    /// <summary>
    /// SchedulerMain
    /// </summary>
    public partial class SchedulerMain : DevExpress.Xpf.Core.ThemedWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\SchedulerMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Scheduling.SchedulerControl schedule;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_TEST;component/schedulermain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SchedulerMain.xaml"
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
            this.schedule = ((DevExpress.Xpf.Scheduling.SchedulerControl)(target));
            
            #line 83 "..\..\SchedulerMain.xaml"
            this.schedule.AppointmentAdded += new DevExpress.Xpf.Scheduling.AppointmentAddedEventHandler(this.schedule_AppointmentAdded);
            
            #line default
            #line hidden
            
            #line 84 "..\..\SchedulerMain.xaml"
            this.schedule.AppointmentRemoved += new DevExpress.Xpf.Scheduling.AppointmentRemovedEventHandler(this.schedule_AppointmentRemoved);
            
            #line default
            #line hidden
            
            #line 85 "..\..\SchedulerMain.xaml"
            this.schedule.AppointmentEdited += new DevExpress.Xpf.Scheduling.AppointmentEditedEventHandler(this.schedule_AppointmentEdited);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


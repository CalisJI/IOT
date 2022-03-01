﻿#pragma checksum "..\..\..\..\View\Scheduler\PlannerView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E7EF28B56DC85C6211E9052EB69AA5B34F6FBFCC870D05E4B7026FB43EDC95B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Mvvm.ViewModel;
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
using DevExpress.Xpf.Grid.Themes;
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.LayoutControl;
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
using WPF_TEST.View;
using WPF_TEST.ViewModel;


namespace WPF_TEST.View {
    
    
    /// <summary>
    /// PlannerView
    /// </summary>
    public partial class PlannerView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 224 "..\..\..\..\View\Scheduler\PlannerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl Grid_data;
        
        #line default
        #line hidden
        
        
        #line 302 "..\..\..\..\View\Scheduler\PlannerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridColumn Grid2Filter;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_TEST;component/view/scheduler/plannerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Scheduler\PlannerView.xaml"
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
            
            #line 17 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((WPF_TEST.View.PlannerView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((WPF_TEST.View.PlannerView)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.UserControl_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 86 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 108 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 131 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseDown_2);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 158 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseDown_3);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 180 "..\..\..\..\View\Scheduler\PlannerView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseDown_4);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Grid_data = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 8:
            this.Grid2Filter = ((DevExpress.Xpf.Grid.GridColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\View\Media\App.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "47170F96D0092568E3887842B3034FEC9D4B403CEB0A60B9C5934D76151FCF0B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
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
using WPF_TEST.View;
using WPF_TEST.ViewModel;
using WPF_TEST.ViewModel.FileConfig;


namespace WPF_TEST {
    
    
    /// <summary>
    /// App
    /// </summary>
    public partial class App : System.Windows.Application {
        
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
            
            #line 9 "..\..\..\..\View\Media\App.xaml"
            this.StartupUri = new System.Uri("MainScreenView.xaml", System.UriKind.Relative);
            
            #line default
            #line hidden
            System.Uri resourceLocater = new System.Uri("/WPF_TEST;component/view/media/app.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Media\App.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main() {
            WPF_TEST.App app = new WPF_TEST.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}


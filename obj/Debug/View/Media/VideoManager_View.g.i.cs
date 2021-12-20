﻿#pragma checksum "..\..\..\..\View\Media\VideoManager_View.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D017531F168C224C9333CED38E07FA7C94D9967C94DD6F02371FB505EA5AA0DA"
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


namespace WPF_TEST.View {
    
    
    /// <summary>
    /// VideoManager_View
    /// </summary>
    public partial class VideoManager_View : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 222 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView videoList;
        
        #line default
        #line hidden
        
        
        #line 396 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement VideoPlayer;
        
        #line default
        #line hidden
        
        
        #line 420 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon icon;
        
        #line default
        #line hidden
        
        
        #line 436 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Skip_Backward;
        
        #line default
        #line hidden
        
        
        #line 464 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Skip_Forward;
        
        #line default
        #line hidden
        
        
        #line 494 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Stop;
        
        #line default
        #line hidden
        
        
        #line 515 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Labeltimer;
        
        #line default
        #line hidden
        
        
        #line 526 "..\..\..\..\View\Media\VideoManager_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider TimeSlider;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_TEST;component/view/media/videomanager_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Media\VideoManager_View.xaml"
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
            this.videoList = ((System.Windows.Controls.ListView)(target));
            
            #line 221 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.videoList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.videoList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.VideoPlayer = ((System.Windows.Controls.MediaElement)(target));
            
            #line 393 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.VideoPlayer.MediaOpened += new System.Windows.RoutedEventHandler(this.VideoPlayer_MediaOpened);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 408 "..\..\..\..\View\Media\VideoManager_View.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.icon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 5:
            this.Skip_Backward = ((System.Windows.Controls.Button)(target));
            
            #line 437 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.Skip_Backward.Click += new System.Windows.RoutedEventHandler(this.Skip_Backward_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Skip_Forward = ((System.Windows.Controls.Button)(target));
            
            #line 465 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.Skip_Forward.Click += new System.Windows.RoutedEventHandler(this.Skip_Forward_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Btn_Stop = ((System.Windows.Controls.Button)(target));
            
            #line 495 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.Btn_Stop.Click += new System.Windows.RoutedEventHandler(this.Btn_Stop_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Labeltimer = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TimeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 523 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.TimeSlider.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TimeSlider_MouseDown);
            
            #line default
            #line hidden
            
            #line 524 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.TimeSlider.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TimeSlider_MouseUp);
            
            #line default
            #line hidden
            
            #line 525 "..\..\..\..\View\Media\VideoManager_View.xaml"
            this.TimeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.TimeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


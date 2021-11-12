using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for VideoManager_View.xaml
    /// </summary>
    public partial class VideoManager_View : UserControl
    {
        public static DispatcherTimer VideoTimer = new DispatcherTimer();
        public VideoManager_View()
        {
            InitializeComponent();
            VideoTimer.Interval = TimeSpan.FromSeconds(1);
            VideoTimer.Tick += VideoTimer_Tick;
            VideoTimer.IsEnabled = false;

            
        }
        bool set = false;
        private void VideoTimer_Tick(object sender, EventArgs e)
        {
            if(VideoPlayer.Source != null) 
            {
                if (VideoPlayer.NaturalDuration.HasTimeSpan) 
                {
                    Labeltimer.Text = string.Format("{0} / {1}", VideoPlayer.Position.ToString(@"mm\:ss"), VideoPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                    TimeSlider.Value = VideoPlayer.Position.Seconds;
                }
            }
            else 
            {
                Labeltimer.Text = "No Select File";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!VideoTimer.IsEnabled && VideoPlayer.Source!=null) 
            {
                VideoTimer.IsEnabled = true;
                VideoTimer.Start();
                VideoPlayer.Play();
                icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;
               

            }
            else if(VideoTimer.IsEnabled && VideoPlayer.Source != null)
            {
                VideoTimer.Stop();
                VideoTimer.IsEnabled = false;
                VideoPlayer.Pause();
                
                icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Play;
            }
        }
        public double value = 0;
        private void videoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoPlayer.Source != null && set) 
            {
                int sliderValue = (int)TimeSlider.Value;

                TimeSpan ts = new TimeSpan(0, 0, 0, sliderValue);
                VideoPlayer.Position = ts;
            }
            
        }

        private void TimeSlider_MouseDown(object sender, MouseButtonEventArgs e)
        {
            set = true;
        }

        private void TimeSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            set = false;
        }

        private void VideoPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            value = VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            TimeSlider.Maximum = value;
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            if (VideoTimer.IsEnabled && VideoPlayer.Source != null)
            {
                VideoTimer.Stop();
                VideoTimer.IsEnabled = false;
                VideoPlayer.Stop();

                icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Play;
            }
        }

        private void Skip_Forward_Click(object sender, RoutedEventArgs e)
        {
            if (VideoPlayer.Source != null && VideoTimer.IsEnabled)
            {


                TimeSlider.Value += 10;
            }
        }

        private void Skip_Backward_Click(object sender, RoutedEventArgs e)
        {
            if (VideoPlayer.Source != null && VideoTimer.IsEnabled)
            {


                TimeSlider.Value -= 10;
            }
        }
    }
}

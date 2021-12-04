using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using WPF_TEST.ViewModel;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for Barcode_View.xaml
    /// </summary>
    public partial class Barcode_View : Window
    {
        AddProjectSchedule_ViewModel AddProjectSchedule_ViewModel;
        Barcode_ViewModel Barcode_ViewModel = new Barcode_ViewModel();
        VideoCaptureDevice localCamera;
        public FilterInfoCollection LocalWebcamCollection;
        public static bool loadstage = false;
        DispatcherTimer timer = new DispatcherTimer();
        public Barcode_View()
        {
            InitializeComponent();
            Loaded += Barcode_View_Loaded;
            Unloaded += Barcode_View_Unloaded1;
            //timer.Tick += Timer_Tick;
            //timer.Interval = new TimeSpan(0, 0, 0, 1);
            //timer.Start();
           
            this.Unloaded += Barcode_View_Unloaded;
        }

        private void Barcode_View_Unloaded1(object sender, RoutedEventArgs e)
        {
            loadstage = false;
        }

        private void Barcode_View_Unloaded(object sender, RoutedEventArgs e)
        {
            localCamera.SignalToStop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void Barcode_View_Loaded(object sender, RoutedEventArgs e)
        {
            loadstage = true;
            LocalWebcamCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            localCamera = new VideoCaptureDevice(LocalWebcamCollection[0].MonikerString);
            localCamera.NewFrame += LocalCamera_NewFrame;
            localCamera.Start();
            
        }
        
        public static string barcode
        {
            get { return Barcode_ViewModel._barcode; }
            set 
            {
                Barcode_ViewModel._barcode = value;
            }
        }
        private void LocalCamera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                System.Drawing.Image img = (Bitmap)eventArgs.Frame.Clone();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                bitmapImage.Freeze();

                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode((Bitmap)img);
                try
                {
                    if (result != null)
                    {
                        string decoded = result.ToString().Trim();
                        
                        barcode = decoded;
                        this.Dispatcher.Invoke(() =>
                        {
                            Macode.Text = barcode;
                        });

                        //localCamera.SignalToStop();
                        //AddProjectSchedule_ViewModel addProjectSchedule_ViewModel = AddProjectSchedule_ViewModel._AddProjectSchedule_ViewModel;
                        //addProjectSchedule_ViewModel.Get_BarCode.CanExecute(barcode);
                        //addProjectSchedule_ViewModel.Get_BarCode.Execute(barcode);
                        Thread thread = new Thread(() => 
                        {
                            AddProjectSchedule_View _View = AddProjectSchedule_View.INS_AddProjectSchedule_View;
                            _View.settext(barcode);
                        });
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();

                        
                        this.Dispatcher.BeginInvoke(new Action(() => 
                        {
                            this.Close();
                        }));
                    }
                   


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "");
                }
                Dispatcher.BeginInvoke(new ThreadStart(delegate 
                {
                    FrameSource.Source = bitmapImage;
                }));
            }
            catch (Exception ex)
            {

               
            }
        }
    }
}

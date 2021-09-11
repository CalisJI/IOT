using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_TEST.ViewModel;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for PlannerView.xaml
    /// </summary>
    public partial class PlannerView : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        public PlannerView()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            
            timer.IsEnabled = true;
            timer.Start();

        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Grid_data.RefreshData();
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Card_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Card_MouseDown_2(object sender, MouseButtonEventArgs e)
        {

        }

        private void Card_MouseDown_3(object sender, MouseButtonEventArgs e)
        {

        }

        private void Card_MouseDown_4(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.IsEnabled = false;
        }
    }
}

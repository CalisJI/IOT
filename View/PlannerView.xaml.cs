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
        void filter(int stautus) 
        {
            switch (stautus)
            {
                case 1:
                    
                    Grid_data.FilterString ="Contains([Current_Stage],'Running')";
                    break;
                case 2:
                    Grid_data.FilterString = "Contains([Current_Stage],'Plan')";
                   
                    break;
                case 3:
                    Grid_data.FilterString = "Contains([Current_Stage],'Queued')";
                   
                    break;
                case 4:
                    Grid_data.FilterString = "Contains([Current_Stage],'Done')";
                    
                    break;
                default:
                    Grid_data.ClearColumnFilter("Current_Stage");
                    break;
            }
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Grid_data.RefreshData();
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            filter(0);
        }

        private void Card_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            filter(1);
        }

        private void Card_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            filter(2);
        }

        private void Card_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            filter(3);
        }

        private void Card_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            filter(4);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.IsEnabled = false;
        }
    }
}

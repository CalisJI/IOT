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
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_TEST.ViewModel;

namespace WPF_TEST
{
    /// <summary>
    /// Interaction logic for Login_form.xaml
    /// </summary>
    public partial class Login_form : Window
    {
        public string Pass { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        public Login_form()
        {
            InitializeComponent();
           
            timer.Interval = new TimeSpan(0, 0, 0,0,800);
            timer.Tick += Timer_Tick;

            timer.IsEnabled = true;


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Login_ViewModel.LoginSuccess)
            {
                MainScreenView mainScreenView = new MainScreenView();
                mainScreenView.Closed += (object sender1, EventArgs e1) =>
                {
                    this.Show();
                };
                this.Hide();
                mainScreenView.Show();
            }
            timer.Stop();
            timer.IsEnabled = false;
        }

        private void pass_box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null) 
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled) 
            {
                timer.IsEnabled = true;
                timer.Start();
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

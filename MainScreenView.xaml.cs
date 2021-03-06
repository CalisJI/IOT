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
using WPF_TEST.SerialCommunicate;

namespace WPF_TEST
{
    /// <summary>
    /// Interaction logic for MainScreenView.xaml
    /// </summary>
    public partial class MainScreenView : Window
    {
        public static bool Main_quit { get; set; }
        public MessageReceiver MessageReceiver { get; set; }
        public MainScreenView()
        {
            Main_quit = false;
            InitializeComponent();
            Closing += MainScreenView_Closing;
        }

        private void MainScreenView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Main_quit = true;
        }
    }
}

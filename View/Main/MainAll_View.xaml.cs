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
    /// Interaction logic for MainAll_View.xaml
    /// </summary>
    public partial class MainAll_View : UserControl
    {
        public static bool LoadDone = false;
       
        public MainAll_View()
        {
            InitializeComponent();

           
        }

       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDone = true;
        }
    }
}

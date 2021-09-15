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

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for Ethenet_Serial.xaml
    /// </summary>
    public partial class Ethenet_Serial : UserControl
    {
        public Ethenet_Serial()
        {
            InitializeComponent();
        }

        private void RCVtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            RCVtb.ScrollToEnd();
        }
    }
}

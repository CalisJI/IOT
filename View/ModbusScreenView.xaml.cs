using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_TEST.ViewModel;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for ModbusScreenView.xaml
    /// </summary>
    public partial class ModbusScreenView : UserControl
    {
        ModbusViewModel ModbusViewModel;
        public ModbusScreenView()
        {
            InitializeComponent();
           
           
        }
        ObservableCollection<ModbusDevice> ModbusDevice = new ObservableCollection<ModbusDevice>();
        public void Edit_element()
        {
           
        }

        private void Home_button_Click(object sender, RoutedEventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(update_btn);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }
    }
}

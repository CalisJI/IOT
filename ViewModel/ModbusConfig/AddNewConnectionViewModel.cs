using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.SerialCommunicate;

namespace WPF_TEST.ViewModel
{
    public class AddNewConnectionViewModel:BaseViewModel
    {
        public static ObservableCollection<ModbusDevice> ModbusDevices { get; set; }
        public AddNewConnectionViewModel() 
        {
        
        }
        ~AddNewConnectionViewModel() 
        {
            
        }
    }
}

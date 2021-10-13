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
    public class ModbusViewModel:BaseViewModel
    {
        public iModbus iModbus = new iModbus();
        public string Name { get; set; }
        public string  Port { get; set; }
        public ObservableCollection<ModbusDevice> ModbusDevices { get; set; }

        public ICommand NewConnect { get; set; }
        public ICommand EditConnect { get; set; }
        public ICommand DeleteConnect { get; set; }
        public ICommand ConnectionExcute { get; set; }

        public ModbusViewModel() 
        {
            NewConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
            
            });
            EditConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
            
            });
            DeleteConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
            
            });
            ConnectionExcute = new RelayCommand<object>((p) => { return true; },(p)=> 
            {
            
            });
        }
        ~ModbusViewModel() 
        {
        
        }
    }
    public class ModbusDevice
    {
        public string DeviceName { get; set; }
        public string Port { get; set; }
        public int Baudrate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity {get;set;}
        public StopBits StopBits { get; set; }
        public int Read_Time_Out { get; set; }
        public int Update_Rate { get; set; }

    }
}

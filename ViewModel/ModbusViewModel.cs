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
        private BaseViewModel _selectedViewModel;
        public iModbus iModbus = new iModbus();
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ObservableCollection<ModbusDevice> ModbusDevices { get; set; }

        public ICommand NewConnect { get; set; }
        public ICommand EditConnect { get; set; }
        public ICommand DeleteConnect { get; set; }
        public ICommand ConnectionExcute { get; set; }
        public ICommand Save_NewConnection { get; set; }
        public ICommand Cancel_Excute { get; set; }

        ModbusDevice ModbusDevice = new ModbusDevice();
        AddNewConnectionViewModel AddNewConnectionViewModel = new AddNewConnectionViewModel();
        ModbusViewModel modbusViewModel;
        public ModbusViewModel() 
        {
            AddNewConnectionViewModel.ModbusDevices = this.ModbusDevices;
            NewConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                modbusViewModel.SelectedViewModel = AddNewConnectionViewModel;
            });
            Cancel_Excute = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                modbusViewModel.SelectedViewModel = this;
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
            Save_NewConnection = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
        }
        ~ModbusViewModel() 
        {
        
        }
    }
    public enum ConntionType 
    {
        Modbus_RTU,
        Modbus_TCP_IP
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
        public int ID { get; set; }
        public ConntionType ConntionType { get; set; }

        public string IP_Address { get; set; }
        public int TCP_IP_Port { get; set; }


    }
}

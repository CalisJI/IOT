using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.SerialCommunicate;

namespace WPF_TEST.ViewModel
{
    public class ModbusViewModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public iModbus iModbus = new iModbus();
        public DataTable ModbusInfor { get; set; }
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
        public PortSettingsViewModel ComportInfo { get; set; }
        public bool _load = false;
        public ModbusDevice ModbusDevice;
        ModbusScreenViewModel ModbusScreenViewModel = new ModbusScreenViewModel();
        AddNewConnectionViewModel AddNewConnectionViewModel = new AddNewConnectionViewModel();
        public ModbusViewModel modbusViewModel;
        public ModbusViewModel() 
        {
            if (!_load) 
            {
                modbusViewModel = this;
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
                _load = true;
            }
            ComportInfo = new PortSettingsViewModel();
            AddNewConnectionViewModel.ModbusDevices = this.ModbusDevices;
           
            NewConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                modbusViewModel.SelectedViewModel = AddNewConnectionViewModel;
            });
            Cancel_Excute = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
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
                if (ModbusDevice != null) 
                {
                    ModbusDevice = new ModbusDevice();
                    ModbusDevices.Add(ModbusDevice);
                }
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
            });
        }
       
    }
    public enum ConntionType 
    {
        Modbus_RTU,
        Modbus_TCP_IP
    }
    [ValueConversion(typeof(ConntionType), typeof(string))]
    public class ConnectionTypeToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ConntionType)value) 
            {
                case ConntionType.Modbus_RTU:
                    return "Modbus RTU";
                case ConntionType.Modbus_TCP_IP:
                    return "Modbus TCP/IP";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
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
        public int ID { get; set; }
        public ConntionType ConntionType { get; set; }

        public string IP_Address { get; set; }
        public int TCP_IP_Port { get; set; }


    }
}

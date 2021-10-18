using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using WPF_TEST.SerialCommunicate;

namespace WPF_TEST.ViewModel
{
    public class ModbusViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public iModbus iModbus = new iModbus();
        private DataTable _modbusInfor;
        public DataTable ModbusInfor
        {
            get
            {
                return _modbusInfor;
            }
            set
            {
                SetProperty(ref _modbusInfor, value, "ModbusInfor");
            }
        }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        private ObservableCollection<ModbusDevice> modbusDevices;
        public ObservableCollection<ModbusDevice> ModbusDevices
        {
            get
            {
                return modbusDevices;
            }
            set
            {
                SetProperty(ref modbusDevices, value, "ModbusDevices");
            }
        }
        private string _deviceName;

        private string _port;
        private int _baudrate;
        private int _dataBits;
        private Parity _parity;
        private StopBits _stopBits;
        private int _read_Time_Out;
        private int _update_Rate;
        private int _id;
        private ConntionTypes _conntionType;

        private string _IP_Address;
        private int _TCP_IP_Port;
        public string DeviceName 
        {
            get
            {
                return _deviceName;
            }
            set 
            {
                SetProperty(ref _deviceName, value, "DeviceName");
            }
        }
        public string Port 
        {
            get 
            {
                return _port;
            }
            set 
            {
                SetProperty(ref _port, value, "Port");
            }
        }
        public int Baudrate
        {
            get 
            {
                return _baudrate;
            }
            set 
            {
                SetProperty(ref _baudrate, value, "Baudrate");
            }
        }
        public int DataBit 
        {
            get
            {
                return _dataBits;
            }
            set
            {
                SetProperty(ref _dataBits, value, "DataBit");
            }
        }
        public Parity Parity
        {
            get
            {
                return _parity;
            }
            set
            {
                SetProperty(ref _parity, value, "Parity");
            }
        }
        public StopBits StopBit
        {
            get
            {
                return _stopBits;
            }
            set
            {
                SetProperty(ref _stopBits, value, "StopBit");
            }
        }
        public int ReadTimeOut
        {
            get
            {
                return _read_Time_Out;
            }
            set
            {
                SetProperty(ref _read_Time_Out, value, "ReadTimeOut");
            }
        }
        public int UpdateRate
        {
            get
            {
                return _update_Rate;
            }
            set
            {
                SetProperty(ref _update_Rate, value, "UpdateRate");
            }
        }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id, value, "ID");
            }
        }
        public ConntionTypes ConntionType
        {
            get
            {
                return _conntionType;
            }
            set
            {
                SetProperty(ref _conntionType, value, "ConntionType");
            }
        }
        public string IPAddress
        {
            get
            {
                return _IP_Address;
            }
            set
            {
                SetProperty(ref _IP_Address, value, "IPAddress");
            }
        }
        public int TCP_Port
        {
            get
            {
                return _TCP_IP_Port;
            }
            set
            {
                SetProperty(ref _TCP_IP_Port, value, "TCP_Port");
            }
        }
        public ICommand NewConnect { get; set; }
        public ICommand EditConnect { get; set; }
        public ICommand DeleteConnect { get; set; }
        public ICommand ConnectionExcute { get; set; }
        public ICommand Save_NewConnection { get; set; }
        public ICommand Cancel_Excute { get; set; }
        public PortSettingsViewModel ComportInfo { get; set; }
        public bool _load = false;
        ModbusDevice modbusDevice;
        public ModbusDevice ModbusDevice 
        {
            get 
            {
                return modbusDevice;
            }
            set 
            {
                SetProperty(ref modbusDevice, value, "Modbusdevice");
            }
        }
        ModbusScreenViewModel ModbusScreenViewModel = new ModbusScreenViewModel();
        AddNewConnectionViewModel AddNewConnectionViewModel = new AddNewConnectionViewModel();
        public ModbusViewModel modbusViewModel;
        public ModbusViewModel() 
        {
            if (!_load) 
            {
                ModbusDevices = new ObservableCollection<ModbusDevice>();
                modbusViewModel = this;
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
                _load = true;
            }
            ComportInfo = new PortSettingsViewModel();
            AddNewConnectionViewModel.ModbusDevices = this.modbusDevices;
           
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
                
                    ModbusDevice = new ModbusDevice();
                    ModbusDevice.DeviceName = DeviceName;
                    ModbusDevice.ConntionType = ConntionType;
                    ModbusDevice.ID = ID;
                    if (ModbusDevice.ConntionType == ConntionTypes.Modbus_RTU) 
                    {
                        ModbusDevice.IP_Address = null;
                        ModbusDevice.TCP_IP_Port = 0;
                        ModbusDevice.Port = Port;
                        ModbusDevice.Baudrate = Baudrate;
                        ModbusDevice.DataBits = DataBit;
                        ModbusDevice.StopBits = StopBit;
                        ModbusDevice.Parity = Parity;
                        ModbusDevice.Read_Time_Out = ReadTimeOut;
                        ModbusDevice.Update_Rate = UpdateRate;
                       
                    }
                    else if(ModbusDevice.ConntionType == ConntionTypes.Modbus_TCP_IP)
                    {
                        ModbusDevice.IP_Address = IPAddress;
                        ModbusDevice.TCP_IP_Port = TCP_Port;
                        ModbusDevice.Update_Rate = UpdateRate;
                        ModbusDevice.Port = null;
                        ModbusDevice.Baudrate = 0;
                        ModbusDevice.DataBits = 8;
                        ModbusDevice.Parity = Parity.None;
                        ModbusDevice.StopBits = StopBits.One;
                        ModbusDevice.Read_Time_Out = ReadTimeOut;

                    }
                    ModbusDevices.Add(ModbusDevice);
               
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
            });
        }
       
    }
    public enum ConntionTypes 
    {
        [Description("Modbus RTU")]
        Modbus_RTU,
        [Description("Modbus TCP/IP")]
        Modbus_TCP_IP
    }
    
    public class ConnectionTypeToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = typeof(ConntionTypes);
            var name = Enum.GetName(type, value);
            FieldInfo fi = type.GetField(name);
            var descriptionAttrib = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            return descriptionAttrib.Description;
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
        public ConntionTypes ConntionType { get; set; }

        public string IP_Address { get; set; }
        public int TCP_IP_Port { get; set; }


    }
}

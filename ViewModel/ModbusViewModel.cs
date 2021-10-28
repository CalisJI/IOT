﻿using System;
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
using WPF_TEST.Class_Resource;
using WPF_TEST.Notyfication;
using MySql.Data.MySqlClient;

namespace WPF_TEST.ViewModel
{
    public class ModbusViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public iModbus iModbus = new iModbus();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataTable SQLModbus = new DataTable();
        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
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
        #region Model
        /// <summary>
        /// 
        /// </summary>
        /// 
        private ModbusDevice _selectedDevice; //return Selected Item to EDit
        private ModbusDevice Edit_Item;
        public ModbusDevice SelectedDevice 
        {
            get 
            {
                return _selectedDevice;
            }
            set 
            {
                SetProperty(ref _selectedDevice, value, "SelectedDevice");
            }
        }
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
        private string _deviceName;
        private int _register;
        private string _port;
        private int _baudrate;
        private int _dataBits;
        private Parity _parity;
        private StopBits _stopBits;
        private int _read_Time_Out;
        private int _update_Rate;
        private int _id;
        private ConntionTypes _conntionType;
        private ModbusFunction _modbusFunction;
        private string _IP_Address;
        private int _TCP_IP_Port;
        public  int RegisterAddress 
        {
            get 
            {
                return _register;
            }
            set 
            {
                SetProperty(ref _register, value, "RegisterAddress");
            }
        }
        public ModbusFunction ModbusFunctionss 
        {
            get 
            {
                return _modbusFunction;
            }
            set 
            {
                SetProperty(ref _modbusFunction, value, "ModbusFunctionss");
            }
        }
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
        #endregion
        public ICommand NewConnect { get; set; }
        public ICommand EditConnect { get; set; }
        public ICommand Save_Edit { get; set; }
        public ICommand DeleteConnect { get; set; }
        public ICommand ConnectionExcute { get; set; }
        public ICommand Save_NewConnection { get; set; }
        public ICommand Cancel_Excute { get; set; }
        public ICommand Update_Data { get; set; }
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
        EditModbusConnectionViewModel EditModbusConnectionViewModel = new EditModbusConnectionViewModel();
        public ModbusViewModel modbusViewModel;
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        public ModbusViewModel() 
        {
            if (!_load) 
            {
                ModbusDevices = new ObservableCollection<ModbusDevice>();
                modbusViewModel = this;
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
                _load = true;
                Sqlexcute.Server = "112.78.2.9";
                Sqlexcute.pwd = "Fwd@2021";
                Sqlexcute.UId = "fwd63823_fwdvina";

                mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref SQLModbus, "ModbusDevice", "fwd63823_database");
                ModbusDevices = Sqlexcute.Conver_From_Data_Table_To_List<ModbusDevice>(SQLModbus);
                
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
                Edit_Item = (ModbusDevice)p;
                SelectedDevice = Edit_Item;
                modbusViewModel.SelectedViewModel = EditModbusConnectionViewModel;
                

            });
            DeleteConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
            
            });
            ConnectionExcute = new RelayCommand<object>((p) => { return true; },(p)=> 
            {
            
            });
            Save_Edit = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                ModbusDevices.Where(w => w.DeviceName == Edit_Item.DeviceName && w.ID == Edit_Item.ID).ToList().ForEach(i => i = SelectedDevice);
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;

            });
            Save_NewConnection = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
                ModbusDevice = new ModbusDevice();
                ModbusDevice.DeviceName = DeviceName;
                ModbusDevice.ConntionType = ConntionType;
                ModbusDevice.ID = ID;
                ModbusDevice.ModbusFunctions = ModbusFunctionss;
                ModbusDevice.Register_Address = RegisterAddress;
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
            Update_Data = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //List<string> dataTable = Sqlexcute.Get_table_Name("fwd63823_database");
                Save_Table();
               
               
            });
        }
        public void Save_Table() 
        {
            SQLModbus = null;
            SQLModbus = Sqlexcute.FillToDataTable<ModbusDevice>(ModbusDevices);
            bool check = true;
            bool exist = false;
            Sqlexcute.AutoCreateTable(SQLModbus, "fwd63823_database", "ModbusDevice", ref check, ref exist);
            if (!check)
            {
                messageBoxService.ShowMessage(Sqlexcute.error_message, "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, SQLModbus, "fwd63823_database");
            if (Sqlexcute.error_message != string.Empty) 
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây","Thông tin lỗi", System.Messaging.MessageType.Report);
            }

        }
    }

    public enum ConntionTypes
    {
        [Description("Modbus RTU")]
        Modbus_RTU,
        [Description("Modbus TCP/IP")]
        Modbus_TCP_IP
    }
    public enum ModbusFunction 
    {
        
        [Description("01 Read Coil")]
        Read_Coil = 1,
        [Description("02 Read Descrete Input")]
        Read_Descrete_Input = 2,
        [Description("03 Read Holding Register")]
        Read_Holding_Register = 3,
        [Description("04 Read Input Registers")]
        Weite_Holding = 4,
    }
    
    
    //public class ConnectionTypeToString : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        var type = typeof(ConntionTypes);
    //        var name = Enum.GetName(type, value);
    //        FieldInfo fi = type.GetField(name);
    //        var descriptionAttrib = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
    //        return descriptionAttrib.Description;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class ConnectionTypeToString : IValueConverter
    {
        private string GetEnumDescription(Enum enumObj)
        {
            if (enumObj == null)
            {
                return string.Empty;
            }
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }
            else
            {
                DescriptionAttribute attrib = attribArray[0] as DescriptionAttribute;
                return attrib.Description;
            }
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum myEnum = (Enum)value;
            if (myEnum == null)
            {
                return null;
            }
            string description = GetEnumDescription(myEnum);
            if (!string.IsNullOrEmpty(description))
            {
                return description;
            }
            return myEnum.ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
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
        public int Register_Address { get; set; }
        public ConntionTypes ConntionType { get; set; }
        public ModbusFunction ModbusFunctions { get; set; }
        public string IP_Address { get; set; }
        public int TCP_IP_Port { get; set; }


    }
}

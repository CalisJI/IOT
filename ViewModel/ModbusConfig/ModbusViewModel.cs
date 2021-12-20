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
using WPF_TEST.Class_Resource;
using WPF_TEST.Notyfication;
using MySql.Data.MySqlClient;
using System.Threading;
using EasyModbus;
using WPF_TEST.Data;
using System.Windows.Threading;

namespace WPF_TEST.ViewModel
{
    public class ModbusViewModel : BaseViewModel
    {
        public DataTable DataValue = new DataTable();
        public DataProvider DataProvider = DataProvider.INS;
        static DateTime Start_ModbusRTU_Service = new DateTime();
        static DateTime Start_ModbusTCP_Service = new DateTime();
        bool temp_run = true;
        bool server_run = false;
        private BaseViewModel _selectedViewModel;
        private BaseViewModel _ChooseTypeModel;
        private BaseViewModel _DisplayType;
        private BaseViewModel _Edit_Type;

      
        public iModbus iModbus = new iModbus();
        private static BackgroundWorker _service;
        public static BackgroundWorker Modbus_Service 
        {
            get 
            {
                if(_service != null) 
                {
                    return _service;
                }
                else 
                {
                    return new BackgroundWorker();
                }
            }
            set 
            {
                _service = value;
            }
        }
        //public static BackgroundWorker Modbus_Service = new BackgroundWorker();
        public static BackgroundWorker ModbusTCP_Server = new BackgroundWorker();
        private BackgroundWorker Temp_Test_thread = new BackgroundWorker();
        //private static List<ModbusTcpModule> ModbusTcpModules = new List<ModbusTcpModule>();
        public static ObservableCollection<iModbus> List_Server
        { get; set; }
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataTable SQLModbus = new DataTable();

        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
       
        

        public BaseViewModel Edit_Type
        {
            get { return _Edit_Type; }
            set
            {
                _Edit_Type = value;
                OnPropertyChanged(nameof(Edit_Type));
            }
        }
        
        public BaseViewModel DisplayType
        {
            get { return _DisplayType; }
            set
            {
                _DisplayType = value;
                OnPropertyChanged(nameof(DisplayType));
            }
        }
        public BaseViewModel ChooseTypeModel
        {
            get { return _ChooseTypeModel; }
            set 
            {
                _ChooseTypeModel = value;
                OnPropertyChanged(nameof(ChooseTypeModel));
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
        private static PLC_Modbus ValueTemp = new PLC_Modbus();
        private static PLC_Modbus _PLCValue;
        public PLC_Modbus Select_PLCVALUE 
        {
            get 
            {
                return _PLCValue;
            }
            set 
            {
                SetProperty(ref _PLCValue, value, nameof(Select_PLCVALUE));
            }
        }

        public static ObservableCollection<ModbusDevice> modbusDevices;
        public ObservableCollection<ModbusDevice> ModbusDevices
        {
            get
            {
                return modbusDevices;
            }
            set
            {
                SetProperty(ref modbusDevices, value, nameof(ModbusDevices));
            }
        }

        private string _str;
        public string Valuestr 
        {

            get { return _str; }
            set
            { SetProperty(ref _str, value, nameof(Valuestr));
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
        private bool _StarByServer;
        private int _quantity;
        public int Quantity 
        {
            get { return _quantity; }
            set 
            {
                SetProperty(ref _quantity, value, nameof(Quantity));
            }
        }
        public bool Start_Byserver
        {
            get
            { 
                return _StarByServer; 
            } 
            set 
            {
                SetProperty(ref _StarByServer, value, nameof(Start_Byserver)); 
            } 
        }
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
        public ICommand Choose_Type { get; set; }
        public ICommand Display_Type { get; set; }
        public ICommand Start_Service { get; set; }
        public ICommand Stop_Service { get; set; }
        public ICommand Stop { get; set; }
        public ICommand Start { get; set; }
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
        Modbus_RTU_Frame_ViewModel Modbus_RTU_Frame_ViewModel = new Modbus_RTU_Frame_ViewModel();
        Modbus_TCP_IP_Frame_ViewModel Modbus_TCP_IP_Frame_ViewModel = new Modbus_TCP_IP_Frame_ViewModel();
        RTU_Frame_ViewModel RTU_Frame_ViewModel = new RTU_Frame_ViewModel();
        TCP_IP_Frame_ViewModel TCP_IP_Frame_ViewModel = new TCP_IP_Frame_ViewModel();
        EditModbus_TCP_Window_ViewModel EditModbus_TCP_Window_ViewModel = new EditModbus_TCP_Window_ViewModel();
        EditModbus_Window_ViewModel EditModbus_Window_ViewModel = new EditModbus_Window_ViewModel();

        string G_namedevice = string.Empty;

        private string[] ComName;
        iModbus test = new iModbus();
        ModbusDevice test_Connection = new ModbusDevice();

        public ModbusViewModel() 
        {
            if (!_load) 
            {
                ModbusDevices = new ObservableCollection<ModbusDevice>();
                ModbusTCP_Server.DoWork += ModbusTCP_Server_DoWork;
                ModbusTCP_Server.RunWorkerCompleted += ModbusTCP_Server_RunWorkerCompleted;
                ModbusTCP_Server.WorkerSupportsCancellation = true;
                ModbusTCP_Server.WorkerReportsProgress = true;
                Modbus_Service.DoWork += Modbus_Service_DoWork;
                Modbus_Service.RunWorkerCompleted += Modbus_Service_RunWorkerCompleted;
                Modbus_Service.WorkerSupportsCancellation = true;
                Modbus_Service.WorkerReportsProgress = true;
                Temp_Test_thread.DoWork += Temp_Test_thread_DoWork;
                Temp_Test_thread.RunWorkerCompleted += Temp_Test_thread_RunWorkerCompleted;
                Temp_Test_thread.WorkerSupportsCancellation = true;
                Temp_Test_thread.WorkerReportsProgress = true;
                modbusViewModel = this;
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
                //modbusViewModel.SelectedViewModel = MenuFileConfig_ViewModel;
                _load = true;
                List_Server = new ObservableCollection<iModbus>();
                Read01 = new List<bool[]>();
                Read02 = new List<bool[]>();
                Read03 = new List<short[]>();
                Read04 = new List<short[]>();
                //Sqlexcute.Server = "112.78.2.9";
                //Sqlexcute.pwd = "Fwd@2021";
                //Sqlexcute.UId = "fwd63823_fwdvina";

                mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref SQLModbus, "ModbusDevice", "fwd63823_database");
                ModbusDevices = Sqlexcute.Conver_From_Data_Table_To_List<ModbusDevice>(SQLModbus);
                Get_Thread(ref ComName);
                GetmodbusTCP();
                SyncValue();
              
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
                try
                {
                    Edit_Item = (ModbusDevice)p;
                    SelectedDevice = Edit_Item;
                    if (Edit_Item.ConntionType == ConntionTypes.Modbus_RTU)
                    {
                        Edit_Type = EditModbus_Window_ViewModel;
                    }
                    else if (Edit_Item.ConntionType == ConntionTypes.Modbus_TCP_IP)
                    {
                        Edit_Type = EditModbus_TCP_Window_ViewModel;
                    }
                    modbusViewModel.SelectedViewModel = EditModbusConnectionViewModel;
                }
                catch (Exception ex)
                {
                    messageBoxService.ShowMessage(ex.Message, "CẢNH BÁO!", System.Messaging.MessageType.Report);
                }
              
                

            });
            DeleteConnect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var delete = (ModbusDevice)p;
                ModbusDevices.Remove(delete);
                Get_Thread(ref ComName);
                GetmodbusTCP();
                SyncValue();
            });
            ConnectionExcute = new RelayCommand<object>((p) => { return true; },(p)=> 
            {
                
                bool check1 = test.Closed();
                if (!check1)
                {
                    messageBoxService.ShowMessage(test.Modbus_status, string.Format("Lỗi Ngắt Kết Nối Thiết Bị {0}", test_Connection.DeviceName), System.Messaging.MessageType.Report);
                }

                var e = (ModbusDevice)p;
                test_Connection = e;

                var c = List_Server.Where(m => m._RS485Port == e.Port 
                                                && m._RS485BaudRate == e.Baudrate 
                                                && m._RS485Parity == e.Parity
                                                && m._Rs485StopBit == e.StopBits
                                                && m.Modbusfunction == e.ModbusFunctions).FirstOrDefault();
                test = c;
                bool mo = test.Opened(); //mở một port
                if (!Temp_Test_thread.IsBusy)
                {
                    if (!mo)
                    {
                        messageBoxService.ShowMessage(c.Modbus_status, "Lỗi Kết Nối", System.Messaging.MessageType.Report);
                    }
                    else
                    {
                        messageBoxService.ShowMessage(string.Format("Kết Nối Thiết Bị {0} Thành Công", test_Connection.DeviceName), "Connecttion Status", System.Messaging.MessageType.Report);
                        
                    }
                };
               
                
            });
            Save_Edit = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                ModbusDevices.Where(w => w.DeviceName == Edit_Item.DeviceName && w.ID == Edit_Item.ID).ToList().ForEach(i => i = SelectedDevice);
                Get_Thread(ref ComName);
                GetmodbusTCP();
                SyncValue();
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
                    ModbusDevice.Start_by_Service = Start_Byserver;
                    ModbusDevice.Read_Time_Out = ReadTimeOut;
                    ModbusDevice.Update_Rate = UpdateRate;
                    ModbusDevice.Quantity = Quantity;
                    
                       
                }
                else if(ModbusDevice.ConntionType == ConntionTypes.Modbus_TCP_IP)
                {
                    ModbusDevice.IP_Address = IPAddress;
                    ModbusDevice.TCP_IP_Port = TCP_Port;
                    ModbusDevice.Update_Rate = UpdateRate;
                    ModbusDevice.Port = null;
                    ModbusDevice.Baudrate = 0;
                    ModbusDevice.DataBits = 8;
                    ModbusDevice.Start_by_Service = Start_Byserver;
                    ModbusDevice.Parity = Parity.None;
                    ModbusDevice.StopBits = StopBits.One;
                    ModbusDevice.Read_Time_Out = ReadTimeOut;
                    ModbusDevice.Quantity = Quantity;

                }
                ModbusDevices.Add(ModbusDevice);
                Get_Thread(ref ComName);
                GetmodbusTCP();
                SyncValue();
                modbusViewModel.SelectedViewModel = ModbusScreenViewModel;
            });
            Update_Data = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //List<string> dataTable = Sqlexcute.Get_table_Name("fwd63823_database");
                try
                {
                    Save_Table();
                }
                catch (Exception ex)
                {

                   
                }
               
               
               
            });
            Choose_Type = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if ((ConntionTypes)p == ConntionTypes.Modbus_RTU) 
                {
                    ChooseTypeModel = Modbus_RTU_Frame_ViewModel;
                }
                else if ((ConntionTypes)p == ConntionTypes.Modbus_TCP_IP) 
                {
                    ChooseTypeModel = Modbus_TCP_IP_Frame_ViewModel;
                }
            });
            Display_Type = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var a = (ModbusDevice)p;
                try
                {
                    if (a.ConntionType == ConntionTypes.Modbus_RTU)
                    {
                        DisplayType = RTU_Frame_ViewModel;
                    }
                    else if (a.ConntionType == ConntionTypes.Modbus_TCP_IP)
                    {
                        DisplayType = TCP_IP_Frame_ViewModel;
                    }
                    Select_PLCVALUE = DataProvider.PLC_DataInput.Where(x => x.Device_Name == a.DeviceName).FirstOrDefault();
                    //G_namedevice = ValueTemp.Device_Name;
                    //DataValue = Sqlexcute.FillToDataTable(ValueTemp.Data);
                }
                catch (Exception)
                {

                   
                }
                
            });
            Start_Service = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    int dem = 0;
                    foreach (var item in List_Server)
                    {
                        if (item.Start_by_service) 
                        {
                            bool check = item.Opened();
                            if (!check) 
                            {
                                messageBoxService.ShowMessage(item.Modbus_status, string.Format("Lỗi Kết Nối (Thiết Bị {0})",dem), System.Messaging.MessageType.Report);
                            }
                            dem++;
                        }
                        
                    }
                    if (!Modbus_Service.IsBusy)
                    {
                        var d = ModbusDevices.Where(x => x.ConntionType == ConntionTypes.Modbus_RTU).Count();
                        if (d > 0) 
                        {
                            Modbus_Service.RunWorkerAsync();
                            Start_ModbusRTU_Service = DateTime.Now;
                        }
                        
                    }
                    if (!ModbusTCP_Server.IsBusy) 
                    {
                        var d = ModbusDevices.Where(x => x.ConntionType == ConntionTypes.Modbus_TCP_IP).Count();
                        if (d > 0) 
                        {
                            ModbusTCP_Server.RunWorkerAsync();
                            Start_ModbusTCP_Service = DateTime.Now;
                        }
                       
                    }
                    server_run = true;

                }
                catch (Exception ex)
                {

                    messageBoxService.ShowMessage(ex.Message, "Thông tin lỗi", System.Messaging.MessageType.Report);
                }
            });
            Stop_Service = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
               
                if (Modbus_Service.IsBusy) 
                {
                    Modbus_Service.CancelAsync();
                    server_run = false;
                }
                if (ModbusTCP_Server.IsBusy) 
                {
                    ModbusTCP_Server.CancelAsync();
                    server_run = false;
                }
            });
            Stop = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (Temp_Test_thread.IsBusy)
                {
                    Temp_Test_thread.CancelAsync();
                }
            });
            Start = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (!Temp_Test_thread.IsBusy)
                {
                    Temp_Test_thread.RunWorkerAsync();
                }
            });

        }
        #region ==================================================================Function============================================================================
        
        private void SyncValue() 
        {
            try
            {
                DataProvider.PLC_DataInput.Clear();
                DataProvider.PLC_DataInput = new ObservableCollection<PLC_Modbus>();
                foreach (var item in ModbusDevices)
                {
                    string name = item.DeviceName;
                    DataProvider.PLC_DataInput.Add(new PLC_Modbus { Device_Name = name, Data = new ObservableCollection<RuntimeValue>() });
                }
                DataProvider.UpLoad_data(1);
            }
            catch (Exception ex)
            {

              
            }
           
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        private void GetmodbusTCP()
        {
            if (ModbusTCP_Server.IsBusy)
            {
                ModbusTCP_Server.CancelAsync();
                server_run = false;
            }
            //if (ModbusTcpModules.Count != 0)
            //{
            //    ModbusTcpModules.Clear();
            //}
            //foreach (var item in ModbusDevices)
            //{
            //    if (item.ConntionType == ConntionTypes.Modbus_TCP_IP)
            //    {
            //        ModbusTcpModule modbusTcpModule = new ModbusTcpModule();
            //        modbusTcpModule.Ip_Address = item.IP_Address;
            //        modbusTcpModule.Ip_Port = item.TCP_IP_Port;
            //        modbusTcpModule.UpdateRate = item.Update_Rate;
            //        ModbusTcpModules.Add(modbusTcpModule);
            //    }
            //    else continue;
            //}
        }
        public void Save_Table()
        {
            SQLModbus = null;
            SQLModbus = Sqlexcute.FillToDataTable(ModbusDevices);
            bool check = true;
            bool exist = false;
            Sqlexcute.AutoCreateTable(SQLModbus, Sqlexcute.Database, "ModbusDevice", ref check, ref exist);
            if (!check)
            {
                messageBoxService.ShowMessage(Sqlexcute.error_message, "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            Sqlexcute.Update_Table_to_Host(SQLModbus, Sqlexcute.Database, "ModbusDevice");

            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            //mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref SQLModbus, "ModbusDevice", "fwd63823_database");
            //ModbusDevices = Sqlexcute.Conver_From_Data_Table_To_List<ModbusDevice>(SQLModbus);
            //Get_Thread(ref ComName);
            //GetmodbusTCP();
            //SyncValue();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Comport"></param>
        private void Get_Thread(ref string[] Comport) //tạo một list object kết nối 485
        {
            List_Server.Clear();
            
            //Read01.Clear();
            //Read02.Clear();
            //Read03.Clear();
            //Read04.Clear();

            //Read01 = new List<bool[]>();
            //Read02 = new List<bool[]>();
            //Read03 = new List<Int16[]>();
            //Read04 = new List<Int16[]>();

            foreach (var item in ModbusDevices)
            {
                bool check = false;
                foreach (var item1 in ModbusDevices)
                {
                    if (item.Port == item1.Port && item.ConntionType == ConntionTypes.Modbus_RTU && item1.ConntionType == ConntionTypes.Modbus_RTU)
                    {
                        check = true;
                    }
                }
                if (check && item.ConntionType == ConntionTypes.Modbus_RTU)
                {
                    iModbus iModbus = new iModbus();
                    iModbus._RS485Port = item.Port;
                    iModbus._RS485BaudRate = item.Baudrate;
                    iModbus._RS485Databit = item.DataBits;
                    iModbus._RS485Parity = item.Parity;
                    iModbus._Rs485StopBit = item.StopBits;
                    iModbus.Modbusfunction = item.ModbusFunctions;
                    iModbus._RS485_Readtimeout = item.Read_Time_Out;
                    iModbus.Start_by_service = item.Start_by_Service;
                    bool exit = List_Server.Any(d => d._RS485Port == iModbus._RS485Port
                                                  && d._RS485Parity == iModbus._RS485Parity
                                                  && d._RS485BaudRate == iModbus._RS485BaudRate
                                                  && d._RS485Databit == iModbus._RS485Databit);
                    if (!exit)
                    {
                        List_Server.Add(iModbus);


                    }

                }
                else if(item.ConntionType == ConntionTypes.Modbus_RTU)
                {
                    iModbus iModbus = new iModbus();
                    iModbus._RS485Port = item.Port;
                    iModbus._RS485BaudRate = item.Baudrate;
                    iModbus._RS485Databit = item.DataBits;
                    iModbus._RS485Parity = item.Parity;
                    iModbus._Rs485StopBit = item.StopBits;
                    iModbus._RS485_Readtimeout = item.Read_Time_Out;
                    iModbus.Start_by_service = item.Start_by_Service;
                    iModbus.Modbusfunction = item.ModbusFunctions;
                    List_Server.Add(iModbus);
                }
                if (item.ModbusFunctions == ModbusFunction.Read_Coil)
                {
                    bool[] read1 = new bool[] { };
                    Read01.Add(read1);
                }
                else if (item.ModbusFunctions == ModbusFunction.Read_Descrete_Input)
                {
                    bool[] read2 = new bool[] { };
                    Read02.Add(read2);
                }
                else if (item.ModbusFunctions == ModbusFunction.Read_Holding_Register)
                {
                    Int16[] read3 = new Int16[] { };
                    Read03.Add(read3);
                }
                else if (item.ModbusFunctions == ModbusFunction.Read_Input_Register)
                {
                    Int16[] read4 = new Int16[] { };
                    Read04.Add(read4);
                }
                check = false;
            }

            Comport = new string[List_Server.Count];
            for (int i = 0; i < List_Server.Count; i++)
            {
                Comport[i] = List_Server.ElementAt(i)._RS485Port;
            }

        }
        #endregion
        #region ============================================================BackGroundWork DoWork==============================================
        private void ModbusTCP_Server_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MainScreenView.Main_quit) 
            {
            
            }
            else if (!ModbusTCP_Server.IsBusy) 
            {
                if (server_run && !ModbusTCP_Server.IsBusy)
                {
                    ModbusTCP_Server.RunWorkerAsync();
                }

            }
        }

        private void ModbusTCP_Server_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ModbusTCP_Server.CancellationPending) 
            {
                e.Cancel = true;
                return;
            }
            else
            {
                foreach (var item in ModbusDevices)
                {
                    TimeSpan timeSpan = DateTime.Now - Start_ModbusTCP_Service;
                    int queue = (int)timeSpan.TotalMilliseconds % item.Update_Rate;
                    if (item.ConntionType == ConntionTypes.Modbus_TCP_IP && item.ModbusFunctions == ModbusFunction.Read_Coil && item.Start_by_Service && queue < 300 && queue >= 0) 
                    {
                        try
                        {
                            ModbusClient modbusClient = new ModbusClient(item.IP_Address, item.TCP_IP_Port);
                            if (!modbusClient.Connected)
                            {
                                modbusClient.Connect();

                            }
                            //var t = ModbusTcpModules.Where(m => m.Port == item.TCP_IP_Port && m.IPAddress == item.IP_Address && m.UpdateRate == item.Update_Rate).FirstOrDefault();
                            bool[] readcoil = modbusClient.ReadCoils(item.Register_Address, item.Quantity);
                            var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                            RuntimeValue runtimeValue = new RuntimeValue();
                            runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                            for (int i = 0; i < readcoil.Length; i++)
                            {
                                runtimeValue.ArrayValue[i] = Convert.ToInt32(readcoil[i]);
                            }
                            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                try
                                {

                                    v.Data.Add(runtimeValue);
                                }
                                catch (Exception ex)
                                {


                                }
                            }));
                            if (modbusClient.Connected) modbusClient.Disconnect();
                            DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                        }
                        catch (Exception)
                        {

                          
                        }
                      

                    }
                    else if(item.ConntionType == ConntionTypes.Modbus_TCP_IP && item.ModbusFunctions == ModbusFunction.Read_Descrete_Input && item.Start_by_Service && queue < 300 && queue >= 0) 
                    {
                        try
                        {
                            ModbusClient modbusClient = new ModbusClient(item.IP_Address, item.TCP_IP_Port);
                            //var t = ModbusTcpModules.Where(m => m.Ip_Port == item.TCP_IP_Port && m.Ip_Address == item.IP_Address && m.UpdateRate == item.Update_Rate).FirstOrDefault();
                            //bool[] readcoil = t.Device_Client.ReadDiscreteInputs(item.Register_Address, item.Quantity);
                            if (!modbusClient.Connected) 
                            {
                                modbusClient.Connect();
                               
                            }
                            bool[] readcoil = modbusClient.ReadDiscreteInputs(item.Register_Address, item.Quantity);
                            var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                            RuntimeValue runtimeValue = new RuntimeValue();
                            runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                            for (int i = 0; i < readcoil.Length; i++)
                            {
                                runtimeValue.ArrayValue[i] = Convert.ToInt32(readcoil[i]);
                            }
                            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                try
                                {

                                    v.Data.Add(runtimeValue);
                                }
                                catch (Exception ex)
                                {


                                }
                            }));
                            if (modbusClient.Connected) modbusClient.Disconnect();
                            DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database

                        }
                        catch (Exception ex)
                        {


                        }
                    }
                    else if (item.ConntionType == ConntionTypes.Modbus_TCP_IP && item.ModbusFunctions == ModbusFunction.Read_Holding_Register && item.Start_by_Service && queue < 300 && queue >= 0)
                    {
                        try
                        {
                            //var t = ModbusTcpModules.Where(m => m.Port == item.TCP_IP_Port && m.IPAddress == item.IP_Address && m.UpdateRate == item.Update_Rate).FirstOrDefault();
                            //int[] readcoil = t.Device_Client.ReadHoldingRegisters(item.Register_Address, item.Quantity);

                            ModbusClient modbusClient = new ModbusClient(item.IP_Address, item.TCP_IP_Port);
                            
                            //var t = ModbusTcpModules.Where(m => m.Ip_Port == item.TCP_IP_Port && m.Ip_Address == item.IP_Address && m.UpdateRate == item.Update_Rate).FirstOrDefault();
                            //bool[] readcoil = t.Device_Client.ReadDiscreteInputs(item.Register_Address, item.Quantity);
                            if (!modbusClient.Connected)
                            {
                                modbusClient.Connect();

                            }
                            int[] readcoil = modbusClient.ReadHoldingRegisters(item.Register_Address, item.Quantity);
                            var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                            RuntimeValue runtimeValue = new RuntimeValue();
                            runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");

                            runtimeValue.ArrayValue = readcoil;
                            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                try
                                {

                                    v.Data.Add(runtimeValue);
                                }
                                catch (Exception ex)
                                {


                                }
                            }));
                            
                           
                            if (modbusClient.Connected) modbusClient.Disconnect();
                            //System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => 
                            //{
                            try
                            {
                                if (Select_PLCVALUE.Device_Name == item.DeviceName && Select_PLCVALUE != null)
                                {
                                    Select_PLCVALUE.Data = DataProvider.PLC_DataInput.Where(x => x.Device_Name == Select_PLCVALUE.Device_Name).FirstOrDefault().Data;
                                    //int[] a = Select_PLCVALUE.Data.ElementAt(Select_PLCVALUE.Data.Count - 1).ArrayValue;
                                }

                            }
                            catch (Exception ex)
                            {


                            }
                            //}));

                            DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                    else if (item.ConntionType == ConntionTypes.Modbus_TCP_IP && item.ModbusFunctions == ModbusFunction.Read_Input_Register && item.Start_by_Service && queue < 300 && queue >= 0)
                    {
                        try
                        {
                            ModbusClient modbusClient = new ModbusClient(item.IP_Address, item.TCP_IP_Port);
                            if (!modbusClient.Connected)
                            {
                                modbusClient.Connect();

                            }
                            //var t = ModbusTcpModules.Where(m => m.Port == item.TCP_IP_Port && m.IPAddress == item.IP_Address && m.UpdateRate == item.Update_Rate).FirstOrDefault();
                            int[] readcoil = modbusClient.ReadInputRegisters(item.Register_Address, item.Quantity);
                            var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                            RuntimeValue runtimeValue = new RuntimeValue();
                            runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");

                            runtimeValue.ArrayValue = readcoil;
                            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                try
                                {

                                    v.Data.Add(runtimeValue);
                                }
                                catch (Exception ex)
                                {


                                }
                            }));

                            if (modbusClient.Connected) modbusClient.Disconnect();
                            //System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            //{
                            try
                            {
                                if (Select_PLCVALUE.Device_Name == item.DeviceName && Select_PLCVALUE != null)
                                {
                                    Select_PLCVALUE.Data = DataProvider.PLC_DataInput.Where(x => x.Device_Name == Select_PLCVALUE.Device_Name).FirstOrDefault().Data;
                                //            int[] a = Select_PLCVALUE.Data.ElementAt(Select_PLCVALUE.Data.Count - 1).ArrayValue;
                                }

                            }
                            catch (Exception ex)
                            {


                            }
                            //}));
                            DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
                //var d = ModbusDevices.Where(m => m.ConntionType == ConntionTypes.Modbus_TCP_IP).Max(tt => tt.Update_Rate);
                //Thread.Sleep(d);
            }
        }

       
        private void Temp_Test_thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MainScreenView.Main_quit)
            {
                //Temp_Test_thread.CancelAsync();
            }
            else 
            {
                if (!temp_run) 
                {
                
                }
                else if (!Temp_Test_thread.IsBusy) 
                {
                    Temp_Test_thread.RunWorkerAsync();
                }
            }
        }
       
        private void Temp_Test_thread_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Temp_Test_thread.CancellationPending) 
            {
                e.Cancel = true;
                temp_run = false;
            }
            else 
            {
                temp_run = true;
                if (test.Modbusfunction == ModbusFunction.Read_Coil)
                {
                    short[] read01 = new short[2];
                    test.SendFc01((byte)test_Connection.ID, (ushort)test_Connection.Register_Address, 16, ref read01);
                }
                else if (test.Modbusfunction == ModbusFunction.Read_Descrete_Input)
                {
                    short[] read01 = new short[2];
                    test.SendFc02((byte)test_Connection.ID, (ushort)test_Connection.Register_Address, 16, ref read01);
                }
                else if (test.Modbusfunction == ModbusFunction.Read_Holding_Register)
                {

                }
                else if (test.Modbusfunction == ModbusFunction.Read_Input_Register)
                {

                }
                Thread.Sleep(test_Connection.Update_Rate);
            }
            
        }

        
        
        private void Modbus_Service_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MainScreenView.Main_quit)
            {
                //Modbus_Service.CancelAsync();
            }
            else 
            {
                if (server_run && !Modbus_Service.IsBusy) 
                {
                    Modbus_Service.RunWorkerAsync();
                }
                
            }
        }
        public static List<bool[]> Read01 { get; set; }
        public static List<bool[]> Read02 { get; set; }
        public static List<Int16[]> Read03 { get; set; }
        public static List<Int16[]> Read04 { get; set; }
        private void Modbus_Service_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Modbus_Service.CancellationPending) 
            {
                e.Cancel = true;
            }
            else 
            {
                //int dem = 0;
                foreach (var item in ModbusDevices)
                {
                    try
                    {
                        // ModbusDevice modbusDevice = new ModbusDevice();
                        TimeSpan timeSpan = DateTime.Now - Start_ModbusRTU_Service;
                        int queue = (int)timeSpan.TotalMilliseconds % item.Update_Rate;
                        if (item.ModbusFunctions == ModbusFunction.Read_Coil && item.Start_by_Service && item.ConntionType == ConntionTypes.Modbus_RTU && queue<300 && queue>=0) 
                        {
                            
                            var o = List_Server.Where(m => m._RS485Port == item.Port
                                                      && m._RS485BaudRate == item.Baudrate
                                                      && m._RS485Databit == item.DataBits
                                                      && m._RS485Parity == item.Parity
                                                      && m._Rs485StopBit == item.StopBits).FirstOrDefault();
                            short[] read1 = new short[2];
                            bool check = o.SendFc01((byte)item.ID, (ushort)item.Register_Address, (ushort)item.Quantity, ref read1);
                            if (!check && o.Modbus_status.Contains("out")) 
                            {
                                try
                                {
                                    o.Closed();
                                }
                                catch (Exception)
                                {

                                    
                                }
                                bool check2 = o.Opened();
                                if (check2) 
                                {
                                    o.SendFc01((byte)item.ID, (ushort)item.Register_Address, (ushort)item.Quantity, ref read1);

                                    var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                                    RuntimeValue runtimeValue = new RuntimeValue();
                                    runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                                    for (int i = 0; i < read1.Length; i++)
                                    {
                                        runtimeValue.ArrayValue[i] = Convert.ToInt32(read1[i]);
                                    }
                                    System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                                    {
                                        try
                                        {

                                            v.Data.Add(runtimeValue);
                                        }
                                        catch (Exception ex)
                                        {


                                        }
                                    }));
                                    try
                                    {
                                        if (Select_PLCVALUE.Device_Name == item.DeviceName && Select_PLCVALUE != null)
                                        {
                                            Select_PLCVALUE.Data = DataProvider.PLC_DataInput.Where(x => x.Device_Name == Select_PLCVALUE.Device_Name).FirstOrDefault().Data;
                                            //            int[] a = Select_PLCVALUE.Data.ElementAt(Select_PLCVALUE.Data.Count - 1).ArrayValue;
                                        }

                                    }
                                    catch (Exception ex)
                                    {


                                    }
                                    DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                                }
                            }
                            
                        }
                        else if(item.ModbusFunctions == ModbusFunction.Read_Descrete_Input && item.Start_by_Service && item.ConntionType == ConntionTypes.Modbus_RTU && queue < 300 && queue >= 0) 
                        {
                            var o = List_Server.Where(m => m._RS485Port == item.Port
                                                      && m._RS485BaudRate == item.Baudrate
                                                      && m._RS485Databit == item.DataBits
                                                      && m._RS485Parity == item.Parity
                                                      && m._Rs485StopBit == item.StopBits).FirstOrDefault();
                            short[] read1 = new short[2];
                            bool check = o.SendFc02((byte)item.ID, (ushort)item.Register_Address, (ushort)item.Quantity, ref read1);
                            if (!check && o.Modbus_status.Contains("out"))
                            {
                                try
                                {
                                    o.Closed();
                                }
                                catch (Exception)
                                {


                                }
                                bool check2 = o.Opened();
                                if (check2)
                                {
                                    o.SendFc02((byte)item.ID, (ushort)item.Register_Address, (ushort)item.Quantity, ref read1);

                                    var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                                    RuntimeValue runtimeValue = new RuntimeValue();
                                    runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                                    for (int i = 0; i < read1.Length; i++)
                                    {
                                        runtimeValue.ArrayValue[i] = Convert.ToInt32(read1[i]);
                                    }
                                    System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                                    {
                                        try
                                        {

                                            v.Data.Add(runtimeValue);
                                        }
                                        catch (Exception ex)
                                        {


                                        }
                                    }));
                                    try
                                    {
                                        if (Select_PLCVALUE.Device_Name == item.DeviceName && Select_PLCVALUE != null)
                                        {
                                            Select_PLCVALUE.Data = DataProvider.PLC_DataInput.Where(x => x.Device_Name == Select_PLCVALUE.Device_Name).FirstOrDefault().Data;
                                            //            int[] a = Select_PLCVALUE.Data.ElementAt(Select_PLCVALUE.Data.Count - 1).ArrayValue;
                                        }

                                    }
                                    catch (Exception ex)
                                    {


                                    }
                                    DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                                }
                            }

                        }
                        else if(item.ModbusFunctions == ModbusFunction.Read_Holding_Register && item.Start_by_Service && item.ConntionType == ConntionTypes.Modbus_RTU && queue < 300 && queue >= 0) 
                        {
                            var o = List_Server.Where(m => m._RS485Port == item.Port
                                                      && m._RS485BaudRate == item.Baudrate
                                                      && m._RS485Databit == item.DataBits
                                                      && m._RS485Parity == item.Parity
                                                      && m._Rs485StopBit == item.StopBits).FirstOrDefault();
                            short[] read1 = new short[2];
                            o.SendFc3((byte)item.ID, (ushort)item.Register_Address, (ushort)item.Quantity, ref read1);

                            var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                            RuntimeValue runtimeValue = new RuntimeValue();
                            runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                            for (int i = 0; i < read1.Length; i++)
                            {
                                runtimeValue.ArrayValue[i] = Convert.ToInt32(read1[i]);
                            }
                            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                try
                                {

                                    v.Data.Add(runtimeValue);
                                }
                                catch (Exception ex)
                                {


                                }
                            }));
                            try
                            {
                                if (Select_PLCVALUE.Device_Name == item.DeviceName && Select_PLCVALUE != null)
                                {
                                    Select_PLCVALUE.Data = DataProvider.PLC_DataInput.Where(x => x.Device_Name == Select_PLCVALUE.Device_Name).FirstOrDefault().Data;
                                    //            int[] a = Select_PLCVALUE.Data.ElementAt(Select_PLCVALUE.Data.Count - 1).ArrayValue;
                                }

                            }
                            catch (Exception ex)
                            {


                            }
                            DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                        }
                        else if(item.ModbusFunctions == ModbusFunction.Read_Input_Register && item.Start_by_Service && item.ConntionType == ConntionTypes.Modbus_RTU && queue < 300 && queue >= 0) 
                        {
                            var o = List_Server.Where(m => m._RS485Port == item.Port
                                                      && m._RS485BaudRate == item.Baudrate
                                                      && m._RS485Databit == item.DataBits
                                                      && m._RS485Parity == item.Parity
                                                      && m._Rs485StopBit == item.StopBits).FirstOrDefault();
                            short[] read1 = new short[2];
                            o.SendFc04((byte)item.ID, (ushort)item.Register_Address, (ushort)item.Quantity, ref read1);

                            var v = DataProvider.PLC_DataInput.Where(x => x.Device_Name == item.DeviceName).FirstOrDefault();
                            RuntimeValue runtimeValue = new RuntimeValue();
                            runtimeValue.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                            for (int i = 0; i < read1.Length; i++)
                            {
                                runtimeValue.ArrayValue[i] = Convert.ToInt32(read1[i]);
                            }
                            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                try
                                {

                                    v.Data.Add(runtimeValue);
                                }
                                catch (Exception ex)
                                {


                                }
                            }));
                            try
                            {
                                if (Select_PLCVALUE.Device_Name == item.DeviceName && Select_PLCVALUE != null)
                                {
                                    Select_PLCVALUE.Data = DataProvider.PLC_DataInput.Where(x => x.Device_Name == Select_PLCVALUE.Device_Name).FirstOrDefault().Data;
                                    //            int[] a = Select_PLCVALUE.Data.ElementAt(Select_PLCVALUE.Data.Count - 1).ArrayValue;
                                }

                            }
                            catch (Exception ex)
                            {


                            }
                            DataProvider.UpLoad_data(1); // cập nhật dữ liệu vào database
                        }
                        
                       
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
                //var max = ModbusDevices.Max(d => d.Update_Rate);
                //Thread.Sleep(max);
            }
        }

        #endregion
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
        Read_Input_Register = 4,
    }
    public class ModbusTcpModule : EasyModbus.ModbusClient
    {
        private ModbusClient _modbusClient = new ModbusClient();
        
        public string Ip_Address { get; set; }
        public int Ip_Port { get; set; }
        public int UpdateRate { get; set; }
        public ModbusClient Device_Client 
        {
            get { return _modbusClient; }
            set 
            {
                _modbusClient.Port = Ip_Port;
                _modbusClient.IPAddress = Ip_Address;
               
            }
        }
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
        public bool Start_by_Service { get; set; }
        public int Quantity { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.Data;
using MySql.Data.MySqlClient;
using System.Text.Json;
using WPF_TEST.ViewModel;

namespace WPF_TEST.Class_Resource
{
    public class DataProvider
    {
        public static string Error_mesage { get; set; }
        private static DataProvider _ins;
        public static DataProvider INS 
        { get 
            {
                if (_ins == null) 
                {
                    _ins = new DataProvider();
                }
                return _ins;
            }
            set 
            {
                _ins = value;
            }
        }
        //public savedataEntities DB { get; set; }
        //public ServerData ServerData { get; set; }
        private Sqlexcute Sqlexcute { get; set; }

        private ObservableCollection<ModbusDevice> _modbusDevices;
        public ObservableCollection<ModbusDevice> ModbusDevices 
        {
            get 
            {
                return _modbusDevices;
            }
            set 
            {
                _modbusDevices = value;
            }
        }

        private string _cloud;
        public string Cloud_Media 
        {
            get 
            {
                return _cloud;
            }
            set 
            {
                _cloud = value;
            }
        }
        private ObservableCollection<DatabaseConfig> _cloudConfig;
        public ObservableCollection<DatabaseConfig> CloudConfig 
        {
            get 
            {
                return _cloudConfig;
            }
            set 
            {
                _cloudConfig = value;
            }
        }
        private ObservableCollection<JobOrder> _jobconfig;
        public ObservableCollection<JobOrder> JobOrderInput 
        {
            get 
            {
                return _jobconfig;
            }
            set 
            {
                _jobconfig = value;
            }
        }

        private ObservableCollection<Works> _workconfig;
        public ObservableCollection<Works> WorkInput 
        {
            get { return _workconfig; }
            set 
            {
                _workconfig = value;
            }
        }

        private ObservableCollection<Customer> _customerConfig;
        public ObservableCollection<Customer> CustomerInput 
        {
            get { return _customerConfig; }
            set
            {
                _customerConfig = value;
            }
        }

        private static ObservableCollection<PLC_Modbus> _Modbus;
        public ObservableCollection<PLC_Modbus> PLC_DataInput 
        {
            get 
            {
                return _Modbus;
            }
            set 
            {
                _Modbus = value;
            }
        }

        private static DataTable _insCloud;
        public static DataTable INS_Cloud 
        {
            get 
            {
                return _insCloud;
            }
            set 
            {
                _insCloud = value;
            }
        }

        private static DataTable _insJob;
        
        public static DataTable INS_JobOrder
        {
            get { return _insJob; }
            set 
            {
                _insJob = value;
            }
        }
        private static DataTable _insWork;
       
        public static DataTable INS_Work
        {
            get
            {
                return _insWork;
            }
            set 
            {
                _insWork = value;
            }
        }
        private static DataTable _inscustomer;
        public static DataTable INS_Customer
        {
            get 
            {
                return _inscustomer;
            }
            set 
            {
                _inscustomer = value;
            }
        }
        private static DataTable _insPLC;
        public static DataTable INS_PLC_Data 
        {
            get 
            {
                return _insPLC;
            }
            set 
            {
                _insPLC = value;
            }
        }

        private ObservableCollection<ConvertoJson> jsons;
        public ObservableCollection<ConvertoJson> Json_Job 
        {
            get 
            {
                return jsons;
            }
            set 
            {
                jsons = value;
            }
        }

        private  static ObservableCollection<ConvertoJson> jsons2;
        private MySqlDataAdapter mySqlDataAdapter;

        public ObservableCollection<ConvertoJson> JsonPLC
        {
            get
            {
                return jsons2;
            }
            set
            {
                jsons2 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private DataProvider()
        {
            //DB = new savedataEntities();
            //ServerData = new ServerData();
            Sqlexcute = new Sqlexcute();
            INS_JobOrder = new DataTable("JobOrderConfig");
            INS_Customer = new DataTable("CustomerConfig");
            INS_Work = new DataTable("Works");
            INS_PLC_Data = new DataTable("ModbusDevice");
            INS_Cloud = new DataTable("Cloud");
            CloudConfig = new ObservableCollection<DatabaseConfig>();
            WorkInput = new ObservableCollection<Works>();
            PLC_DataInput = new ObservableCollection<PLC_Modbus>();
            JobOrderInput = new ObservableCollection<JobOrder>();
            CustomerInput = new ObservableCollection<Customer>();
            initializerData();
            for (int i = 0; i < 5; i++)
            {
                LoadData(i);

            }
            var d = Data_Source();
            JobOrderInput = d.Item1;
            //PLC_DataInput = d.Item2;
            CustomerInput = d.Item2;
            WorkInput = d.Item3;
            CloudConfig = d.Item4;
            PLC_DataInput = SearchDevice();
        }

        /// <summary>
        /// type 0 JobOrder, 
        /// 
        /// type 2 customer, 
        /// type 3 work
        /// type 4 Cloud
        /// </summary>
        /// <param name="type"></param>
        public void UpLoad_data(int type) 
        {
            try
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                switch (type)
                {
                    case 0:
                        var s = JsonSerializer.Serialize(JobOrderInput);
                        Json_Job = new ObservableCollection<ConvertoJson>();
                        Json_Job.Add(new ConvertoJson { Code = s});
                        INS_JobOrder = Sqlexcute.FillToDataTable(Json_Job);
                        INS_JobOrder.TableName = "JobOrderConfig";
                        Sqlexcute.Update_Table_to_Host( INS_JobOrder, Sqlexcute.Database, INS_JobOrder.TableName);
                        break;
                    case 2:
                        INS_Customer = Sqlexcute.FillToDataTable(CustomerInput);
                        INS_Customer.TableName = "CustomerConfig";
                        Sqlexcute.Update_Table_to_Host(INS_Customer, Sqlexcute.Database, INS_Customer.TableName);
                        break;
                    case 3:
                        INS_Work = Sqlexcute.FillToDataTable(WorkInput);
                        INS_Work.TableName = "Works";
                        Sqlexcute.Update_Table_to_Host(INS_Work, Sqlexcute.Database, INS_Work.TableName);
                        break;
                    //case 1:
                    //    var s1 = JsonSerializer.Serialize(PLC_DataInput);
                    //    JsonPLC = new ObservableCollection<ConvertoJson>();
                    //    JsonPLC.Add(new ConvertoJson { Code = s1 });
                    //    INS_PLC_Data = Sqlexcute.FillToDataTable(JsonPLC);
                    //    INS_PLC_Data.TableName = "ModbusDevice";
                    //    Sqlexcute.Update_Table_to_Host(INS_PLC_Data, Sqlexcute.Database, INS_PLC_Data.TableName);
                    //    break;
                    case 4:
                        INS_Cloud = Sqlexcute.FillToDataTable(CloudConfig);
                        INS_Cloud.TableName = "Cloud";
                        Sqlexcute.Update_Table_to_Host( INS_Cloud, Sqlexcute.Database, INS_Cloud.TableName);
                        break;
                    default:
                        break;
                }
                Error_mesage = string.Empty;
            }
            catch (Exception ex)
            {

                Error_mesage = ex.Message;
            }
            
          
        }
        private void initializerData()
        {
            int check_Job = 2;
            int check_work = 2;
            //int check_PLC = 2;
            int check_customer = 2;
            int check_cloud = 2;
            Sqlexcute.Check_Table(Sqlexcute.Database, INS_JobOrder.TableName, ref check_Job);
            Sqlexcute.Check_Table(Sqlexcute.Database, INS_Customer.TableName, ref check_customer);
            //Sqlexcute.Check_Table(Sqlexcute.Database, INS_PLC_Data.TableName, ref check_PLC);
            Sqlexcute.Check_Table(Sqlexcute.Database, INS_Work.TableName, ref check_work);
            Sqlexcute.Check_Table(Sqlexcute.Database, INS_Cloud.TableName, ref check_cloud);
            if(check_cloud == 0) 
            {
                DatabaseConfig databaseConfig = new DatabaseConfig();
                
                CloudConfig.Add(databaseConfig);

                INS_Cloud = Sqlexcute.FillToDataTable(CloudConfig);
                INS_Cloud.TableName = "Cloud";
            }
            if (check_customer == 0) 
            {
                Customer customer = new Customer();
                CustomerInput.Add(customer);

                INS_Customer = Sqlexcute.FillToDataTable(CustomerInput);
                INS_Customer.TableName = "CustomerConfig";
            }
           
            //customer.Customer_Info = "Company1";

            //customer.Address = "Đà Nẵng";
            //customer.Contact_Person = "Mr.Thi";
            //customer.PhoneNumber = "0123456789";
            //customer.Email = "Person13@gmail.com";
            //customer.Customer_Details = "Email: " + customer.Email + " \n Fax:43223432 \n Address:" + customer.Address + "";

            if (check_work == 0) 
            {

                Works works = new Works();
                //Random random = new Random();
                //works.WorkOrderName = "Test1";
                //works.Product = "Product1";
                //works.Remark = "Something";
                //works.ImageProduct = @"F:\IMAGE\ELECTRONICS_machine_technology_circuit_electronic_computer_technics_detail_psychedelic_abstract_pattern_6160x4106.jpg";
                //works.Quantity = random.Next(1, 50);
                WorkInput.Add(works);

                INS_Work = Sqlexcute.FillToDataTable(WorkInput);
                INS_Work.TableName = "Works";
            }

            if (check_Job == 0) 
            {
                JobOrder jobOrder = new JobOrder();

                //jobOrder.Customerinformation = customer;
                //jobOrder.ID = random.Next(111111, 888888);
                //jobOrder.Customer_PO = "PO1";
                //jobOrder.Quotation = "Quotation1";
                //jobOrder.Priority = TaskPriority.Normal;

                //jobOrder.Requested_Start = DateTime.Today + TimeSpan.FromDays(1);
                //jobOrder.Requested_End = DateTime.Now + TimeSpan.FromDays(3);
                //jobOrder.Requested_Report_Date = DateTime.Today;
                //jobOrder.SaleOrder = "SaleOrder1";
                //jobOrder.Stage = Status.Queued;
                //jobOrder.Complete = 25;
                //jobOrder.Current_Stage = PlannerModel.getColor(jobOrder.Stage);
                //jobOrder.Works = WorkInput;
                JobOrderInput.Add(jobOrder);
                //var s = JsonSerializer.Serialize(JobOrderInput);
                //Json_Job = new ObservableCollection<ConvertoJson>();
                //Json_Job.Add(new ConvertoJson { Code = s });
                INS_JobOrder = Sqlexcute.FillToDataTable(JobOrderInput);
                INS_JobOrder.TableName = "JobOrderConfig";
            }

            //if (check_PLC == 0) 
            //{
            //    PLC_Modbus _Modbus = new PLC_Modbus();
            //    PLC_DataInput.Add(_Modbus);
            //    var s1 = JsonSerializer.Serialize(PLC_DataInput);
            //    JsonPLC = new ObservableCollection<ConvertoJson>();
            //    JsonPLC.Add(new ConvertoJson { Code = s1 });
            //    INS_PLC_Data = Sqlexcute.FillToDataTable(JsonPLC);
            //    INS_PLC_Data.TableName = "ModbusDevice";
            //}
        }

        /// <summary>
        /// ================type 0 JobOrder
        /// 
        /// ================type 2 customer
        /// ================type 3 work
        /// ================type 4 Cloud
        /// </summary>
        /// <param name="type"></param>
        public void LoadData(int type) 
        {
            try
            {
                switch (type)
                {
                    case 0:
                        Sqlexcute.AutoCreateTable(_insJob, Sqlexcute.Database, INS_JobOrder.TableName, ref _insJob , true);
                        break;
                    //case 1:
                    //    Sqlexcute.AutoCreateTable(_insPLC, Sqlexcute.Database, INS_PLC_Data.TableName, ref _insPLC , true);
                    //    break;
                    case 2:
                        Sqlexcute.AutoCreateTable(_inscustomer, Sqlexcute.Database, INS_Customer.TableName, ref _inscustomer);
                        break;
                    case 3:
                        Sqlexcute.AutoCreateTable(_insWork, Sqlexcute.Database, INS_Work.TableName, ref _insWork);
                        break;
                    case 4:
                        Sqlexcute.AutoCreateTable(_insCloud, Sqlexcute.Database, INS_Cloud.TableName, ref _insCloud);
                        break;
                    default:
                        break;
                }
                
                Error_mesage = string.Empty;
            }
            catch (Exception ex)
            {
                Error_mesage = ex.Message;
            }
           
        }
        public void UpdateRuntime(PLC_Modbus pLC_Modbus)
        {
            try
            {
                DataTable dataTable = new DataTable(pLC_Modbus.Device_Name);
                dataTable.Columns.Add("CurrentTime");
                dataTable.Columns.Add("ArrayValue");
                dataTable.Columns.Add("DeviceStage");
                foreach (var item in pLC_Modbus.Data)
                {
                    string ValueRange = string.Empty;
                    foreach (var value in item.ArrayValue)
                    {
                        ValueRange += value.ToString() + "-";
                    }
                    ValueRange = ValueRange.Substring(0, ValueRange.Length - 1);
                    dataTable.Rows.Add(item.CurrentTime, ValueRange, item.Stage.ToString());
                }
                Sqlexcute.Update_Runtime_to_Host(dataTable, pLC_Modbus.Device_Name);
                if (Sqlexcute.error_message != string.Empty)
                {
                    throw new Exception(Sqlexcute.error_message + " PLC_Error");
                }
                Error_mesage = string.Empty;
            }
            catch (Exception ex)
            {
                Error_mesage = ex.Message;
               
            }
           
        }

        /// <summary>
        /// Cập nhật dữ liêu đơn PLC lên Server
        /// </summary>
        /// <param name="DeviceName"></param>
        /// <param name="Value"></param>
        /// <param name="Currenttime"></param>
        public void UpdateRuntime(string DeviceName,int[] Value,string Currenttime) 
        {
            string cmm = string.Empty;
            foreach (var item in Value)
            {
                cmm += item.ToString() + "-";
            }
            cmm = cmm.Substring(0, cmm.Length - 1);

            Sqlexcute.SQL_command("INSERT INTO " + DeviceName + " ( `CurrentTime`,`ArrayValue`) VALUES ('"+Currenttime+"','"+cmm+"')",Sqlexcute.Database);
            Error_mesage = string.Empty;
            if (Sqlexcute.error_message != string.Empty) 
            {
                Error_mesage = Sqlexcute.error_message;
            }
            
        }

        public void DropTableDataDevice(string modbusDevice) 
        {
            try
            {
                int check = 2;
                Sqlexcute.Check_Table(Sqlexcute.Database, modbusDevice, ref check);
                if (check == 1)
                {
                    Sqlexcute.SQL_command("DROP TABLE `" + modbusDevice + "`", Sqlexcute.Database);
                }
                if (Sqlexcute.error_message != string.Empty) 
                {
                    throw new Exception(Sqlexcute.error_message);
                }
                Error_mesage = string.Empty;
            }
            catch (Exception ex)
            {
                Error_mesage = ex.Message;
                
            }
            
        }

        /// <summary>
        /// Tìm và trả vể dữ liệu của các thiết bị từ Server 
        /// </summary>
        public ObservableCollection<PLC_Modbus> SearchDevice() 
        {
            ObservableCollection<PLC_Modbus> pLC_Modbus = new ObservableCollection<PLC_Modbus>();
           
            try
            {
                _insPLC = new DataTable("ModbusDevice");
                Sqlexcute.GetData_FroM_Database(ref _insPLC, "ModbusDevice", Sqlexcute.Database);
                ModbusDevices = Sqlexcute.Conver_From_Data_Table_To_List<ModbusDevice>(_insPLC);
                if (pLC_Modbus.Count > 0) 
                {
                    pLC_Modbus.Clear();
                }
                foreach (var item in ModbusDevices)
                {
                    pLC_Modbus.Add(new PLC_Modbus() { Device_Name = item.DeviceName, Data = new ObservableCollection<RuntimeValue>()});
                    int check = 2;
                    Sqlexcute.Check_Table(Sqlexcute.Database, item.DeviceName, ref check);
                    if (check == 0)
                    {
                        string sqlsc = string.Empty;
                        sqlsc = "CREATE TABLE " + item.DeviceName + " (";
                        sqlsc += "CurrentTime VARCHAR(200),ArrayValue VARCHAR(200),DeviceStage VARCHAR(200),";
                        sqlsc += "PRIMARY KEY (CurrentTime))";

                        Sqlexcute.SQL_command(sqlsc, Sqlexcute.Database);
                    }
                }
                Error_mesage = string.Empty;
            }
            catch (Exception ex)
            {

                Error_mesage = ex.Message;
            }
            return pLC_Modbus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (ObservableCollection<JobOrder>,ObservableCollection<Customer>,ObservableCollection<Works>, ObservableCollection<DatabaseConfig>) Data_Source()
        {
            ObservableCollection<JobOrder> jobOrders = new ObservableCollection<JobOrder>();
            ObservableCollection<Works> works = new ObservableCollection<Works>();
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
           
            ObservableCollection<ConvertoJson> JS_Job = new ObservableCollection<ConvertoJson>();
            //ObservableCollection<ConvertoJson> js_PLC = new ObservableCollection<ConvertoJson>();
            ObservableCollection<DatabaseConfig> cloud = new ObservableCollection<DatabaseConfig>();
            try
            {

                cloud = Sqlexcute.Conver_From_Data_Table_To_List<DatabaseConfig>(INS_Cloud);
                jobOrders = Sqlexcute.Conver_From_Data_Table_To_List<JobOrder>(INS_JobOrder);
                works = Sqlexcute.Conver_From_Data_Table_To_List<Works>(INS_Work);
                customers = Sqlexcute.Conver_From_Data_Table_To_List<Customer>(INS_Customer);
                //js_PLC = Sqlexcute.Conver_From_Data_Table_To_List<ConvertoJson>(INS_PLC_Data);

                jobOrders = JsonSerializer.Deserialize<ObservableCollection<JobOrder>>(JS_Job.ElementAt(0).Code);
                //jobOrders = Sqlexcute.Conver_From_Data_Table_To_List<JobOrder>()
                //pLC_Modbus = JsonSerializer.Deserialize<ObservableCollection<PLC_Modbus>>(js_PLC.ElementAt(0).Code);


            }
            catch (Exception ex)
            {
               

            }
            return (jobOrders, customers, works,cloud);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using System.Data;
using MySql.Data.MySqlClient;
using WPF_TEST.Notyfication;
using WPF_TEST.Data;
using DevExpress.Mvvm.DataAnnotations;
using System.Text.Json;
using System.Windows.Threading;

namespace WPF_TEST.ViewModel
{
    [POCOViewModel]
    public class EditJobModel:BaseViewModel
    {
        private static EditJobModel model;
        public static EditJobModel INS_EditJobModel
        {
            get 
            {
                if (model != null) 
                {
                    return model;
                }
                else 
                {
                    model = new EditJobModel();
                    return model;
                }
            }
            set 
            {
                model = value;
            }
        }

        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataTable JobOrder_Table = new DataTable("JobOrder");
        DataTable Customer_Table = new DataTable("Customer_Details");
        DataTable Work_Table = new DataTable("Work Information");
       

        DispatcherTimer UpdateRuntime = new DispatcherTimer();

        #region Model
        public static bool Editting = false;
        private ObservableCollection<ConvertoJson> convertoJson;
        public ObservableCollection<ConvertoJson> ToJson
        {
            get { return convertoJson; }
            set { SetProperty(ref convertoJson, value, nameof(ToJson)); }
        }

        public static ObservableCollection<Works> _work;
        public ObservableCollection<Works> WorksList { get { return _work; } set { SetProperty(ref _work, value, nameof(WorksList)); } }
        public static ObservableCollection<Customer> _customerInfo;
        public ObservableCollection<Customer> CustomerInfo { get { return _customerInfo; } set { SetProperty(ref _customerInfo, value, nameof(CustomerInfo)); } }



        private ObservableCollection<JobOrder> _jobOrder;
        public ObservableCollection<JobOrder> JobOrders
        {
            get
            {
                return _jobOrder;
            }
            set
            {
                SetProperty(ref _jobOrder, value, nameof(JobOrders));
            }
        }
        private string _salesOrder;
        public string SalesOrder
        {
            get 
            {
                return _salesOrder;
            }
            set 
            {
                SetProperty(ref _salesOrder, value, nameof(SalesOrder));
            }
        }
        private string _customer;
        public string Custommer 
        {
            get 
            {
                return _customer;
            }
            set 
            {
                SetProperty(ref _customer, value, nameof(Custommer));
            }
        }
        private string _customer_Details;
        public string Customer_Details 
        {
            get 
            {
                return _customer_Details;
            }
            set 
            {
                SetProperty(ref _customer_Details, value, nameof(Customer_Details));
            }
        }
        private string _quotation;
        public string Quotation 
        {
            get 
            {
                return _quotation;
            }
            set 
            {
                SetProperty(ref _quotation, value, nameof(Quotation));
            }
        }
        private string _customer_PO;
        public string Customer_PO 
        {
            get 
            {
                return _customer_PO;
            }
            set 
            {
                SetProperty(ref _customer_PO, value, nameof(Customer_PO));
            }
        }
        private DateTime _request_Start;
        public DateTime Request_Start 
        {
            get 
            {
                return _request_Start;
            }
            set 
            {
                SetProperty(ref _request_Start, value, nameof(Request_Start));
            }
        }
        private DateTime _request_end;
        public DateTime Request_End 
        { 
            get { return _request_end; }
            set { SetProperty(ref _request_end, value, nameof(Request_End)); } 
        }
        private DateTime _request_report;
        public DateTime Request_Report { get { return _request_report; } set { SetProperty(ref _request_report, value, nameof(Request_Report)); } }

        private Customer _customerSelected;
        public Customer CustomerSelected 
        { get { return _customerSelected; }
            set 
            {
                SetProperty(ref _customerSelected, value, nameof(CustomerSelected));
            }
        }

        //public Customer CustomerSelected
        //{
        //    get { return _customerSelected; }
        //    set
        //    {
        //        SetProperty(ref _customerSelected, value, nameof(CustomerSelected));
        //    }
        //}
        #endregion
        
        #region Commmand
        //public ICommand Save_EditJob 
        //{
        //    get 
        //    {
        //        return new RelayCommand<object>((p) => { return true; }, (p) =>
        //        {
        //            Save_Table();
        //        });
        //    }
        //}
        
        public ICommand SelectToEditcbbox { get; set; }
        public ICommand Loaded { get; set; }
        public ICommand Unload { get; set; }
        private bool load_edit = false;
        #endregion
        public EditJobModel editJobModel;
        private MySqlDataAdapter mySqlDataAdapter;

        // Thêm công việc càn thực hiện tỏng đơn hàng thu công
        private void Add()
        {
            Random random = new Random();
            Works works = new Works();
            works.WorkOrderName = "Test1";
            works.Product = "Product1";
            works.Remark = "Something";
            works.ImageProduct = @"F:\IMAGE\ELECTRONICS_machine_technology_circuit_electronic_computer_technics_detail_psychedelic_abstract_pattern_6160x4106.jpg";
            works.Quantity = random.Next(1, 50);
            Works works1 = new Works();
            works1.WorkOrderName = "Test2";
            works1.Product = "Product2";
            works1.Remark = "Something2";
            works1.ImageProduct = @"F:\IMAGE\W_Motors_Lykan_HyperSport_2014_4K_7128x4493.jpg";
            works1.Quantity = random.Next(1, 50);
            Works works2 = new Works();
            works2.WorkOrderName = "Test3";
            works2.Product = "Product3";
            works2.Remark = "Mã thử nghiệm 1";
            works2.ImageProduct = @"F:\IMAGE\ELECTRONICS_machine_technology_circuit_electronic_computer_technics_detail_psychedelic_abstract_pattern_6160x4106.jpg";
            works2.Quantity = random.Next(1, 50);
            Works works3 = new Works();
            works3.WorkOrderName = "Test4";
            works3.Product = "Product4";
            works3.Remark = "Mã Thử nghiệm 2";
            works3.ImageProduct = @"F:\IMAGE\W_Motors_Lykan_HyperSport_2014_4K_7128x4493.jpg";
            works3.Quantity = random.Next(1, 50);
            WorksList.Add(works);
            WorksList.Add(works1);
            WorksList.Add(works2);
            WorksList.Add(works3);
        }
        //private void Add_Customer() 
        //{
        //    Customer customer = new Customer();
        //    customer.Customer_Info = "Company1";
        //    customer.Customer_Details = "Email: Person13gmail.com \n Fax:5530145 \n Address:Da Nang ...";
        //    customer.Address = "Đà Nẵng";
        //    customer.Contact_Person = "Mr.Thi";
        //    customer.PhoneNumber = "0123456789";
        //    customer.Email = "Person13@gmail.com";
        //    Customer customer1 = new Customer();
        //    customer1.Customer_Info = "Company2";
        //    customer1.Customer_Details = "Email: Person13gmail.com \n Fax:5530145 \n Address:Da Nang ...";
        //    customer1.Address = "Sài Gòn";
        //    customer1.Contact_Person = "Mr.Dao";
        //    customer1.PhoneNumber = "0321789456";
        //    customer1.Email = "Person13@gmail.com";
        //    CustomerInfo.Add(customer);
        //    CustomerInfo.Add(customer1);
        //}


        //======================== Thêm đơn hàng thủ công===========================
        private void Add_Job() 
        {
            JobOrder jobOrder = new JobOrder();
            Random random = new Random();
            //jobOrder.Customerinformation = CustomerInfo[0];
            jobOrder.BarCode = random.Next(111111, 888888).ToString();
            jobOrder.Customer_PO = "PO1";
            jobOrder.Quotation = "Quotation1";
            jobOrder.Priority = TaskPriority.Normal;
            
            jobOrder.Requested_Start = DateTime.Today + TimeSpan.FromDays(1);
            jobOrder.Requested_End = DateTime.Now + TimeSpan.FromDays(3);
            jobOrder.Requested_Report_Date = DateTime.Today;
            jobOrder.SaleOrder = "SaleOrder1";
            jobOrder.Stage = Status.Queued;
            jobOrder.Complete = 25;
            jobOrder.Current_Stage = PlannerModel.getColor(jobOrder.Stage);
            jobOrder.Quantity = WorksList[0].Quantity;
            jobOrder.Product = WorksList[0].Product;
            jobOrder.ProductCode = WorksList[0].WorkOrderName;
            

            //JobOrder jobOrder1 = new JobOrder();

            //jobOrder1.Customerinformation = CustomerInfo[1];
            //jobOrder1.ID = random.Next(111111, 888888).ToString();
            //jobOrder1.Customer_PO = "PO2";
            //jobOrder1.Quotation = "Quotation2";
            //jobOrder1.Priority = TaskPriority.Normal;
            //jobOrder1.Current_Stage = PlannerModel.getColor(Status.Plan);
            //jobOrder1.Requested_Start = DateTime.Today + TimeSpan.FromDays(1);
            //jobOrder1.Requested_End = DateTime.Now + TimeSpan.FromDays(8);
            //jobOrder1.Requested_Report_Date = DateTime.Today;
            //jobOrder1.SaleOrder = "SaleOrder2";
            //jobOrder1.Stage = Status.Plan;
            //jobOrder1.Current_Stage = PlannerModel.getColor(jobOrder1.Stage);
            //jobOrder1.Complete = 0;
            //Works works = new Works();
            //works.Product = "Sản phẩm 2";
            //works.WorkOrderName = "Mã 1";
            //works.ImageProduct = @"F:\IMAGE\W_Motors_Lykan_HyperSport_2014_4K_7128x4493.jpg";
            //works.Remark = "Noremark";
            //works.Quantity = random.Next(1, 20);
            //WorksList.Add(works);
            //jobOrder1.Works.Add(works);
            //JobOrders.Add(jobOrder);
            //JobOrders.Add(jobOrder1);
            //PlannerModel._jobOrder = JobOrders;
        }

        

       
        public EditJobModel() 
        {
            if (!load_edit) 
          {


                JobOrders = new ObservableCollection<JobOrder>();
                ToJson = new ObservableCollection<ConvertoJson>();
                CustomerInfo = new ObservableCollection<Customer>();
                WorksList = new ObservableCollection<Works>();
                CustomerInfo = CustomerSetting_ViewModel.customers;
                PlannerModel._jobOrder = JobOrders;
                PlannerModel._customerInfo = CustomerInfo;
                PlannerModel._work = WorksList;
                SchedulerViewModel._jobOrders = JobOrders;
                AddProjectSchedule_ViewModel.jobOrders = JobOrders;
                AddProjectSchedule_ViewModel._Work_Library = WorksList;
                AddProjectSchedule_ViewModel._customer = CustomerInfo;
                int check = 2;
                int check1 = 2;
                int check2 = 2;
                //int check3 = 2;
                bool check_ = true;
                bool exist_ = true;
               
                load_edit = true;
                //Sqlexcute.Server = "112.78.2.9";
                //Sqlexcute.pwd = "Fwd@2021";
                //Sqlexcute.UId = "fwd63823_fwdvina";
                Sqlexcute.Check_Table(Sqlexcute.Database, "JobOrder", ref check);
                Sqlexcute.Check_Table(Sqlexcute.Database, Customer_Table.TableName, ref check1);
                Sqlexcute.Check_Table(Sqlexcute.Database, Work_Table.TableName, ref check2);
                Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
                {
                    Editting = true;
                });
                Unload = new RelayCommand<object>((p) => { return true; }, (p) => 
                {
                    Editting = false;
                });
                //if (check1 == 0)
                //{

                //    Add_Customer();
                //    Customer_Table = Sqlexcute.FillToDataTable(CustomerInfo);
                //    Sqlexcute.AutoCreateTable(Customer_Table, Sqlexcute.Database, Customer_Table.TableName, ref check_, ref exist_);
                //    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, Sqlexcute.Database);

                //    Customer_Table = Sqlexcute.FillToDataTable(CustomerInfo);
                //    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, Customer_Table, Sqlexcute.Database, Customer_Table.TableName);
                //}
                //else
                //{
                //    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, Sqlexcute.Database);
                //    CustomerInfo = Sqlexcute.Conver_From_Data_Table_To_List<Customer>(Customer_Table);
                //}
                if (check2 == 0)
                {
                    
                    Add();
                    Work_Table = Sqlexcute.FillToDataTable(WorksList);
                    Sqlexcute.AutoCreateTable(Work_Table, Sqlexcute.Database, Work_Table.TableName, ref check_, ref exist_);
                    Sqlexcute.GetData_FroM_Database(ref Work_Table, Work_Table.TableName, Sqlexcute.Database);
             
                    Work_Table = Sqlexcute.FillToDataTable(WorksList);
                    Sqlexcute.Update_Table_to_Host(Work_Table, Sqlexcute.Database, Work_Table.TableName);

                }
                else
                {
                    Sqlexcute.GetData_FroM_Database(ref Work_Table, Work_Table.TableName, Sqlexcute.Database);
                    WorksList = Sqlexcute.Conver_From_Data_Table_To_List<Works>(Work_Table);

                }

                if (check == 0)
                {
                    Add_Job();
                    JobOrder_Table = Sqlexcute.FillToDataTable(JobOrders);
                    Sqlexcute.AutoCreateTable(JobOrder_Table, Sqlexcute.Database, JobOrder_Table.TableName);
                    PlannerModel.DatatableScheduler = Sqlexcute.FillToDataTable(JobOrders);
                    mySqlDataAdapter = null;

                    Sqlexcute.Update_Table_to_Host(JobOrder_Table, Sqlexcute.Database, "JobOrder");
                }
                else if (check == 1)
                {
                    try
                    {
                        Sqlexcute.GetData_FroM_Database(ref JobOrder_Table, "JobOrder", Sqlexcute.Database,Sqlexcute.getLimitRow(0,500));
                     
                        JobOrders = Sqlexcute.Conver_From_Data_Table_To_List<JobOrder>(JobOrder_Table);
                        PlannerModel._jobOrder = JobOrders;
                        PlannerModel._customerInfo = CustomerInfo;
                        PlannerModel._work = WorksList;
                        SchedulerViewModel._jobOrders = JobOrders;
                        SchedulerViewModel._jobOrders = JobOrders;
                        AddProjectSchedule_ViewModel.jobOrders = JobOrders;
                        AddProjectSchedule_ViewModel._Work_Library = WorksList;
                        AddProjectSchedule_ViewModel._customer = CustomerInfo;
                    }
                    catch (Exception ex )
                    {

                       
                    }

                }
               
                
            }      
            SelectToEditcbbox = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var a = (Customer)p;
                    var b = CustomerInfo.Where(cc => cc.Customer_Info == a.Customer_Info).FirstOrDefault();

                    CustomerSelected = b;
                }
                catch (Exception ex)
                {

                    
                }
               
                
            });
        }
        //public void Save_Table()
        //{
        //    JobOrder_Table = new DataTable();
            
        //    JobOrder_Table = Sqlexcute.FillToDataTable(JobOrders);
          
        //    Sqlexcute.Update_Table_to_Host(JobOrder_Table, "fwd63823_database", JobOrder_Table.TableName);
        //    if (Sqlexcute.error_message != string.Empty)
        //    {
        //        messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
        //    }
        //    else 
        //    {
        //        Sqlexcute.SQL_command(" DELETE S1 FROM " + JobOrder_Table.TableName + " AS S1  INNER JOIN " + JobOrder_Table.TableName + " AS S2 WHERE S1.BarCode = S2.BarCode AND S1.id < S2.id", Sqlexcute.Database);
        //        messageBoxService.ShowMessage("Đã Lưu", "Thông tin", System.Messaging.MessageType.Report);
        //    }
        //}
    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using WPF_TEST.Data;
using MySql.Data.MySqlClient;
using WPF_TEST.Notyfication;

namespace WPF_TEST.ViewModel
{
    public class AddProjectSchedule_ViewModel:BaseViewModel
    {
        #region =================================SingleTon=======================
        private static AddProjectSchedule_ViewModel addProjectSchedule_ViewModel;
        public static AddProjectSchedule_ViewModel _AddProjectSchedule_ViewModel
        {
            get
            {
                if (addProjectSchedule_ViewModel == null)
                {
                    addProjectSchedule_ViewModel = new AddProjectSchedule_ViewModel();
                }
                return addProjectSchedule_ViewModel;
            }
            set
            {
                addProjectSchedule_ViewModel = value;
            }
        }

        #endregion
        DataTable JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
        public static ObservableCollection<JobOrderRuntime> _jobOrderRuntime;
        public ObservableCollection<JobOrderRuntime> JobOrdersRumtimes
        {
            get
            {
                return _jobOrderRuntime;
            }
            set
            {
                SetProperty(ref _jobOrderRuntime, value, nameof(JobOrdersRumtimes));
            }
        }
        private Customer _singleCustomer;
        public Customer SingleCustomer 
        {
            get { return _singleCustomer; }
            set { SetProperty(ref _singleCustomer, value, nameof(SingleCustomer)); }
        }
        public static ObservableCollection<Customer> _customer;
        public ObservableCollection<Customer> CustomerInfor
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value, nameof(Customer_Infor)); }
        }
        private ObservableCollection<ConvertoJson> convertoJson;
        public ObservableCollection<ConvertoJson> ToJson
        {
            get { return convertoJson; }
            set { SetProperty(ref convertoJson, value, nameof(ToJson)); }
        }

        public static ObservableCollection<JobOrder> jobOrders;
        public ObservableCollection<JobOrder> JobOrders 
        {
            get { return jobOrders; }
            set { SetProperty(ref jobOrders, value, nameof(JobOrders)); }
        }
        public static ObservableCollection<Works> _Work_Library;
        public ObservableCollection<Works> Work_Library 
        {
            get { return _Work_Library; }
            set { SetProperty(ref _Work_Library, value, nameof(Work_Library)); }
        }
        private TaskPriority _taskPriority;
        public TaskPriority TaskPriority 
        {
            get
            {
                if (_taskPriority != null) 
                {
                    return _taskPriority;
                }
                else 
                {
                    return TaskPriority.Normal;
                }
                
            }
            set { SetProperty(ref _taskPriority, value, nameof(TaskPriority)); }
        }
     
        private string _customer_Infor;
        public string Customer_Infor
        {
            get { return _customer_Infor; }
            set { SetProperty(ref _customer_Infor, value, nameof(Customer_Infor)); }
        }
        private string _saleorder;
        public string SaleOrder 
        {
            get { return _saleorder; }
            set { SetProperty(ref _saleorder, value, nameof(SaleOrder)); }
        }
        private string customer;
        public string CustomerName
        {

            get { return customer; }
            set { SetProperty(ref customer, value, nameof(CustomerName)); }
        }
        private DateTime _reportdate;
        public DateTime Report_Date 
        {
            get { return _reportdate; }
            set { SetProperty(ref _reportdate, value, nameof(Report_Date)); }
        }
        private DateTime _request_Start;
        public DateTime Request_Start 
        {
            get { return _request_Start; }
            set { SetProperty(ref _request_Start, value, nameof(Request_Start)); }
        }
        private TimeSpan start;
        public TimeSpan Request_time_start
        {
            get { return start; }
            set 
            {
                SetProperty(ref start, value, nameof(Request_time_start));
            }
        }


        private DateTime _request_end;
        public DateTime Request_End
        {
            get { return _request_end; }
            set { SetProperty(ref _request_end, value, nameof(Request_End)); }
        }

        private TimeSpan _end;
        public TimeSpan Request_time_end
        {
            get { return start; }
            set
            {
                SetProperty(ref _end, value, nameof(Request_time_end));
            }
        }
        private string _customerPO;
        public string Customer_PO
        {
            get { return _customerPO; }

            set { SetProperty(ref _customerPO, value, nameof(Customer_PO)); }
        }
        private string _quotation;
        public string Quotation 
        {
            get { return _quotation; }
            set { SetProperty(ref _quotation, value, nameof(Quotation)); }
        }
        private ObservableCollection<Works> _work;
        public ObservableCollection<Works> WorksList 
        {

            get { return _work; }
            set { SetProperty(ref _work, value, nameof(WorksList)); }
        }
        private int _quantity;
        public int Quantity 
        {
            get 
            {
                return _quantity;
            }
            set 
            {
                SetProperty(ref _quantity, value, nameof(Quantity));
            }
        }
        private Works _selectedwork;
        public Works Selected_Work 
        {
            get 
            {
                return _selectedwork;
            }
            set
            {
                SetProperty(ref _selectedwork, value, nameof(Selected_Work));
            }
        }
        private string _id;
        public string ID_Barcode 
        {
            get { return _id; }
            set { SetProperty(ref _id, value, nameof(ID_Barcode)); }
        }
        public ICommand AddJob
        { get; set; }
        public ICommand AddrangeWork { get; set; }

        public ICommand ChooseCustomer { get; set; }

        public ICommand AddSelectjob { get; set; }
        public ICommand UndoSelect { get; set; }
        public ICommand selectpriority { get; set; }
        public ICommand SelectedWork { get; set; }
        public ICommand Get_BarCode { get; set; }


        static bool Loaed = false;


        private MySqlDataAdapter mySqlDataAdapter;
        Sqlexcute Sqlexcute = new Sqlexcute();
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        public AddProjectSchedule_ViewModel() 
        {
            if (!Loaed) 
            {
                Loaed = true;
                
            }
            Get_BarCode = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    if (p != null) 
                    {
                        ID_Barcode = p.ToString();
                    }
                    
                }
                catch (Exception ex)
                {

                  
                }
                
            });
            SelectedWork = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    Selected_Work = (Works)p;
                }
                catch (Exception ex)
                {

                   
                }
            });
            AddSelectjob = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
               
                try
                {
                    var ss = Work_Library.Where(m => m.Selected == true).ToList();
                    WorksList = new ObservableCollection<Works>();
                    for (int i = 0; i < ss.Count; i++)
                    {
                        WorksList.Add(ss.ElementAt(i));
                    }
                }
                catch (Exception)
                {

                   
                }
               

            });

            selectpriority = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    
                    string bb = p.ToString();
                    switch (bb) 
                    {
                        case "High":
                            TaskPriority = TaskPriority.High;
                            break;
                        case "Urgent":
                            TaskPriority = TaskPriority.Urgent;
                            break;
                        case "Low":
                            TaskPriority = TaskPriority.Low;
                            break;
                        case "Normal":
                            TaskPriority = TaskPriority.Normal;
                            break;

                    }
                }
                catch (Exception)
                {

                  
                }
            });
            UndoSelect = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (WorksList.Count != 0) 
                {
                    WorksList.Clear();
                    foreach (var item in Work_Library)
                    {
                        if (item.Selected) item.Selected = false;
                    }
                    
                }
                
            });
            AddrangeWork = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
               
            });
            AddJob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Random random = new Random();
                JobOrder jobOrder = new JobOrder();
                jobOrder.ID = random.Next(111111, 999999);
                jobOrder.ActualvsPlan = 0;
                jobOrder.Complete = 0;
                jobOrder.Stage = Status.Plan;
                jobOrder.Current_Stage = PlannerModel.getColor(jobOrder.Stage);
                jobOrder.SaleOrder = SaleOrder;
                jobOrder.Priority = TaskPriority;
                jobOrder.Requested_End = Request_End;
                jobOrder.Request_end_Time = Request_time_end;

                jobOrder.Requested_Start = Request_Start;
                jobOrder.Request_start_Time = Request_time_start;
                jobOrder.Requested_Report_Date = DateTime.Now;
                jobOrder.Quotation = Quotation;
                jobOrder.Customerinformation = SingleCustomer;
                
                jobOrder.Customer_PO = Customer_PO;
                jobOrder.Works = new ObservableCollection<Works>();
                foreach (var item in WorksList)
                {
                    
                    jobOrder.Works.Add(item);
                }

                JobOrders.Add(jobOrder);
                try
                {
                    JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
                    JobOrdersRumtimes = PlannerModel._jobOrderRuntime;
                    JobOrdersRumtimes.Add(new JobOrderRuntime
                    {
                        CurrentStage = jobOrder.Stage,
                        ActualvsLife = jobOrder.ActualvsPlan,
                        OrderName = jobOrder.SaleOrder,
                        PercentComplete = jobOrder.Complete


                    });
                }
                catch (Exception ex )
                {

                    
                }
               
                JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName);
                Save_Table();
                foreach (var item in Work_Library)
                {
                    item.Selected = false;
                }
                WorksList.Clear();
                SchedulerViewModel schedulerViewModel = SchedulerViewModel._SchedulerViewModel;
                schedulerViewModel.SaveAddjob.CanExecute(null);
                schedulerViewModel.SaveAddjob.Execute(null);
              
            });
            ChooseCustomer = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var a = (Customer)p;
                    SingleCustomer = a;
                    Customer_Infor = a.Customer_Details;
                }
                catch (Exception ex)
                {

                   
                }
              
            });
        }
        public void CompareBarCode(string barcode) 
        {
        
            
        }
        public void Save_Table()
        {

            PlannerModel.DatatableScheduler = new DataTable("JobOrder");
            var Json = JsonSerializer.Serialize(JobOrders);
            try
            {
                ToJson = new ObservableCollection<ConvertoJson>();
                ToJson.Add(new ConvertoJson { Code = Json });
            }
            catch (Exception)
            {

                ToJson = new ObservableCollection<ConvertoJson>();
                ToJson.Add(new ConvertoJson { Code = Json });
            }



            PlannerModel.DatatableScheduler = Sqlexcute.FillToDataTable(ToJson);

            if (ToJson.ElementAt(0).Code != "") 
            {
                Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, PlannerModel.DatatableScheduler, Sqlexcute.Database, "JobOrder");
                if (Sqlexcute.error_message != string.Empty)
                {
                    messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
                }
                else
                {
                    messageBoxService.ShowMessage("Đã Lưu", "Thông tin", System.Messaging.MessageType.Report);
                }

            }

        }
    }
}

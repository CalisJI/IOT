using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.Native;
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WPF_TEST.Class_Resource;
using System.Data.Entity;
using System.Threading;
using System.Windows.Threading;
using System.Data;
using MySql.Data.MySqlClient;
using WPF_TEST.Data;
using System.Windows.Input;
using WPF_TEST.Notyfication;
using System.Text.Json;
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    static class PlannerHelper 
    {
        public const string ImagePath = "pack://application:,,,/WPF_TEST;component/ImageSource/";
        //public const string ImagePath = @"F:\VISUAL PROJECT\C#\WPF\WPF_TEST\ImageSource\";
    }
    
    public class PlannerModel:BaseViewModel
    {
        //public IEnumerable<TaskPriority> myPriority
        //{
        //    get { return Enum.GetValues(typeof(TaskPriority)).Cast<TaskPriority>(); }

        //}
        //savedataEntities savedataEntities = new savedataEntities();
        //Sqlexcute Sqlexcute = new Sqlexcute();
        //public static DataTable JobOrder_Table = new DataTable("Job Information");
        //public static DataTable Customer_Table = new DataTable("Customer_Details");
        //public static DataTable Work_Table = new DataTable("Work Information");

        private static PlannerModel _insPlanModel;
        public static PlannerModel INS_PlanViewModel 
        {
            get 
            {
                if (_insPlanModel != null) 
                {
                    return _insPlanModel;
                }
                else 
                {
                    return new PlannerModel();
                }
            }
            set 
            {
                _insPlanModel = value;
            }
        }

        #region =================================Data Table ================================
        DataTable JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
        #endregion

        #region                                 Command                         
        public static ICommand Save_EditJob { get; set; }
        public static ICommand Manager_Plan { get; set; }
        public static ICommand StopMultiThread { get; set; }
        public static ICommand RunMultiThread { get; set; }
        public static ICommand DeleteJob { get; set; }
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public ICommand Select_To_Changed { get; set; }
        #endregion

        #region ==============================Timer======================
        
        #endregion
        private ObservableCollection<ConvertoJson> convertoJson;
        public ObservableCollection<ConvertoJson> ToJson 
        {
            get { return convertoJson; }
            set { SetProperty(ref convertoJson, value, nameof(ToJson)); }
        }

        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();

        public static DataTable DatatableScheduler = new DataTable("Job Information");
        private static DispatcherTimer DispatcherTimer;
        //public static DispatcherTimer DispatcherTimer 
        //{
        //    get 
        //    {
        //        if (_dispatcherTimer == null) 
        //        {
        //            _dispatcherTimer = new DispatcherTimer();
        //        }
        //        return _dispatcherTimer;

        //    }
        //    set 
        //    {
        //        _dispatcherTimer = value;
        //    }
        //}
        public EditJobModel EditJobModel { get; set; }
        //public  ObservableCollection<processdata> Resource { get; set; }
        //public  ObservableCollection<proessdataappointment> Appointments { get; set; }
        public ObservableCollection<ImageSource> Images { get; set; }

        public static bool PauseMultiThread = false;

        public static ObservableCollection<Works> _work;
        public  ObservableCollection<Works> WorksList { get { return _work; } set { SetProperty(ref _work, value, nameof(WorksList)); } }
        public static ObservableCollection<Customer> _customerInfo;
        public  ObservableCollection<Customer> CustomerInfo { get { return _customerInfo; } set { SetProperty(ref _customerInfo, value, nameof(CustomerInfo)); } }

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

        public static ObservableCollection<JobOrder> _jobOrder;
        public  ObservableCollection<JobOrder> JobOrders
        {
            get
            {
                return _jobOrder;
            }
            set
            {
               SetProperty(ref _jobOrder, value, nameof(JobOrders));
                //OnPropertyChanged(nameof(JobOrders));
            }
        }
        public static JobOrder ItemSelected;
        //public JobOrder ItemSelected 
        //{
        //    get 
        //    {
        //        return _select;
        //    }
        //    set 
        //    {
        //        SetProperty(ref _select, value, nameof(ItemSelected));
        //    }
        //}
        private static ObservableCollection<PlanConfiguration> collection;
        public ObservableCollection<PlanConfiguration> PlanConfig 
        {
            get 
            {
                return collection;
            }
            set 
            {
                SetProperty(ref collection, value, nameof(PlanConfig));
            }
        }
        private static int running;
        private static int queued;
        private static int done;
        private static int delayed;
        private static int plan;
        private static int paused;
        private static int ready;
        private PlannerTask _plannerTask;
        public PlannerTask PlannerTask 
        {
            get 
            {
                return _plannerTask;
            }
            set 
            {
                _plannerTask = value;
                OnPropertyChanged("PlannerTask");
            }
        }
        public int Runnings 
        {
            get 
            { 
                return running; 
            }
            set 
            {
                SetProperty(ref running, value, nameof(Runnings));
            } 
        }
        public int Delayeds { get { return delayed; } set { SetProperty(ref delayed, value, nameof(Delayeds)); } }
        public int Plans { get { return plan; } set { SetProperty(ref plan, value, nameof(Plans)); } }
        public int Queueds { get { return queued; } set { SetProperty(ref queued, value, nameof(Queueds)); } }
        public int Dones { get { return done; } set { SetProperty(ref done, value, nameof(Dones)); } }
        public int Readys { get { return ready; } set { SetProperty(ref ready, value, nameof(Readys)); } }
        public int Pauseds { get { return paused; } set { SetProperty(ref paused, value, nameof(Pauseds)); } }

        public TaskPriority taskPriority;
        public Status status;
        public Status Status { get { return status; } set { SetProperty(ref status, value, "Status"); } }
        public TaskPriority TaskPriority
        {
            get
            {
                if (taskPriority != null) 
                {
                    return taskPriority;
                }
                else 
                {
                    return TaskPriority.Urgent;
                }
                
            } 
            set { SetProperty(ref taskPriority, value, "TaskPriority"); } }


        public static BackgroundWorker Runtime = new BackgroundWorker();


        public static bool load = false;
        //public ObservableCollection<PlannerTask> AssignedTask { get; set; }
        Sqlexcute Sqlexcute = new Sqlexcute();
        private MySqlDataAdapter mySqlDataAdapter;
        private void Initial() 
        {
            JobOrder jobOrder = new JobOrder();
            JobOrders.Add(jobOrder);
        }

        // thêm runrime thủ công
        public void adruntime()
        {
            JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
            foreach (var item in JobOrders)
            {
                JobOrderRuntime jobOrderRuntime = new JobOrderRuntime();
                jobOrderRuntime.BarCode = item.BarCode;
                jobOrderRuntime.OrderName = item.SaleOrder;
                jobOrderRuntime.ActualvsLife = item.ActualvsPlan;
                jobOrderRuntime.CurrentStage = item.Stage;
                jobOrderRuntime.PercentComplete = item.Complete;

                //if (JobOrdersRumtimes == null) JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
                JobOrdersRumtimes.Add(jobOrderRuntime);
            }

        }
        public ObservableCollection<JobOrderRuntime> FilterRuntime() 
        {

            ObservableCollection<JobOrderRuntime> runtime = new ObservableCollection<JobOrderRuntime>();
            DataTable dataTable = new DataTable();
            int a = Convert.ToInt32(Status.Running);
            int b = Convert.ToInt32(Status.Delayed);
            int c = Convert.ToInt32(Status.Paused);
            int d = Convert.ToInt32(Status.Ready);
            int e = Convert.ToInt32(Status.Queued);
            int f = Convert.ToInt32(Status.Done);
            List<string> list = JobOrders.Select(x => x.BarCode).ToList();
            string cmd = string.Empty;

            foreach (var item in list)
            {
                cmd += "or BarCode = '" + item + "' ";
            }
            cmd = cmd.Substring(3, cmd.Length -3);
            dataTable = Sqlexcute.Read_Table_Group(
                "SELECT * FROM JobOrderRuntime where (" +
                "CurrentStage = " + a.ToString() + " " +
                "or CurrentStage = " + b.ToString() + " " +
                "or CurrentStage = " + c.ToString() + " " +
                "or CurrentStage = " + d.ToString() + " " +
                "or CurrentStage = " + e.ToString() + " " +
                "or CurrentStage = " + f.ToString() + ") and (" + cmd + ")");
            runtime = Sqlexcute.Conver_From_Data_Table_To_List<JobOrderRuntime>(dataTable);
            if (Sqlexcute.error_message != string.Empty) 
            {
                messageBoxService.ShowMessage(Sqlexcute.error_message, "Lỗi", System.Windows.MessageBoxImage.Error);
            }
            return runtime;


        }
        //Cập nhật giá trị runtime
        public void updateruntime()
        {
            try
            {
                //JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
                PlanNotification();

                JobOrdersRumtimes = FilterRuntime();
                //mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrderRuntime_Table, JobOrderRuntime_Table.TableName, Sqlexcute.Database);
                //JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
                //JobOrdersRumtimes = Sqlexcute.Conver_From_Data_Table_To_List<JobOrderRuntime>(JobOrderRuntime_Table);
                //if (JobOrdersRumtimes.Count != JobOrders.Count)
                //{

                //    adruntime();
                //    JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
                //    JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                //    Sqlexcute.Update_Table_to_Host(JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName);
                //}
                //else
                //{
                //    foreach (var item in JobOrdersRumtimes)
                //    {
                //        var ss = JobOrders.FirstOrDefault(i => i.BarCode == item.BarCode);
                //        if (ss != null)
                //        {
                //            if (ss.Complete != item.PercentComplete || ss.ActualvsPlan != item.ActualvsLife || ss.Stage != item.CurrentStage) 
                //            {
                //                ss.Complete = item.PercentComplete;
                //                ss.ActualvsPlan = item.ActualvsLife;
                //                ss.Stage = item.CurrentStage;
                //                ss.Current_Stage = getColor(item.CurrentStage);
                //                _ = Sqlexcute.SQL_command("UPDATE `JobOrder` SET `ActualvsPlan` = '" + ss.ActualvsPlan.ToString() + "', `Complete` = '" + ss.Complete.ToString() + "', `Stage` = '" + ss.Stage.ToString() + "' WHERE (`BarCode` = '" + ss.BarCode + "')", Sqlexcute.Database);
                //            }
                          
                //        }

                //    }
                //}
                foreach (var item in JobOrdersRumtimes)
                {
                    var ss = JobOrders.FirstOrDefault(i => i.BarCode == item.BarCode);
                    if (ss != null)
                    {
                        if (ss.Complete != item.PercentComplete || ss.ActualvsPlan != item.ActualvsLife || ss.Stage != item.CurrentStage || ss.Current_Stage != getColor(item.CurrentStage)) 
                        {
                            ss.Complete = item.PercentComplete;
                            ss.ActualvsPlan = item.ActualvsLife;
                            ss.Stage = item.CurrentStage;
                            ss.Current_Stage = getColor(item.CurrentStage);
                            _ = Sqlexcute.SQL_command("UPDATE `JobOrder` SET `ActualvsPlan` = '" + ss.ActualvsPlan.ToString() + "', `Complete` = '" + ss.Complete.ToString() + "', `Stage` = '" + Convert.ToInt32(ss.Stage).ToString() + "', `Current_Stage` = '" + getColor(ss.Stage) + "' WHERE (`BarCode` = '" + ss.BarCode + "')", Sqlexcute.Database);
                        }

                    }

                }



                //DatatableScheduler = new DataTable("JobOrder");

                ////var Json = JsonSerializer.Serialize(JobOrders);
                ////ToJson = new ObservableCollection<ConvertoJson>();
                ////ToJson.Add(new ConvertoJson { Code = Json });
                //DatatableScheduler = Sqlexcute.FillToDataTable(JobOrders);
                //if (JobOrders.Count > 0)
                //{
                //    Sqlexcute.Update_Table_to_Host(DatatableScheduler, "fwd63823_database", "JobOrder");
                //}

            }
            catch (Exception ex)
            {

               
            }
           
        }
        Thread Thread1 = null;
        public PlannerModel() 
        {
            AddProjectSchedule_ViewModel._jobOrderRuntime = JobOrdersRumtimes;
            DispatcherTimer = new DispatcherTimer();
            DispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            DispatcherTimer.Tick += DispatcherTimer_Tick;
            if (!DispatcherTimer.IsEnabled)
            {
                //DispatcherTimer.IsEnabled = true;
                //DispatcherTimer.Start();
            }
            if (!load) 
            {
                Runtime.DoWork += Runtime_DoWork;
                Runtime.RunWorkerCompleted += Runtime_RunWorkerCompleted;
                Runtime.WorkerSupportsCancellation = true;
                //JobOrders = new ObservableCollection<JobOrder>();
                ////PlannerModel.JobOrders = new ObservableCollection<JobOrder>();
                //CustomerInfo = new ObservableCollection<Customer>();
                //WorksList = new ObservableCollection<Works>();
                JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
                Thread1 = new Thread(updatedata);
                Thread1.IsBackground = true;
                int check = 2;
                bool check_ = true;
                bool exist_ = true;
                ToJson = new ObservableCollection<ConvertoJson>();
                load = true;
             
                AddProjectSchedule_ViewModel.jobOrders = JobOrders;
                #region Comment


                //Sqlexcute.Check_Table(Sqlexcute.Database, JobOrderRuntime_Table.TableName, ref check);
                //Sqlexcute.Check_Table("fwd63823_database", DatatableScheduler.TableName, ref check);
                //if (check == 0)
                //{
                //    //Initial();
                //    //DatatableScheduler = Sqlexcute.FillToDataTable(JobOrders);

                //    //Sqlexcute.AutoCreateTable(DatatableScheduler, Sqlexcute.Database, DatatableScheduler.TableName, ref check_, ref exist_);
                //    //mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref DatatableScheduler, DatatableScheduler.TableName, Sqlexcute.Database);
                //    ////AddVideo();
                //    //DatatableScheduler = Sqlexcute.FillToDataTable(JobOrders);
                //    //Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, DatatableScheduler, Sqlexcute.Database, DatatableScheduler.TableName);
                //}
                //else
                //{
                //    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref DatatableScheduler, DatatableScheduler.TableName, Sqlexcute.Database);
                //    JobOrders = Sqlexcute.Conver_From_Data_Table_To_List<JobOrder>(DatatableScheduler);
                //}

                //if (check == 0)
                //{
                //    try
                //    {
                //        adruntime();
                //        JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                //        Sqlexcute.AutoCreateTable(JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName, ref check_, ref exist_);
                //        mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrderRuntime_Table, JobOrderRuntime_Table.TableName, Sqlexcute.Database);

                //        JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                //        Sqlexcute.Update_Table_to_Host(JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName);
                //    }
                //    catch (Exception)
                //    {


                //    }

                //}
                //else if (check == 1)
                //{
                //    try
                //    {
                //        mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrderRuntime_Table, JobOrderRuntime_Table.TableName, Sqlexcute.Database);
                //        JobOrdersRumtimes = Sqlexcute.Conver_From_Data_Table_To_List<JobOrderRuntime>(JobOrderRuntime_Table);

                //        if (JobOrdersRumtimes.Count != JobOrders.Count)
                //        {
                //            JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();

                //            adruntime();
                //        }
                //        else
                //        {
                //            foreach (var item in JobOrders)
                //            {
                //                var ss = JobOrdersRumtimes.Where(i => i.BarCode == item.BarCode).FirstOrDefault();
                //                ss.ActualvsLife = item.ActualvsPlan;
                //                ss.CurrentStage = item.Stage;
                //                ss.PercentComplete = item.Complete;
                //                ss.OrderName = item.SaleOrder;

                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {

                //        string aaa = ex.Message;
                //    }


                //}
                //var c = JobOrders;
                #endregion
                var a = GetStage();
                Readys = a.Item1;
                Dones = a.Item2;
                Runnings = a.Item3;
                Delayeds = a.Item4;
                Pauseds = a.Item5;
                Plans = a.Item6;
                Queueds = a.Item7;
            }
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (!DispatcherTimer.IsEnabled) 
                {
                    DispatcherTimer.IsEnabled = true;
                    DispatcherTimer.Start();
                }
            });
            Unloaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (DispatcherTimer.IsEnabled) 
                {
                    DispatcherTimer.Stop();
                    DispatcherTimer.IsEnabled = false;
                }
            });
            Save_EditJob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Thread thread = new Thread(() => 
                {
                    update_row();
                    //Save_Table();
                });thread.Start();
                
            });
            Manager_Plan = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //PlanTimer.Tick += PlanTimer_Tick;
                //PlanTimer.Interval = new TimeSpan(0, 0, 10);
                //if (!PlanTimer.IsEnabled)
                //{
                //    PlanTimer.Start();
                //}
            });
            StopMultiThread = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                PauseMultiThread = true;
            });
            RunMultiThread = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                PauseMultiThread = false;
            });
            DeleteJob = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    ItemSelected = (JobOrder)p;
                   
                    Deleted_Row_Table();
                    _ = JobOrders.Remove(ItemSelected);
                    
                }
                catch (Exception)
                {

                   
                }
                
            });
            

            //Initialize();

        }

       

        
        DateTime Ground_timer = DateTime.Now;


        #region                 Timer TIck              
        private void PlanTimer_Tick(object sender, EventArgs e)
        {
            
            
        }
        #endregion
        private void Runtime_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
        }

        private void Runtime_DoWork(object sender, DoWorkEventArgs e)
        {
            updatedata();
        }

        private void updatedata() 
        {
            //GetStage(ref Readys, ref done, ref running, ref delayed, ref paused, ref plan, ref queued);
            var a = GetStage();
            Readys = a.Item1;
            Dones = a.Item2;
            Runnings = a.Item3;
            Delayeds = a.Item4;
            Pauseds = a.Item5;
            Plans = a.Item6;
            Queueds = a.Item7;
            updateruntime();    
        }
        
        public void update_row() 
        {
            _ = Sqlexcute.SQL_command("UPDATE `JobOrder` SET `SaleOrder` = '" + ItemSelected.SaleOrder + "', `Quotation` = '" + ItemSelected.Quotation + "', `Customer_PO` = '" + ItemSelected.Customer_PO + "', `Requested_Start` = '" + ItemSelected.Requested_Start.ToString("yyyy-MM-dd HH:mm:ss") + "', `Request_start_Time` = '" + ItemSelected.Request_start_Time.ToString() + "', `Requested_End` = '" + ItemSelected.Requested_End.ToString("yyyy-MM-dd HH:mm:ss") + "', `Request_end_Time` = '" + ItemSelected.Request_end_Time.ToString() + "', `Requested_Report_Date` = '" + ItemSelected.Requested_Report_Date.ToString("yyyy-MM-dd HH:mm:ss") + "', `Priority` = '" + Convert.ToInt32(ItemSelected.Priority).ToString() + "', `ProductCode` = '" + ItemSelected.ProductCode.ToString() + "', `Product` = '" + ItemSelected.Product.ToString() + "', `Quantity` = '" + ItemSelected.Quantity.ToString() + "'  WHERE (`BarCode` = '" + ItemSelected.BarCode + "')", Sqlexcute.Database);
            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            else
            {
                messageBoxService.ShowMessage("Đã Lưu", "Thông tin", System.Messaging.MessageType.Report);
            }
        }

        public void Deleted_Row_Table()
        {
            try
            {
                Sqlexcute.SQL_command("DELETE FROM `JobOrder` WHERE (`BarCode` = '" + ItemSelected.BarCode.ToString() + "')", Sqlexcute.Database);
                Sqlexcute.SQL_command("DELETE FROM `JobOrderRuntime` WHERE (`BarCode` = '" + ItemSelected.BarCode.ToString() + "')", Sqlexcute.Database);
                if (Sqlexcute.error_message != string.Empty)
                {
                    messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
                }
                else
                {
                    messageBoxService.ShowMessage("Đã Xóa", "Thông tin", System.Messaging.MessageType.Report);
                }
            }
            catch (Exception)
            {
                messageBoxService.ShowMessage("Không có danh mục được ch", "Thông tin", System.Messaging.MessageType.Report);

            }

            //DatatableScheduler = new DataTable();
            ////var Json = JsonSerializer.Serialize(JobOrders);
            ////try
            ////{
            ////    ToJson = new ObservableCollection<ConvertoJson>();
            ////    ToJson.Add(new ConvertoJson { Code = Json });
            ////}
            ////catch (Exception)
            ////{

            ////    ToJson = new ObservableCollection<ConvertoJson>();
            ////    ToJson.Add(new ConvertoJson { Code = Json });
            ////}



            //DatatableScheduler = Sqlexcute.FillToDataTable(JobOrders);

            //Sqlexcute.Update_Table_to_Host(DatatableScheduler, Sqlexcute.Database, "JobOrder");


        }
        public void PlanNotification() 
        {
            try
            {
                if (PauseMultiThread)
                {
                    return;
                }

                DateTime dateTime = DateTime.Now;
                TimeSpan timeSpan = dateTime - Ground_timer;
                int dd = (int)timeSpan.TotalSeconds;
                if (dd >= 5)
                {
                    //Ground_timer = dateTime;
                    //string aa = dateTime.ToString("HH:mm:ss");
                    //Sqlexcute.SQL_command("UPDATE Message SET `MSG` = '" + aa + "' WHERE (`ID` = '1')", Sqlexcute.Database);
                    if (EditJobModel.Editting) return;
                    DataTable dataTable = Sqlexcute.Read_data(Sqlexcute.Database, "Message");
                    if (dataTable != null)
                    {
                        List<string> Status = new List<string>();
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string a = dataTable.Rows[i][1].ToString();
                            Status.Add(a);
                        }
                        //string msg = dataTable.Rows[0][1].ToString();
                        //string msgread = dataTable.Rows[1][1].ToString();
                        //string msgPause = dataTable.Rows[2][1].ToString();
                        //Đơn hàng đến ngày thực hiện (Trạng thái Plan)

                        // trường hợp lên lịch bình thường không có chen ngang
                        List<JobOrder> Sametype = JobOrders.Where(x => x.Requested_Start.Date == dateTime.Date && x.Stage == ViewModel.Status.Plan).ToList();

                        if (Sametype != null && Sametype.Count > 0)
                        {
                            List<JobOrder> HighPriority = Sametype.Where(x => x.Priority == TaskPriority.Urgent).ToList();
                            if (HighPriority != null && HighPriority.Count > 0)
                            {
                                for (int i = 0; i < PlanConfig.Count; i++)
                                {
                                    for (int j = 0; j < HighPriority.Count; j++)
                                    {

                                        string[] code = PlanConfig[i].BarCodes.Split(',');
                                        for (int t = 0; t < code.Length; t++)
                                        {
                                            if (HighPriority[j].BarCode.Contains(code[t]))
                                            {
                                                if (Status[i] == "")
                                                {
                                                    Status[i] = HighPriority[j].BarCode;
                                                    _ = Sqlexcute.SQL_command("UPDATE Message SET `MSG` = '" + Status[i] + "' WHERE (`ID` = '" + (i + 1).ToString() + "')", Sqlexcute.Database);
                                                }
                                                else if (!Status[i].Contains(HighPriority[j].BarCode))
                                                {
                                                    Status[i] = HighPriority[j].BarCode + "-" + Status[i];
                                                    _ = Sqlexcute.SQL_command("UPDATE Message SET `MSG` = '" + Status[i] + "' WHERE (`ID` = '" + (i + 1).ToString() + "')", Sqlexcute.Database);
                                                }
                                                else
                                                { }


                                                //goto FOUND1;
                                            }
                                        }
                                    }
                                    //FOUND1:;
                                }
                                foreach (var item in HighPriority)
                                {
                                    item.Stage = ViewModel.Status.Queued;
                                    item.Current_Stage = getColor(ViewModel.Status.Queued);
                                    _ = Sqlexcute.SQL_command("UPDATE `JobOrder` SET `Current_Stage` = '" + getColor(item.Stage) + "' WHERE (`id` = '" + item.BarCode + "');", Sqlexcute.Database);
                                    _ = Sametype.Remove(item);
                                }

                            }
                            for (int i = 0; i < Sametype.Count; i++)
                            {
                                for (int j = 0; j < PlanConfig.Count; j++)
                                {
                                    string[] code = PlanConfig[j].BarCodes.Split(',');
                                    for (int t = 0; t < code.Length; t++)
                                    {
                                        if (Sametype[i].BarCode.Contains(code[t]))
                                        {
                                            if (Status[j] == "")
                                            {
                                                Status[j] += Sametype[i].BarCode;
                                                _ = Sqlexcute.SQL_command("UPDATE Message SET `MSG` = '" + Status[j] + "' WHERE (`ID` = '" + (j + 1).ToString() + "')", Sqlexcute.Database);
                                                goto FOUND2;
                                            }
                                            else if (!Status[j].Contains(Sametype[i].BarCode))
                                            {
                                                Status[j] += "-" + Sametype[i].BarCode;
                                                _ = Sqlexcute.SQL_command("UPDATE Message SET `MSG` = '" + Status[j] + "' WHERE (`ID` = '" + (j + 1).ToString() + "')", Sqlexcute.Database);
                                                goto FOUND2;
                                            }


                                        }
                                    }
                                }
                            FOUND2:;
                            }

                            foreach (JobOrder item in Sametype)
                            {
                                item.Stage = ViewModel.Status.Queued;
                                item.Current_Stage = getColor(item.Stage);
                                _ = Sqlexcute.SQL_command("UPDATE `JobOrder` SET `Current_Stage` = '" + item.Current_Stage + "' WHERE (`id` = '" + item.BarCode + "');", Sqlexcute.Database);
                            }
                        }


                        // Trường hợp có đơn hàng uuw tiên được thêm vào




                    }


                }
            }
            catch (Exception)
            {


            }
        }
        public void Save_Table_Thread()
        {

            DatatableScheduler = new DataTable();
            DatatableScheduler = Sqlexcute.FillToDataTable(JobOrders);

            Sqlexcute.Update_Table_to_Host(DatatableScheduler, Sqlexcute.Database, "JobOrder");
            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
        }
        
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(MainScreenView.Main_quit) 
            {
                DispatcherTimer.Stop();
                DispatcherTimer.IsEnabled = false;
            }
            else 
            {
                if (PauseMultiThread) return;
                if (PlannerView.timerStage) 
                {
                    try
                    {

                        ////Dispatcher.CurrentDispatcher.BeginInvoke(new Action(delegate 
                        ////{

                        ////    updatedata();
                        ////}));
                        //Thread thread = new Thread(() =>
                        //{
                        //    updatedata();
                        //}); thread.Start();
                        //thread.IsBackground = true;
                        if (!Runtime.IsBusy) 
                        {
                            Runtime.RunWorkerAsync();
                        }

                    }
                    catch (Exception)
                    {


                    }
                }

     
            }
            
        }
        public static string getColor(Status status) 
        {
            
            switch (status) 
            {
                case Status.Plan:
                    return " - Plan";
                case Status.Ready:
                    return " - Ready";
                case Status.Running:
                    return " - Running";
                case Status.Delayed:
                    return " - Delayed";
                case Status.Done:
                    return " - Done";
                case Status.Paused:
                    return " - Paused";
                case Status.Queued:
                    return " - Queued";
            }
            return "";
        }
        
        int GetPlan(Status status, ref int count)
        {

            switch (status)
            {
                case Status.Plan:
                    count++;
                    break;

            }
            return count;
        }
        int GetRunning(Status status,ref int count)
        {
            
            switch (status)
            {
                case Status.Running:
                    count++;
                    break;

            }
            return count;
        }
        int GetDelayed(Status status, ref int count)
        {

            switch (status)
            {
                case Status.Delayed:
                    count++;
                    break;

            }
            return count;
        }
        int GetDone(Status status, ref int count)
        {

            switch (status)
            {
                case Status.Done:
                    count++;
                    break;

            }
            return count;
        }
        int GetPaused(Status status, ref int count)
        {

            switch (status)
            {
                case Status.Paused:
                    count++;
                    break;

            }
            return count;
        }
        int GetReady(Status status, ref int count)
        {

            switch (status)
            {
                case Status.Ready:
                    count++;
                    break;

            }
            return count;
        }
        int GetQueued(Status status, ref int count)
        {

            switch (status)
            {
                case Status.Queued:
                    count++;
                    break;

            }
            return count;
        }
         (int,int,int,int,int,int,int) GetStage() 
        {
            int _Ready;
            int _Done;
            int _Running;
            int _Delayed;
            int _Paused;
            int _Plan;
            int _Queued;
            _Ready = JobOrders.Where(i => i.Stage == Status.Ready).Count();
            _Done = JobOrders.Where(i => i.Stage == Status.Done).Count();
            _Running = JobOrders.Where(i => i.Stage == Status.Running).Count();
            _Delayed = JobOrders.Where(i => i.Stage == Status.Delayed).Count();
            _Paused = JobOrders.Where(i => i.Stage == Status.Paused).Count();
            _Plan = JobOrders.Where(i => i.Stage == Status.Plan).Count();
            _Queued = JobOrders.Where(i => i.Stage == Status.Queued).Count();

            return (_Ready, _Done, _Running, _Delayed, _Paused, _Plan, _Queued);
        }

    }
   
    public class PlannerTask 
    {
        public float Completion { get; set; }     
        public string  Current_Stage { get; set; }
        public TaskPriority Priority { get; set; }
        public Status Status { get; set; }    
        public float Actual_vs_Liftime { get; set; }
     
    }
    public enum TaskPriority
    {
        
        [Image(PlannerHelper.ImagePath + "Low.png")]
        Low,
        [Image(PlannerHelper.ImagePath + "Normal.png")]
        //[Image(PlannerHelper.ImagePath + "High.png")]
        Normal,
        [Image(PlannerHelper.ImagePath + "Medium.png")]
        High,
        [Image(PlannerHelper.ImagePath + "High.png")]
        Urgent

    }
    public enum Status 
    {

        Queued = 0,
        Ready = 1,
        Running = 2,   
        Paused = 3,
        Delayed = 4,
        Done = 5,
        Plan = 6

    }
    [ValueConversion(typeof(TaskPriority), typeof(string))]
    public class TaskPriorityToIconFilenameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((TaskPriority)value)
            {
                case TaskPriority.Low:
                    return "Low.png";
                case TaskPriority.Normal:
                    return "Normal.png";
                case TaskPriority.High:
                    return "Medium.png";
                case TaskPriority.Urgent:
                    return "High.png";
                default:
                    return "Low.png";
            }

            // or
            //return Enum.GetName(typeof(TaskPriority), value) + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    [ValueConversion(typeof(Status), typeof(string))]
    public class NameToBackgroundConverter : MarkupExtension, IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Status status = new Status();
            if (value.ToString().Contains("Running")) 
            {
                status = Status.Running;
            }
            else if (value.ToString().Contains("Queued"))
            {
                status = Status.Queued;
            }
            else if(value.ToString().Contains("Ready"))
            {
                status = Status.Ready;
            }
            else if(value.ToString().Contains("Paused"))
            {
                status = Status.Paused;
            }
            else if(value.ToString().Contains("Delayed"))
            {
                status = Status.Delayed;
            }
            else if(value.ToString().Contains("Done"))
            {
                status = Status.Done;
            }
            else if(value.ToString().Contains("Plan"))
            {
                status = Status.Plan;
            }
            switch (status)
            {
                case Status.Running:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05fd00"));
                    //return Brushes.Green;
                case Status.Queued:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080"));
                    //return Brushes.Gray;
                case Status.Ready:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7c0080"));
                    //return Brushes.DarkViolet;
                case Status.Paused:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fefe00"));
                    //return Brushes.Yellow;
                case Status.Delayed:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fd0000"));
                    //return Brushes.Red;
                case Status.Done:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6495e5"));
                    //return Brushes.Blue;
                case Status.Plan:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffa204"));
                    //return Brushes.Orange;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    //public enum TaskPriority
    //{
    //    Low,
    //    Normal,
    //    High,
    //    Urgent,
    //}
    
    public class Images 
    {
        public BitmapImage IMG { get; set; }
       
    }
    public class EnumToItemSourceProvider : MarkupExtension
    {
        public Type EnumType { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            List<object> result = new List<object>();
            Array values = Enum.GetValues(EnumType);
            foreach (var value in values)
                result.Add(new { Name = Enum.GetName(EnumType, value), Value = value });

            return result;
        }
    }

}

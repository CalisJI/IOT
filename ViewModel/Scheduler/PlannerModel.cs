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
        #region =================================Data Table ================================
        DataTable JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
        #endregion

        public ICommand Save_EditJob { get; set; }
       // public ICommand Save_work { get; set; }

        private ObservableCollection<ConvertoJson> convertoJson;
        public ObservableCollection<ConvertoJson> ToJson 
        {
            get { return convertoJson; }
            set { SetProperty(ref convertoJson, value, nameof(ToJson)); }
        }

        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();

        public static DataTable DatatableScheduler = new DataTable("Job Information");
        private static DispatcherTimer _dispatcherTimer;
        public static DispatcherTimer DispatcherTimer 
        {
            get 
            {
                if (_dispatcherTimer == null) 
                {
                    _dispatcherTimer = new DispatcherTimer();
                }
                return _dispatcherTimer;

            }
            set 
            {
                _dispatcherTimer = value;
            }
        }
        public EditJobModel EditJobModel { get; set; }
        //public  ObservableCollection<processdata> Resource { get; set; }
        //public  ObservableCollection<proessdataappointment> Appointments { get; set; }
        public ObservableCollection<ImageSource> Images { get; set; }

       

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
        private int running;
        private int queued;
        private int done;
        private int delayed;
        private int plan;
        private int paused;
        private int ready;
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
        public int Runnings { get { return this.running; } set { this.running = value; OnPropertyChanged("Runnings"); } }
        public int Delayeds { get { return this.delayed; } set { this.delayed = value; OnPropertyChanged("Delayeds"); } }
        public int Plans { get { return this.plan; } set { this.plan = value; OnPropertyChanged("Plans"); } }
        public int Queueds { get { return this.queued; } set { this.queued = value; OnPropertyChanged("Queueds"); } }
        public int Dones { get { return this.done; } set { this.done = value; OnPropertyChanged("Dones"); } }
        public int Readys { get { return this.ready; } set { this.ready = value; OnPropertyChanged("Readys"); } }
        public int Pauseds { get { return this.paused; } set { this.paused = value; OnPropertyChanged("Pauseds"); } }

        public TaskPriority taskPriority;
        public Status status;
        public Status Status { get { return status; } set { SetProperty(ref status, value, "Status"); } }
        public TaskPriority TaskPriority { get { return taskPriority; } set { SetProperty(ref taskPriority, value, "TaskPriority"); } }


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
            foreach (var item in JobOrders)
            {
                JobOrderRuntime jobOrderRuntime = new JobOrderRuntime();
                jobOrderRuntime.OrderName = item.SaleOrder;
                jobOrderRuntime.ActualvsLife = item.ActualvsPlan;
                jobOrderRuntime.CurrentStage = item.Stage;
                jobOrderRuntime.PercentComplete = item.Complete;

                if (JobOrdersRumtimes == null) JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
                JobOrdersRumtimes.Add(jobOrderRuntime);
            }

        }

        //Cập nhật giá trị runtime
        private void updateruntime()
        {
            try
            {
                JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
                mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrderRuntime_Table, JobOrderRuntime_Table.TableName, Sqlexcute.Database);
                JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();
                JobOrdersRumtimes = Sqlexcute.Conver_From_Data_Table_To_List<JobOrderRuntime>(JobOrderRuntime_Table);
                if (JobOrdersRumtimes.Count != JobOrders.Count)
                {
                    JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();

                    adruntime();
                }
                else
                {
                    foreach (var item in JobOrdersRumtimes)
                    {
                        var ss = JobOrders.Where(i => i.SaleOrder == item.OrderName).FirstOrDefault();
                        if (ss != null)
                        {
                            ss.Complete = item.PercentComplete;
                            ss.ActualvsPlan = item.ActualvsLife;
                            ss.Stage = item.CurrentStage;
                            ss.Current_Stage = getColor(item.CurrentStage);
                        }

                    }
                }
               
                
                JobOrderRuntime_Table = new DataTable("JobOrderRuntime");
                JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName);
                DatatableScheduler = new DataTable("JobOrder");
                var Json = JsonSerializer.Serialize(JobOrders);
                ToJson = new ObservableCollection<ConvertoJson>();
                ToJson.Add(new ConvertoJson { Code = Json });
                DatatableScheduler = Sqlexcute.FillToDataTable(ToJson);
                if (ToJson.ElementAt(0).Code != "") 
                {
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, DatatableScheduler, "fwd63823_database", "JobOrder");
                }
                
            }
            catch (Exception ex)
            {

               
            }
           
        }
        Thread Thread1 = null;
        public PlannerModel() 
        {
            AddProjectSchedule_ViewModel._jobOrderRuntime = JobOrdersRumtimes;
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
                Sqlexcute.Server = "112.78.2.9";
                Sqlexcute.pwd = "Fwd@2021";
                Sqlexcute.UId = "fwd63823_fwdvina";
                AddProjectSchedule_ViewModel.jobOrders = JobOrders;
                Sqlexcute.Check_Table(Sqlexcute.Database, JobOrderRuntime_Table.TableName, ref check);
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

                if (check == 0)
                {
                    try
                    {
                        adruntime();
                        JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                        Sqlexcute.AutoCreateTable(JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName, ref check_, ref exist_);
                        mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrderRuntime_Table, JobOrderRuntime_Table.TableName, Sqlexcute.Database);

                        JobOrderRuntime_Table = Sqlexcute.FillToDataTable(JobOrdersRumtimes);
                        Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, JobOrderRuntime_Table, Sqlexcute.Database, JobOrderRuntime_Table.TableName);
                    }
                    catch (Exception)
                    {

                        
                    }
                   
                }
                else if (check == 1)
                {
                    try
                    {
                        mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrderRuntime_Table, JobOrderRuntime_Table.TableName, Sqlexcute.Database);
                        JobOrdersRumtimes = Sqlexcute.Conver_From_Data_Table_To_List<JobOrderRuntime>(JobOrderRuntime_Table);

                        if (JobOrdersRumtimes.Count != JobOrders.Count)
                        {
                            JobOrdersRumtimes = new ObservableCollection<JobOrderRuntime>();

                            adruntime();
                        }
                        else
                        {
                            foreach (var item in JobOrders)
                            {
                                var ss = JobOrdersRumtimes.Where(i => i.OrderName == item.SaleOrder).FirstOrDefault();
                                ss.ActualvsLife = item.ActualvsPlan;
                                ss.CurrentStage = item.Stage;
                                ss.PercentComplete = item.Complete;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        string aaa = ex.Message;
                    }
                   
                   
                }
                var a = JobOrders;
                GetStage(ref ready, ref done, ref running, ref delayed, ref paused, ref plan, ref queued);
            }
            Save_EditJob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Thread thread = new Thread(() => 
                {
                    Save_Table();
                });thread.Start();
                
            });
            

            DispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer.Tick += DispatcherTimer_Tick;
            if (!DispatcherTimer.IsEnabled) 
            {
               DispatcherTimer.IsEnabled = true;
               DispatcherTimer.Start();
            }
            
            //Initialize();

        }

        private void Runtime_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
        }

        private void Runtime_DoWork(object sender, DoWorkEventArgs e)
        {
            updatedata();
        }

        private void updatedata() 
        {
            GetStage(ref ready, ref done, ref running, ref delayed, ref paused, ref plan, ref queued);
            updateruntime();
            
            
        }
        public void Save_Table()
        {
           
            DatatableScheduler = new DataTable();
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
            
           
            
            DatatableScheduler = Sqlexcute.FillToDataTable(ToJson);
        
            Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, DatatableScheduler, "fwd63823_database", "JobOrder");
            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            else
            {
                messageBoxService.ShowMessage("Đã Lưu", "Thông tin", System.Messaging.MessageType.Report);
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
        private void GetStage(ref int _Ready, ref int _Done, ref int _Running, ref int _Delayed, ref int _Paused, ref int _Plan, ref int _Queued) 
        {
            _Ready = JobOrders.Where(i => i.Stage == Status.Ready).Count();
            _Done = JobOrders.Where(i => i.Stage == Status.Done).Count();
            _Running = JobOrders.Where(i => i.Stage == Status.Running).Count();
            _Delayed = JobOrders.Where(i => i.Stage == Status.Delayed).Count();
            _Paused = JobOrders.Where(i => i.Stage == Status.Paused).Count();
            _Plan = JobOrders.Where(i => i.Stage == Status.Plan).Count();
            _Queued = JobOrders.Where(i => i.Stage == Status.Queued).Count();
        }
        //void Initialize() 
        //{
        //    using(savedataEntities savedataEntities = new savedataEntities()) 
        //    {
                
        //        savedataEntities.proessdataappointments.Load();
        //        savedataEntities.processdatas.Load();
        //        int Ready = 0;
        //        int Done = 0;
        //        int Running = 0;
        //        int Delayed = 0;
        //        int Paused = 0;
        //        int Plan = 0;
        //        int Queued = 0;
        //        Appointments = savedataEntities.proessdataappointments.Local;
        //        if (AssignedTask.Count > Appointments.Count)
        //        {
        //            var secondNotFirst = AssignedTask.Where(x => !Appointments.Any(z => x.Name == z.ProcessName)).FirstOrDefault();
        //            AssignedTask.Remove(secondNotFirst);
        //        }
        //        for (int i = 0; i < Appointments.Count; i++)
        //        {
        //            bool err = false;
        //            try
        //            {
        //                var a = AssignedTask.ElementAt(i);
        //                err = false;
        //            }
        //            catch (Exception)
        //            {
        //                err = true;
        //                AssignedTask.Add(new PlannerTask());

        //            }
        //            finally 
        //            {
                        
        //                var item = Appointments.ElementAt(i);
        //                AssignedTask.ElementAt(i).Name = item.ProcessName;
        //                AssignedTask.ElementAt(i).StartDate = item.StartTime;
        //                AssignedTask.ElementAt(i).DueDate = item.EndTime;
        //                AssignedTask.ElementAt(i).Priority = (TaskPriority)item.Priority;
        //                AssignedTask.ElementAt(i).Current_Stage = item.Notes + getColor((Status)item.StatusId);
        //                AssignedTask.ElementAt(i).Name = item.ProcessName;
        //                AssignedTask.ElementAt(i).Status = (Status)item.StatusId;
        //                item.StatusId = (int)AssignedTask.ElementAt(i).Status;
        //                TimeSpan? total = item.EndTime - item.StartTime;
        //                TimeSpan? today = DateTime.Now - item.StartTime;
        //                float percent = (float)((float)today.Value.TotalMinutes / total.Value.TotalMinutes);
        //                AssignedTask.ElementAt(i).Completion = percent*100;
        //                GetDone((Status)item.StatusId, ref Done );
        //                GetDelayed((Status)item.StatusId, ref Delayed);
        //                GetPaused((Status)item.StatusId, ref Paused);
        //                GetReady((Status)item.StatusId, ref Ready);
        //                GetRunning((Status)item.StatusId, ref Running);
        //                GetPlan((Status)item.StatusId, ref Plan);
        //                GetQueued((Status)item.StatusId, ref Queued);

        //            }
                    
        //        }
        //        Readys = Ready;
        //        Runnings = Running;
        //        Plans = Plan;
        //        Queueds = Queued;
        //        Delayeds = Delayed;
        //        Pauseds = Paused;
        //        Dones = Done;

        //    }
            
        //}
        
        void GenerateAssignedTasks() 
        {
        //    AssignedTask = new ObservableCollection<PlannerTask>();
        //    PlannerTask plannerTask = new PlannerTask();
            
        //    plannerTask.Priority = (TaskPriority)1;
        //    plannerTask.Actual_vs_Liftime = 0.65f;
        //    plannerTask.Completion = 50;
        //    plannerTask.Current_Stage = "Inspetion";
        //    AssignedTask.Add(plannerTask);


        //    PlannerTask plannerTask1 = new PlannerTask();
         
        //    plannerTask1.Priority = (TaskPriority)2;
        //    plannerTask1.Actual_vs_Liftime = 0.25f;
        //    plannerTask1.Completion = 30;
        //    plannerTask1.Current_Stage = "Inspetion";
        //    AssignedTask.Add(plannerTask1);

        //    PlannerTask plannerTask2 = new PlannerTask();
          
        //    plannerTask2.Priority = (TaskPriority)3;
        //    plannerTask2.Actual_vs_Liftime = 0.25f;
        //    plannerTask2.Completion = 30;
        //    plannerTask2.Current_Stage = "Inspetion";
        //    AssignedTask.Add(plannerTask2);

        //    PlannerTask plannerTask4 = new PlannerTask();
          
        //    plannerTask4.Priority = 0;
        //    plannerTask4.Actual_vs_Liftime = 0.25f;
        //    plannerTask4.Completion = 30;
        //    plannerTask4.Current_Stage = "Inspetion";
        //    AssignedTask.Add(plannerTask4);

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
        Normal,
        [Image(PlannerHelper.ImagePath + "Medium.png")]
        High,
        [Image(PlannerHelper.ImagePath + "High.png")]
        Urgent

    }
    public enum Status 
    {

        Queued = 0,
        Ready=1,
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
                    return null;
            }

            // or
            return Enum.GetName(typeof(TaskPriority), value) + ".png";
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

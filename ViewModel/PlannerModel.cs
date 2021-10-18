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
        ObservableCollection<PlannerTask> assignedTask;
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
        public ObservableCollection<PlannerTask> AssignedTask { get { return assignedTask; } set { SetProperty(ref assignedTask, value, "AssignedTask"); } }
        //public ObservableCollection<PlannerTask> AssignedTask { get; set; }
        public PlannerModel() 
        {
           
            
            AssignedTask = new ObservableCollection<PlannerTask>();
            DispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer.Tick += DispatcherTimer_Tick;
            DispatcherTimer.Start();
            //Initialize();

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Initialize();
        }
        string getColor(Status status) 
        {
            
            switch (status) 
            {
                case Status.Plan:
                    return " : Plan";
                case Status.Ready:
                    return " : Ready";
                case Status.Running:
                    return " : Running";
                case Status.Delayed:
                    return " : Delayed";
                case Status.Done:
                    return " : Done";
                case Status.Paused:
                    return " : Paused";
                case Status.Queued:
                    return " : Queued";
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
            AssignedTask = new ObservableCollection<PlannerTask>();
            PlannerTask plannerTask = new PlannerTask();
            plannerTask.Name = "Mã số 1";
            plannerTask.Posting_Time = DateTime.Now ;
            plannerTask.StartDate = DateTime.Now ;
            plannerTask.DueDate = DateTime.Now;
            plannerTask.Priority = (TaskPriority)1;
            plannerTask.Actual_vs_Liftime = 0.65f;
            plannerTask.Completion = 50;
            plannerTask.Current_Stage = "Inspetion";
            AssignedTask.Add(plannerTask);


            PlannerTask plannerTask1 = new PlannerTask();
            plannerTask1.Name = "Mã số 2";
            plannerTask1.Posting_Time = DateTime.Now ;
            plannerTask1.StartDate = DateTime.Now ;
            plannerTask1.DueDate = DateTime.Now;
            plannerTask1.Priority = (TaskPriority)2;
            plannerTask1.Actual_vs_Liftime = 0.25f;
            plannerTask1.Completion = 30;
            plannerTask1.Current_Stage = "Inspetion";
            AssignedTask.Add(plannerTask1);

            PlannerTask plannerTask2 = new PlannerTask();
            plannerTask2.Name = "Mã số 3";
            plannerTask2.Posting_Time = DateTime.Now;
            plannerTask2.StartDate = DateTime.Now;
            plannerTask2.DueDate = DateTime.Now;
            plannerTask2.Priority = (TaskPriority)3;
            plannerTask2.Actual_vs_Liftime = 0.25f;
            plannerTask2.Completion = 30;
            plannerTask2.Current_Stage = "Inspetion";
            AssignedTask.Add(plannerTask2);

            PlannerTask plannerTask4 = new PlannerTask();
            plannerTask4.Name = "Mã số 3";
            plannerTask4.Posting_Time = DateTime.Now;
            plannerTask4.StartDate = DateTime.Now;
            plannerTask4.DueDate = DateTime.Now;
            plannerTask4.Priority = 0;
            plannerTask4.Actual_vs_Liftime = 0.25f;
            plannerTask4.Completion = 30;
            plannerTask4.Current_Stage = "Inspetion";
            AssignedTask.Add(plannerTask4);

        }
        
    }
   
    public class PlannerTask 
    {
        public float Completion { get; set; }
        public string Name { get; set; }
        public string  Current_Stage { get; set; }
        public TaskPriority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? StartDate { get; set; }
        
        public float Actual_vs_Liftime { get; set; }
        public DateTime? Posting_Time { get; set; }
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

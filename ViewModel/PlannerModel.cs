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
        public virtual ObservableCollection<processdata> Resource { get; set; }
        public virtual ObservableCollection<proessdataappointment> Appointments { get; set; }
        public ObservableCollection<ImageSource> Images { get; set; }
        ObservableCollection<PlannerTask> assignedTask;

        public TaskPriority taskPriority;
        public TaskPriority TaskPriority { get { return taskPriority; } set { SetProperty(ref taskPriority, value, "TaskPriority"); } }
        public ObservableCollection<PlannerTask> AssignedTask { get { return assignedTask; } set { SetProperty(ref assignedTask, value, "AssignedTask"); } }
        //public ObservableCollection<PlannerTask> AssignedTask { get; set; }
        public PlannerModel() 
        {
            GenerateAssignedTasks();
            AssignedTask = new ObservableCollection<PlannerTask>();
            Thread t = new Thread(() => 
            {
                while (true) 
                {
                    Initialize();
                    Thread.Sleep(5000);
                }
               
            });
            t.Start();
            t.IsBackground = true;
        }

        void Initialize() 
        {
            using(savedataEntities savedataEntities = new savedataEntities()) 
            {
                savedataEntities.proessdataappointments.Load();
                savedataEntities.processdatas.Load();

                Appointments = savedataEntities.proessdataappointments.Local;
                if (AssignedTask.Count > Appointments.Count)
                {
                    var secondNotFirst = AssignedTask.Where(x => !Appointments.Any(z => x.Name == z.ProcessName));
                    AssignedTask.Remove((PlannerTask)secondNotFirst);


                }
                for (int i = 0; i < Appointments.Count; i++)
                {
                    try
                    {
                        var a = AssignedTask.ElementAt(i);
                    }
                    catch (Exception)
                    {

                        AssignedTask.Add(new PlannerTask());
                    }
                    var item = Appointments.ElementAt(i);

                    AssignedTask.ElementAt(i).Name = item.ProcessName;
                    AssignedTask.ElementAt(i).StartDate = item.StartTime;
                    AssignedTask.ElementAt(i).DueDate = item.EndTime;
                    AssignedTask.ElementAt(i).Priority = (TaskPriority)item.Priority;
                    AssignedTask.ElementAt(i).Current_Stage = item.Notes;
                    AssignedTask.ElementAt(i).Name = item.ProcessName;
                    item.StatusId = (int)AssignedTask.ElementAt(i).Status;
                }
            }
            
        }
        
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
        
        Queued,
        Ready,
        Running,     
        Paused,
        Delayed,
        Done,
        Plan

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
    [ValueConversion(typeof(TaskPriority), typeof(string))]
    public class NameToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            switch ((Status)value)
            {
                case Status.Running:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#05fd00"));
                    
                case Status.Queued:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080"));
                    
                case Status.Ready:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7c0080"));
                   
                case Status.Paused:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fefe00"));
                   
                case Status.Delayed:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("fd0000"));
                   
                case Status.Done:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6495e5"));
                    
                case Status.Plan:
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffa204"));
                   
            }
            return Enum.GetName(typeof(Status), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
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

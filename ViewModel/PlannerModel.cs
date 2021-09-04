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

namespace WPF_TEST.ViewModel
{
    static class PlannerHelper 
    {
        public const string ImagePath = "pack://appication:,,,/WPF_TEST;component/ImageSource/";
    }
    public class PlannerModel:BaseViewModel
    {
        //public IEnumerable<TaskPriority> myPriority
        //{
        //    get { return Enum.GetValues(typeof(TaskPriority)).Cast<TaskPriority>(); }

        //}
        public ObservableCollection<Image> Image { get; set; }
        ObservableCollection<PlannerTask> assignedTask;

        public TaskPriority taskPriority;
        public TaskPriority TaskPriority { get { return taskPriority; } set { SetProperty(ref taskPriority, value, "TaskPriority"); } }
        public ObservableCollection<PlannerTask> AssignedTask { get { return assignedTask; } set { SetProperty(ref assignedTask, value, "AssignedTask"); } }

        public PlannerModel() 
        {
            GenerateAssignedTasks();
            Initialize();
            
        }
        void Initialize() 
        {
            
        }
        void GenerateAssignedTasks() 
        {
            AssignedTask = new ObservableCollection<PlannerTask>();
            PlannerTask plannerTask = new PlannerTask();
            plannerTask.Name = "Mã số 1";
            plannerTask.Posting_Time = DateTime.Now ;
            plannerTask.StartDate = DateTime.Now ;
            plannerTask.DueDate = DateTime.Now;
            plannerTask.Priority = TaskPriority.Normal;
            plannerTask.Actual_vs_Liftime = 0.65f;
            plannerTask.Completion = 50;
            plannerTask.Current_Stage = "Inspetion";
            AssignedTask.Add(plannerTask);


            PlannerTask plannerTask1 = new PlannerTask();
            plannerTask1.Name = "Mã số 2";
            plannerTask1.Posting_Time = DateTime.Now ;
            plannerTask1.StartDate = DateTime.Now ;
            plannerTask1.DueDate = DateTime.Now;
            plannerTask1.Priority = TaskPriority.High;
            plannerTask1.Actual_vs_Liftime = 0.25f;
            plannerTask1.Completion = 30;
            plannerTask1.Current_Stage = "Inspetion";
            AssignedTask.Add(plannerTask1);

        }
    }
   
    public class PlannerTask 
    {
        public float Completion { get; set; }
        public string Name { get; set; }
        public string  Current_Stage { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        
        public float Actual_vs_Liftime { get; set; }
        public DateTime Posting_Time { get; set; }
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
    //public enum TaskPriority
    //{
    //    [Image(@"D:\VISUAL PROJECT\C#\WPF\WPF_TEST\ImageSource\Low.png")] Low,
    //    [Image(@"D:\VISUAL PROJECT\C#\WPF\WPF_TEST\ImageSource\Low.png")] Normal,
    //    [Image(@"D:\VISUAL PROJECT\C#\WPF\WPF_TEST\ImageSource\Low.png")] High,
    //    [Image(@"D:\VISUAL PROJECT\C#\WPF\WPF_TEST\ImageSource\Low.png")] Urgent,
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

using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using DevExpress.Mvvm.POCO;
namespace WPF_TEST.ViewModel
{
    [POCOViewModel]
    public class ProcessAppointment : BindableBase
    {
        public static ProcessAppointment Create()
        {
            return ViewModelSource.Create(() => new ProcessAppointment());
        }
        internal static ProcessAppointment Create(DateTime startTime, DateTime endTime,
            int ProcessId, string notes, string location, int categoryId, string ProcessName)
        {

            ProcessAppointment apt = Create();
            apt.StartTime = startTime;
            apt.EndTime = endTime;
            apt.ProcessId = ProcessId;
            apt.Notes = notes;
            apt.Location = location;
            apt.CategoryId = categoryId;
            apt.ProcessName = ProcessName;
           
            return apt;
        }
        public enum StatusProcess 
        {
            
        }
        protected ProcessAppointment() { }

        public virtual int Id { get; set; }
        public virtual bool AllDay { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string ProcessName { get; set; }
        public virtual string Notes { get; set; }
        public virtual string Subject { get; set; }
        public virtual int StatusId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int Type { get; set; }
        public virtual string Location { get; set; }
        public virtual string RecurrenceInfo { get; set; }
        public virtual string ReminderInfo { get; set; }
        public virtual int? ProcessId { get; set; }
       
    }
}
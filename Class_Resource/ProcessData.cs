using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System;
namespace WPF_TEST.Class_Resource
{
    [POCOViewModel]
    public class ProcessData:BindableBase
    {
        public static ProcessData Create() 
        {
            return ViewModelSource.Create(() => new ProcessData());
        }
        public static ProcessData Create(int Id, string Name) 
        {
            ProcessData processData = ProcessData.Create();
            processData.Id = Id;
            processData.Name = Name;
            return processData;
        }
        protected ProcessData() 
        {
        
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
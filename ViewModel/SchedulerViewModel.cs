using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.iCalendar;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using WPF_TEST.Class_Resource;

namespace WPF_TEST.ViewModel
{
    [POCOViewModel]
    public class SchedulerViewModel:BaseViewModel
    {
        public virtual ObservableCollection<ProcessData> ProcessDatas { get; set; }
        public virtual ObservableCollection<ProcessAppointment> Appointments { get; set; }

        //private BaseViewModel _selectedViewModel;
        //public BaseViewModel SelectedViewModel
        //{
        //    get { return _selectedViewModel; }
        //    set
        //    {
        //        _selectedViewModel = value;
        //        OnPropertyChanged(nameof(SelectedViewModel));
        //    }
        //}
        OutlookInspiredDemoViewModel OutlookInspiredDemoViewModel = new OutlookInspiredDemoViewModel();
       
        
        private void CreateProcess()
        {
            ProcessDatas = new ObservableCollection<ProcessData>();
            ProcessDatas.Add(ProcessData.Create(Id: 1, Name: "Action 1"));
            ProcessDatas.Add(ProcessData.Create(Id: 2, Name: "Action 2"));
            ProcessDatas.Add(ProcessData.Create(Id: 3, Name: "Action 3"));
        }
        private void CreateMedicalAppointments()
        {
            Appointments = new ObservableCollection<ProcessAppointment>();
            Appointments.Add(ProcessAppointment.Create(
                startTime: DateTime.Now.Date.AddHours(10), endTime: DateTime.Now.Date.AddHours(11),
                ProcessId: 1, notes: "", location: "101", categoryId: 1, ProcessName: "Anyone"));
        }
        public void CreateProcessAppointments( DateTime dateTimeStart,DateTime dateTimeEnd,int ProcessID, string note, string locations, int categori,string ProcessName) 
        {
            Appointments = new ObservableCollection<ProcessAppointment>();
            Appointments.Add(ProcessAppointment.Create(
                startTime: dateTimeStart, endTime: dateTimeEnd,
                ProcessId: ProcessID, notes: note, location: locations, categoryId: categori, ProcessName: ProcessName));
        }
        public SchedulerViewModel()
        {
            //CreateProcess();
            CreateMedicalAppointments();
            //if (!loaded)
            //{
            //    scheduleViewModel = this;
            //    scheduleViewModel.SelectedViewModel = OutlookInspiredDemoViewModel;
            //    loaded = true;
            //}
        }
        public void OutlookImport(SchedulerControl scheduler)
        {
            OutlookExchange(scheduler, OutlookExchangeType.Import);
        }
        public void OutlookExport(SchedulerControl scheduler)
        {
            OutlookExchange(scheduler, OutlookExchangeType.Export);
        }
        public void iCalendarImport(SchedulerControl scheduler)
        {
            ICalendarImporter importer = new ICalendarImporter(scheduler);
            using (Stream stream = OpenRead("Calendar", "iCalendar files (*.ics)|*.ics"))
            {
                if (stream != null)
                    importer.Import(stream);
            }
        }
        public void iCalendarExport(SchedulerControl scheduler)
        {
            ICalendarExporter exporter = new ICalendarExporter(scheduler);
            using (Stream stream = OpenWrite("Calendar", "iCalendar files (*.ics)|*.ics"))
            {
                if (stream != null)
                {
                    exporter.Export(stream);
                    stream.Flush();
                }
            }
        }
        void OutlookExchange(SchedulerControl scheduler, OutlookExchangeType exchangeType)
        {
            try
            {
                string[] outlookCalendarPaths = DevExpress.XtraScheduler.Outlook.OutlookExchangeHelper.GetOutlookCalendarPaths();
                if (outlookCalendarPaths == null || outlookCalendarPaths.Length == 0)
                    return;

                OutlookExchangeOptionsWindow optionsWindow = new OutlookExchangeOptionsWindow();
                optionsWindow.DataContext = OutlookExchangeOptionsWindowViewModel.Create(scheduler, exchangeType, outlookCalendarPaths);
                optionsWindow.Owner = Window.GetWindow(scheduler);
                optionsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                optionsWindow.ShowDialog();
            }
            catch
            {
                DXMessageBox.Show(String.Format("Unable to {0}.\nCheck whether MS Outlook is installed.", "get the list of available calendars from Microsoft Outlook"),
                    "Import from MS Outlook", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        Stream OpenRead(string fileName, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog() { FileName = fileName, Filter = filter, FilterIndex = 1 };
            if (dialog.ShowDialog() != true)
                return null;
            return dialog.OpenFile();
        }
        Stream OpenWrite(string fileName, string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog() { FileName = fileName, Filter = filter, FilterIndex = 1 };
            if (dialog.ShowDialog() != true)
                return null;
            return dialog.OpenFile();
        }
    }
}
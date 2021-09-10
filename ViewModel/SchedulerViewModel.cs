using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.iCalendar;
using FastMember;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_TEST.Class_Resource;

namespace WPF_TEST.ViewModel
{
    [POCOViewModel]
    public class SchedulerViewModel:BaseViewModel
    {
        savedataEntities savedataEntities = new savedataEntities();
        //public BindingList<processdata> Resource { get; set; }
        //public BindingList<proessdataappointment> Appointments { get; set; }
        public virtual ObservableCollection<processdata> Resource { get; set; }
        public virtual ObservableCollection<proessdataappointment> Appointments { get; set; }


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
        //OutlookInspiredDemoViewModel OutlookInspiredDemoViewModel = new OutlookInspiredDemoViewModel();
        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            using (savedataEntities context = new savedataEntities())
        //            {
        //                context.SaveChanges();
        //            }

        //        });
        //    }
        //}

        public ICommand SaveCommand
        {
            get 
            {
                return new RelayCommand<object>((p) => { return true; }, (p)=>{
                    var a = DataProvider.INS.DB.proessdataappointments.ToList();
                    if (Appointments.Count >= a.Count)
                    {
                        Appointments.ElementAt(Appointments.Count - 1).idProessDataAppoint = Appointments.ElementAt(Appointments.Count - 2).idProessDataAppoint + 1;
                    }



                    var b = Resource;
                    var c = Appointments;
                    savedataEntities.SaveChanges();
                    //IEnumerable<ObservableCollection<proessdataappointment>> observableCollections = (IEnumerable<ObservableCollection<proessdataappointment>>)Appointments;
                    //using (var reader = ObjectReader.Create(observableCollections)) 
                    //{
                    //    DataProvider.INS.DB.proessdataappointments.Load();
                    //}
                });
            }
        }

        
        public SchedulerViewModel()
        {
            savedataEntities.proessdataappointments.Load();
            savedataEntities.processdatas.Load();
            
            
            Resource = new ObservableCollection<processdata>();
            Appointments = new ObservableCollection<proessdataappointment>();
            Resource = savedataEntities.processdatas.Local;
            Appointments = savedataEntities.proessdataappointments.Local;
            //foreach (var item in a)
            //{
            //    Resource.Add(item);
            //}
            //var b = DataProvider.INS.DB.proessdataappointments.ToList();
            //foreach (var item in b)
            //{
            //    Appointments.Add(item);
            //}
            //context.proessdataappointments.Load();
            //context.Resource.Load();

            //SaveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    using (savedataEntities context = new savedataEntities())
            //    {
            //        context.SaveChanges();
            //    }

            //});
            //CreateProcess();
            //CreateProcessAppointments();
            //if (!loaded)
            //{
            //    scheduleViewModel = this;
            //    scheduleViewModel.SelectedViewModel = OutlookInspiredDemoViewModel;
            //    loaded = true;
            //}
        }
       
        
        //public void OutlookImport(SchedulerControl scheduler)
        //{
        //    OutlookExchange(scheduler, OutlookExchangeType.Import);
        //}
        //public void OutlookExport(SchedulerControl scheduler)
        //{
        //    OutlookExchange(scheduler, OutlookExchangeType.Export);
        //}
        //public void iCalendarImport(SchedulerControl scheduler)
        //{
        //    ICalendarImporter importer = new ICalendarImporter(scheduler);
        //    using (Stream stream = OpenRead("Calendar", "iCalendar files (*.ics)|*.ics"))
        //    {
        //        if (stream != null)
        //            importer.Import(stream);
        //    }
        //}
        //public void iCalendarExport(SchedulerControl scheduler)
        //{
        //    ICalendarExporter exporter = new ICalendarExporter(scheduler);
        //    using (Stream stream = OpenWrite("Calendar", "iCalendar files (*.ics)|*.ics"))
        //    {
        //        if (stream != null)
        //        {
        //            exporter.Export(stream);
        //            stream.Flush();
        //        }
        //    }
        //}
        //void OutlookExchange(SchedulerControl scheduler, OutlookExchangeType exchangeType)
        //{
        //    try
        //    {
        //        string[] outlookCalendarPaths = DevExpress.XtraScheduler.Outlook.OutlookExchangeHelper.GetOutlookCalendarPaths();
        //        if (outlookCalendarPaths == null || outlookCalendarPaths.Length == 0)
        //            return;

        //        OutlookExchangeOptionsWindow optionsWindow = new OutlookExchangeOptionsWindow();
        //        optionsWindow.DataContext = OutlookExchangeOptionsWindowViewModel.Create(scheduler, exchangeType, outlookCalendarPaths);
        //        optionsWindow.Owner = Window.GetWindow(scheduler);
        //        optionsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //        optionsWindow.ShowDialog();
        //    }
        //    catch
        //    {
        //        DXMessageBox.Show(String.Format("Unable to {0}.\nCheck whether MS Outlook is installed.", "get the list of available calendars from Microsoft Outlook"),
        //            "Import from MS Outlook", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}
        //Stream OpenRead(string fileName, string filter)
        //{
        //    OpenFileDialog dialog = new OpenFileDialog() { FileName = fileName, Filter = filter, FilterIndex = 1 };
        //    if (dialog.ShowDialog() != true)
        //        return null;
        //    return dialog.OpenFile();
        //}
        //Stream OpenWrite(string fileName, string filter)
        //{
        //    SaveFileDialog dialog = new SaveFileDialog() { FileName = fileName, Filter = filter, FilterIndex = 1 };
        //    if (dialog.ShowDialog() != true)
        //        return null;
        //    return dialog.OpenFile();
        //}

        
    }
    
}
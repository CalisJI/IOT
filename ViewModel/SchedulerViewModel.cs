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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using WPF_TEST.Data;
using WPF_TEST.Notyfication;

namespace WPF_TEST.ViewModel
{
    [POCOViewModel]
    public class SchedulerViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        public ICommand WorKScope { get; set; }
        public ICommand Save { get; set; }
        public ICommand GotoEditJob { get; set; }
        public ICommand Goback { get; set; }
        public ICommand Schedule { get; set; }
        public ICommand GotoHome { get; set; }
        public ICommand ChangeCustomer { get; set; }
        public ICommand Save_EditJob { get; set; }
        public ICommand StartSchedule { get; set; }
        public ICommand Backschedule { get; set; }
        public ICommand ViewSchedule { get; set; }
        public ICommand BacKPartSchedule { get; set; }
        public ICommand WorkScope_Back { get; set; }
        public ICommand SelectedWork { get; set; }
        public ICommand Save_work { get; set; }



        private ObservableCollection<Customer> _customerInfo;
        public ObservableCollection<Customer> CustomerInfo { get { return _customerInfo; } set { SetProperty(ref _customerInfo, value, nameof(CustomerInfo)); } }

        private Works works = new Works();

        public static ObservableCollection<JobOrder> _jobOrders;
        public ObservableCollection<JobOrder> JobOrders 
        {
            get 
            {
                return _jobOrders;
            }
            set 
            {
                SetProperty(ref _jobOrders, value, nameof(JobOrders));
            }
        }

        private string _detail;
        public string Details
        { get { return _detail; } set { SetProperty(ref _detail, value, nameof(Details)); } }
        private JobOrder Edit_JobItem;
        private JobOrder _SelectedJob;
        
        private Works _work;
        public Works GetWorks
        {

            get { return _work; }
            set
            {
                SetProperty(ref _work, value, nameof(GetWorks));
            }
        }

        public JobOrder SelectedJob
        {
            get
            {
                return _SelectedJob;
            }
            set
            {
                SetProperty(ref _SelectedJob, value, nameof(SelectedJob));
            }
        }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public bool loaded = false;
        //public ObservableCollection<Customer> CustomerInfo { get; set; }
        //public ObservableCollection<Works> WorksList { get; set; }
        EditJobModel EditJobModel = new EditJobModel();
        
        PartSchedulrt_ViewModel PartSchedulrt_ViewModel = new PartSchedulrt_ViewModel();
        ScheduleListTime_ViewModel ScheduleListTime_ViewModel = new ScheduleListTime_ViewModel();
        PlannerModel PlannerModel = new PlannerModel();
        WorkScope_ViewModel WorkScope_ViewModel = new WorkScope_ViewModel();
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    //var a = DataProvider.INS.DB.proessdataappointments.ToList();
                    /////var d = DataProvider.INS.ServerData.Test.ToList();
                    //if (Appointments.Count >= a.Count)
                    //{
                    //    Appointments.ElementAt(Appointments.Count - 1).idProessDataAppoint = Appointments.ElementAt(Appointments.Count - 2).idProessDataAppoint + 1;
                    //}



                    //var b = Resource;
                    //var c = Appointments;
                    //savedataEntities.SaveChanges();
                    //IEnumerable<ObservableCollection<proessdataappointment>> observableCollections = (IEnumerable<ObservableCollection<proessdataappointment>>)Appointments;
                    //using (var reader = ObjectReader.Create(observableCollections)) 
                    //{
                    //    DataProvider.INS.DB.proessdataappointments.Load();
                    //}
                });
            }
        }
        SchedulerViewModel schedulerViewModel;

        public SchedulerViewModel()
        {
            
          

            if (!loaded)
            {
               
                //CustomerInfo = EditJobModel.CustomerInfo;
                //WorksList = EditJobModel.WorksList;
                schedulerViewModel = this;
                //workflowCreatorModel.SelectedViewModel = EditJobModel;
                schedulerViewModel.SelectedViewModel = PlannerModel;
                loaded = true;
                CustomerInfo = EditJobModel._customerInfo;

            }
            //Save_work = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
            //    var aa = SelectedJob.Works.Where(s => s == works).FirstOrDefault();
            //    aa = GetWorks;

            //});
            SelectedWork = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var aa = SelectedJob.Works.Where(s => s == (Works)p).FirstOrDefault();
                GetWorks = aa;
               // works = GetWorks;

            }); 
            BacKPartSchedule = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                schedulerViewModel.SelectedViewModel = PartSchedulrt_ViewModel;
            });
            ViewSchedule = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                schedulerViewModel.SelectedViewModel = ScheduleListTime_ViewModel;
            });
            Backschedule = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                schedulerViewModel.SelectedViewModel = EditJobModel;
            });
            WorKScope = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedJob.Works.Count == 1) 
                {
                    GetWorks = SelectedJob.Works.ElementAt(0);
                }
                schedulerViewModel.SelectedViewModel = WorkScope_ViewModel;
                
            });
            Goback = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.schedulerViewModel.SelectedViewModel = PlannerModel;
            });
            Save = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            GotoEditJob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    if (p == null) 
                    {
                        throw new Exception();
                    }
                    Edit_JobItem = (JobOrder)p;
                    var dd = JobOrders.Where(x => x == Edit_JobItem).FirstOrDefault();
                    SelectedJob = Edit_JobItem;
                    this.schedulerViewModel.SelectedViewModel = EditJobModel;
                }
                catch (Exception )
                {
                    messageBoxService.ShowMessage("Vui lòng chọn chọn đơn hàng để chỉnh sửa", "Thông báo!", System.Messaging.MessageType.Report);
                   
                }
               
            });
            //Schedule = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
            //    SchedulerMain schedulerMain = new SchedulerMain();
            //    schedulerMain.ShowDialog();
            //});
            WorkScope_Back = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                schedulerViewModel.SelectedViewModel = EditJobModel;
            });
            GotoHome = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            ChangeCustomer = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var d = (Customer)p;
                }
                catch (Exception)
                {

                    
                }
               
                //SelectedJob.Customer_Details = d.Customer_Details;
            });
            StartSchedule = new RelayCommand<object>((p) => { return true; }, (p) =>
             {
                 schedulerViewModel.SelectedViewModel = PartSchedulrt_ViewModel;
             });
            

        }
        
    }
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var v = (bool)value;
                return v ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (InvalidCastException)
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
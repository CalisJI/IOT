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
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    [POCOViewModel]
    public class SchedulerViewModel : BaseViewModel
    {
        private static SchedulerViewModel _Schedule;
        public static SchedulerViewModel _SchedulerViewModel 
        {
            get 
            {
                if (_Schedule != null) 
                {
                    return _Schedule;
                }
                else 
                {
                    return new SchedulerViewModel();
                }
            }
            set 
            {
                _Schedule = value;
            }
        }


        private BaseViewModel _selectedViewModel;
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        public ICommand WorKScope { get; set; }
        public ICommand SaveAddjob { get; set; }
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
        public ICommand OpenBarCode { get; set; }
        public ICommand Add_Project { get; set; }
        public ICommand AddworkScope { get; set; }

        public ICommand SaveNewJob { get; set; }

        public ICommand selectpriority { get; set; }

        public ICommand BackAddJob { get; set; }
        public ICommand DeleteWork { get; set; }
        public ICommand ConfirmEditjob { get; set; }
        public ICommand Loaded { get; set; }

        private string _customer_Infor;
        public string Customer_Infor
        {
            get { return _customer_Infor; }
            set { SetProperty(ref _customer_Infor, value, nameof(Customer_Infor)); }
        }

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
        private Customer Edit_JobItem;
        private JobOrder _SelectedJob;
        private Customer _singleCustomer;
        public Customer SingleCustomer
        {
            get { return _singleCustomer; }
            set { SetProperty(ref _singleCustomer, value, nameof(SingleCustomer)); }
        }
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
        Work_Edit_ViewModel Work_Edit_ViewModel = new Work_Edit_ViewModel();
        AddProjectSchedule_ViewModel AddProjectSchedule_ViewModel = AddProjectSchedule_ViewModel._AddProjectSchedule_ViewModel;
        FrameWorkscope_ViewModel FrameWorkscope_ViewModel;
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
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    Loading_Indicator.Finished();
                }
                catch (Exception ex)
                {

                  
                }
               
            });
            ConfirmEditjob = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                

                foreach (var item in Work_Edit_ViewModel._work)
                {
                    SelectedJob.Works.Add(item);
                }
                //schedulerViewModel.SelectedViewModel = EditJobModel;

            });
            selectpriority = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {

                    string bb = p.ToString();
                    switch (bb)
                    {
                        case "High":
                            SelectedJob.Priority = TaskPriority.High;
                            break;
                        case "Urgent":
                            SelectedJob.Priority = TaskPriority.Urgent;
                            break;
                        case "Low":
                            SelectedJob.Priority = TaskPriority.Low;
                            break;
                        case "Normal":
                            SelectedJob.Priority = TaskPriority.Normal;
                            break;

                    }
                }
                catch (Exception)
                {


                }
            });
            DeleteWork = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var d = (Works)p;
                    var a = SelectedJob.Works.Where(x => x == d).SingleOrDefault();
                    SelectedJob.Works.Remove(a);
                }
                catch (Exception ex)
                {

                    
                }
               
            });
            SaveNewJob = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
            Add_Project = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (AddProjectSchedule_ViewModel != null) 
                {
                    AddProjectSchedule_ViewModel = null;
                }
                AddProjectSchedule_ViewModel = AddProjectSchedule_ViewModel._AddProjectSchedule_ViewModel;
                schedulerViewModel.SelectedViewModel = AddProjectSchedule_ViewModel;
            });
            BackAddJob = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                schedulerViewModel.SelectedViewModel = AddProjectSchedule_ViewModel;
            });
            OpenBarCode = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Barcode_View barcode = new Barcode_View();
                barcode.ShowDialog();
            });
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
                try
                {
                    if (SelectedJob.Works.Count == 1)
                    {
                        GetWorks = SelectedJob.Works.ElementAt(0);
                    }
                    schedulerViewModel.SelectedViewModel = WorkScope_ViewModel;
                }
                catch (Exception)
                {

                    schedulerViewModel.SelectedViewModel = WorkScope_ViewModel;
                }
             
                
            });
            Goback = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                schedulerViewModel.SelectedViewModel = PlannerModel;
            });
            SaveAddjob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                schedulerViewModel.SelectedViewModel = PlannerModel;
                AddProjectSchedule_ViewModel = null;
                
            });
            GotoEditJob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    if (p == null) 
                    {
                        throw new Exception();
                    }
                    SelectedJob = (JobOrder)p;
                    //var dd = JobOrders.Where(x => x == Edit_JobItem).FirstOrDefault();
                    //SelectedJob = Edit_JobItem;
                    Edit_JobItem = CustomerInfo.Where(x => x == SelectedJob.Customerinformation).FirstOrDefault();
                    schedulerViewModel.SelectedViewModel = EditJobModel;
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
                    SingleCustomer = d;
                    Customer_Infor = d.Customer_Details;
                    SelectedJob.Customerinformation = d;
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
            AddworkScope = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                schedulerViewModel.SelectedViewModel = new FrameWorkscope_ViewModel();
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
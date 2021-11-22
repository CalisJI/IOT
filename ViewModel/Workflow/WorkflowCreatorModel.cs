using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using WPF_TEST.Data;
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    public class WorkflowCreatorModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        //public ICommand WorKScope { get; set; }
        //public ICommand Save { get; set; }
        //public ICommand GotoEditJob { get; set; }
        //public ICommand Goback { get; set; }
        //public ICommand Schedule { get; set; }
        //public ICommand GotoHome { get; set; }
        //public ICommand ChangeCustomer { get; set; }
      
        //private string _detail;
        //public string Details 
        //{ get { return _detail; } set { SetProperty(ref _detail, value, nameof(Details)); } }
        //private JobOrder Edit_JobItem;
        //private JobOrder _SelectedJob;
        //public JobOrder SelectedJob 
        //{
        //    get 
        //    {
        //        return _SelectedJob;
        //    }
        //    set 
        //    {
        //        SetProperty(ref _SelectedJob, value, nameof(SelectedJob));
        //    }
        //}
        //public BaseViewModel SelectedViewModel
        //{
        //    get { return _selectedViewModel; }
        //    set
        //    {
        //        _selectedViewModel = value;
        //        OnPropertyChanged(nameof(SelectedViewModel));
        //    }
        //}
        //private bool _IsBusy;
        //public bool IsBusy
        //{
        //    get { return _IsBusy; }
        //    set
        //    {
        //        _IsBusy = value;
        //        OnPropertyChanged("IsBusy");
        //    }
        //}
        //public bool loaded = false;
        //public ObservableCollection<Customer> CustomerInfo { get; set; }
        //public ObservableCollection<Works> WorksList { get; set; }
        //public PlannerModel PlannerModel { get; set; }
        //public EditJobModel EditJobModel { get; set; }
        //WorkScope_ViewModel WorkScope_ViewModel = new WorkScope_ViewModel();
       
        public WorkflowCreatorModel workflowCreatorModel;
       
        public WorkflowCreatorModel() 
        {
            //PlannerModel = new PlannerModel();
            //EditJobModel = new EditJobModel();
            //CustomerInfo = EditJobModel.CustomerInfo;
            //WorksList = EditJobModel.WorksList;
            
            //if (!loaded) 
            //{
            //    workflowCreatorModel = this;
              
            //    workflowCreatorModel.SelectedViewModel = PlannerModel;
            //    loaded = true;
              
            //}
            //WorKScope = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    workflowCreatorModel.SelectedViewModel = WorkScope_ViewModel;
            //});
            //Goback = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
            //    this.workflowCreatorModel.SelectedViewModel = PlannerModel;
            //});
            //Save = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
            
            //});
            //GotoEditJob = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
            //    Edit_JobItem = (JobOrder)p;
            //    SelectedJob = Edit_JobItem;
            //    this.workflowCreatorModel.SelectedViewModel = EditJobModel; 
            //});
            ////Schedule = new RelayCommand<object>((p) => { return true; }, (p) => 
            ////{
            ////    SchedulerMain schedulerMain = new SchedulerMain();
            ////    schedulerMain.ShowDialog();
            ////});
            //GotoHome = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
                
            //});
            //ChangeCustomer = new RelayCommand<object>((p) => { return true; }, (p) => 
            //{
            //    var d = (Customer)p;
            //    //SelectedJob.Customer_Details = d.Customer_Details;
            //});
        }
    }
    
    //public class BoolToVisibilityConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        try
    //        {
    //            var v = (bool)value;
    //            return v ? Visibility.Visible : Visibility.Collapsed;
    //        }
    //        catch (InvalidCastException)
    //        {
    //            return Visibility.Collapsed;
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

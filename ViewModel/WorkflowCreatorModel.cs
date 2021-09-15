using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    public class WorkflowCreatorModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public ICommand WorKScope { get; set; }
        public ICommand Save { get; set; }
        public ICommand GotoEditJob { get; set; }
        public ICommand Goback { get; set; }
        public ICommand Schedule { get; set; }
        public ICommand GotoHome { get; set; }
        private proessdataappointment _proessdataappointment;
        public proessdataappointment proessdataappointment
        {
            get
            {
                return _proessdataappointment;

            }
            set
            {
                _proessdataappointment = value;
                OnPropertyChanged("proessdataappointment");
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
        public PlannerModel PlannerModel { get; set; }
        public EditJobModel EditJobModel { get; set; }
       
        public WorkflowCreatorModel workflowCreatorModel;
        
        public WorkflowCreatorModel() 
        {
            PlannerModel = new PlannerModel();
            EditJobModel = new EditJobModel();
            EditJobModel.PlannerModel = PlannerModel;
            
            if (!loaded) 
            {
                workflowCreatorModel = this;
                //workflowCreatorModel.SelectedViewModel = EditJobModel;
                workflowCreatorModel.SelectedViewModel = PlannerModel;
                loaded = true;
            }
            WorKScope = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //this.IsBusy = true;

                //await Task.Run(() =>
                //{                   
                //    this.workflowCreatorModel.SelectedViewModel = PlannerModel;
                //});
                //this.IsBusy = false;

                //this.dataStreamCollectionModel.SelectedViewModel = DataCollectConfigureModel;
            });
            Goback = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                this.workflowCreatorModel.SelectedViewModel = PlannerModel;
            });
            Save = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
            
            });
            GotoEditJob = new RelayCommand<object>((p) => { return true; }, (p) => 
            { 
                this.workflowCreatorModel.SelectedViewModel = EditJobModel; 
            });
            Schedule = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                SchedulerMain schedulerMain = new SchedulerMain();
                schedulerMain.ShowDialog();
            });
            GotoHome = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
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

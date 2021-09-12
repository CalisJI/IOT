using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    public class WorkflowCreatorModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public ICommand WorKScope { get; set; }
        public ICommand Save { get; set; }
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
        PlannerModel PlannerModel = new PlannerModel();
        EditJobModel EditJobModel = new EditJobModel();
        public WorkflowCreatorModel workflowCreatorModel;
        
        public WorkflowCreatorModel() 
        {
            if (!loaded) 
            {
                workflowCreatorModel = this;
                workflowCreatorModel.SelectedViewModel = EditJobModel;
                //workflowCreatorModel.SelectedViewModel = PlannerModel;
                loaded = true;
            }
            WorKScope = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                this.IsBusy = true;

                await Task.Run(() =>
                {                   
                    this.workflowCreatorModel.SelectedViewModel = PlannerModel;
                });
                this.IsBusy = false;

                //this.dataStreamCollectionModel.SelectedViewModel = DataCollectConfigureModel;
            });
            Save = new RelayCommand<object>((p) => { return true; }, (p) => 
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

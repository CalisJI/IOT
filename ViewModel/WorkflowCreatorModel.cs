using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class WorkflowCreatorModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public ICommand WorKScope { get; set; }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
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
                //workflowCreatorModel.SelectedViewModel = PlannerModel;
                workflowCreatorModel.SelectedViewModel = EditJobModel;
                loaded = true;
            }
            WorKScope = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.workflowCreatorModel.SelectedViewModel = PlannerModel;
                //this.dataStreamCollectionModel.SelectedViewModel = DataCollectConfigureModel;
            });
        }
    }
}

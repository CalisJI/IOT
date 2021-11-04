using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class MainScreenViewModel: BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand DataStreamCollectionModel_Command { get; set; }
        public ICommand WorkFlow { get; set; }
       
        public ICommand Schedular { get; set; }
        public ICommand Home { get; set; }

        //DataStreamCollectionModel DataStreamCollectionModel = new DataStreamCollectionModel();
        MainMenuModel MainMenuModel = new MainMenuModel();
        WorkflowCreatorModel WorkflowCreatorModel = new WorkflowCreatorModel();
        SchedulerViewModel SchedulerViewModel = new SchedulerViewModel();
        MainAll_ViewModel MainAll_ViewModel = new MainAll_ViewModel();
        public MainScreenViewModel mainScreenViewModel;
        public bool loadMain = false;
        public MainScreenViewModel() 
        {
            if (!loadMain) 
            {
                mainScreenViewModel = this;
                mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
                loadMain = true;
            }
            DataStreamCollectionModel_Command = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = MainMenuModel;
            });
            WorkFlow = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = WorkflowCreatorModel;
            });
            Schedular = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SchedulerMain schedulerMain = new SchedulerMain();
                schedulerMain.ShowDialog();
            });
            Home = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel = this;
                mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
            });


        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using WPF_TEST.Data;
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    public class MainScreenViewModel: BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        private UserAccount user;
        public UserAccount CurrentAccount
        {
            get { return user; }
            set 
            {
                SetProperty(ref user, value, nameof(CurrentAccount));
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
        public ICommand Image_Manager { get; set; }
        public ICommand Audio_Manager { get; set; }
        public ICommand Video_Manager { get; set; }
        public ICommand Document_Manager { get; set; }

        public ICommand DataStreamCollectionModel_Command { get; set; }
        public ICommand WorkFlow { get; set; }
       
        public ICommand Schedular { get; set; }
        public ICommand Home { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand DataStream { get; set; }
        public ICommand Sensor_Collection { get; set; }
        public ICommand Raw_Sensor_Collection { get; set; }
        public ICommand Ethernet_Collection { get; set; }
        public ICommand Modbus_Connection { get; set; }
        public ICommand Web_API { get; set; }
        public ICommand Configure_File { get; set; }
        public ICommand PLC_data { get; set; }
        public ICommand Main_menu { get; set; }
        public ICommand Media { get; set; }
        public ICommand Usermanager { get; set; }

        public ICommand Load { get; set; }
        public ICommand Unload { get; set; }

        static FileConnfig_Main_ViewModel FileConnfig_Main_ViewModel = new FileConnfig_Main_ViewModel();
        //DataStreamCollectionModel DataStreamCollectionModel = new DataStreamCollectionModel();
        static MainMenuModel MainMenuModel = new MainMenuModel();
        WorkflowCreatorModel WorkflowCreatorModel = new WorkflowCreatorModel();
        static SchedulerViewModel SchedulerViewModel = new SchedulerViewModel();
        static MainAll_ViewModel MainAll_ViewModel = new MainAll_ViewModel();
        static DataCollectConfigureModel DataCollectConfigureModel = new DataCollectConfigureModel();
        static Ethenet_SerialModel ethenet_SerialModel = new Ethenet_SerialModel();
        static ModbusViewModel ModbusViewModel = new ModbusViewModel();
        static Content_Manager_ViewModel Content_Manager_ViewModel = new Content_Manager_ViewModel();
        public MainScreenViewModel mainScreenViewModel;
        public Access_Managerment_ViewModel Access_Managerment_ViewModel = new Access_Managerment_ViewModel();
        public bool loadMain = false;
        public MainScreenViewModel() 
        {
            CurrentAccount = Login_ViewModel.LoginAcount;
            if (!loadMain) 
            {
                CurrentAccount = Login_ViewModel.LoginAcount;
                mainScreenViewModel = this;
                mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
                loadMain = true;
            }
            Load = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                CurrentAccount = Login_ViewModel.LoginAcount;
                mainScreenViewModel = this;
                mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
                loadMain = true;
            });
            Image_Manager = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = Content_Manager_ViewModel.ImageManager_ViewModel;
            });
            Audio_Manager = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = Content_Manager_ViewModel.AudioManager_ViewModel;
            });
            Video_Manager = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = Content_Manager_ViewModel.VideoManager_ViewModel;
            });
            Document_Manager = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = Content_Manager_ViewModel.DocumentManager_ViewModel;
            });
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
                //SchedulerMain schedulerMain = new SchedulerMain();
                //schedulerMain.ShowDialog();

                mainScreenViewModel.SelectedViewModel = SchedulerViewModel;

                //Task.Factory.StartNew(() => {
                //    loading_ViewModel loading_ViewModel = new loading_ViewModel();
                //    mainScreenViewModel.SelectedViewModel = loading_ViewModel;
                //    Dispatcher.CurrentDispatcher.Invoke(new Action(() => 
                //    {
                        

                //    }));
                    
                //});
                
            });
            Usermanager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                mainScreenViewModel.SelectedViewModel = Access_Managerment_ViewModel;
            });
            Home = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
               
                mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
            });
            DataStream = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.mainScreenViewModel.SelectedViewModel = DataCollectConfigureModel;


            });

            Sensor_Collection = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            });
            Raw_Sensor_Collection = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            });
            Ethernet_Collection = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.mainScreenViewModel.SelectedViewModel = ethenet_SerialModel;
            });
            Modbus_Connection = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.mainScreenViewModel.SelectedViewModel = ModbusViewModel;
            });
            Web_API = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            });
            Configure_File = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.mainScreenViewModel.SelectedViewModel = FileConnfig_Main_ViewModel;
            });

            PLC_data = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            });
            Main_menu = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //dataStreamCollectionModel.SelectedViewModel = MainMenu;

                //mainScreenViewModel.SelectedViewModel = this;
            });
            Media = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                mainScreenViewModel.SelectedViewModel = Content_Manager_ViewModel;
            });


        }
       
    }
}

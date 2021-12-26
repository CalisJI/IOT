using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        

        public string[] CountriesArray = new[] { "United States", "Afghanistan", "Albania", "Algeria", "Andorra", "Angola",
            "Anguilla", "Antarctica", "Antigua & Barbuda", "Argentina", "Armenia", "Aruba (neth.)", "Australia", "Austria", "Azerbaijan", "Azores (port.)", "Bahamas",
            "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia And Herzegovina", "Botswana", "Brazil",
            "British Virgin Islands", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic",
            "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic",
            "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands", "Fiji", "Finland", "Fmr Yug Rep Macedonia", "France", "French Guiana", "French Polynesia",
            "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guinea", "Guinea Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong",
            "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Iraq-Saudi Arabia Neutral Zone", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati",
            "Korea Dem.People's Rep.", "Korea, Republic Of", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya Arab Jamahiriy", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar",
            "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mexico", "Micronesia, Fed Stat", "Moldova, Republic Of", "Monaco", "Mongolia", "Morocco",
            "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau Islands",
            "Panama", "Panama Canal Zone", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint Lucia", "San Marino",
            "Sao Tome & Principe", "Saudi Arabia", "Senegal", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "Spain", "Sri Lanka", "St.Kitts & Nevis",
            "St.Vinct & Grenadine", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Rep.", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad & Tobago", "Tunisia",
            "Turkey", "Turkmenistan", "Turks And Caicos Islands", "Tuvalu", "U.S. Virgin Islands", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City (Holy See)",
            "Venezuela", "Vietnam", "Western Sahara", "Western Samoa", "Yemen", "Yugoslavia", "Zaire", "Zambia", "Zimbabwe" };

        #region Command

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
        public ICommand CustomerManager { get; set; }
        public ICommand User_Manager { get; set; }

        public ICommand OpenDataBaseSetting { get; set; }
        #endregion
        FileConnfig_Main_ViewModel FileConnfig_Main_ViewModel = new FileConnfig_Main_ViewModel();
        //DataStreamCollectionModel DataStreamCollectionModel = new DataStreamCollectionModel();
        MainMenuModel MainMenuModel = new MainMenuModel();
        CustomerSetting_ViewModel CustomerSetting_ViewModel = new CustomerSetting_ViewModel();
        WorkflowCreatorModel WorkflowCreatorModel = new WorkflowCreatorModel();
        SchedulerViewModel SchedulerViewModel = SchedulerViewModel._SchedulerViewModel;
        MainAll_ViewModel MainAll_ViewModel = new MainAll_ViewModel();
        DataCollectConfigureModel DataCollectConfigureModel = new DataCollectConfigureModel();
        Ethenet_SerialModel ethenet_SerialModel = new Ethenet_SerialModel();
        ModbusViewModel ModbusViewModel = ModbusViewModel.INS;
        Content_Manager_ViewModel Content_Manager_ViewModel = new Content_Manager_ViewModel();
        public MainScreenViewModel mainScreenViewModel;
        public Access_Managerment_ViewModel Access_Managerment_ViewModel = new Access_Managerment_ViewModel();
        UserManager_ViewModel UserManager_ViewModel = UserManager_ViewModel.INSUserManager_ViewModel;
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

            User_Manager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
                    Loading_Indicator.BeingBusy();
                

                mainScreenViewModel.SelectedViewModel = UserManager_ViewModel;
            });
            Load = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                CurrentAccount = Login_ViewModel.LoginAcount;
                //mainScreenViewModel = this;
                mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
                loadMain = true;
                Loading_Indicator.Finished();
            });
            Unload = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //mainScreenViewModel.SelectedViewModel = MainAll_ViewModel;
                loadMain = false;
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
                Loading_Indicator.BeingBusy();
                
                mainScreenViewModel.SelectedViewModel = SchedulerViewModel;
                SchedulerViewModel.Goback.Execute(null);
                //Task.Factory.StartNew(() => {
                //    loading_ViewModel loading_ViewModel = new loading_ViewModel();
                //    mainScreenViewModel.SelectedViewModel = loading_ViewModel;
                //    Dispatcher.CurrentDispatcher.Invoke(new Action(() => 
                //    {


                //    }));

                //});

            });
            CustomerManager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                mainScreenViewModel.SelectedViewModel = CustomerSetting_ViewModel;
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
                Loading_Indicator.BeingBusy();
                
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

            OpenDataBaseSetting = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                DatabaseConfig_View databaseConfig_View = new DatabaseConfig_View();
                databaseConfig_View.ShowDialog();
            });
        }
       
    }
    
}

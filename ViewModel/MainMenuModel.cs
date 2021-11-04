using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class MainMenuModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
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

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        DataCollectConfigureModel DataCollectConfigureModel = new DataCollectConfigureModel();
        Ethenet_SerialModel ethenet_SerialModel = new Ethenet_SerialModel();
        ModbusViewModel ModbusViewModel = new ModbusViewModel();
        public bool loaded = false;
        //MainMenuModel mainMenuModel { get; set; }
        public MainMenuModel() 
        {
            //if (!loaded)
            //{
            //    mainMenuModel = this;
            //    loaded = true;
            //}
            //DataStream = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    this.mainMenuModel.SelectedViewModel = DataCollectConfigureModel;
               

            //});

            //Sensor_Collection = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            //});
            //Raw_Sensor_Collection = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            //});
            //Ethernet_Collection = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    this.mainMenuModel.SelectedViewModel = ethenet_SerialModel;
            //});
            //Modbus_Connection = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    this.mainMenuModel.SelectedViewModel = ModbusViewModel;
            //});
            //Web_API = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            //});
            //Configure_File = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            //});

            //PLC_data = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    //this.dataCollectConfigureModel.SelectedViewModel = new AMDashBoard();
            //});
            //Main_menu = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    //dataStreamCollectionModel.SelectedViewModel = MainMenu;

            //    mainMenuModel.SelectedViewModel = this;
            //});
        }
    }
}

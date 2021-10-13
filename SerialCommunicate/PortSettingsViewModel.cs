using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.ViewModel;

namespace WPF_TEST.SerialCommunicate
{
    public class PortSettingsViewModel:BaseViewModel
    {
        private string _selectedComPort;
        private int _baudrate;
        private Parity _parity;
        private StopBits _stopBit;
        private int _databits;
        public int DataBit 
        {

            get { return _databits; }
            set { _databits = value; OnPropertyChanged("DataBit");}
        
        }
        public string SelectedCOMPort
        {
           
            get { return _selectedComPort; }
            set {_selectedComPort=value; OnPropertyChanged("SelectedCOMPort"); }
        }
        public int SelectedBaudRate
        {

            get { return _baudrate; }
            set { _baudrate = value; OnPropertyChanged("SelectedBaudRate"); }
        }
        public Parity SelectedParity
        {

            get { return _parity; }
            set { _parity = value; OnPropertyChanged("SelectedParity"); }
        }
        public StopBits SelectedStopBits
        {

            get { return _stopBit; }
            set { _stopBit = value; OnPropertyChanged("SelectedStopBits"); }
        }
        public ObservableCollection<string> AvaliablePorts { get; set; }

        public ObservableCollection<int> Baud_rate { get; private set; }
        public ObservableCollection<Parity> Paritys { get; private set; }
        public ObservableCollection<StopBits> Stop_bits { get; private set; }
        public ObservableCollection<int> DataBits { get; private set; }
        public ICommand RefreshPortsCommand { get; }

        public PortSettingsViewModel()
        {
            AvaliablePorts = new ObservableCollection<string>();
            Baud_rate = new ObservableCollection<int>() { 9600, 14400, 19200, 28800, 38400, 57600, 76800, 115200, 230400 };
            Paritys = new ObservableCollection<Parity>() { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
            Stop_bits = new ObservableCollection<StopBits>() { StopBits.One, StopBits.None, StopBits.Two, StopBits.OnePointFive };
            DataBits = new ObservableCollection<int>() { 7, 8 };
            RefreshPortsCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RefreshPorts(); });

            RefreshPorts();
        }

        private void RefreshPorts()
        {
            AvaliablePorts.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                AvaliablePorts.Add(port);
            }
            
        }
    }
}

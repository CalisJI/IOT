using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Collections.ObjectModel;

namespace WPF_TEST.ViewModel
{
    public class Ethenet_SerialModel:BaseViewModel
    {
        public ObservableCollection<string> Comport { get; private set; }
        public ObservableCollection<int> Baud_rate { get; private set; }
        public ObservableCollection<Parity> Paritys { get; private set; }
        public ObservableCollection<StopBits> Stop_bits { get; private set; }

        public string SelectValueOne { get; set; }
        public StopBits StopBits { get; set; }
        public int Baudrate { get; set; }
        public Parity Parity_ { get; set; }
        public Ethenet_SerialModel ethenet_SerialModel;
        public bool load = false;
        public Ethenet_SerialModel() 
        {
            if (!load) 
            {
                ethenet_SerialModel = this;
                load = true;
                string[] COMPort = SerialPort.GetPortNames();
                Comport = new ObservableCollection<string>();
                Baud_rate = new ObservableCollection<int>() { 9600, 14400, 19200, 28800, 38400, 57600, 76800, 115200, 230400 };
                Paritys = new ObservableCollection<Parity>() { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
                Stop_bits = new ObservableCollection<StopBits>() { StopBits.One, StopBits.None, StopBits.Two, StopBits.OnePointFive };
                foreach (var item in COMPort)
                {
                    Comport.Add(item);
                }
                SelectValueOne = Comport[0];
                StopBits = Stop_bits[0];
                Parity_ = Paritys[0];
                Baudrate = Baud_rate[0];
            }
        }

    }
}

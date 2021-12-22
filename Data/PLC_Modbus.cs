using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.ViewModel;

namespace WPF_TEST.Data
{
    public class PLC_Modbus
    {
        public string Device_Name { get; set; }
        
        private ObservableCollection<RuntimeValue> _data = new ObservableCollection<RuntimeValue>();
        public ObservableCollection<RuntimeValue> Data
        {
            get
            {
                return _data;
            }
            set 
            {
                
                _data = value;
            } 
        }
    }
    public class RuntimeValue 
    {
        public string CurrentTime { get; set; }
        public int[] ArrayValue { get; set; }
        public DeviceStage Stage { get; set; }
    }
}

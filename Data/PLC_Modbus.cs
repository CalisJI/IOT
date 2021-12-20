using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(_data.Count >= 10) 
                {
                    _data.RemoveAt(0);
                   
                }
                _data = value;
            } 
        }
    }
    public class RuntimeValue 
    {
        public string CurrentTime { get; set; }
        public int[] ArrayValue { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Class_Resource
{
    public class TimerSetting
    {
        private int dem;
        public int TimerUpdatePLCData 
        {
            get 
            {
                if (dem < 1) 
                {
                    return 10;
                }
                else 
                {
                    return dem;
                }
            }
            set 
            {
                dem = value;
            }
        }

    }
}

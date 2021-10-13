using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Class_Resource
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider INS 
        { get 
            {
                if (_ins == null) 
                {
                    _ins = new DataProvider();
                }
                return _ins;
            }
            set 
            {
                _ins = value;
            }
        }
        public savedataEntities DB { get; set; }
        //public ServerData ServerData { get; set; }
        private DataProvider()
        {
            DB = new savedataEntities();
            //ServerData = new ServerData();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.Data;

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
        //public savedataEntities DB { get; set; }
        //public ServerData ServerData { get; set; }
        private Sqlexcute Sqlexcute { get; set; }
        private static DataTable _insJob;
        
        public static DataTable INS_JobOrder
        {
            get { return _insJob; }
            set 
            {
                _insJob = value;
            }
        }
        private static DataTable _insWork;
       
        public static DataTable INS_Work
        {
            get
            {
                return _insWork;
            }
            set 
            {
                _insWork = value;
            }
        }
        private static DataTable _inscustomer;
        public static DataTable INS_Customer
        {
            get 
            {
                return _inscustomer;
            }
            set 
            {
                _inscustomer = value;
            }
        }
        private static DataTable _insPLC;
        public static DataTable INS_PLC_Data 
        {
            get 
            {
                return _insPLC;
            }
            set 
            {
                _insPLC = value;
            }
        }

        private DataProvider()
        {
            //DB = new savedataEntities();
            //ServerData = new ServerData();
            Sqlexcute = new Sqlexcute();
            INS_JobOrder = new DataTable("JobOrderConfig");
            INS_Customer = new DataTable("CustomerConfig");
            INS_Work = new DataTable("WorksConfig");
            INS_PLC_Data = new DataTable("PLCDataConfig");
        }

        private void LoadData() 
        {
            try
            {
                Sqlexcute.AutoCreateTable(_insJob, Sqlexcute.Database, INS_JobOrder.TableName,ref _insJob);
                Sqlexcute.AutoCreateTable(_insPLC, Sqlexcute.Database, INS_PLC_Data.TableName, ref _insPLC);
                Sqlexcute.AutoCreateTable(_inscustomer, Sqlexcute.Database, INS_Customer.TableName, ref _inscustomer);
                Sqlexcute.AutoCreateTable(_insWork, Sqlexcute.Database, INS_Work.TableName, ref _inscustomer);
                //Sqlexcute.GetData_FroM_Database(ref _insJob, INS_JobOrder.TableName, Sqlexcute.Database);
                //Sqlexcute.GetData_FroM_Database(ref _insWork, INS_Work.TableName, Sqlexcute.Database);
                //Sqlexcute.GetData_FroM_Database(ref _inscustomer, INS_Customer.TableName, Sqlexcute.Database);
                //Sqlexcute.GetData_FroM_Database(ref _insPLC, INS_PLC_Data.TableName, Sqlexcute.Database);
            }
            catch (Exception ex)
            {

            }
           
        }
    }
}

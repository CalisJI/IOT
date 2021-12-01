using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Data
{
    public class UserAccount
    {
        Permit permit = new Permit();
        //ObservableCollection<Permit> permits = new ObservableCollection<Permit>();
        //public ObservableCollection<Permit> Permits 
        //{
        //    get { return permits; }
        //    set 
        //    {
        //        permits = value;
        //    }
        //}
        public int UserID { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public Permit Permit { get { return permit; } set { permit = value; } }

    }
    public class Permit
    {
        private Weekly_Schedule weekly_Schedule = new Weekly_Schedule();
        private MCPReport mCPReport = new MCPReport();
        private ViewJob viewJob = new ViewJob();
        private CompletedJob completedJob = new CompletedJob();
        private SalesDraft salesDraft = new SalesDraft();
        private ModifySalesItem modifySales = new ModifySalesItem();
        private UACC uacc = new UACC();

        public UACC UACC
        {
            get 
            {
                return uacc;
            }
            set
            {
                uacc = value;
            }
        }
        public Weekly_Schedule Weekly_Schedule 
        {
            get 
            {
                return weekly_Schedule;
            }

            set 
            {
                weekly_Schedule = value;
            }
        }
        public MCPReport MCPReport
        {
            get
            {
                return mCPReport;
            }

            set
            {
                mCPReport = value;
            }
        }
        public ViewJob ViewJob
        {
            get
            {
                return viewJob;
            }

            set
            {
                viewJob = value;
            }
        }
        public CompletedJob CompletedJob
        {
            get
            {
                return completedJob;
            }

            set
            {
                completedJob = value;
            }
        }
        public SalesDraft SalesDraft
        {
            get
            {
                return salesDraft;
            }

            set
            {
                salesDraft = value;
            }
        }
        public ModifySalesItem ModifySalesItem
        {
            get
            {
                return modifySales;
            }

            set
            {
                modifySales = value;
            }
        }
    }
    public class Weekly_Schedule 
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class MCPReport
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ViewJob
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class CompletedJob
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class SalesDraft
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ModifySalesItem
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ConvertoJson 
    {
        public string Code { get; set; }
    }
    public class UACC
    {
        public bool Schedule { get; set; }
        public bool DataInput { get; set; }
        public bool Operator { get; set; }
        public bool ModifyAccount { get; set; }
    }
}

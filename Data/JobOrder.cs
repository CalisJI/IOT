using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.ViewModel;

namespace WPF_TEST.Data
{
    public class JobOrder
    {
        private Status status = new Status();
        private ObservableCollection<Works> works = new ObservableCollection<Works>();
        public int ID { get; set; }
        public string SaleOrder { get; set; }
        public string Customer { get; set; }
        public string Customer_Details { get; set; }
        public string Quotation { get; set; }
        public string Customer_PO { get; set; }
        public DateTime Requested_Start { get; set; }
        public DateTime Requested_End { get; set; }
        public DateTime Requested_Report_Date { get; set; }
        public DateTime Posting_Date { get; set; }
        public TaskPriority Priority
        { get; set; }
        public float ActualvsPlan { get; set; }
        public float Complete { get; set; }
        public int LabelId
        { get { return (int)this.status; } }
        public Status Stage { get { return status; } set { status = value; } }
        public string Current_Stage { get; set; }

        public ObservableCollection< Works> Works
        {
            get
            {
                return works; 
            }
            set { works = value; }
        }

    }
}

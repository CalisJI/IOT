using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Data
{
    public class JobOrder
    {
        public int ID { get; set; }
        public string SaleOrder { get; set; }
        public string Customer { get; set; }
        public string Customer_Details { get; set; }
        public string Quotation { get; set; }
        public string Customer_PO { get; set; }
        public DateTime Requested_Start { get; set; }
        public DateTime Requested_End { get; set; }
        public DateTime Requested_Report_Date { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.ViewModel;

namespace WPF_TEST.Data
{
    public class JobOrderRuntime
    {
        public string BarCode { get; set; }
        public string OrderName { get; set; }
        public float ActualvsLife { get; set; }
        public float PercentComplete { get; set; }
        public Status CurrentStage { get; set; }
    }
}
  
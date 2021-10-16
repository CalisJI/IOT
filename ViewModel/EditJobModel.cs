using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Class_Resource;

namespace WPF_TEST.ViewModel
{
    public class EditJobModel:BaseViewModel
    {
        public PlannerModel PlannerModel { get; set; }
        //public ObservableCollection<processdata> Resource { get; set; }
        //public ObservableCollection<proessdataappointment> Appointments { get; set; }
        public EditJobModel() 
        {
           

        }
    }
}

using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_TEST.Class_Resource;
using WPF_TEST.ViewModel;

namespace WPF_TEST
{
    /// <summary>
    /// Interaction logic for SchedulerMain.xaml
    /// </summary>
    public partial class SchedulerMain : ThemedWindow
    {
        
        public virtual ObservableCollection<proessdataappointment> Appointments { get; set; }
        public SchedulerMain()
        {
            InitializeComponent();
           
          
        }
        
        private void Expander_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
       
        private void schedule_AppointmentAdded(object sender, DevExpress.Xpf.Scheduling.AppointmentAddedEventArgs e)
        {
           
        }

        private void schedule_AppointmentEdited(object sender, DevExpress.Xpf.Scheduling.AppointmentEditedEventArgs e)
        {
           
        }

        private void schedule_AppointmentRemoved(object sender, DevExpress.Xpf.Scheduling.AppointmentRemovedEventArgs e)
        {
           
        }
    }
}

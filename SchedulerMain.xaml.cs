using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
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

namespace WPF_TEST
{
    /// <summary>
    /// Interaction logic for SchedulerMain.xaml
    /// </summary>
    public partial class SchedulerMain : ThemedWindow
    {
        
        public SchedulerMain()
        {
            InitializeComponent();
            //DataEntity.proessdataappointments.Load();
            //DataEntity.processdatas.Load();
            //this.schedule.DataSource.AppointmentsSource = DataEntity.proessdataappointments.Local;
            //this.schedule.DataSource.ResourcesSource = DataEntity.processdatas.Local;
        }
        
        private void Expander_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void schedule_AppointmentAdded(object sender, DevExpress.Xpf.Scheduling.AppointmentAddedEventArgs e)
        {
            schedule.RefreshData();
        }

        private void schedule_AppointmentEdited(object sender, DevExpress.Xpf.Scheduling.AppointmentEditedEventArgs e)
        {
            schedule.RefreshData();
        }

        private void schedule_AppointmentRemoved(object sender, DevExpress.Xpf.Scheduling.AppointmentRemovedEventArgs e)
        {
            schedule.RefreshData();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class ScheduleViewModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        OutlookInspiredDemoViewModel OutlookInspiredDemoViewModel = new OutlookInspiredDemoViewModel();
        private bool loaded;
        public ScheduleViewModel scheduleViewModel;
        public ScheduleViewModel() 
        {
            if (!loaded)
            {
                scheduleViewModel = this;
                scheduleViewModel.SelectedViewModel = OutlookInspiredDemoViewModel;
                loaded = true;
            }
        }
    }
}

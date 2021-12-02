using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Data;
namespace WPF_TEST.ViewModel
{
    public class Work_Edit_ViewModel:BaseViewModel
    {
        public ICommand UndoSelect { get; set; }
        public ICommand SelectedWork { get; set; }
        public ICommand AddSelectjob { get; set; }

        public static ObservableCollection<Works> _work;
        public ObservableCollection<Works> WorksList
        {

            get { return _work; }
            set { SetProperty(ref _work, value, nameof(WorksList)); }
        }
        private Works _selectedwork;
        public Works Selected_Work
        {
            get
            {
                return _selectedwork;
            }
            set
            {
                SetProperty(ref _selectedwork, value, nameof(Selected_Work));
            }
        }

        public static ObservableCollection<Works> _Work_Library;
        public ObservableCollection<Works> Work_Library
        {
            get { return _Work_Library; }
            set { SetProperty(ref _Work_Library, value, nameof(Work_Library)); }
        }
        public Work_Edit_ViewModel() 
        {
            Work_Library = AddProjectSchedule_ViewModel._Work_Library;
            AddSelectjob = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                try
                {
                    var ss = Work_Library.Where(m => m.Selected == true).ToList();
                    WorksList = new ObservableCollection<Works>();
                    for (int i = 0; i < ss.Count; i++)
                    {
                        WorksList.Add(ss.ElementAt(i));
                    }
                }
                catch (Exception)
                {


                }


            });
            SelectedWork = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    Selected_Work = (Works)p;
                }
                catch (Exception ex)
                {


                }
            });
            UndoSelect = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (WorksList.Count != 0)
                {
                    WorksList.Clear();
                    foreach (var item in Work_Library)
                    {
                        if (item.Selected) item.Selected = false;
                    }

                }

            });
        }
    }
}

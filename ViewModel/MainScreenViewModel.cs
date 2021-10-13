using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class MainScreenViewModel: BaseViewModel
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
        public ICommand DataStreamCollectionModel_Command { get; set; }
        public ICommand MyProperty { get; set; }
        DataStreamCollectionModel DataStreamCollectionModel = new DataStreamCollectionModel();
        public MainScreenViewModel mainScreenViewModel;
        public bool loadMain = false;
        public MainScreenViewModel() 
        {
            if (!loadMain) 
            {
                mainScreenViewModel = this;
                loadMain = true;
            }
            DataStreamCollectionModel_Command = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                mainScreenViewModel.SelectedViewModel = DataStreamCollectionModel;
            });
        }
        ~MainScreenViewModel() 
        {
            
        }
    }
}

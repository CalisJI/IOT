using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class MainMenuModel:BaseViewModel
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
       
        public bool loaded = false;
        MainMenuModel mainMenuModel;
        public MainMenuModel() 
        {
            if (!loaded)
            {
                mainMenuModel = this;
                loaded = true;
            }
            
        }
    }
}

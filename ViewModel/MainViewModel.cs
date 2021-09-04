using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
     public class MainViewModel : BaseViewModel
     {
        public bool Isload { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadConfiguration { get; set; }

        public BaseViewModel CurrentModel { get; }
        public MainViewModel() 
        {

            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Isload = true;
                Login_form login_Form = new Login_form();
                login_Form.ShowDialog();
            });
            LoadConfiguration = new RelayCommand<object>((p) => { return true; }, (p) => { Configuration configuration = new Configuration(); configuration.ShowDialog(); });
        }
     }
}

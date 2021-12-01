using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Data;

namespace WPF_TEST.ViewModel
{
    public class Access_Managerment_ViewModel:BaseViewModel
    {
        public ICommand Selected { get; set; }
        private UserAccount account;
        public UserAccount SelectedUser 
        {
            get 
            {
                return account;
            }
            set 
            {
                SetProperty(ref account, value, nameof(SelectedUser));
            }    
        }
        public Access_Managerment_ViewModel() 
        {
            Selected = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var a = (UserAccount)p;
                SelectedUser = a;
            });
        }
    }
}

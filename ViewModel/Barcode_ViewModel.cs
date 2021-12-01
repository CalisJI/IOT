using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.View;

namespace WPF_TEST.ViewModel
{
    public class Barcode_ViewModel:BaseViewModel
    {
        public static ObservableCollection<string> _barcode;
        public ObservableCollection<string> ResultBarCode 
        {
            get 
            {
                return _barcode;
            }
            set 
            {
                SetProperty(ref _barcode, value, nameof(ResultBarCode));
            }
        }
        
        public ICommand GetSource { get; set; }
        public Barcode_ViewModel() 
        {
            
            GetSource = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
        }
    }
}

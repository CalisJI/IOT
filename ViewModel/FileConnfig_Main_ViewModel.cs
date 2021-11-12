using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
    public class FileConnfig_Main_ViewModel:BaseViewModel
    {
        private BaseViewModel _selectedModel;
        public BaseViewModel SelectedViewModel 
        {
            get { return _selectedModel; }
            set 
            {
                SetProperty(ref _selectedModel, value, nameof(SelectedViewModel));
            }
        }
        public ICommand XML
        { get; set; }
        public ICommand Excel_CSV{ get; set; }
        public ICommand Txt { get; set; }

        public static bool loaded = false;
        public ExcelFileConfig_ViewModel ExcelFileConfig_ViewModel = new ExcelFileConfig_ViewModel();
        FileConnfig_Main_ViewModel fileConnfig_Main_ViewModel;
        
        public FileConnfig_Main_ViewModel() 
        {
            if (!loaded) 
            {
                fileConnfig_Main_ViewModel = this;
                fileConnfig_Main_ViewModel.SelectedViewModel = ExcelFileConfig_ViewModel;

                loaded = true;
            }
        }
    }
}

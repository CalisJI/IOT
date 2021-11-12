using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WPF_TEST.ViewModel
{
    public class ConfigurationModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public ICommand UpdateViewCommand { get; set; }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        bool loaded = false;
        private ConfigurationModel configurationModel;
        public ConfigurationModel() 
        {
            if (!loaded) 
            {
                configurationModel = this;
                loaded = true;
            }
            UpdateViewCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                if (p.ToString() == "AMDashBoard")
                {
                    this.configurationModel.SelectedViewModel = new AMDashBoardModel();

                }
            });
            //UpdateViewCommand = new UpdateViewCommand(this);
        }

    }
}

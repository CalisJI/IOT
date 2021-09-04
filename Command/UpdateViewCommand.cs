using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.ViewModel;

namespace WPF_TEST.Command
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private DataStreamCollectionModel dataStreamCollectionModel;
     

        public UpdateViewCommand(DataStreamCollectionModel dataStreamCollectionModel)
        {
            this.dataStreamCollectionModel = dataStreamCollectionModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Main_menu")
            {
                dataStreamCollectionModel.SelectedViewModel = new MainMenuModel();
            }
            else if (parameter.ToString() == "PMDashBoard")
            {

            }
            else if (parameter.ToString() == "MyAppraval")
            {

            }
            else if (parameter.ToString() == "Configuration")
            {

            }
            else if (parameter.ToString() == "Checklist")
            {

            }

        }
    }
}

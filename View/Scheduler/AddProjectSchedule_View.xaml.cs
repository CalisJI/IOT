using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_TEST.ViewModel;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for AddProjectSchedule_View.xaml
    /// </summary>
    public partial class AddProjectSchedule_View : UserControl
    {
        AddProjectSchedule_ViewModel AddProjectSchedule_ViewModel = AddProjectSchedule_ViewModel._AddProjectSchedule_ViewModel;
        private static AddProjectSchedule_View _View;
        DispatcherTimer DispatcherTimer = new DispatcherTimer();
        public static AddProjectSchedule_View INS_AddProjectSchedule_View 
        {
            get 
            {
                if (_View != null) 
                {
                    return _View;
                }
                else 
                {
                    return new AddProjectSchedule_View();                
                }
            }
            set 
            {
                
            }
        }
        //public void settext(string code) 
        //{
            
        //    Barcodetbx.Text = code;

        //    AddProjectSchedule_ViewModel.BarcodeApply.CanExecute(code);
        //    AddProjectSchedule_ViewModel.BarcodeApply.Execute(code);
        //    this.Barcodetbx.Focus();
        //}
        public AddProjectSchedule_View()
        {
            InitializeComponent();
          
        }

       
        private void Barcodetbx_TargetUpdated(object sender, DataTransferEventArgs e)
        {
           

        }

        private void Barcodetbx_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
            {
                
            }
        }
    }
}

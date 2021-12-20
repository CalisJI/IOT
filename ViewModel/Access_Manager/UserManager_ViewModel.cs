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
    public class UserManager_ViewModel:Barcode_ViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel 
        {
            get 
            {
                return _selectedViewModel;
            }
            set 
            {
                SetProperty(ref _selectedViewModel, value, nameof(SelectedViewModel));
            }
        }

        private static UserManager_ViewModel model;
        public static UserManager_ViewModel INSUserManager_ViewModel 
        {
            get 
            {
                if (model != null) 
                {
                    return model;
                }
                else 
                {
                    return  new UserManager_ViewModel();
                }
            }
            set 
            {
                model = value;
            }
        }

        private ObservableCollection<UserSchedule> schedule;
        public ObservableCollection<UserSchedule> PersonnelWorkTime
        {
            get 
            {
                return schedule;
            }
            set 
            {
                SetProperty(ref schedule, value, nameof(PersonnelWorkTime));
            }
        }
        public ICommand Loadcmd { get; set; }
        public ICommand FrameSchedule_Loaded { get; set; }
        public ICommand FrameCertification_Loaded { get; set; }

        public ICommand OpenedSchedule_View { get; set; }
        public ICommand OpenedCertification_View { get; set; }

        private UserAccount user;
        public UserAccount CurrentAccount
        {
            get { return user; }
            set
            {
                SetProperty(ref user, value, nameof(CurrentAccount));
            }
        }

        Frame_Certification_ViewModel Frame_Certification_ViewModel = new Frame_Certification_ViewModel();
        Frame_Schedule_ViewModel Frame_Schedule_ViewModel = new Frame_Schedule_ViewModel();
        public UserManager_ViewModel() 
        {
            CurrentAccount = Login_ViewModel.LoginAcount;

            FrameSchedule_Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Loading_Indicator.Finished();
            });

            FrameCertification_Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Loading_Indicator.Finished();
            });

            OpenedCertification_View = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Loading_Indicator.BeingBusy();
                SelectedViewModel = Frame_Certification_ViewModel;
                
            });
            OpenedSchedule_View = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Loading_Indicator.BeingBusy();
                SelectedViewModel = Frame_Schedule_ViewModel;
            });
            Loadcmd = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                CurrentAccount = Login_ViewModel.LoginAcount;
                SelectedViewModel = Frame_Schedule_ViewModel;
                Loading_Indicator.Finished();
            });
        }
    }
}

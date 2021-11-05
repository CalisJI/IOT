using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TEST.ViewModel
{
     public class Content_Manager_ViewModel:BaseViewModel
     {
        public static ImageManager_ViewModel ImageManager_ViewModel = new ImageManager_ViewModel();
        public static AudioManager_ViewModel AudioManager_ViewModel = new AudioManager_ViewModel();
        public static VideoManager_ViewModel VideoManager_ViewModel = new VideoManager_ViewModel();
        public static DocumentManager_ViewModel DocumentManager_ViewModel = new DocumentManager_ViewModel();
        private BaseViewModel _selectedViewmodel;
        public BaseViewModel SelectedViewModel 
        {
            get { return _selectedViewmodel; }
            set 
            {
                SetProperty(ref _selectedViewmodel, value, nameof(SelectedViewModel));
            }
        }
        public Content_Manager_ViewModel content_Manager_ViewModel;

        public ICommand Image_Manager { get; set; }
        public ICommand Audio_Manager { get; set; }
        public ICommand Video_Manager { get; set; }
        public ICommand Document_Manager { get; set; }
        private bool load = false;

        public Content_Manager_ViewModel() 
        {
            if (!load) 
            {
                content_Manager_ViewModel = this;
                load = true;
            }
            Image_Manager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                content_Manager_ViewModel.SelectedViewModel = ImageManager_ViewModel;
            });
            Audio_Manager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                content_Manager_ViewModel.SelectedViewModel = AudioManager_ViewModel;
            });
            Video_Manager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                content_Manager_ViewModel.SelectedViewModel = VideoManager_ViewModel;
            });
            Document_Manager = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                content_Manager_ViewModel.SelectedViewModel = DocumentManager_ViewModel;
            });
        }
     }
}

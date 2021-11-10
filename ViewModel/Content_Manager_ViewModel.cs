using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.Data;

namespace WPF_TEST.ViewModel
{
     public class Content_Manager_ViewModel:BaseViewModel
     {
        public static ImageManager_ViewModel ImageManager_ViewModel = new ImageManager_ViewModel();
        public static AudioManager_ViewModel AudioManager_ViewModel = new AudioManager_ViewModel();
        public static VideoManager_ViewModel VideoManager_ViewModel = new VideoManager_ViewModel();
        public static DocumentManager_ViewModel DocumentManager_ViewModel = new DocumentManager_ViewModel();
        #region Model of Media

        private string _linkVideo;
        public string Linkvideo 
        {
            get 
            {
                return _linkVideo;
            }
            set 
            {
                SetProperty(ref _linkVideo, value, nameof(Linkvideo));
            }
        }

        private string _type;
        public string VideoType
        {
            get
            {
                return _type;
            }
            set
            {
                SetProperty(ref _type, value, nameof(VideoType));
            }
        }

        private string _version;
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                SetProperty(ref _version, value, nameof(Version));
            }
        }

        private string _videoGroup;
        public string VideoGroup
        {
            get
            {
                return _videoGroup;
            }
            set
            {
                SetProperty(ref _videoGroup, value, nameof(VideoGroup));
            }
        }

        private string _videoCategory;
        public string VideoCategory
        {
            get
            {
                return _videoCategory;
            }
            set
            {
                SetProperty(ref _videoCategory, value, nameof(VideoCategory));
            }
        }
        private ImageObject _image;
        public ImageObject Image_
        {
            get 
            {
                return _image;
            }
            set 
            {
                SetProperty(ref _image, value, nameof(Image_));
            } 
        }
        private VideoObject _video;
        public VideoObject video 
        {
            get { return _video; }
            set 
            {
                SetProperty(ref _video, value, nameof(video));
            }
        }

        private Uri _uri;
        public Uri Uri 
        {
            get 
            {
                return _uri;
            }
            set 
            {
                SetProperty(ref _uri, value, nameof(Uri));
            } 
        }
        private ObservableCollection<ImageObject> _imageObject;
        public ObservableCollection<ImageObject> ImageObjects 
        {
            get 
            {
                return _imageObject;   
            }
            set 
            {
                SetProperty(ref _imageObject, value, nameof(ImageObjects));
            }
        }
        private ObservableCollection<VideoObject> _videoObject;
        public ObservableCollection<VideoObject> VideoObjects 
        {
            get { return _videoObject; }
            set { SetProperty(ref _videoObject, value, nameof(VideoObjects)); }
        }
        #endregion
        private static bool load = false;
        private void AddVideo() 
        {
            VideoObject videoObject1 = new VideoObject();
            videoObject1.LinkVideo = @"F:\Video\WIN_20211014_17_23_57_Pro.mp4";
            videoObject1.Type = "Test";
            videoObject1.Version = "1.1";
            videoObject1.VideoGroup = "FWD";
            videoObject1.Category = "unknown";
            VideoObjects.Add(videoObject1);
            VideoObject videoObject2 = new VideoObject();
            videoObject2.LinkVideo = @"\\192.168.2.174\CloudFWD\FWD Automation.wmv";
            videoObject2.Type = "Test2";
            videoObject2.Version = "1.1";
            videoObject2.VideoGroup = "FWD1";
            videoObject2.Category = "unknown2";
            VideoObjects.Add(videoObject2);
        }
        private void AddImage() 
        {
            ImageObject imageObject = new ImageObject();

            imageObject.ImageName = "Hình 1";
            imageObject.LinkImage = @"\\192.168.2.174\CloudFWD\Hinh1.jpg";
            imageObject.ImageGroup = "Test";
            imageObject.ImageType = "Electric";
            imageObject.ImageVersion = 1.1f;
            imageObject.ImgaeCategory = "unknown";
            imageObject.ImageDateUpLoad = DateTime.Now + TimeSpan.FromDays(3);
            ImageObjects.Add(imageObject);

            ImageObject imageObject1 = new ImageObject();

            imageObject1.ImageName = "Hình 1";
            imageObject1.LinkImage = @"\\192.168.2.174\CloudFWD\Hinh2.jpg";
            imageObject1.ImageGroup = "Test";
            imageObject1.ImageType = "Electric";
            imageObject1.ImageVersion = 1.1f;
            imageObject1.ImgaeCategory = "unknown";
            imageObject1.ImageDateUpLoad = DateTime.Now + TimeSpan.FromDays(3);
            ImageObjects.Add(imageObject1);

            ImageObject imageObject2 = new ImageObject();

            imageObject2.ImageName = "Hình 1";
            imageObject2.LinkImage = @"\\192.168.2.174\CloudFWD\Hinh3.jpg";
            imageObject2.ImageGroup = "Test";
            imageObject2.ImageType = "Electric";
            imageObject2.ImageVersion = 1.1f;
            imageObject2.ImgaeCategory = "unknown";
            imageObject2.ImageDateUpLoad = DateTime.Now + TimeSpan.FromDays(3);
            ImageObjects.Add(imageObject2);

            ImageObject imageObject3 = new ImageObject();

            imageObject3.ImageName = "Hình 1";
            imageObject3.LinkImage = @"\\192.168.2.174\CloudFWD\Hinh4.jpg";
            imageObject3.ImageGroup = "Test";
            imageObject3.ImageType = "Electric";
            imageObject3.ImageVersion = 1.1f;
            imageObject3.ImgaeCategory = "unknown";
            imageObject3.ImageDateUpLoad = DateTime.Now + TimeSpan.FromDays(3);
            ImageObjects.Add(imageObject3);

            ImageObject imageObject4 = new ImageObject();

            imageObject4.ImageName = "Hình 1";
            imageObject4.LinkImage = @"\\192.168.2.174\CloudFWD\Hinh5.jpg";
            imageObject4.ImageGroup = "Test";
            imageObject4.ImageType = "Electric";
            imageObject4.ImageVersion = 1.1f;
            imageObject4.ImgaeCategory = "unknown";
            imageObject4.ImageDateUpLoad = DateTime.Now + TimeSpan.FromDays(3);
            ImageObjects.Add(imageObject4);

        }
        public ICommand SelectVideoItem { get; set; }
        public ICommand SelectImageItem { get; set; }
        public ICommand SelectAudioItem { get; set; }
        public ICommand SelectDocumentItem { get; set; }
        public Content_Manager_ViewModel() 
        {
            if (!load) 
            {
                ImageObjects = new ObservableCollection<ImageObject>();
                VideoObjects = new ObservableCollection<VideoObject>();
                AddVideo();
                AddImage();
            }
            SelectVideoItem = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var c = (VideoObject)p;
                Uri = new Uri(c.LinkVideo);
                video = c;
            });
            SelectAudioItem = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
            SelectDocumentItem = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
            SelectImageItem = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var c = (ImageObject)p;
                Image_ = c;
            });
        }
     }
    public class PageInfoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Format("PAGE: {0} OF {1}", values[0], values[1]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF_TEST.Data;
using MySql.Data;
using MySql;
using WPF_TEST.Class_Resource;
using MySql.Data.MySqlClient;

namespace WPF_TEST.ViewModel
{
     public class Content_Manager_ViewModel:BaseViewModel
     {
        public static ImageManager_ViewModel ImageManager_ViewModel = new ImageManager_ViewModel();
        public static AudioManager_ViewModel AudioManager_ViewModel = new AudioManager_ViewModel();
        public static VideoManager_ViewModel VideoManager_ViewModel = new VideoManager_ViewModel();
        public static DocumentManager_ViewModel DocumentManager_ViewModel = new DocumentManager_ViewModel();
        public static DataTable VideoObjectTable = new DataTable();
        public static DataTable ImageObjectTable = new DataTable();
        public static DataTable AudioObjectTable = new DataTable("AudioObject");
        public static DataTable DocumentObjectTable = new DataTable("DocumentObject");
        Sqlexcute Sqlexcute = new Sqlexcute();

        private static Content_Manager_ViewModel _content_Manager_ViewModel = new Content_Manager_ViewModel();
        public static Content_Manager_ViewModel INS_Content_Manager_ViewModel 
        {
            get 
            {
                if (_content_Manager_ViewModel != null) 
                {
                    return _content_Manager_ViewModel;
                }
                else 
                {
                    return new Content_Manager_ViewModel();
                }
            }
            set 
            {
                _content_Manager_ViewModel = value;
            }
        }

       
       
        private static ObservableCollection<AudioObject> _audioObjects;
        public ObservableCollection<AudioObject> AudioObjects 
        {
            get
            {
                return _audioObjects;
            }
            set 
            {
                SetProperty(ref _audioObjects, value, nameof(AudioObjects));
            }
        }
        private static ObservableCollection<DocumentObject> _documentObjects;
        public ObservableCollection<DocumentObject> DocumentObjects 
        {
            get { return _documentObjects; }
            set { SetProperty(ref _documentObjects, value, nameof(DocumentObjects)); }
        }
        private static ObservableCollection<ImageObject> _imageObject;
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
        private static ObservableCollection<VideoObject> _videoObject;
        public  ObservableCollection<VideoObject> VideoObjects 
        {
            get { return _videoObject; }
            set { SetProperty(ref _videoObject, value, nameof(VideoObjects)); }
        }
       
        private static bool load = false;
        private MySqlDataAdapter mySqlDataAdapter;

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
        private void AddDocumnet()
        {
            DocumentObject documentObject = new DocumentObject();
            documentObject.LinkDocument = "";
            documentObject.DocumentCategory = "";
            documentObject.DocumentDateUpLoad = DateTime.Now - TimeSpan.FromDays(1);
            documentObject.DocumentGroup = "";
            documentObject.DocumentName = "Document1";
            documentObject.DocumentType = "unknown";
            documentObject.DocumentVersion = 1.1f;
            DocumentObjects.Add(documentObject);

            DocumentObject documentObject1 = new DocumentObject();
            documentObject1.LinkDocument = "";
            documentObject1.DocumentCategory = "";
            documentObject1.DocumentDateUpLoad = DateTime.Now - TimeSpan.FromDays(1);
            documentObject1.DocumentGroup = "";
            documentObject1.DocumentName = "Document2";
            documentObject1.DocumentType = "unknown";
            documentObject1.DocumentVersion = 1.1f;
            DocumentObjects.Add(documentObject1);
        }

        private void AddAudio()
        {
            AudioObject audioObject = new AudioObject();
            audioObject.AudioCategory = "unknown";
            audioObject.AudioDateupLoad = DateTime.Now + TimeSpan.FromDays(5);
            audioObject.AudioGroup = "";
            audioObject.AudioName = "Audio1";
            audioObject.AudioType = "Type1";
            audioObject.AudioVersion = 1.0f;
            audioObject.LinkAudio = "";

            AudioObjects.Add(audioObject);

            AudioObject audioObject1 = new AudioObject();
            audioObject1.AudioCategory = "unknown";
            audioObject1.AudioDateupLoad = DateTime.Now + TimeSpan.FromDays(5);
            audioObject1.AudioGroup = "";
            audioObject1.AudioName = "Audio2";
            audioObject1.AudioType = "Type2";
            audioObject1.AudioVersion = 1.0f;
            audioObject1.LinkAudio = "";

            AudioObjects.Add(audioObject1);
        }
        private void AddImage() 
        {
           

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
      
        
        public ICommand SelectAudioItem { get; set; }
        public ICommand SelectDocumentItem { get; set; }
        public Content_Manager_ViewModel() 
        {
            if (!load) 
            {
                int check = 2;
                int check1 = 2;
                int check2 = 2;
                int check3 = 2;
                bool check_ = true;
                bool exist_ = true;
                ImageObjects = new ObservableCollection<ImageObject>();
                VideoObjects = new ObservableCollection<VideoObject>();
                DocumentObjects = new ObservableCollection<DocumentObject>();
                AudioObjects = new ObservableCollection<AudioObject>();
                //AddVideo();
                //AddImage();
                //Sqlexcute.Server = "112.78.2.9";
                //Sqlexcute.pwd = "Fwd@2021";
                //Sqlexcute.UId = "fwd63823_fwdvina";
                Sqlexcute.Check_Table("fwd63823_database", VideoObjectTable.TableName, ref check);
                Sqlexcute.Check_Table("fwd63823_database", ImageObjectTable.TableName, ref check1);
                Sqlexcute.Check_Table("fwd63823_database", AudioObjectTable.TableName, ref check2);
                Sqlexcute.Check_Table("fwd63823_database", DocumentObjectTable.TableName, ref check3);

                if (check == 0)
                {

                    VideoObjectTable = Sqlexcute.FillToDataTable<VideoObject>(VideoObjects);
                  
                    Sqlexcute.AutoCreateTable(VideoObjectTable, "fwd63823_database", VideoObjectTable.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref VideoObjectTable, VideoObjectTable.TableName, "fwd63823_database");
                    AddVideo();
                    VideoObjectTable = Sqlexcute.FillToDataTable<VideoObject>(VideoObjects);
                    Sqlexcute.Update_Table_to_Host(VideoObjectTable, "fwd63823_database", VideoObjectTable.TableName);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref VideoObjectTable, VideoObjectTable.TableName, "fwd63823_database");
                    VideoObjects = Sqlexcute.Conver_From_Data_Table_To_List<VideoObject>(VideoObjectTable);
                }
                if (check1 == 0)
                {

                    
                    ImageObjectTable = Sqlexcute.FillToDataTable<ImageObject>(ImageObjects);
                    Sqlexcute.AutoCreateTable(ImageObjectTable, "fwd63823_database", ImageObjectTable.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref ImageObjectTable, ImageObjectTable.TableName, "fwd63823_database");
                    AddImage();
                    ImageObjectTable = Sqlexcute.FillToDataTable<ImageObject>(ImageObjects);
                    Sqlexcute.Update_Table_to_Host(ImageObjectTable, "fwd63823_database", ImageObjectTable.TableName);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref ImageObjectTable, ImageObjectTable.TableName, "fwd63823_database");
                    ImageObjects = Sqlexcute.Conver_From_Data_Table_To_List<ImageObject>(ImageObjectTable);
                }
                if (check3 == 0)
                {
                    
                    DocumentObjectTable = Sqlexcute.FillToDataTable(DocumentObjects);
                    Sqlexcute.AutoCreateTable(DocumentObjectTable, "fwd63823_database", DocumentObjectTable.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref DocumentObjectTable, DocumentObjectTable.TableName, "fwd63823_database");
                    AddDocumnet();
                    DocumentObjectTable = Sqlexcute.FillToDataTable<DocumentObject>(DocumentObjects);
                    Sqlexcute.Update_Table_to_Host( DocumentObjectTable, "fwd63823_database", DocumentObjectTable.TableName);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref DocumentObjectTable, DocumentObjectTable.TableName, "fwd63823_database");
                    DocumentObjects = Sqlexcute.Conver_From_Data_Table_To_List<DocumentObject>(DocumentObjectTable);
                }
                if (check2 == 0)
                {

                    AudioObjectTable = Sqlexcute.FillToDataTable<AudioObject>(AudioObjects);
                    Sqlexcute.AutoCreateTable(AudioObjectTable, "fwd63823_database", AudioObjectTable.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref AudioObjectTable, AudioObjectTable.TableName, "fwd63823_database");
                    AddAudio();
                    AudioObjectTable = Sqlexcute.FillToDataTable<AudioObject>(AudioObjects);
                    Sqlexcute.Update_Table_to_Host(AudioObjectTable, "fwd63823_database", AudioObjectTable.TableName);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref AudioObjectTable, AudioObjectTable.TableName, "fwd63823_database");
                    AudioObjects = Sqlexcute.Conver_From_Data_Table_To_List<AudioObject>(AudioObjectTable);
                }
            }
            
            SelectAudioItem = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
            SelectDocumentItem = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
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

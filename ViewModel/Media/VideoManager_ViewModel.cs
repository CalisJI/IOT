using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Data;
using WPF_TEST.Notyfication;
using System.IO;
using System.Windows.Forms;
using WPF_TEST.Class_Resource;
using System.Data;
using MySql.Data.MySqlClient;

namespace WPF_TEST.ViewModel
{
    public class VideoManager_ViewModel:BaseViewModel
    {

        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        public static DataTable VideoObjectTable = new DataTable();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataProvider DataProvider = DataProvider.INS;
        
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
        private ObservableCollection<VideoObject> _videoObject;
        public ObservableCollection<VideoObject> VideoObjects
        {
            get { return _videoObject; }
            set { SetProperty(ref _videoObject, value, nameof(VideoObjects)); }
        }

        private bool e_done;
        public bool E_Done 
        {
            get 
            {
                return e_done;
            }
            set 
            {
                SetProperty(ref e_done, value, nameof(E_Done));
            }
        }

        private MySqlDataAdapter mySqlDataAdapter;

        public ICommand FrameVideoLoad { get; set; }
        public ICommand EditExcute { get; set; }
        public ICommand SelectVideoItem { get; set; }
        public ICommand DoneEdit { get; set; }
        public ICommand Delete_Video { get; set; }
        public ICommand OpentoAdd { get; set; }

        public VideoManager_ViewModel() 
        {
            SelectVideoItem = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var c = (VideoObject)p;
                    Uri = new Uri(c.LinkVideo);
                    video = c;
                }
                catch (Exception ex)
                {

                   
                }
               
            });
            OpentoAdd = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    VideoObject videoObject = new VideoObject();
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        File.Copy(openFileDialog.FileName, DataProvider.CloudConfig.ElementAt(0).VideoFolder + @"/" + openFileDialog.SafeFileName);
                        videoObject.LinkVideo = DataProvider.CloudConfig.ElementAt(0).VideoFolder + @"/" + openFileDialog.SafeFileName;
                        videoObject.VideoGroup = "";
                        videoObject.Version = "";
                        videoObject.Category = "";
                        VideoObjects.Add(videoObject);
                    }
                }
                catch (Exception ex)
                {

                    messageBoxService.ShowMessage("Lỗi: \n"+ ex.Message+"", "Thêm Video", System.Messaging.MessageType.Report);
                }
                

            });
            Delete_Video = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var a = (VideoObject)p;
                    VideoObjects.Remove(a);
                }
                catch (Exception ex)
                {
                    messageBoxService.ShowMessage(ex.Message, "Lỗi Xóa Video", System.Messaging.MessageType.Report);
                    
                }
                

            });
            DoneEdit = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    E_Done = false;

                    VideoObjectTable = Sqlexcute.FillToDataTable<VideoObject>(VideoObjects);
                    Sqlexcute.Update_Table_to_Host(VideoObjectTable, Sqlexcute.Database, VideoObjectTable.TableName);
                    messageBoxService.ShowMessage("Đã Lưu", "Lưu Video", System.Messaging.MessageType.Report);
                }
                catch (Exception ex)
                {

                   
                }
               
            });
            EditExcute = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                E_Done = true;
            });
            FrameVideoLoad = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Loading_Indicator.Finished();

                Content_Manager_ViewModel content_Manager_ViewModel = Content_Manager_ViewModel.INS_Content_Manager_ViewModel;

                VideoObjects = content_Manager_ViewModel.VideoObjects;
            });
        }
    }
}

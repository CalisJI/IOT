using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using WPF_TEST.Class_Resource;
using WPF_TEST.Notyfication;
using System.IO;

namespace WPF_TEST.ViewModel
{
    public class DataConfig_ViewModel: BaseViewModel
    {
        #region Notify
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        #endregion


        #region Model
        private bool enableButton;
        public bool EnabnleButton 
        {
            get 
            {
                return enableButton;
            }
            set 
            {
                SetProperty(ref enableButton, value, nameof(EnabnleButton));
            }
        }

        private string _storagefolder;
        public string Storage 
        {
            get 
            {
                return _storagefolder;
            }
            set 
            {
                SetProperty(ref _storagefolder, value, nameof(Storage));
            }
        }

        private string _video;
        public string VideoStorage 
        {
            get 
            {
                return _video;
            }
            set 
            {
                SetProperty(ref _video, value, nameof(VideoStorage));
            }
        }
        private string _image;
        public string ImageStorage 
        {
            get
            {
                return _image;
            }
            set 
            {
                SetProperty(ref _image, value, nameof(ImageStorage));
            }
        }
        private string _audio;
        public string AudioStorage 
        {
            get 
            {
                return _audio;
            }
            set 
            {
                SetProperty(ref _audio, value, nameof(AudioStorage));
            }
        }
        private string _document;
        public string DocumentStorage 
        {
            get 
            {
                return _document;
            }
            set 
            {
                SetProperty(ref _document, value, nameof(DocumentStorage));
            }
        }
        private DataProvider _DataProvider = DataProvider.INS;
        public DataProvider DataProvider 
        {
            get 
            {
                return _DataProvider;
            }
            set 
            {
                SetProperty(ref _DataProvider, value, nameof(DataProvider));
            }
        }

        #endregion


        const string VideoFolder = "VideoObject";
        const string AudioFolder = "AudioFolder";
        const string ImageFolder = "ImageFolder";
        const string DocumentFolder = "DocumentFolder";

        #region             Command             

        public ICommand  Selectfolder
        { get; set; }
        public ICommand SaveSetting { get; set; }
        #endregion
        public DataConfig_ViewModel() 
        {
            if (DataProvider.CloudConfig.Count != 0) 
            {
                Storage = DataProvider.CloudConfig.ElementAt(0).CloudStorage;
                AudioStorage = DataProvider.CloudConfig.ElementAt(0).AudioFolder;
                VideoStorage = DataProvider.CloudConfig.ElementAt(0).VideoFolder;
                DocumentStorage = DataProvider.CloudConfig.ElementAt(0).DocumentFolder;
                ImageStorage = DataProvider.CloudConfig.ElementAt(0).ImageFolder;
            }
            else 
            {
                DataProvider.CloudConfig.Add(new Data.DatabaseConfig() { AudioFolder = "", CloudStorage = "", VideoFolder = "", ImageFolder = "", DatabaseName = "", DocumentFolder = "" });
                DataProvider.UpLoad_data(4);
            }
            
            Selectfolder = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if(folderBrowserDialog.ShowDialog() == DialogResult.OK) 
                {
                    try
                    {
                        if (DataProvider.CloudConfig.Count != 0) 
                        {
                            if (folderBrowserDialog.SelectedPath != DataProvider.CloudConfig.ElementAt(0).CloudStorage)
                            {
                                Storage = folderBrowserDialog.SelectedPath;
                                VideoStorage = Storage + @"/" + VideoFolder;
                                AudioStorage = Storage + @"/" + AudioFolder;
                                DocumentStorage = Storage + @"/" + DocumentFolder;
                                ImageStorage = Storage + @"/" + ImageFolder;

                                EnabnleButton = true;
                            }
                        }
                        
                        
                    }
                    catch (Exception ex)
                    {

                        messageBoxService.ShowMessage(ex.Message, "Lỗi chọn Folder", System.Messaging.MessageType.Report);
                    }
                    

                }
            });
            SaveSetting = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    DataProvider.CloudConfig.ElementAt(0).CloudStorage = Storage;
                    DataProvider.CloudConfig.ElementAt(0).VideoFolder = VideoStorage;
                    DataProvider.CloudConfig.ElementAt(0).AudioFolder = AudioStorage;
                    DataProvider.CloudConfig.ElementAt(0).DocumentFolder = DocumentStorage;
                    DataProvider.CloudConfig.ElementAt(0).ImageFolder = ImageStorage;
                    DataProvider.UpLoad_data(4);

                    if (!Directory.Exists(VideoStorage)) 
                    {
                        Directory.CreateDirectory(VideoStorage);
                    }
                    if (!Directory.Exists(AudioStorage))
                    {
                        Directory.CreateDirectory(AudioStorage);
                    }
                    if (!Directory.Exists(ImageStorage))
                    {
                        Directory.CreateDirectory(ImageStorage);
                    }
                    if (!Directory.Exists(DocumentStorage))
                    {
                        Directory.CreateDirectory(DocumentStorage);
                    }

                    if (DataProvider.Error_mesage != string.Empty) 
                    {
                        throw new Exception(DataProvider.Error_mesage);
                    }
                    EnabnleButton = false;
                }
                catch (Exception ex)
                {

                    messageBoxService.ShowMessage(ex.Message, "Lỗi Cài Đặt Cloud", System.Messaging.MessageType.Report);
                }
            });
        }
    }
}

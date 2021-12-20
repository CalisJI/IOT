using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using WPF_TEST.Data;
using WPF_TEST.Notyfication;

namespace WPF_TEST.ViewModel
{
    public class ImageManager_ViewModel:BaseViewModel
    {
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataProvider DataProvider = DataProvider.INS;
        public static DataTable ImageObjectTable = new DataTable();
        #region Model
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
        #endregion


        #region Command
        public ICommand SelectImageItem { get; set; }
        public ICommand EditExcute { get; set; }
        public ICommand FrameImageLoaded { get; set; }
        public ICommand DoneEdit { get; set; }
        public ICommand Delete_Image { get; set; }
        public ICommand OpentoAdd { get; set; }
        #endregion
        public ImageManager_ViewModel() 
        {
            SelectImageItem = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var c = (ImageObject)p;
                    Image_ = c;
                }
                catch (Exception ex)
                {

                   
                }
               
            });
            OpentoAdd = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    ImageObject imageObject = new ImageObject();
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        File.Copy(openFileDialog.FileName, DataProvider.CloudConfig.ElementAt(0).ImageFolder + @"/" + openFileDialog.SafeFileName);
                        imageObject.LinkImage = DataProvider.CloudConfig.ElementAt(0).ImageFolder + @"/" + openFileDialog.SafeFileName;
                        imageObject.ImageDateUpLoad = DateTime.Now;
                        imageObject.ImageGroup = "";
                        imageObject.ImageName = "";
                        imageObject.ImageType = "";
                        imageObject.ImageVersion = 1.0f;
                        imageObject.ImgaeCategory = "";
                        ImageObjects.Add(imageObject);


                    }
                }
                catch (Exception ex)
                {

                    messageBoxService.ShowMessage("Lỗi Đưỡng Dẫn: \n" + ex.Message + "", "Thêm Video", System.Messaging.MessageType.Report);
                }


            });
            DoneEdit = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    E_Done = false;

                    ImageObjectTable = Sqlexcute.FillToDataTable(ImageObjects);
                    Sqlexcute.Update_Table_to_Host(ImageObjectTable, Sqlexcute.Database, ImageObjectTable.TableName);
                    messageBoxService.ShowMessage("Đã Lưu", "Lưu Ảnh", System.Messaging.MessageType.Report);
                }
                catch (Exception ex)
                {


                }

            });
            Delete_Image = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var a = (ImageObject)p;
                    ImageObjects.Remove(a);
                }
                catch (Exception ex)
                {
                    messageBoxService.ShowMessage(ex.Message, "Lỗi Xóa Ảnh", System.Messaging.MessageType.Report);

                }


            });
            EditExcute = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                E_Done = true;
            });
            FrameImageLoaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Loading_Indicator.Finished();
                Content_Manager_ViewModel content_Manager_ViewModel = Content_Manager_ViewModel.INS_Content_Manager_ViewModel;
                ImageObjects = content_Manager_ViewModel.ImageObjects;
            });
        }
    }
}

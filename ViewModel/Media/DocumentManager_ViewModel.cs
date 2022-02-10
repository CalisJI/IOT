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
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace WPF_TEST.ViewModel
{
    public class DocumentManager_ViewModel:BaseViewModel
    {
       
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataProvider DataProvider = DataProvider.INS;
        public static System.Data.DataTable DocumentObjectTable = new System.Data.DataTable();
        #region Model
        private DocumentObject _document;
        public DocumentObject Document_
        {
            get
            {
                return _document;
            }
            set
            {
                SetProperty(ref _document, value, nameof(Document_));
            }
        }
        private static ObservableCollection<DocumentObject> _documentObject;
        public ObservableCollection<DocumentObject> DocumentObjects
        {
            get
            {
                return _documentObject;
            }
            set
            {
                SetProperty(ref _documentObject, value, nameof(DocumentObjects));
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
        public ICommand FrameDocumentLoaded { get; set; }
        public ICommand DoneEdit { get; set; }
        public ICommand Delete_Image { get; set; }
        public ICommand OpentoAdd { get; set; }
        public ICommand View { get; set; }
        #endregion
        public DocumentManager_ViewModel()
        {
           
            SelectImageItem = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //try
                //{
                //    var c = (DocumentObject)p;
                //    Document_ = c;
                //}
                //catch (Exception ex)
                //{


                //}

            });
            OpentoAdd = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    DocumentObject documentObject = new DocumentObject();
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        File.Copy(openFileDialog.FileName, DataProvider.CloudConfig.ElementAt(0).DocumentFolder + @"/" + openFileDialog.SafeFileName,true);
                        documentObject.DocumentCategory = "";
                        documentObject.DocumentDateUpLoad = DateTime.Now;
                        documentObject.LinkDocument = DataProvider.CloudConfig.ElementAt(0).DocumentFolder + @"/" + openFileDialog.SafeFileName;
                        documentObject.DocumentVersion = 1;
                        documentObject.DocumentGroup = "";
                        documentObject.DocumentType = "";
                        documentObject.DocumentName = "";
                        DocumentObjects.Add(documentObject);

                        DocumentObjectTable = Sqlexcute.FillToDataTable(DocumentObjects);
                        Sqlexcute.Update_Table_to_Host(DocumentObjectTable, Sqlexcute.Database, DocumentObjectTable.TableName);
                        messageBoxService.ShowMessage("Đã Lưu", "Lưu Tài Liệu", System.Messaging.MessageType.Report);
                    }
                }
                catch (Exception ex)
                {

                    messageBoxService.ShowMessage("Lỗi Đưỡng Dẫn: \n" + ex.Message + "", "Thêm Tài Liệu", System.Messaging.MessageType.Report);
                }


            });
            DoneEdit = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    E_Done = false;

                    DocumentObjectTable = Sqlexcute.FillToDataTable(DocumentObjects);
                    Sqlexcute.Update_Table_to_Host(DocumentObjectTable, Sqlexcute.Database, DocumentObjectTable.TableName);
                    messageBoxService.ShowMessage("Đã Lưu", "Lưu Tài Liệu", System.Messaging.MessageType.Report);
                }
                catch (Exception ex)
                {


                }

            });
            Delete_Image = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var a = (DocumentObject)p;
                    DocumentObjects.Remove(a);
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
            FrameDocumentLoaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Loading_Indicator.Finished();
                Content_Manager_ViewModel content_Manager_ViewModel = Content_Manager_ViewModel.INS_Content_Manager_ViewModel;
                DocumentObjects = content_Manager_ViewModel.DocumentObjects;
            });
            View = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    if(Document_.LinkDocument.Contains(".doc")
                    || Document_.LinkDocument.Contains(".docx") 
                    || Document_.LinkDocument.Contains(".docm")
                    || Document_.LinkDocument.Contains(".pdf"))
                    {
                        Application ap = new Application();
                        Document document = ap.Documents.Open(Document_.LinkDocument);
                    }
                   
                }
                catch (Exception ex)
                {
                    messageBoxService.ShowMessage(ex.Message, "Lỗi", System.Windows.MessageBoxImage.Error);
                   
                }
            });
        }
    }
}

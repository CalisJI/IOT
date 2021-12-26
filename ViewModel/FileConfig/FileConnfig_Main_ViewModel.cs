using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.ViewModel.FileConfig;
using WPF_TEST.Notyfication;
using WPF_TEST.FileProcess;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Data;
using WPF_TEST.Data;
using System.Text.Json;
using WPF_TEST.Class_Resource;
using MySql.Data.MySqlClient;
using WPF_TEST.Notyfication;
using System.ComponentModel;

namespace WPF_TEST.ViewModel
{
    public class FileConnfig_Main_ViewModel:BaseViewModel
    {
        DataProvider DataProvider = DataProvider.INS;
        Sqlexcute Sqlexcute = new Sqlexcute();
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        
        
        
        private MySqlDataAdapter mySqlDataAdapter;

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel 
        {
            get { return _selectedViewModel; }
            set 
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public static DataTable _data;
        public DataTable DatatableExcel 
        {

            get { return _data; }
            set
            { 
                SetProperty(ref _data, value, nameof(DatatableExcel)); 
            }
        }
        //public DataTable DataTable = new DataTable();
        private int PageCOunt;
        public int Page_Count 
        {
            get 
            {
                return PageCOunt;
            }
            set 
            {
                SetProperty(ref PageCOunt, value, nameof(Page_Count));
            }
        }
        private static JobTableConfig jobTables;
        public JobTableConfig JobTableConfigs 
        {
            get 
            {
                return jobTables;
            }
            set 
            {
                SetProperty(ref jobTables, value, nameof(jobTables));
            }
        }

        ObservableCollection<string> _pageSheet;
        public ObservableCollection<string> PageSheet 
        {
            get { return _pageSheet; }
            set 
            {
                SetProperty(ref _pageSheet, value, nameof(PageSheet));
            }
        }
        public ObservableCollection<JobOrder> _jobOrder;
        public ObservableCollection<JobOrder> JobOrders 
        {
            get { return _jobOrder; }
            set { SetProperty(ref _jobOrder, value, nameof(JobOrders)); }
        }

        public static DataTable DatatableScheduler = new DataTable("Job Information");
        private ObservableCollection<ConvertoJson> convertoJson;
        public ObservableCollection<ConvertoJson> ToJson
        {
            get { return convertoJson; }
            set { SetProperty(ref convertoJson, value, nameof(ToJson)); }
        }

        private int _percent;
        public int Percentage 
        {
            get 
            {
                return _percent;
            }
            set 
            {
                SetProperty(ref _percent, value, nameof(Percentage));
            }
        }
        private static bool _visible;
        public bool CanSee 
        {
            get 
            {
                return _visible;
            }
            set 
            {
                SetProperty(ref _visible, value, nameof(CanSee));
            }
        }

        public ICommand XML
        { get; set; }
        public ICommand Excel{ get; set; }
        public ICommand CSV { get; set; }
        public ICommand Json { get; set; }
        public ICommand Txt { get; set; }

        public ICommand Openfolder { get; set; }
        public ICommand Changedtable { get; set; }

        public ICommand EXcelLoaded { get; set; }
        public ICommand ApplyExcel { get; set; }

        public ICommand CatDatBang { get; set; }
        public ICommand LuuConfigJob { get; set; }

        public  bool loaded = false;
        ExcelFileConfig_ViewModel ExcelFileConfig_ViewModel = new ExcelFileConfig_ViewModel();
        
        XMLData_ViewModel XMLData_ViewModel = new XMLData_ViewModel();
        JSONData_ViewModel JSONData_ViewModel = new JSONData_ViewModel();
        TXTData_ViewModel TXTData_ViewModel = new TXTData_ViewModel();

        ExcelProcess ExcelProcess = new ExcelProcess();
        MenuFileConfig_ViewModel MenuFileConfig_ViewModel = new MenuFileConfig_ViewModel();
        public FileConnfig_Main_ViewModel fileConnfig_Main_ViewModel;


        #region Threading Funtion
        static BackgroundWorker NhapDuLieu = new BackgroundWorker();
        #endregion


        public FileConnfig_Main_ViewModel() 
        {
            NhapDuLieu.DoWork += NhapDuLieu_DoWork;
            NhapDuLieu.RunWorkerCompleted += NhapDuLieu_RunWorkerCompleted;
            NhapDuLieu.ProgressChanged += NhapDuLieu_ProgressChanged;
            NhapDuLieu.WorkerReportsProgress = true;
            NhapDuLieu.WorkerSupportsCancellation = true;
            
            if (!loaded) 
            {
                fileConnfig_Main_ViewModel = this;
                fileConnfig_Main_ViewModel.SelectedViewModel = MenuFileConfig_ViewModel;
                PageSheet = new ObservableCollection<string>();
                JobOrders = DataProvider.JobOrderInput;

                loaded = true;
            }
            EXcelLoaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                JobOrders = PlannerModel._jobOrder;
                JobtableConfig_Load();
            });
            Excel = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                fileConnfig_Main_ViewModel.SelectedViewModel = ExcelFileConfig_ViewModel;
            });
            CSV = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                fileConnfig_Main_ViewModel.SelectedViewModel = ExcelFileConfig_ViewModel;
            });
            Json = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                fileConnfig_Main_ViewModel.SelectedViewModel = JSONData_ViewModel;
            });
            Txt = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                fileConnfig_Main_ViewModel.SelectedViewModel = TXTData_ViewModel;
            });
            XML = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                fileConnfig_Main_ViewModel.SelectedViewModel = XMLData_ViewModel;
            });
            ApplyExcel = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                CanSee = true;
                NhapDuLieu.RunWorkerAsync();
                
                //ConfigData();
            });

            CatDatBang = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });

            LuuConfigJob = new RelayCommand<object>((p) => { return true; },(p)=>
            {

                UpdateJobConfig(JobTableConfigs);
            });
            #region =====================================================Open Excel===================================================================
            Openfolder = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|Excel Comma Seprate|*.csv" })
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            PageSheet.Clear();
                            PageSheet = new ObservableCollection<string>();

                            if (Path.GetExtension(openFileDialog.FileName) == ".csv")
                            {
                                string[] GetTypeTable = new string[] { };
                                DatatableExcel = ExcelProcess.ReadCsvFile(openFileDialog.FileName);
                                for (int i = 0; i < DatatableExcel.Columns.Count; i++)
                                {
                                    GetTypeTable[i] = DatatableExcel.Columns[i].ColumnName;
                                }
                            }
                            else
                            {
                                ObservableCollection<string> vs = new ObservableCollection<string>();
                                ExcelProcess.Get_excel(openFileDialog.FileName, ref vs);
                                PageSheet = vs;
                                Page_Count = PageSheet.Count + 1;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                  
                }
               
            });
            Changedtable = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var c = p.ToString();
                    DatatableExcel = ExcelProcess.DataTableCollection[c];
                }
                catch (Exception ex)
                {

                   
                }
               
            });
            #endregion
        }
        
        private void NhapDuLieu_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Percentage = e.ProgressPercentage;
        }

        private void NhapDuLieu_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CanSee = false;
            if (DataProvider.Error_mesage != string.Empty)
            {
                messageBoxService.ShowMessage(DataProvider.Error_mesage , "Lỗi Nhập Dữ Liệu", System.Windows.MessageBoxImage.Error);
            }
            else 
            {
                messageBoxService.ShowMessage("Đã Lưu", "Nhập Dữ Liệu", System.Windows.MessageBoxImage.Information);
            }
           
        }

        private void NhapDuLieu_DoWork(object sender, DoWorkEventArgs e)
        {
            if (NhapDuLieu.CancellationPending) 
            {
                e.Cancel = true;
            }
            else 
            {
                if (DatatableExcel != null)
                {
                    try
                    {
                        for (int i = 1; i < DatatableExcel.Rows.Count; i++)
                        {
                            JobOrder jobOrder = new JobOrder();
                            string bb = DatatableExcel.Rows[i][JobTableConfigs.SoHieuCongViec_Col].ToString();
                            jobOrder.ID = bb;
                            //jobOrder.SaleOrder = DatatableExcel.Rows[i][1].ToString();
                            jobOrder.Quotation = DatatableExcel.Rows[i][JobTableConfigs.ThamKhao_Col].ToString();
                            //jobOrder.Customer_PO = DatatableExcel.Rows[i][3].ToString();
                            jobOrder.Requested_Report_Date = DateTime.Today;
                            jobOrder.Requested_Start = DateTime.Parse(DatatableExcel.Rows[i][JobTableConfigs.NgayBatDau_Col].ToString());
                            jobOrder.Requested_End = DateTime.Parse(DatatableExcel.Rows[i][JobTableConfigs.NgayKetThuc_Col].ToString());
                            jobOrder.ActualvsPlan = 0;
                            jobOrder.Complete = 0;
                            jobOrder.Priority = TaskPriority.Normal;
                            jobOrder.Stage = Status.Plan;
                            jobOrder.Current_Stage = PlannerModel.getColor(jobOrder.Stage);
                            jobOrder.Customerinformation = new Customer();
                            string Tensanpahm = DatatableExcel.Rows[i][JobTableConfigs.TenSanPham_Col].ToString();
                            string SoLuong = DatatableExcel.Rows[i][JobTableConfigs.SoLuong_Col].ToString();
                            string Masanpahm = DatatableExcel.Rows[i][JobTableConfigs.MaSanPham_Col].ToString();
                            jobOrder.Works = GetWorks(Tensanpahm, SoLuong, Masanpahm);
                            jobOrder.Priority = TaskPriority.Normal;

                            DataProvider.JobOrderInput.Add(jobOrder);
                            double a = (double)i / (double)(DatatableExcel.Rows.Count*2);
                            int b = (int)(a * 100);
                            NhapDuLieu.ReportProgress(b);
                        }



                        DataProvider.UpLoad_data(0);
                        PlannerModel plannerModel = PlannerModel.INS_PlanViewModel;
                        foreach (var item in DataProvider.JobOrderInput)
                        {
                            plannerModel.JobOrders.Add(item);

                        }
                        NhapDuLieu.ReportProgress(75);
                        PlannerModel.Save_EditJob.Execute(null);
                        plannerModel.adruntime();
                        NhapDuLieu.ReportProgress(90);
                        if (DataProvider.Error_mesage != string.Empty)
                        {
                            throw new Exception(DataProvider.Error_mesage);
                        }
                        NhapDuLieu.ReportProgress(100);
                    }
                    catch (Exception ex)
                    {

                        
                    }


                }
            }
        }

       
        public void JobtableConfig_Load() 
        {
            try
            {
                JobTableConfigs = new JobTableConfig();
                JobTableConfigs = XMLConfig.Get_JobtableConfig();
            }
            catch (Exception ex)
            {

                messageBoxService.ShowMessage(ex.Message, "Lỗi Cấu Hình File", System.Windows.MessageBoxImage.Error);
            }
            
        }

        public void RefreshConfig()
        {

            try
            {
                JobTableConfigs = new JobTableConfig();
                JobTableConfigs = XMLConfig.Get_JobtableConfig();
            }
            catch (Exception ex)
            {

                messageBoxService.ShowMessage(ex.Message, "Lỗi Cấu Hình File", System.Windows.MessageBoxImage.Error);
            }
        }

        public void UpdateJobConfig(JobTableConfig jobTableConfig) 
        {
            try
            {
                XMLConfig.Update_JobtableConfig(jobTableConfig);
            }
            catch (Exception ex)
            {

                messageBoxService.ShowMessage(ex.Message, "Lỗi Cập Nhật Cấu Hình File", System.Windows.MessageBoxImage.Error);
            }
            
        }

        public void ConfigData() 
        {
            if (DatatableExcel != null) 
            {
                try
                {
                    for (int i = 1; i < DatatableExcel.Rows.Count; i++)
                    {
                        JobOrder jobOrder = new JobOrder();
                        string bb = DatatableExcel.Rows[i][JobTableConfigs.MaSanPham_Col].ToString();
                        jobOrder.ID = bb;
                        //jobOrder.SaleOrder = DatatableExcel.Rows[i][1].ToString();
                        jobOrder.Quotation = DatatableExcel.Rows[i][JobTableConfigs.ThamKhao_Col].ToString();
                        //jobOrder.Customer_PO = DatatableExcel.Rows[i][3].ToString();
                        jobOrder.Requested_Report_Date = DateTime.Today;
                        jobOrder.Requested_Start = DateTime.Parse(DatatableExcel.Rows[i][JobTableConfigs.NgayBatDau_Col].ToString());
                        jobOrder.Requested_End = DateTime.Parse(DatatableExcel.Rows[i][JobTableConfigs.NgayKetThuc_Col].ToString());
                        jobOrder.ActualvsPlan = 0;
                        jobOrder.Complete = 0;
                        jobOrder.Priority = TaskPriority.Normal;
                        jobOrder.Stage = Status.Plan;
                        jobOrder.Current_Stage = PlannerModel.getColor(jobOrder.Stage);
                        //jobOrder.Customerinformation = CustomerSetting_ViewModel.customers.Where(x =>
                        //                                                                         x.Customer_Info == DatatableExcel.Rows[i][7].ToString()
                        //                                                                         && x.Address == DatatableExcel.Rows[i][8].ToString()).FirstOrDefault();
                        //var a = ScanWork();
                        string Tensanpahm = DatatableExcel.Rows[i][JobTableConfigs.TenSanPham_Col].ToString();
                        string SoLuong = DatatableExcel.Rows[i][JobTableConfigs.SoLuong_Col].ToString();
                        string Masanpahm = DatatableExcel.Rows[i][JobTableConfigs.MaSanPham_Col].ToString();
                        jobOrder.Works = GetWorks(Tensanpahm,SoLuong,Masanpahm);
                        jobOrder.Priority = TaskPriority.Normal;

                        DataProvider.JobOrderInput.Add(jobOrder);
                    }

                    

                    DataProvider.UpLoad_data(0);

                    messageBoxService.ShowMessage("Đã Lưu", "Nhập Dữ Liệu", System.Windows.MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                   
                }
               

            }
        }
         (string[],string[],string[]) ScanWork() 
        {
            string[] W_O = new string[DatatableExcel.Rows.Count];
            string[] remark = new string[DatatableExcel.Rows.Count];
            string[] quantity = new string[DatatableExcel.Rows.Count];
            for (int i = 0; i < DatatableExcel.Rows.Count; i++)
            {
                W_O[i] = DatatableExcel.Rows[i][9].ToString();
                remark[i] = DatatableExcel.Rows[i][10].ToString();
                quantity[i] = DatatableExcel.Rows[i][11].ToString();
            }
            return (W_O, remark, quantity);
        }
        public ObservableCollection<Works> GetWorks(string[] W_O , string[] remark, string[] quantity) 
        {
            ObservableCollection<Works> works = new ObservableCollection<Works>();
            for (int i = 0; i < W_O.Length; i++)
            {
                Works works1 = new Works();
                var get = PlannerModel._work.Where(s => s.WorkOrderName == W_O[i]).FirstOrDefault();
                works1 = get;
                works1.Quantity = int.Parse(quantity[i]);
                works1.Remark = remark[i];
                works.Add(works1);
            }
            return works;
            
        }
        public ObservableCollection<Works> GetWorks(string Tensanpham,string soluong,string masanpham)
        {
            ObservableCollection<Works> works = new ObservableCollection<Works>();
           
            Works works1 = new Works();
                //var get = PlannerModel._work.Where(s => s.WorkOrderName == Tensanpham).FirstOrDefault();
                
            works1.Quantity = int.Parse(soluong);
            works1.WorkOrderName = Tensanpham;
            works1.Product = masanpham;
            works.Add(works1);
           
            return works;

        }
        public Customer Customer_Config(string name) // Find customer
        {
            Customer cc = new Customer();

            foreach (var item in CustomerSetting_ViewModel.customers)
            {
                for (int i = 0; i < item.Customer_Info.Length; i++)
                {

                }
            }

            return cc;
        }
        public void Save_Table()
        {

            DatatableScheduler = new DataTable();
            var Json = JsonSerializer.Serialize(JobOrders);
            try
            {
                ToJson = new ObservableCollection<ConvertoJson>();
                ToJson.Add(new ConvertoJson { Code = Json });
            }
            catch (Exception)
            {

                ToJson = new ObservableCollection<ConvertoJson>();
                ToJson.Add(new ConvertoJson { Code = Json });
            }



            DatatableScheduler = Sqlexcute.FillToDataTable(ToJson);

            Sqlexcute.Update_Table_to_Host( DatatableScheduler, "fwd63823_database", "JobOrder");
            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            else
            {
                messageBoxService.ShowMessage("Đã Lưu", "Thông tin", System.Messaging.MessageType.Report);
            }

        }
    }
    public class JobTableConfig
    {
        public int SoHieuCongViec_Col { get; set; }
        public int SoSeri_Col { get; set; }
        public int MaSanPham_Col { get; set; }
        public int TenSanPham_Col { get; set; }
        public int SoLuong_Col { get; set; }
        public int SoLuowngHoanThanh_Col { get; set; }
        public int NgayBatDau_Col { get; set; }
        public int NgayKetThuc_Col { get; set; }
        public int TinhTrang_Col { get; set; }
        public int ThamKhao_Col { get; set; }
    }
}

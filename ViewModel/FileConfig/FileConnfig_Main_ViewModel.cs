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
        public  bool loaded = false;
        ExcelFileConfig_ViewModel ExcelFileConfig_ViewModel = new ExcelFileConfig_ViewModel();
        
        XMLData_ViewModel XMLData_ViewModel = new XMLData_ViewModel();
        JSONData_ViewModel JSONData_ViewModel = new JSONData_ViewModel();
        TXTData_ViewModel TXTData_ViewModel = new TXTData_ViewModel();

        ExcelProcess ExcelProcess = new ExcelProcess();
        MenuFileConfig_ViewModel MenuFileConfig_ViewModel = new MenuFileConfig_ViewModel();
        public FileConnfig_Main_ViewModel fileConnfig_Main_ViewModel;
       

        public FileConnfig_Main_ViewModel() 
        {
            
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
                ConfigData();
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

        public void ConfigData() 
        {
            if (DatatableExcel != null) 
            {
                try
                {
                    JobOrder jobOrder = new JobOrder();
                    string bb = DatatableExcel.Rows[0][0].ToString();
                    jobOrder.ID = bb;
                    jobOrder.SaleOrder = DatatableExcel.Rows[0][1].ToString();
                    jobOrder.Quotation = DatatableExcel.Rows[0][2].ToString();
                    jobOrder.Customer_PO = DatatableExcel.Rows[0][3].ToString();
                    jobOrder.Requested_Report_Date = DateTime.Parse(DatatableExcel.Rows[0][4].ToString());
                    jobOrder.Requested_Start = DateTime.Parse(DatatableExcel.Rows[0][5].ToString());
                    jobOrder.Requested_End = DateTime.Parse(DatatableExcel.Rows[0][6].ToString());
                    jobOrder.ActualvsPlan = 0;
                    jobOrder.Complete = 0;
                    jobOrder.Priority = TaskPriority.Normal;
                    jobOrder.Stage = Status.Plan;
                    jobOrder.Current_Stage = PlannerModel.getColor(jobOrder.Stage);
                    jobOrder.Customerinformation = CustomerSetting_ViewModel.customers.Where(x =>
                                                                                             x.Customer_Info == DatatableExcel.Rows[0][7].ToString()
                                                                                             && x.Address == DatatableExcel.Rows[0][8].ToString()).FirstOrDefault();
                    var a = ScanWork();
                    jobOrder.Works = GetWorks(a.Item1, a.Item2, a.Item3);
                    jobOrder.Priority = TaskPriority.Normal;

                    DataProvider.JobOrderInput.Add(jobOrder);

                    DataProvider.UpLoad_data(0);

                    messageBoxService.ShowMessage("Đã Lưu", "Nhập Dữ Liệu", System.Messaging.MessageType.Report);
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

            Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, DatatableScheduler, "fwd63823_database", "JobOrder");
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
}

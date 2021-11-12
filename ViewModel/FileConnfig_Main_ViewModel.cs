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

namespace WPF_TEST.ViewModel
{
    public class FileConnfig_Main_ViewModel:BaseViewModel
    {
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
        private DataTable _data;
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



        public ICommand XML
        { get; set; }
        public ICommand Excel{ get; set; }
        public ICommand CSV { get; set; }
        public ICommand Json { get; set; }
        public ICommand Txt { get; set; }

        public ICommand Openfolder { get; set; }
        public ICommand Changedtable { get; set; }
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
                
                loaded = true;
            }
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
            Openfolder = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|Excel Comma Seprate|*.csv" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        PageSheet.Clear();
                        if (Path.GetExtension(openFileDialog.FileName) == ".csv")
                        {
                            DatatableExcel = ExcelProcess.ReadCsvFile(openFileDialog.FileName);
                            
                        }
                        else
                        {
                            ObservableCollection<string> vs = new ObservableCollection<string>();
                            ExcelProcess.Get_excel(openFileDialog.FileName , ref vs);
                            PageSheet = vs;
                        }

                    }
                }
            });
            Changedtable = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                var c = p.ToString();
                DatatableExcel = ExcelProcess.DataTableCollection[c];
            });
        }
    }
}

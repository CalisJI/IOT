using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using WPF_TEST.Data;
using System.Text.Json;
using WPF_TEST.Notyfication;

namespace WPF_TEST.ViewModel
{
    public class PlanSetting_ViewModel : BaseViewModel
    {
        #region Variable
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataTable Table_PlanConfigJson = new DataTable("PlanConfiguration");
        private static string Table_Name = "PlanConfiguration";

        WPFMessageBoxService WPFMessageBoxService = new WPFMessageBoxService();
        #endregion
        private static PlanSetting_ViewModel model;
        public static PlanSetting_ViewModel INS_PlanSetting
        {
            get
            {
                if (model != null)
                {
                    return model;
                }
                else
                {
                    model = new PlanSetting_ViewModel();
                    return model;
                }
            }
            set
            {
                model = value;
            }
        }
        #region Model
        private ObservableCollection<ConvertoJson> jsons;
        public ObservableCollection<ConvertoJson> ToJson
        {
            get 
            {
                return jsons;
            }
            set 
            {
                SetProperty(ref jsons, value, nameof(ToJson));
            }
        }
        private static ObservableCollection<PlanConfiguration> collection;
        public ObservableCollection<PlanConfiguration> PlanConfig
        {
            get 
            {
                return collection;
            }
            set 
            {
                SetProperty(ref collection, value, nameof(PlanConfig));
            }
        }
        private static bool _isEnable = false;
        public bool IsEnable
        {
            get 
            {
                return _isEnable;
            }
            set 
            {
                SetProperty(ref _isEnable, value, nameof(IsEnable));
            }
        }
        #endregion
        #region Icommand

        public ICommand AddNew { get; set; }
        public ICommand Editting { get; set; }
        public ICommand Delete { get; set; }
        public ICommand SaveConfig { get; set; }
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
       

        #endregion
        public PlanSetting_ViewModel() 
        {
            int check = 2;
            PlanConfig = new ObservableCollection<PlanConfiguration>();
            
            Sqlexcute.Check_Table(Sqlexcute.Database, Table_Name, ref check);
            if (check == 0) 
            {
                Initial();
                //var Json = JsonSerializer.Serialize(PlanConfig);
                //try
                //{
                //    ToJson = new ObservableCollection<ConvertoJson>();
                //    ToJson.Add(new ConvertoJson { Code = Json });
                //}
                //catch (Exception)
                //{

                //    ToJson = new ObservableCollection<ConvertoJson>();
                //    ToJson.Add(new ConvertoJson { Code = Json });
                //}
                Table_PlanConfigJson = Sqlexcute.FillToDataTable(PlanConfig);
                Sqlexcute.AutoCreateTable(Table_PlanConfigJson, Sqlexcute.Database, Table_Name);
            }
            else 
            {
                try
                {
                    Sqlexcute.GetData_FroM_Database(ref Table_PlanConfigJson,Table_Name, Sqlexcute.Database);
                    PlanConfig = Sqlexcute.Conver_From_Data_Table_To_List <PlanConfiguration>(Table_PlanConfigJson);
                    PlannerModel.INS_PlanViewModel.PlanConfig = PlanConfig;
                }
                catch (Exception)
                {

                
                }
            }
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            Unloaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            AddNew = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                PlanConfiguration planConfiguration = new PlanConfiguration();
                planConfiguration.TenMay = "New";
                planConfiguration.BarCodes = "Barcode";
                PlanConfig.Add(planConfiguration);
                PlannerModel.INS_PlanViewModel.PlanConfig = PlanConfig;

            });
            Editting = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsEnable = true;
            });
            Delete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (!IsEnable) return;
                var a = (PlanConfiguration)p;
                _ = PlanConfig.Remove(a);
                PlannerModel.INS_PlanViewModel.PlanConfig = PlanConfig;
            });
            SaveConfig = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {

                    MessageInitial();
                    PlannerModel.INS_PlanViewModel.PlanConfig = PlanConfig;
                    Table_PlanConfigJson = Sqlexcute.FillToDataTable(PlanConfig);
                    Sqlexcute.Update_Table_to_Host(Table_PlanConfigJson, Sqlexcute.Database, Table_Name);
                    _ = Sqlexcute.SQL_command(" DELETE S1 FROM " + Table_Name + " AS S1  INNER JOIN " + Table_Name + " AS S2 WHERE S1.TenMay = S2.TenMay AND S1.id < S2.id", Sqlexcute.Database);
                    for (int i = 0; i < PlanConfig.Count; i++)
                    {
                        _ = Sqlexcute.SQL_command("UPDATE `" + Table_Name + "` SET `id` = '" + (i + 1).ToString() + "' WHERE (`TenMay`='" + PlanConfig[i].TenMay + "')", Sqlexcute.Database);
                    }
                    if (Sqlexcute.error_message == "") 
                    {
                        WPFMessageBoxService.ShowMessage("Đã Lưu", "Lưu Cài Đặt", System.Windows.MessageBoxImage.Information);
                        IsEnable = false;
                    }
                    else 
                    {
                        WPFMessageBoxService.ShowMessage(Sqlexcute.error_message, "Lỗi", System.Windows.MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {

                    
                }
            });
        }
        /// <summary>
        /// Đồng bộ bẳng Meaasge và bẳng cấu hình mã barcode của plan
        /// </summary>
        public void MessageInitial() 
        {
            List<int> ID = new List<int>();
            DataTable dataTable = Sqlexcute.Read_data(Sqlexcute.Database, "Massage");
            if (dataTable.Rows.Count != PlanConfig.Count)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(dataTable.Rows[i][0].ToString());
                    ID.Add(id);
                }
                for (int i = 0; i < PlanConfig.Count; i++)
                {
                    if (!ID.Contains(i + 1))
                    {
                        _ = Sqlexcute.SQL_command("INSERT INTO `Massage`(`ID`,`MGS`) VALUES ('" + i + 1 + "','')", Sqlexcute.Database);
                    }
                }
                DataTable dataTable1 = Sqlexcute.Read_data(Sqlexcute.Database, "Massage");
                if (dataTable1.Rows.Count > PlanConfig.Count)
                {
                    for (int i = PlanConfig.Count; i < dataTable1.Rows.Count; i++)
                    {
                        _ = Sqlexcute.SQL_command("DELETE FROM `Message` WHERE (`ID` = '" + (i + 1).ToString() + "')", Sqlexcute.Database);
                    }

                }
            }
        }

        private void Initial() 
        {
            PlanConfig = new ObservableCollection<PlanConfiguration>();
            PlanConfiguration planConfiguration = new PlanConfiguration();
            planConfiguration.BarCodes = "";
            planConfiguration.TenMay = "";
            PlanConfig.Add(planConfiguration);
        }
    }
    public class PlanConfiguration 
    {
       
        public string TenMay { get; set; }
        public string  BarCodes { get; set; }
        
    }
}

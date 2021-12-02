using MySql.Data.MySqlClient;
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
using WPF_TEST.Notyfication;
using System.Text.Json;
using System.Security;
using WPF_TEST.View;
using System.Threading;

namespace WPF_TEST.ViewModel
{
    public class Login_ViewModel:BaseViewModel
    {
        private MySqlDataAdapter mySqlDataAdapter;
        
        public static UserAccount LoginAcount = new UserAccount();
        public static bool LoginSuccess { get; set; }

        WPFMessageBoxService WPFMessageBoxService = new WPFMessageBoxService();
        public DataTable TableUser = new DataTable("User Account");


        private UserAccount account;
        public UserAccount SelectedUser
        {
            get
            {
                return account;
            }
            set
            {
                SetProperty(ref account, value, nameof(SelectedUser));
            }
        }

        public static Permit Permit { get; set; }
        private string _userId;
        private string pass;
        public static int IDuser { get; set; }
        
        public string UserID 
        {
            get 
            {
                return _userId;
            }
            set 
            {
                SetProperty(ref _userId, value, nameof(UserID));
            }
        }

        public string Password 
        {
            private get { return pass; }
            set 
            {
                SetProperty(ref pass, value, nameof(Password));
            }
        }
        private ObservableCollection<ConvertoJson> convert_to_Json;
        public ObservableCollection<ConvertoJson> ToJSON
        {
            get { return convert_to_Json; }
            set 
            {
                SetProperty(ref convert_to_Json, value, nameof(ToJSON));
            }
        }
        private static ObservableCollection<UserAccount> _userAccounts;
        public ObservableCollection<UserAccount> ListUser 
        {
            get 
            {
                return _userAccounts;
            }
            set 
            {
                SetProperty(ref _userAccounts, value, nameof(ListUser));
            }
        }
        public ICommand Login { get; set; }
        public ICommand Selected { get; set; }
        public ICommand Save_permit { get; set; }
        public static bool Loaded { get; set; }

        Sqlexcute Sqlexcute = new Sqlexcute();
        private void  Admin() 
        {
            LoginSuccess = false;
            UserAccount userAccount = new UserAccount();
            userAccount.UserID = 1;
            userAccount.User = "admin";
            userAccount.Pass = Sqlexcute.MD5Genrate("fwd@2021");

            userAccount.Permit.Weekly_Schedule.CacAccess = true;
            userAccount.Permit.Weekly_Schedule.CanAdd = true;
            userAccount.Permit.Weekly_Schedule.CanDelete = true;
            userAccount.Permit.Weekly_Schedule.CanEdit = true;

            userAccount.Permit.ViewJob.CacAccess = true;
            userAccount.Permit.ViewJob.CanAdd = true;
            userAccount.Permit.ViewJob.CanDelete = true;
            userAccount.Permit.ViewJob.CanEdit = true;

            userAccount.Permit.SalesDraft.CacAccess = true;
            userAccount.Permit.SalesDraft.CanAdd = true;
            userAccount.Permit.SalesDraft.CanDelete = true;
            userAccount.Permit.SalesDraft.CanEdit = true;

            userAccount.Permit.ModifySalesItem.CacAccess = true;
            userAccount.Permit.ModifySalesItem.CanAdd = true;
            userAccount.Permit.ModifySalesItem.CanDelete = true;
            userAccount.Permit.ModifySalesItem.CanEdit = true;

            userAccount.Permit.MCPReport.CacAccess = true;
            userAccount.Permit.MCPReport.CanAdd = true;
            userAccount.Permit.MCPReport.CanDelete = true;
            userAccount.Permit.MCPReport.CanEdit = true;

            userAccount.Permit.CompletedJob.CacAccess = true;
            userAccount.Permit.CompletedJob.CanAdd = true;
            userAccount.Permit.CompletedJob.CanDelete = true;
            userAccount.Permit.CompletedJob.CanEdit = true;

            userAccount.Permit.UACC.DataInput = true;
            userAccount.Permit.UACC.Schedule = true;
            userAccount.Permit.UACC.Operator = true;
            userAccount.Permit.UACC.ModifyAccount = true;


            UserAccount userAccount1 = new UserAccount();
            userAccount1.UserID = 2;
            userAccount1.User = "User1";
            userAccount1.Pass = Sqlexcute.MD5Genrate("fwd@2021");

            userAccount1.Permit.Weekly_Schedule.CacAccess = true;
            userAccount1.Permit.Weekly_Schedule.CanAdd = true;
            userAccount1.Permit.Weekly_Schedule.CanDelete = true;
            userAccount1.Permit.Weekly_Schedule.CanEdit = true;

            userAccount1.Permit.ViewJob.CacAccess = true;
            userAccount1.Permit.ViewJob.CanAdd = true;
            userAccount1.Permit.ViewJob.CanDelete = true;
            userAccount1.Permit.ViewJob.CanEdit = true;

            userAccount1.Permit.SalesDraft.CacAccess = true;
            userAccount1.Permit.SalesDraft.CanAdd = true;
            userAccount1.Permit.SalesDraft.CanDelete = true;
            userAccount1.Permit.SalesDraft.CanEdit = true;

            userAccount1.Permit.ModifySalesItem.CacAccess = true;
            userAccount1.Permit.ModifySalesItem.CanAdd = true;
            userAccount1.Permit.ModifySalesItem.CanDelete = true;
            userAccount1.Permit.ModifySalesItem.CanEdit = true;

            userAccount1.Permit.MCPReport.CacAccess = true;
            userAccount1.Permit.MCPReport.CanAdd = true;
            userAccount1.Permit.MCPReport.CanDelete = true;
            userAccount1.Permit.MCPReport.CanEdit = true;

            userAccount1.Permit.CompletedJob.CacAccess = true;
            userAccount1.Permit.CompletedJob.CanAdd = true;
            userAccount1.Permit.CompletedJob.CanDelete = true;
            userAccount1.Permit.CompletedJob.CanEdit = true;

            userAccount1.Permit.UACC.DataInput = false;
            userAccount1.Permit.UACC.Schedule = false;
            userAccount1.Permit.UACC.Operator = true;
            userAccount1.Permit.UACC.ModifyAccount = false;
            ListUser.Add(userAccount);
            ListUser.Add(userAccount1);
        }
        public Login_ViewModel() 
        {
            if (!Loaded)
            {
                Sqlexcute.Server = "112.78.2.9";
                Sqlexcute.pwd = "Fwd@2021";
                Sqlexcute.UId = "fwd63823_fwdvina";
                int check = 2;
                ListUser = new ObservableCollection<UserAccount>();
                ToJSON = new ObservableCollection<ConvertoJson>();
                Sqlexcute.Check_Table(Sqlexcute.Database, "UserAccount", ref check);
                if (check == 0) 
                {
                    Admin();
                    bool check2 = false;
                    bool exit = false;
                    var Json = JsonSerializer.Serialize(ListUser);
                    ToJSON.Add(new ConvertoJson { Code = Json });
                    //var aa = JsonSerializer.Deserialize<ObservableCollection<UserAccount>>(Json);
                    

                    TableUser = Sqlexcute.FillToDataTable(ToJSON);

                    Sqlexcute.Create_JSon_Table(TableUser, Sqlexcute.Database, "UserAccount");
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, TableUser, Sqlexcute.Database, "UserAccount");
                }
                else if (check == 1) 
                {
                    Sqlexcute.GetData_FroM_Database(ref TableUser, "UserAccount", Sqlexcute.Database);
                    ToJSON = Sqlexcute.Conver_From_Data_Table_To_List<ConvertoJson>(TableUser);

                    ListUser = JsonSerializer.Deserialize<ObservableCollection<UserAccount>>(ToJSON.ElementAt(0).Code);
                }
               
                Loaded = true;
            }
            Login = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var check = ListUser.Where(b => b.User == UserID).FirstOrDefault();
                    var login = ListUser.Where(a => a.User == UserID && a.Pass == Sqlexcute.MD5Genrate(Password)).FirstOrDefault();
                    if (login != null && check != null)
                    {
                        LoginSuccess = true;
                        Permit = login.Permit;
                        LoginAcount = login;
                        Loading_Indicator.BeingBusy();
                        //WPFMessageBoxService.ShowMessage("Đăng nhập thành công", "Login!", System.Messaging.MessageType.Report);
                        
                    }
                    else if (check != null && login == null)
                    {
                        WPFMessageBoxService.ShowMessage("Mật khẩu không chính xác", "Login!", System.Messaging.MessageType.Report);
                        LoginSuccess = false;
                    }
                    else if (check == null && login == null) 
                    {
                        WPFMessageBoxService.ShowMessage("Tài Khoản không tồn tại", "Login!", System.Messaging.MessageType.Report);
                        LoginSuccess = false;
                    }
                }
                catch (Exception ex)
                {
                    WPFMessageBoxService.ShowMessage("Tên đăng nhập hoặc mật khẩu không hợp lệ", "Login!", System.Messaging.MessageType.Report);
                    LoginSuccess = false;

                }
               
            });
            Selected = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var a = (UserAccount)p;
                    SelectedUser = a;
                }
                catch (Exception)
                {

                    
                }
               
            });
            Save_permit = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var Json = JsonSerializer.Serialize(ListUser);
                    ToJSON = new ObservableCollection<ConvertoJson>();
                    ToJSON.Add(new ConvertoJson { Code = Json });
                    //var aa = JsonSerializer.Deserialize<ObservableCollection<UserAccount>>(Json);

                    TableUser = new DataTable("User Account");
                    TableUser = Sqlexcute.FillToDataTable(ToJSON);
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, TableUser, Sqlexcute.Database, "UserAccount");
                    WPFMessageBoxService.ShowMessage("Đã Lưu", "Lưu dữ liệu!", System.Messaging.MessageType.Report);
                }
                catch (Exception ex)
                {

                    WPFMessageBoxService.ShowMessage(ex.Message, "Lỗi Lưu Dữ Liệu!", System.Messaging.MessageType.Report);
                }
            });
            
        }

       
    }
    public static class Loading_Indicator 
    {
        public static Loading Loading { get; set; }
        public static void BeingBusy() 
        {
            Thread thread = new Thread(() => 
            {
                Loading = new Loading();
                Loading.ShowDialog();

            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
           
           
        }
        public static void Finished() 
        {
            Loading.Dispatcher.BeginInvoke(new Action(() => 
            {
                Loading.Close();
            }));
        }
    }
}

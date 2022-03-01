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
using WPF_TEST.View.Access_Management;

namespace WPF_TEST.ViewModel
{
    public class Login_ViewModel:BaseViewModel
    {
        private static Login_ViewModel login_ViewModel = new Login_ViewModel();
        public static Login_ViewModel INS 
        {
            get 
            {
                if (login_ViewModel != null) 
                {
                    return login_ViewModel;
                }
                else 
                {
                   
                    return new Login_ViewModel(); ;
                }
            }
            set 
            {

                login_ViewModel = value;
            }
        }

        private MySqlDataAdapter mySqlDataAdapter;
        
        public static UserAccount LoginAcount = new UserAccount();
        public static bool LoginSuccess { get; set; }

        WPFMessageBoxService WPFMessageBoxService = new WPFMessageBoxService();
        public DataTable TableUser = new DataTable("User Account");

        public static DataTable Personnel = new DataTable("Personnel");

        #region Nhân Viên Mới Properties

        private ObservableCollection<Information> _info;
        public ObservableCollection<Information> NewPerSon 
        {
            get 
            {
                if (_info != null) 
                {
                    return _info;
                }
                else 
                {
                    _info = new ObservableCollection<Information>();
                    Information information = new Information();
                    information.Name = "";
                    information.Notes = "";
                    information.PhoneNumber = "0000000000";
                    information.Position = "";
                    information.Photo = Convert.FromBase64String("None");
                    information.Email = "Example@email.com";
                    information.Country = "Việt Nam";
                    information.City = "Đà Nẵng";
                    information.Birth = DateTime.Parse("01/01/1990");
                    information.Address = "--------";
                    _info.Add(information);
                    return _info;
                }
                
            }
            set 
            {
                SetProperty(ref _info, value, nameof(NewPerSon));
            }
        }   

        private string _name;
        public string FullName 
        {
            get 
            {
                return _name;
            }
            set 
            {
                SetProperty(ref _name, value, nameof(FullName));
            }
        }

        private string _address;
        public string NewAddress
        {
            get
            {
                return _address;
            }
            set
            {
                SetProperty(ref _address, value, nameof(NewAddress));
            }
        }

        private string _city;
        public string NewCity
        {
            get
            {
                return _city;
            }
            set
            {
                SetProperty(ref _city, value, nameof(NewCity));
            }
        }

        private string _position;
        public string NewPosition
        {
            get
            {
                return _position;
            }
            set
            {
                SetProperty(ref _position, value, nameof(NewPosition));
            }
        }

        private DateTime _birth;
        public DateTime NewBirth
        {
            get
            {
                if (_birth == DateTime.Parse("01/01/0001")) 
                {
                    _birth = DateTime.Today;
                }
                return _birth;
            }
            set
            {
                SetProperty(ref _birth, value, nameof(NewBirth));
            }
        }

        private string _phone;
        public string NewPhone
        {
            get
            {
                return _phone;
            }
            set
            {
                SetProperty(ref _phone, value, nameof(NewPhone));
            }
        }
        private string _email;
        public string NewEmail
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value, nameof(NewEmail));
            }
        }
        private string _note;
        public string NewNote
        {
            get
            {
                return _note;
            }
            set
            {
                SetProperty(ref _note, value, nameof(NewNote));
            }
        }

        private string _country;
        public string NewCountry
        {
            get
            {
                return _country;
            }
            set
            {
                SetProperty(ref _country, value, nameof(NewCountry));
            }
        }
        #endregion


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
        private static ObservableCollection<Information> _nhanvien;
        public ObservableCollection<Information> HoSoNhanVien
        {
            get
            {
                return _nhanvien;
            }
            set
            {
                SetProperty(ref _nhanvien, value, nameof(HoSoNhanVien));
            }
        }
        public static ICommand Login { get; set; }
        public ICommand Selected { get; set; }
        public ICommand Save_permit { get; set; }
        public ICommand SavePersonnel { get; set; }
        public static ICommand ThemNguoi { get; set; }
        public ICommand OpenAddForm { get; set; }
        public ICommand HuyBo { get; set; }
        public static bool Loaded { get; set; }

        Sqlexcute Sqlexcute = new Sqlexcute();
        private void  Admin() 
        {
            LoginSuccess = false;
            UserAccount userAccount = new UserAccount();
            userAccount.UserID = 1;
            userAccount.User = "admin";
            userAccount.Pass = Sqlexcute.MD5Genrate("00000000");

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

        public void Employee() 
        {
            Information information = new Information();
            information.Name = "";
            information.Notes = "";
            information.PhoneNumber = "0123456789";
            information.Position = "";
            information.Photo = Convert.FromBase64String("None");
            information.Email = "Example@email.com";
            information.Country = "Việt Nam";
            information.City = "Đà Nẵng";
            information.Birth = DateTime.Parse("01/01/1990");
            information.Address = "125 Võ An Ninh";

            HoSoNhanVien.Add(information);
        }
        public Login_ViewModel() 
        {
            if (!Loaded)
            {
                //Sqlexcute.Server = "112.78.2.9";
                //Sqlexcute.pwd = "Fwd@2021";
                //Sqlexcute.UId = "fwd63823_fwdvina";
                int check = 2;
                int check1 = 2;
                bool checkex = false;
                bool exist = false;
                ListUser = new ObservableCollection<UserAccount>();
                HoSoNhanVien = new ObservableCollection<Information>();
                ToJSON = new ObservableCollection<ConvertoJson>();
                Sqlexcute.Check_Table(Sqlexcute.Database, "UserAccount", ref check);
                Sqlexcute.Check_Table(Sqlexcute.Database, "Personnel", ref check1);
                if (check == 0) 
                {
                    Admin();
                    
                    var Json = JsonSerializer.Serialize(ListUser);
                    ToJSON.Add(new ConvertoJson { Code = Json });
                    //var aa = JsonSerializer.Deserialize<ObservableCollection<UserAccount>>(Json);
                    

                    TableUser = Sqlexcute.FillToDataTable(ToJSON);

                    Sqlexcute.Create_JSon_Table(TableUser, Sqlexcute.Database, "UserAccount");
                    Sqlexcute.Update_Table_to_Host(TableUser, Sqlexcute.Database, "UserAccount");
                }
                else if (check == 1) 
                {
                    Sqlexcute.GetData_FroM_Database(ref TableUser, "UserAccount", Sqlexcute.Database);
                    ToJSON = Sqlexcute.Conver_From_Data_Table_To_List<ConvertoJson>(TableUser);

                    ListUser = JsonSerializer.Deserialize<ObservableCollection<UserAccount>>(ToJSON.ElementAt(0).Code);
                }

                if (check1 == 0) 
                {
                    Employee();
                    //Personnel.TableName = "Personnel";
                    Personnel = Sqlexcute.FillToDataTable(HoSoNhanVien);
                    Sqlexcute.AutoCreateTable(Personnel, Sqlexcute.Database, "Personnel", ref checkex, ref exist);
                    Sqlexcute.Update_Table_to_Host(Personnel, Sqlexcute.Database, "Personnel");
                }
                else if (check1==1)
                {
                    Personnel = new DataTable("Personnel");
                    Sqlexcute.GetData_FroM_Database(ref Personnel, "Personnel", Sqlexcute.Database);
                    HoSoNhanVien = Sqlexcute.Conver_From_Data_Table_To_List<Information>(Personnel);
                }

                Loaded = true;
            }
            Login = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    var check = ListUser.Where(b => b.User == UserID).FirstOrDefault();
                    var login = ListUser.Where(a => a.User == UserID && a.Pass == Sqlexcute.MD5Genrate(Password)).FirstOrDefault();
                    if (MainScreenViewModel.Home != null) 
                    {
                        MainScreenViewModel.Home.Execute(null);
                    }
                    
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
                    Sqlexcute.Update_Table_to_Host(TableUser, Sqlexcute.Database, "UserAccount");
                    WPFMessageBoxService.ShowMessage("Đã Lưu", "Lưu dữ liệu!", System.Messaging.MessageType.Report);
                }
                catch (Exception ex)
                {

                    WPFMessageBoxService.ShowMessage(ex.Message, "Lỗi Lưu Dữ Liệu!", System.Messaging.MessageType.Report);
                }
            });
            SavePersonnel = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                try
                {
                    Personnel = new DataTable("Personnel");
                    Personnel = Sqlexcute.FillToDataTable(HoSoNhanVien);
                    Sqlexcute.Update_Table_to_Host(Personnel, Sqlexcute.Database, "Personnel");
                    WPFMessageBoxService.ShowMessage("Đã Lưu", "Lưu Dữ Liệu:", System.Windows.MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    WPFMessageBoxService.ShowMessage(ex.Message, "Lỗi", System.Windows.MessageBoxImage.Error);
                }
               
            });
            ThemNguoi = new RelayCommand<object>((p) => { return true; },(P)=> 
            {
                try
                {
                    var a = NewPerSon.ElementAt(0);
                    HoSoNhanVien.Add(a);
                    Personnel = new DataTable("Personnel");
                    Personnel = Sqlexcute.FillToDataTable(HoSoNhanVien);
                    Sqlexcute.Update_Table_to_Host(Personnel, Sqlexcute.Database, "Personnel");
                    WPFMessageBoxService.ShowMessage("Thêm Thành Công", "Thêm Nhân Sự:", System.Windows.MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    WPFMessageBoxService.ShowMessage(ex.Message, "Lỗi", System.Windows.MessageBoxImage.Error);
                }
                

            });

            OpenAddForm = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                AddNewPersonnel_View addNewPersonnel_View = new AddNewPersonnel_View();
                addNewPersonnel_View.ShowDialog();
            });
            HuyBo = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                NewPerSon = new ObservableCollection<Information>();
            });
            
        }

        public bool Changpass(string User,string oldPW,string newPW) 
        {
            bool changed = false;
            if(User == LoginAcount.User && Sqlexcute.MD5Genrate(oldPW) == LoginAcount.Pass) 
            {
                UserAccount a = ListUser.Where(x => x.User == LoginAcount.User && x.Pass == LoginAcount.Pass).FirstOrDefault();

                a.Pass = Sqlexcute.MD5Genrate(newPW);
                var Json = JsonSerializer.Serialize(ListUser);
                ToJSON.Add(new ConvertoJson { Code = Json });
                //var aa = JsonSerializer.Deserialize<ObservableCollection<UserAccount>>(Json);


                TableUser = Sqlexcute.FillToDataTable(ToJSON);

                Sqlexcute.Create_JSon_Table(TableUser, Sqlexcute.Database, "UserAccount");
                Sqlexcute.Update_Table_to_Host(TableUser, Sqlexcute.Database, "UserAccount");
                changed = true;
                return changed;
            }
            else 
            {
                changed = false;
                return changed;
            }
            
        }
       
    }
    public static class Loading_Indicator 
    {
        private static Loading loading;
        public static Loading Loading 
        {
            get 
            {
                return loading;
            }
            set 
            {
                loading = value;
            }
        }
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
            try
            {
                
                    Loading.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Loading.Close();
                    }));
                
               
            }
            catch (Exception ex)
            {

               
            }
            
        }
    }
}

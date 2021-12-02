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

namespace WPF_TEST.ViewModel
{
    public class CustomerSetting_ViewModel:BaseViewModel
    {
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        private MySqlDataAdapter mySqlDataAdapter;
        DataTable Customer_Table = new DataTable("Customer");
        Sqlexcute Sqlexcute = new Sqlexcute();
        private static bool enable =false;
        public bool Enable_Add 
        {
            get { return enable; }
            set 
            {
                SetProperty(ref enable, value, nameof(Enable_Add));
            }
        }
        public static ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customer_Storage
        {
            get { return customers; }
            set 
            {
                SetProperty(ref customers, value, nameof(Customer_Storage));
            }
        }

        private string _companyName;
        public string CompanyName       // Tên công ty
        {
            get 
            {
                return _companyName;
            }
            set 
            {
                SetProperty(ref _companyName, value, nameof(CompanyName));
            }
        }
        private string _contactName;
        public string ContactName       // Tên người cần liên hệ
        {
            get
            {
                return _contactName;
            }
            set
            {
                SetProperty(ref _contactName, value, nameof(ContactName));
            }
        }
        private string _phoneNumber; //  số điện thaoij 1
        public string PhomeNumber 
        {
            get { return _phoneNumber; }
            set 
            {
                SetProperty(ref _phoneNumber, value, nameof(PhomeNumber));
            }
        }

        private string _phoneNumber2; // số điện thoại 2
        public string PhomeNumber2
        {
            get { return _phoneNumber2; }
            set
            {
                SetProperty(ref _phoneNumber2, value, nameof(PhomeNumber2));
            }
        }
        private string _email;
        public string Email   // Email
        {
            get { return _email; }
            set 
            {
                SetProperty
                    (ref _email, value, nameof(Email));
            }

        }
        private string _address;
        public string Address  // địa chỉ giao hàng
        {
            get { return _address; }
            set 
            {
                SetProperty(ref _address, value, nameof(Address));
            }
        }

        private string _requirement;
        public string Requirements
        {
            get { return _requirement; }
            set 
            {
                SetProperty(ref _requirement, value, nameof(Requirements));
            }
        }
        public bool load = false;
        public ICommand EnableAdd { get; set; }
        public ICommand Delete_Contact { get; set; }
        public ICommand Save_Contact { get; set; }
        public ICommand Loaded { get; set; }
        public CustomerSetting_ViewModel()
        {
            if (!load)
            {
                Customer_Storage = new ObservableCollection<Customer>();
                initialize();
                load = true;
            }
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                initialize();
            });
            
            EnableAdd = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Enable_Add = true;
            });
            Delete_Contact = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            Save_Contact = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (CompanyName == null || ContactName == null || Address == null || CompanyName == string.Empty || ContactName == string.Empty || Address == string.Empty || PhomeNumber == null || _phoneNumber == string.Empty) 
                {
                    return;
                }
                try
                {
                    Customer customer = new Customer();
                    customer.Address = Address;
                    customer.Customer_Info = CompanyName;
                    customer.Contact_Person = ContactName;
                    customer.Customer_Requirement = Requirements;
                    customer.PhoneNumber = PhomeNumber;
                    customer.PhonNumer_2 = PhomeNumber2;
                    customer.Email = Email;

                    Customer_Storage.Add(customer);

                    Customer_Table = Sqlexcute.FillToDataTable(Customer_Storage);
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, Customer_Table, Sqlexcute.Database, Customer_Table.TableName);
                    Enable_Add = false;
                    messageBoxService.ShowMessage("Đã Lưu", "Cập nhật danh sach khách hàng", System.Messaging.MessageType.Report);
                }
                catch (Exception ex)
                {

                   
                }
               
            });
        }
        private void initialize() 
        {
            int check1 = 2;
            bool check_ = true;
            bool exist_ = true;
            Sqlexcute.Check_Table(Sqlexcute.Database, Customer_Table.TableName, ref check1);
            if (check1 == 0)
            {

                Add_Customer();
                Customer_Table = Sqlexcute.FillToDataTable(Customer_Storage);
                Sqlexcute.AutoCreateTable(Customer_Table, Sqlexcute.Database, Customer_Table.TableName, ref check_, ref exist_);
                mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, Sqlexcute.Database);

                Customer_Table = Sqlexcute.FillToDataTable(Customer_Storage);
                Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, Customer_Table, Sqlexcute.Database, Customer_Table.TableName);
            }
            else
            {
                mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, Sqlexcute.Database);
                Customer_Storage = Sqlexcute.Conver_From_Data_Table_To_List<Customer>(Customer_Table);
            }
        }
        private void Add_Customer()
        {
            Customer customer = new Customer();
            customer.Customer_Info = "Company1";
            
            customer.Address = "Đà Nẵng";
            customer.Contact_Person = "Mr.Thi";
            customer.PhoneNumber = "0123456789";
            customer.Email = "Person13@gmail.com";
            customer.Customer_Details = "Email: " + customer.Email + " \n Fax:43223432 \n Address:" + customer.Address + "";
            Customer customer1 = new Customer();
            customer1.Customer_Info = "Company2";
            
            customer1.Address = "Sài Gòn";
            customer1.Contact_Person = "Mr.Dao";
            customer1.PhoneNumber = "0321789456";
            customer1.Email = "Person13@gmail.com";
            customer1.Customer_Details = "Email: "+customer1.Email+" \n Fax:5530145 \n Address:"+customer1.Address+"";
            Customer_Storage.Add(customer);
            Customer_Storage.Add(customer1);
        }

    }
}

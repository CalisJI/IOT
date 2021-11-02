using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.Class_Resource;
using System.Data;
using MySql.Data.MySqlClient;
using WPF_TEST.Notyfication;

namespace WPF_TEST.ViewModel
{
    public class EditJobModel:BaseViewModel
    {
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataTable JobOrder_Table = new DataTable("Job Information");
        DataTable Customer_Table = new DataTable("Customer_Details");
        #region Model
        private ObservableCollection<Customer> _customerInfo;
        public ObservableCollection<Customer> CustomerInfo { get { return _customerInfo; } set { SetProperty(ref _customerInfo, value, nameof(CustomerInfo)); } }

        private ObservableCollection<JobOrder> _jobOrder;
        public ObservableCollection<JobOrder> JobOrders
        {
            get
            {
                return _jobOrder;
            }
            set
            {
                SetProperty(ref _jobOrder, value, nameof(JobOrders));
            }
        }
        private string _salesOrder;
        public string SalesOrder
        {
            get 
            {
                return _salesOrder;
            }
            set 
            {
                SetProperty(ref _salesOrder, value, nameof(SalesOrder));
            }
        }
        private string _customer;
        public string Custommer 
        {
            get 
            {
                return _customer;
            }
            set 
            {
                SetProperty(ref _customer, value, nameof(Custommer));
            }
        }
        private string _customer_Details;
        public string Customer_Details 
        {
            get 
            {
                return _customer_Details;
            }
            set 
            {
                SetProperty(ref _customer_Details, value, nameof(Customer_Details));
            }
        }
        private string _quotation;
        public string Quotation 
        {
            get 
            {
                return _quotation;
            }
            set 
            {
                SetProperty(ref _quotation, value, nameof(Quotation));
            }
        }
        private string _customer_PO;
        public string Customer_PO 
        {
            get 
            {
                return _customer_PO;
            }
            set 
            {
                SetProperty(ref _customer_PO, value, nameof(Customer_PO));
            }
        }
        private DateTime _request_Start;
        public DateTime Request_Start 
        {
            get 
            {
                return _request_Start;
            }
            set 
            {
                SetProperty(ref _request_Start, value, nameof(Request_Start));
            }
        }
        private DateTime _request_end;
        public DateTime Request_End 
        { 
            get { return _request_end; }
            set { SetProperty(ref _request_end, value, nameof(Request_End)); } 
        }
        private DateTime _request_report;
        public DateTime Request_Report { get { return _request_report; } set { SetProperty(ref _request_report, value, nameof(Request_Report)); } }

        #endregion
        public PlannerModel PlannerModel { get; set; }
        #region Commmand
        public ICommand Save_EditJob { get; set; }
        private bool load_edit = false;
        #endregion
        public EditJobModel editJobModel;
        private MySqlDataAdapter mySqlDataAdapter;

        public EditJobModel() 
        {
            if (!load_edit) 
            {
                int check = 2;
                int check1 = 2;
                bool check_ = true;
                bool exist_ = true;
                JobOrders = new ObservableCollection<JobOrder>();
                load_edit = true;
                Sqlexcute.Server = "112.78.2.9";
                Sqlexcute.pwd = "Fwd@2021";
                Sqlexcute.UId = "fwd63823_fwdvina";
                Sqlexcute.Check_Table("fwd63823_database", JobOrder_Table.TableName, ref check);
                Sqlexcute.Check_Table("fwd63823_database", Customer_Table.TableName, ref check1);
                if (check1 == 0)
                {
                    Sqlexcute.AutoCreateTable(Customer_Table, "fwd63823_database", Customer_Table.TableName, ref check_, ref exist_);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, "fwd63823_database");
                    CustomerInfo = Sqlexcute.Conver_From_Data_Table_To_List<Customer>(Customer_Table);
                }
                if (check == 0) 
                {
                    Sqlexcute.AutoCreateTable(JobOrder_Table, "fwd63823_database", JobOrder_Table.TableName, ref check_, ref exist_);
                }
                else 
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrder_Table, JobOrder_Table.TableName, "fwd63823_database");
                    JobOrders = Sqlexcute.Conver_From_Data_Table_To_List<JobOrder>(JobOrder_Table);
                }

            }
            Save_EditJob = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                Save_Table();
            });

        }
        public void Save_Table()
        {
            JobOrder_Table = null;
            JobOrder_Table = Sqlexcute.FillToDataTable<JobOrder>(JobOrders);
            bool check = true;
            bool exist = false;
            Sqlexcute.AutoCreateTable(JobOrder_Table, "fwd63823_database", JobOrder_Table.TableName, ref check, ref exist);
            if (!check)
            {
                messageBoxService.ShowMessage(Sqlexcute.error_message, "Thông tin lỗi", System.Messaging.MessageType.Report);
            }
            Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, JobOrder_Table, "fwd63823_database", "ModbusDevice");
            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }

        }
    }
    public class Customer 
    {
        public string Customer_Info { get; set; }
        public string Customer_Details { get; set; }
    }
    public class JobOrder
    {
        public string SaleOrder { get; set; }
        public string Customer { get; set; }
        public string Customer_Details { get; set; }
        public string Quotation { get; set; }
        public string Customer_PO { get; set; }
        public DateTime Requested_Start { get; set; }
        public DateTime Requested_End { get; set; }
        public DateTime Requested_Report_Date { get; set; }

    }

}

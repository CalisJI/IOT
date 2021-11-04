﻿using System;
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
using WPF_TEST.Data;

namespace WPF_TEST.ViewModel
{
    public class EditJobModel:BaseViewModel
    {
        WPFMessageBoxService messageBoxService = new WPFMessageBoxService();
        Sqlexcute Sqlexcute = new Sqlexcute();
        DataTable JobOrder_Table = new DataTable("Job Information");
        DataTable Customer_Table = new DataTable("Customer_Details");
        DataTable Work_Table = new DataTable("Work Information");

        #region Model
        private ObservableCollection<Works> _work;
        public ObservableCollection<Works> WorksList { get { return _work; } set { SetProperty(ref _work, value, nameof(WorksList)); } }
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
        private void Add()
        {
            Works works = new Works();
            works.WorkOrderName = "Test1";
            works.Product = "Product1";
            works.Remark = "Something";
            works.ImageProduct = @"F:\IMAGE\ELECTRONICS_machine_technology_circuit_electronic_computer_technics_detail_psychedelic_abstract_pattern_6160x4106.jpg";

            Works works1 = new Works();
            works1.WorkOrderName = "Test2";
            works1.Product = "Product2";
            works1.Remark = "Something2";
            works1.ImageProduct = @"F:\IMAGE\ELECTRONICS_machine_technology_circuit_electronic_computer_technics_detail_psychedelic_abstract_pattern_6160x4106.jpg";
            WorksList.Add(works);
            WorksList.Add(works1);
        }
        private void Add_Customer() 
        {
            Customer customer = new Customer();
            customer.Customer_Info = "Customer1";
            customer.Customer_Details = "Email: Person13gmail.com \n Fax:5530145 \n Address:Da Nang ...";
            Customer customer1 = new Customer();
            customer1.Customer_Info = "Customer2";
            customer1.Customer_Details = "Email: Person32gmail.com \n Fax:54320145 \n Address:Da Nang ...";
            CustomerInfo.Add(customer);
            CustomerInfo.Add(customer1);
        }
        private void Add_Job() 
        {
            JobOrder jobOrder = new JobOrder();

            jobOrder.Customer = CustomerInfo[0].Customer_Info;
            jobOrder.Customer_Details = CustomerInfo[0].Customer_Details;
            jobOrder.Customer_PO = "PO1";
            jobOrder.Quotation = "Quotation1";
            jobOrder.Requested_Start = DateTime.Today + TimeSpan.FromDays(1);
            jobOrder.Requested_End = DateTime.Now + TimeSpan.FromDays(3);
            jobOrder.Requested_Report_Date = DateTime.Today;
            jobOrder.SaleOrder = "SaleOrder1";

            JobOrder jobOrder1 = new JobOrder();

            jobOrder1.Customer = CustomerInfo[1].Customer_Info;
            jobOrder1.Customer_Details = CustomerInfo[1].Customer_Details;
            jobOrder1.Customer_PO = "PO2";
            jobOrder1.Quotation = "Quotation2";
            jobOrder1.Requested_Start = DateTime.Today + TimeSpan.FromDays(1);
            jobOrder1.Requested_End = DateTime.Now + TimeSpan.FromDays(8);
            jobOrder1.Requested_Report_Date = DateTime.Today;
            jobOrder1.SaleOrder = "SaleOrder2";

            JobOrders.Add(jobOrder);
            JobOrders.Add(jobOrder1);
        }
        public EditJobModel() 
        {
            if (!load_edit) 
            {
                int check = 2;
                int check1 = 2;
                int check2 = 2;
                bool check_ = true;
                bool exist_ = true;
                JobOrders = new ObservableCollection<JobOrder>();
                CustomerInfo = new ObservableCollection<Customer>();
                WorksList = new ObservableCollection<Works>();
                load_edit = true;
                Sqlexcute.Server = "112.78.2.9";
                Sqlexcute.pwd = "Fwd@2021";
                Sqlexcute.UId = "fwd63823_fwdvina";
                Sqlexcute.Check_Table("fwd63823_database", JobOrder_Table.TableName, ref check);
                Sqlexcute.Check_Table("fwd63823_database", Customer_Table.TableName, ref check1);
                Sqlexcute.Check_Table("fwd63823_database", Work_Table.TableName, ref check2);
                if (check1 == 0)
                {
                   
                    Add_Customer();
                    Customer_Table = Sqlexcute.FillToDataTable<Customer>(CustomerInfo);
                    Sqlexcute.AutoCreateTable(Customer_Table, "fwd63823_database", Customer_Table.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, "fwd63823_database");
                    Add_Customer();
                    Customer_Table = Sqlexcute.FillToDataTable<Customer>(CustomerInfo);
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, Customer_Table, "fwd63823_database", Customer_Table.TableName);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Customer_Table, Customer_Table.TableName, "fwd63823_database");
                    CustomerInfo = Sqlexcute.Conver_From_Data_Table_To_List<Customer>(Customer_Table);
                }
                if (check2 == 0)
                {
                    
                    Add();
                    Work_Table = Sqlexcute.FillToDataTable<Works>(WorksList);
                    Sqlexcute.AutoCreateTable(Work_Table, "fwd63823_database", Work_Table.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Work_Table, Work_Table.TableName, "fwd63823_database");
                    Add();
                    Work_Table = Sqlexcute.FillToDataTable<Works>(WorksList);
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, Work_Table, "fwd63823_database", Work_Table.TableName);
                }
                else
                {
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref Work_Table, Work_Table.TableName, "fwd63823_database");
                    WorksList = Sqlexcute.Conver_From_Data_Table_To_List<Works>(Work_Table);
                }
                if (check == 0) 
                {
                    Add_Job();
                    JobOrder_Table = Sqlexcute.FillToDataTable<JobOrder>(JobOrders);
                    Sqlexcute.AutoCreateTable(JobOrder_Table, "fwd63823_database", JobOrder_Table.TableName, ref check_, ref exist_);
                    mySqlDataAdapter = Sqlexcute.GetData_FroM_Database(ref JobOrder_Table, JobOrder_Table.TableName, "fwd63823_database");
                    Add_Job();
                    JobOrder_Table = Sqlexcute.FillToDataTable<JobOrder>(JobOrders);
                    Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, JobOrder_Table, "fwd63823_database", JobOrder_Table.TableName);
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
            Sqlexcute.Update_Table_to_Host(ref mySqlDataAdapter, JobOrder_Table, "fwd63823_database", JobOrder_Table.TableName);
            if (Sqlexcute.error_message != string.Empty)
            {
                messageBoxService.ShowMessage("Lỗi khi lưu dữ liệu lên đám mây:\n " + Sqlexcute.error_message + "", "Thông tin lỗi", System.Messaging.MessageType.Report);
            }

        }
    }
   
   

}

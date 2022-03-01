using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.ViewModel;

namespace WPF_TEST.Data
{
    public class UserAccount
    {
        Permit permit = new Permit();
        //Information information = new Information();
        //ObservableCollection<Permit> permits = new ObservableCollection<Permit>();
        //public ObservableCollection<Permit> Permits 
        //{
        //    get { return permits; }
        //    set 
        //    {
        //        permits = value;
        //    }
        //}
        public int UserID { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public Permit Permit { get { return permit; } set { permit = value; } }
        //public Information Information 
        //{
        //    get 
        //    {
        //        return information;
        //    }
        //    set 
        //    {
        //        information = value;
        //    }
        //}


    }
    public class Information : BaseViewModel
    {

        private string _name;
        private byte[] _photo;
        private string _address;
        private string _city;
        private string _position;
        private DateTime _birth;
        private string _phone;
        private string _email;
        private string _notes;
        private string _country;

       

        public string Name { get { return _name; } set { SetProperty(ref _name, value, nameof(Name)); } }
        public byte[] Photo
        {
            get
            {
                _photo = Convert.FromBase64String(Image);
                return _photo;
            }
            set 
            {
               
                SetProperty(ref _photo, value, nameof(Photo));
                Image = Convert.ToBase64String(_photo);
            }
        }
        public string Address { get { return _address; } set { SetProperty(ref _address, value, nameof(Address)); } }
        public string City { get { return _city; } set { SetProperty(ref _city, value, nameof(City)); } }
        public string Position { get { return _position; } set { SetProperty(ref _position, value, nameof(Position)); } }
        public DateTime Birth 
        {
            get 
            {
                if (_birth == DateTime.Parse("1/1/0001"))
                {
                    return DateTime.Today;
                }
                else 
                {
                    return _birth;
                }
                
            }
            set { SetProperty(ref _birth, value, nameof(Birth)); } }
        public string PhoneNumber { get { return _phone; } set { SetProperty(ref _phone, value, nameof(PhoneNumber)); } }
        public string Email { get { return _email; } set { SetProperty(ref _email, value, nameof(Email)); } }
        //public string Group { get; set; }
        public string Notes { get { return _notes; } set { SetProperty(ref _notes, value, nameof(Notes)); } }
        public string Country { get { return _country; } set { SetProperty(ref _country, value, nameof(Country)); } }
        private string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                SetProperty(ref image, value, nameof(Image));
            }
        }

    }
    public class Permit
    {
        private Weekly_Schedule weekly_Schedule = new Weekly_Schedule();
        private MCPReport mCPReport = new MCPReport();
        private ViewJob viewJob = new ViewJob();
        private CompletedJob completedJob = new CompletedJob();
        private SalesDraft salesDraft = new SalesDraft();
        private ModifySalesItem modifySales = new ModifySalesItem();
        private UACC uacc = new UACC();

        public UACC UACC
        {
            get 
            {
                return uacc;
            }
            set
            {
                uacc = value;
            }
        }
        public Weekly_Schedule Weekly_Schedule 
        {
            get 
            {
                return weekly_Schedule;
            }

            set 
            {
                weekly_Schedule = value;
            }
        }
        public MCPReport MCPReport
        {
            get
            {
                return mCPReport;
            }

            set
            {
                mCPReport = value;
            }
        }
        public ViewJob ViewJob
        {
            get
            {
                return viewJob;
            }

            set
            {
                viewJob = value;
            }
        }
        public CompletedJob CompletedJob
        {
            get
            {
                return completedJob;
            }

            set
            {
                completedJob = value;
            }
        }
        public SalesDraft SalesDraft
        {
            get
            {
                return salesDraft;
            }

            set
            {
                salesDraft = value;
            }
        }
        public ModifySalesItem ModifySalesItem
        {
            get
            {
                return modifySales;
            }

            set
            {
                modifySales = value;
            }
        }
    }
    public class Weekly_Schedule 
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class MCPReport
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ViewJob
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class CompletedJob
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class SalesDraft
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ModifySalesItem
    {
        public bool CanEdit { get; set; }
        public bool CacAccess { get; set; }

        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ConvertoJson 
    {
        
        //public int Id { get; set; }
        public string Code { get; set; }
    }
    public class UACC
    {
        public bool Schedule { get; set; }
        public bool DataInput { get; set; }
        public bool Operator { get; set; }
        public bool ModifyAccount { get; set; }
    }
}

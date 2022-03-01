using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using WPF_TEST.Data;
using System.IO;
using WPF_TEST.ViewModel;
using System.Collections.ObjectModel;
//using System.Windows;
//using static System.Net.Mime.MediaTypeNames;

namespace WPF_TEST.Class_Resource
{
    public class XMLConfig

    {
        private static string RuntimeDataxml = System.IO.Directory.GetCurrentDirectory() + @"\" + "RuntimeData.xml";
        private static string Joborderxml = System.IO.Directory.GetCurrentDirectory() + @"\" + "JobData.xml";
        private static string TimerSettingxml = System.IO.Directory.GetCurrentDirectory() + @"\" + "UpdateCycle.xml";
        private static string JobTableConfigxml = System.IO.Directory.GetCurrentDirectory() + @"\" + "JobTableConfig.xml";
        #region Runtime Region
        public static void CheckFile(string fileName) 
        {
            if (!File.Exists(fileName)) 
            {
                File.Create(fileName).Close();
            }
        }

        public static string Create_MapFile(string FileName)
        {
            string Devicefile = System.IO.Directory.GetCurrentDirectory() + @"\" + FileName + ".xml";
            return Devicefile;
        }

        /// <summary>
        /// Hàm trả về Data của PLC
        /// </summary>
        /// <param name="Mapping_path"> Tên thiết bị</param>
        /// <returns></returns>
        public static PLC_Modbus Get_PlcData(string Mapping_path)
        {
           
            if (File.Exists(Create_MapFile(Mapping_path)))
            {
               
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(PLC_Modbus));
                    Stream stream = new FileStream(Create_MapFile(Mapping_path), FileMode.Open);
                    PLC_Modbus mapping = (PLC_Modbus)xmlSerializer.Deserialize(stream);
                    stream.Close();
                    return mapping;

            }
            else
            {
                PLC_Modbus PLC_Modbus = new PLC_Modbus();
                PLC_Modbus.Device_Name = "NewDevice";
                PLC_Modbus.Data = new System.Collections.ObjectModel.ObservableCollection<RuntimeValue>();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PLC_Modbus));
                Stream stream = new FileStream(Create_MapFile(Mapping_path), FileMode.Create);
                XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlwriter, PLC_Modbus);
                xmlwriter.Close();
                stream.Close();
                return PLC_Modbus;
            }
        }
        /// <summary>
        /// Hàm Cập nhật Dữ liệu Data Runtime
        /// </summary>
        /// <param name="PLC_Modbus"> Object PLC Data</param>
        /// <param name="MapFile_Path"> Tên thiết bị</param>
        public static void Update_PLCData(PLC_Modbus PLC_Modbus, string MapFile_Path)
        {
            CheckFile(Create_MapFile(MapFile_Path));
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PLC_Modbus));
            using (TextWriter textWriter = new StreamWriter(Create_MapFile(MapFile_Path)))
            {
                xmlSerializer.Serialize(textWriter, PLC_Modbus);
                textWriter.Close();
            }
        }

        #endregion
        #region JobOrder Region
        /// <summary>
        /// Hàm trả về danh sach chi tiết các job
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<JobOrder> Get_Joborder()
        {
            if (File.Exists(Joborderxml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<JobOrder>));
                Stream stream = new FileStream(Joborderxml, FileMode.Open);
                ObservableCollection<JobOrder> Joborder = (ObservableCollection<JobOrder>)xmlSerializer.Deserialize(stream);
                stream.Close();
                return Joborder;
            }
            else
            {
                ObservableCollection<JobOrder> JobOrders = new ObservableCollection<JobOrder>();
                JobOrder JobOrder = new JobOrder();

                JobOrder.ActualvsPlan = 0;
                JobOrder.Complete = 0;
                JobOrder.Stage = ViewModel.Status.Plan;
                JobOrder.Current_Stage = PlannerModel.getColor(JobOrder.Stage);
                //JobOrder.Customerinformation = new Customer();
                JobOrder.Customer_PO = "";
                JobOrder.BarCode = "000";
                JobOrder.Priority = TaskPriority.Normal;
                JobOrder.Quotation = "None";
                JobOrder.Requested_End = DateTime.Now;
                JobOrder.Requested_Report_Date = DateTime.Now;
                JobOrder.Requested_Start = DateTime.Now;
                JobOrder.SaleOrder = "None";
                //JobOrder.Works = new System.Collections.ObjectModel.ObservableCollection<Works>();
                JobOrders.Add(JobOrder);


                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<JobOrder>));
                Stream stream = new FileStream(Joborderxml, FileMode.Create);
                XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlwriter, JobOrders);
                xmlwriter.Close();
                stream.Close();
                return JobOrders;
            }
        }

        /// <summary>
        /// Hàm cập nhật Job
        /// </summary>
        /// <param name="ListJob"> Object ObservableCollection<JobOrder> </param>
        public static void Update_JobSetting(ObservableCollection<JobOrder> ListJob)
        {
            CheckFile(Joborderxml);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<JobOrder>));
            using (TextWriter textWriter = new StreamWriter(Joborderxml))
            {
                xmlSerializer.Serialize(textWriter, ListJob);
                textWriter.Close();
            }
        }
        #endregion
        #region Timer Setting Region
        public static TimerSetting Get_TimerConfig()
        {
            if (File.Exists(TimerSettingxml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TimerSetting));
                Stream stream = new FileStream(TimerSettingxml, FileMode.Open);
                TimerSetting TimerSetting = (TimerSetting)xmlSerializer.Deserialize(stream);
                stream.Close();
                return TimerSetting;
            }
            else
            {
                TimerSetting TimerSetting = new TimerSetting();
                TimerSetting.TimerUpdatePLCData = 30;


                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TimerSetting));
                Stream stream = new FileStream(TimerSettingxml, FileMode.Create);
                XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlwriter, TimerSetting);
                xmlwriter.Close();
                stream.Close();
                return TimerSetting;
            }
        }

        public static void Update_TimerSetting(TimerSetting timerSetting)
        {
            CheckFile(TimerSettingxml);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TimerSetting));
            using (TextWriter textWriter = new StreamWriter(TimerSettingxml))
            {
                xmlSerializer.Serialize(textWriter, timerSetting);
                textWriter.Close();
            }
        }
        #endregion

        #region Cấu Hình Bảng Công Dữ Liệu Công Việc
        public static JobTableConfig Get_JobtableConfig()
        {
            if (File.Exists(JobTableConfigxml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(JobTableConfig));
                Stream stream = new FileStream(JobTableConfigxml, FileMode.Open);
                JobTableConfig JobTableConfig = (JobTableConfig)xmlSerializer.Deserialize(stream);
                stream.Close();
                return JobTableConfig;
            }
            else
            {
                JobTableConfig JobTableConfig = new JobTableConfig();
                JobTableConfig.SoHieuCongViec_Col = 0;
                JobTableConfig.MaSanPham_Col = 2;
                JobTableConfig.TenSanPham_Col = 3;
                JobTableConfig.SoLuong_Col = 4;
                JobTableConfig.SoLuowngHoanThanh_Col = 5;
                JobTableConfig.NgayBatDau_Col = 6;
                JobTableConfig.NgayKetThuc_Col = 7;
                JobTableConfig.TinhTrang_Col = 10;
                JobTableConfig.ThamKhao_Col = 11;

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(JobTableConfig));
                Stream stream = new FileStream(JobTableConfigxml, FileMode.Create);
                XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlwriter, JobTableConfig);
                xmlwriter.Close();
                stream.Close();
                return JobTableConfig;
            }
        }

        public static void Update_JobtableConfig(JobTableConfig JobTableConfig)
        {
            CheckFile(JobTableConfigxml);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(JobTableConfig));
            using (TextWriter textWriter = new StreamWriter(JobTableConfigxml))
            {
                xmlSerializer.Serialize(textWriter, JobTableConfig);
                textWriter.Close();
            }
        }
        #endregion
    }
}

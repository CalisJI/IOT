using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using WPF_TEST.ViewModel;
using System.Security.Cryptography;
using System.Globalization;
using System.Text.Json;
using WPF_TEST.Data;

namespace WPF_TEST.Class_Resource
{
    public class Sqlexcute
    {
        
        public static string pwd { get { return "Fwd@2021"; } }
        //public static string pwd = "12345678";
        public string error_message;
        //public static string Server = "127.0.0.1";
        public static string Server { get { return "112.78.2.9"; } }
        public static string UId { get { return "fwd63823_fwdvina"; } }
        public static string Database { get { return "fwd63823_database"; } }


        private static MySqlConnection _sQL_Connection = new MySqlConnection("Server = " + Server + ";Database =" + Database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none");
        private static MySqlConnection SQL_Connection 
        {
            get 
            {
                if (_sQL_Connection != null)
                {
                    return _sQL_Connection;
                }
                else 
                {
                    return new MySqlConnection("Server = " + Server + ";Database =" + Database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none");
                }
            }
            set 
            {
                _sQL_Connection = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Db"></param>
        /// <param name="TB"></param>
        /// <returns></returns>
        private string Check_Table_Exits(string Db, string TB) 
        {
            string check = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '"+Db+"' AND table_name = '"+TB+"'";
            return check;
        }
        //private string StrCon = "Server = " + Server + "; UId = root; Pwd = " + pwd + "; Pooling = false; Character Set=utf8";
        private string StrCon(string Server, string pwd)
        {
            string Set = "Server = " + Server + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none";
            return Set;
        }
        private string StrCon_Database(string Server,string pwd,string database) 
        {
            string set = "Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none";
            return set;
        }

        #region *******************************************PERMISSION*************************************************
        public string MD5Genrate(string pass) 
        {
            string MD5String = string.Empty;
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            foreach (byte item in hasData)
            {
                MD5String += item;
            }
            return MD5String;
        }

        public string getID_user(string userid, string pass)
        {
            string ID = "";
            SQL_Connection = new MySqlConnection(StrCon(Server, pwd));
            SQL_Connection.Open();
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM UserAccount WHERE [User] = '" + userid + "' AND Pass = '" + pass + "'", SQL_Connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ID = dr["UserID"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                error_message = e.Message;
            }
            // StrCon.Close();
            SQL_Connection.Close();

            return ID;
        }

        #endregion
        public DataTable Get_Database_Name()
        {
            DataTable dt = new DataTable();
            try
            {

                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }
                dt = SQL_Connection.GetSchema("Databases");
                error_message = string.Empty;
                SQL_Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return dt;
            }

        }
        public List<string> Get_table_Name(string datebase)
        {
            DataTable dt = new DataTable();
            List<string> listName = new List<string>();
            try
            {

                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }
                //using (MySqlCommand com = new MySqlCommand(" SELECT * FROM sys.tables where table_schema = 'agv_data'", con))
                using (MySqlCommand com = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'AND TABLE_SCHEMA='" + datebase + "' ", SQL_Connection))
                    {

                        using (MySqlDataReader reader = com.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                listName.Add((string)reader["TABLE_NAME"]);
                            }
                        }
                    }
                    error_message = string.Empty;
                    return listName;
               
            }
            catch (Exception ex)
            {

                error_message = ex.Message;
                return listName;
            }

        }
        public int count = 0;
        public DataTable Fill_data(string database, string table)
        {
            DataTable dt = new DataTable();
            try
            {
                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }

                string str = "SELECT * FROM " + table + "";
                MySqlDataAdapter adp = new MySqlDataAdapter(str, SQL_Connection);
                MySqlCommandBuilder cmd = new MySqlCommandBuilder(adp);

                adp.Fill(dt);
                SQL_Connection.Close();
                error_message = string.Empty;
                return dt;
               

            }
            catch (Exception ex)
            {

                error_message = ex.Message;
                return dt;
            }
        }
        /// <summary>
        /// Đọc Bàng Có Điều Kiện
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable Read_Table_Group(string str)
        {
            DataTable dataTable = new DataTable();
            MySqlDataAdapter mySqlData;
            try
            {
                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }
                int i = 0;
                //string str = "SELECT * FROM " + table + "";
                mySqlData = new MySqlDataAdapter(str, SQL_Connection);
                MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlData);
                mySqlData.Fill(dataTable);
                //MySqlCommand cmd = new MySqlCommand(str, SQL_Connection);
                //var SQL_Reader = cmd.ExecuteReader();
                //if (SQL_Reader.HasRows)
                //{
                //    while (SQL_Reader.Read())
                //    {
                //        dataTable.Rows.Add();
                //        for (int j = 0; j < SQL_Reader.FieldCount; j++)
                //        {
                //            if (SQL_Reader.IsDBNull(j)) break;
                //            dataTable.Columns.Add();
                //            dataTable.Rows[i][j] = SQL_Reader.GetString(j);

                //        }
                //        i++;

                //    }
                //}
                SQL_Connection.Close();
                error_message = string.Empty;
                return dataTable;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return dataTable;
            }
        }
        public DataTable Read_data(string database, string table)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if(SQL_Connection.State == ConnectionState.Closed) 
                {
                    SQL_Connection.Open();
                }
                int i = 0;
                string str = "SELECT * FROM " + table + "";

                MySqlCommand cmd = new MySqlCommand(str, SQL_Connection);
                var SQL_Reader = cmd.ExecuteReader();
                if (SQL_Reader.HasRows)
                {
                    while (SQL_Reader.Read())
                    {
                        dataTable.Rows.Add();
                        for (int j = 0; j < SQL_Reader.FieldCount; j++)
                        {
                            if (SQL_Reader.IsDBNull(j)) break;
                            dataTable.Columns.Add();
                            dataTable.Rows[i][j] = SQL_Reader.GetString(j);

                        }
                        i++;

                    }
                }
                SQL_Connection.Close();
                error_message = string.Empty;
                return dataTable;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return dataTable;
            }
        }
        /// <summary>
        /// Hàm thực hiện câu truy vấn đơn
        /// </summary>
        /// <param name="command"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public bool SQL_command(string command, string database)
        {
            try
            {
                //SQL_Connection = new MySqlConnection("Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none");
                if (SQL_Connection.State == ConnectionState.Closed && SQL_Connection.State!= ConnectionState.Connecting && SQL_Connection.State != ConnectionState.Executing)
                {
                    SQL_Connection.Open();
                    MySqlCommand cmd = new MySqlCommand(command, SQL_Connection);

                    cmd.ExecuteNonQuery();
                    SQL_Connection.Close();
                    error_message = string.Empty;
                   
                }

                return true;

            }
            catch (Exception ex)
            {
                
                SQL_Connection.Close();
                error_message = ex.Message;
                return false;
            }
        }
        private void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public void SaveData2DB(DataTable dt, string tempCsvFileSpec, string database, string table)
        {

            
                ToCSV(dt, tempCsvFileSpec);
                tempCsvFileSpec = tempCsvFileSpec.Replace('\\', '/');
                var msbl = new MySqlBulkLoader(new MySqlConnection("Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none"));
                msbl.TableName = table;
                msbl.FileName = tempCsvFileSpec;
                //msbl.FileName = "F:/VISUAL PROJECT/C#/Winfom/READ_EXCEL/bin/Debug/tempCVS2.csv";
                msbl.FieldTerminator = ",";
                msbl.FieldQuotationCharacter = '"';
                var dem = msbl.Load();
                File.Delete(tempCsvFileSpec);
           
        }
        /// <summary>
        /// Kiểm tra và trả về sự tồn tại của bảng
        /// </summary>
        /// <param name="database"></param>
        /// <param name="TableName"></param>
        /// <param name="check"></param>
        public void Check_Table(string database, string TableName,ref int check) 
        {
            try
            {
                int count = 2;
                
                    MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName), SQL_Connection);

                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }

                MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())

                    {
                        count = reader.GetInt32(0);
                    }
                    SQL_Connection.Close();
                
                check = count;
            }
            catch (Exception ex)
            {

                error_message = ex.Message;
            }
            
            
        }
        /// <summary>
        /// Tạo bảng bình thường dựa trên Properties của Datatable
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="database"></param>
        /// <param name="TableName"></param>
        /// <param name="check"></param>
        /// <param name="exist"></param>
        public void AutoCreateTable(DataTable dataTable, string database, string TableName, ref bool check, ref bool exist)
        {
            string cmd;
            int count = 2;
            //*****************************************************
            // Code for processing

            MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName), SQL_Connection);

            if (SQL_Connection.State == ConnectionState.Closed)
            {
                SQL_Connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())

            {
                count = reader.GetInt32(0);
            }
            SQL_Connection.Close();

            if (count == 0)

            {

                //MessageBox.Show("No such data table exists!");
                string sqlsc = string.Empty;
                sqlsc = "CREATE TABLE " + TableName + " (";
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sqlsc += "" + dataTable.Columns[i].ColumnName + " ";
                    string columnType = dataTable.Columns[i].DataType.ToString();
                    switch (columnType)
                    {
                        case "System.Int32":
                            sqlsc += " INT ";
                            break;
                        case "System.Int64":
                            sqlsc += " BIGINT(50) ";
                            break;
                        case "System.Int16":
                            sqlsc += " SMALLINT(50)";
                            break;
                        case "System.Byte":
                            sqlsc += " TINYINT(50)";
                            break;
                        case "System.Boolean":
                            sqlsc += " TINYINT(1)";
                            break;
                        case "System.Decimal":
                            sqlsc += " DECIMAL(45) ";
                            break;
                        case "System.DateTime":
                            sqlsc += " DATETIME ";
                            break;
                        case "System.Double":
                            sqlsc += " DOUBLE ";
                            break;
                        case "System.Single":
                            sqlsc += " FLOAT ";
                            break;

                        //case "WPF_TEST.ViewModel.Status":
                        //    sqlsc += " ENUM('Queued','Ready','Running','Paused','Delayed','Done','Plan') ";
                        //    break;
                        case "System.String":
                        default:
                            sqlsc += string.Format(" VARCHAR({0}) ", dataTable.Columns[i].MaxLength == -1 ? "400" : dataTable.Columns[i].MaxLength.ToString());
                            break;
                    }
                    if (dataTable.Columns[i].AutoIncrement)
                        sqlsc += " IDENTITY(" + dataTable.Columns[i].AutoIncrementSeed.ToString() + "," + dataTable.Columns[i].AutoIncrementStep.ToString() + ") ";
                    if (!dataTable.Columns[i].AllowDBNull)
                        sqlsc += " NOT NULL ";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) + ", PRIMARY KEY (" + dataTable.Columns[0].ColumnName + "))";
                exist = false;
                //*****************************************************
                check = SQL_command(cmd, database);

            }
            else if (count == 1)
            {
                exist = true;
                // MessageBox.Show("Such data table exists!");

            }

        }


        /// <summary>
        /// Tạo Bảng Có AutoInCrease ID
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="database"></param>
        /// <param name="TableName"></param>
        public void AutoCreateTable(DataTable dataTable, string database, string TableName,bool Json = false)
        {
            string cmd;

            //*****************************************************
            // Code for processing


            if (!Json) 
            {
                string sqlsc = string.Empty;
                sqlsc = "CREATE TABLE " + TableName + " ( id INT NOT NULL AUTO_INCREMENT,";
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sqlsc += "" + dataTable.Columns[i].ColumnName + " ";
                    string columnType = dataTable.Columns[i].DataType.ToString();
                    switch (columnType)
                    {
                        case "System.Int32":
                            sqlsc += " INT ";
                            break;
                        case "System.Int64":
                            sqlsc += " BIGINT(50) ";
                            break;
                        case "System.Int16":
                            sqlsc += " SMALLINT(50)";
                            break;
                        case "System.Byte":
                            sqlsc += " TINYINT(50)";
                            break;
                        case "System.Boolean":
                            sqlsc += " TINYINT(1)";
                            break;
                        case "System.Decimal":
                            sqlsc += " DECIMAL(45) ";
                            break;
                        case "System.DateTime":
                            sqlsc += " DATETIME ";
                            break;
                        case "System.Double":
                            sqlsc += " DOUBLE ";
                            break;
                        case "System.Single":
                            sqlsc += " FLOAT ";
                            break;
                        case "System.TimeSpan":
                            sqlsc += " TIME ";
                            break;
                        //case "WPF_TEST.ViewModel.Status":
                        //    sqlsc += " ENUM('Queued','Ready','Running','Paused','Delayed','Done','Plan') ";
                        //    break;
                        case "System.String":
                        default:
                            sqlsc += string.Format(" VARCHAR({0}) ", dataTable.Columns[i].MaxLength == -1 ? "400" : dataTable.Columns[i].MaxLength.ToString());
                            break;
                    }
                    if (dataTable.Columns[i].AutoIncrement)
                        sqlsc += " IDENTITY(" + dataTable.Columns[i].AutoIncrementSeed.ToString() + "," + dataTable.Columns[i].AutoIncrementStep.ToString() + ") ";
                    if (!dataTable.Columns[i].AllowDBNull)
                        sqlsc += " NOT NULL ";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) + ", PRIMARY KEY (id)) ENGINE=InnoDB";

                //*****************************************************
                _ = SQL_command(cmd, database);
            }
            else 
            {
                string sqlsc = string.Empty;
                sqlsc = "CREATE TABLE " + TableName + " (";
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sqlsc += "" + dataTable.Columns[i].ColumnName + " ";
                    sqlsc += "JSON";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) + ")";
                _ = SQL_command(cmd, database);
            }
                
                

          

        }
        /// <summary>
        /// Kiêm tra xem bảng đã tồn tại hay chưa.
        /// Nếu chưa thì tạo bảng.
        /// Parameter "Json"= true tạo bảng kiểu Json
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="database"></param>
        /// <param name="TableName"></param>
        /// <param name="dataTable1"></param>
        /// <param name="Json"></param>
        public void AutoCreateTable(DataTable dataTable, string database, string TableName, ref DataTable dataTable1, bool Json = false)
        {
            string cmd;
            int count = 2;
            //*****************************************************
            // Code for processing
           
                MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName), SQL_Connection);

            if (SQL_Connection.State == ConnectionState.Closed)
            {
                SQL_Connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {
                    count = reader.GetInt32(0);
                }
                SQL_Connection.Close();
           
            if (count == 0 && !Json)

            {

                //MessageBox.Show("No such data table exists!");
                string sqlsc = string.Empty;
                sqlsc = "CREATE TABLE " + TableName + " (";
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sqlsc += "" + dataTable.Columns[i].ColumnName + " ";
                    string columnType = dataTable.Columns[i].DataType.ToString();
                    switch (columnType)
                    {
                        case "System.Int32":
                            sqlsc += " INT ";
                            break;
                        case "System.Int64":
                            sqlsc += " BIGINT(50) ";
                            break;
                        case "System.Int16":
                            sqlsc += " SMALLINT(50)";
                            break;
                        case "System.Byte":
                            sqlsc += " TINYINT(50)";
                            break;
                        case "System.Boolean":
                            sqlsc += " TINYINT(1)";
                            break;
                        case "System.Decimal":
                            sqlsc += " DECIMAL(45) ";
                            break;
                        case "System.DateTime":
                            sqlsc += " DATETIME ";
                            break;
                        case "System.Double":
                            sqlsc += " DOUBLE ";
                            break;
                        case "System.Single":
                            sqlsc += " FLOAT ";
                            break;

                        //case "WPF_TEST.ViewModel.Status":
                        //    sqlsc += " ENUM('Queued','Ready','Running','Paused','Delayed','Done','Plan') ";
                        //    break;
                        case "System.String":
                        default:
                            sqlsc += string.Format(" VARCHAR({0}) ", dataTable.Columns[i].MaxLength == -1 ? "400" : dataTable.Columns[i].MaxLength.ToString());
                            break;
                    }
                    if (dataTable.Columns[i].AutoIncrement)
                        sqlsc += " IDENTITY(" + dataTable.Columns[i].AutoIncrementSeed.ToString() + "," + dataTable.Columns[i].AutoIncrementStep.ToString() + ") ";
                    if (!dataTable.Columns[i].AllowDBNull)
                        sqlsc += " NOT NULL ";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) + ", PRIMARY KEY (" + dataTable.Columns[0].ColumnName + "))";

                //*****************************************************
                SQL_command(cmd, database);
                dataTable1 = new DataTable(TableName);
                SQL_command("DELETE FROM " + TableName + "", Database);
            }
            else if (count == 0 && Json) 
            {
                string sqlsc = string.Empty;
                sqlsc = "CREATE TABLE " + TableName + " (";
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sqlsc += "" + dataTable.Columns[i].ColumnName + " ";
                    sqlsc += "JSON";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) + ")";
                var check = SQL_command(cmd, database);
                //dataTable1 = new DataTable(TableName);
                //SQL_command("DELETE FROM " + TableName + "", Database);
            }
            else if (count == 1)
            {
                try
                {
                    GetData_FroM_Database(ref dataTable1, TableName, database);
                }
                catch (Exception ex)
                {

                    error_message = ex.Message;
                }

            }

        }
        //public void UpdateTable_to_MySQlHost( ref DataTable dataTable,string table_Name, string Database) 
        //{
        //    using(SQL_Connection = new MySqlConnection(StrCon(Server, pwd))) 
        //    {
        //        string Query = "SELECT * FROM " + table_Name + "";
        //        MySqlDataAdapter mySqlData = new MySqlDataAdapter(Query, SQL_Connection);
        //        MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlData);
        //        mySqlData.Fill(dataTable);
        //        mySqlData.Update(dataTable);
        //    }
        //}
        /// <summary>
        /// Chọn Số lượng hàng cập nhập
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public string getLimitRow(int low,int high) 
        {
            string aa = " LIMIT " + low.ToString() + ", " + high.ToString() + "";
            return aa;
        }

        /// <summary>
        /// Lấy dữ liệu ban đầu từ Server
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="table_Name"></param>
        /// <param name="Database"></param>
        /// <returns></returns>
        public void GetData_FroM_Database(ref DataTable dataTable , string table_Name,string database ,string limit ="")
        {
            MySqlDataAdapter mySqlData;
            try
            {

                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }
                string Query = "SELECT * FROM " + table_Name + "" + limit + "";
                mySqlData = new MySqlDataAdapter(Query, SQL_Connection);
                MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlData);
                mySqlData.Fill(dataTable);

                SQL_Connection.Close();
                error_message = string.Empty;
               
            }
            catch (Exception ex)
            {

                error_message = ex.Message;
               
            }

           
           
        }
        /// <summary>
        /// Tạo bảng kiểu JSon
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="database"></param>
        /// <param name="TableName"></param>
        public void Create_JSon_Table(DataTable dataTable, string database, string TableName) 
        {
            string cmd;
            int count = 2;
            //*****************************************************
            // Code for processing
           
                MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName), SQL_Connection);

            if (SQL_Connection.State == ConnectionState.Closed)
            {
                SQL_Connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {
                    count = reader.GetInt32(0);
                }
                SQL_Connection.Close();
           
            if (count == 0)
            {
                string sqlsc = string.Empty;
                sqlsc = "CREATE TABLE " + TableName + " (";
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sqlsc += "" + dataTable.Columns[i].ColumnName + " ";
                    sqlsc += "JSON";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) +")";
                var check = SQL_command(cmd, database);
            }
        }

        public void Update_Runtime_to_Host(DataTable dataTable, string table_Name)
        {
            MySqlDataAdapter mySqlDataAdapter = null;
            try
            {

                //SQL_command("DELETE FROM " + table_Name + "", Database);
                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }

                string Query = "SELECT * FROM " + table_Name + "";
                mySqlDataAdapter = new MySqlDataAdapter(Query, SQL_Connection);
                MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.Update(dataTable);
                error_message = string.Empty;
                SQL_Connection.Close();
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                SQL_Connection.Close();
            }

        }

        /// <summary>
        /// Cập nhật bảng hiện tại lên Server
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="Database"></param>
        /// <param name="table_Name"></param>
        public void Update_Table_to_Host(DataTable dataTable, string Database  ,string table_Name) 
        {
            MySqlDataAdapter mySqlDataAdapter = null;
            try
            {
                
                //SQL_command("DELETE FROM " + table_Name + "",Database);
                if (SQL_Connection.State == ConnectionState.Closed)
                {
                    SQL_Connection.Open();
                }
             
                string Query = "SELECT * FROM " + table_Name + "";
                mySqlDataAdapter = new MySqlDataAdapter(Query, SQL_Connection);
                MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.Update(dataTable);
                error_message = string.Empty;
                SQL_Connection.Close();
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                SQL_Connection.Close();             
            }
           
        }
        /// <summary>
        /// Tạo bảng từ file CSV
        /// </summary>
        /// <param name="path"></param>
        /// <param name="table"></param>
        /// <param name="database"></param>
        public void AutoCreat_table(string path, string table, string database)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string cmd = @"create table " + table + " ()";
                string Fulltext = string.Empty;
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString();
                    string[] rows = Fulltext.Split(new char[] { '\r', '\n' });
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(',');
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    string insert = string.Empty;
                                    if (j == rowValues.Count() - 1)
                                    {
                                        string field_insert = "C" + rowValues[j] + " VARCHAR(50)";
                                        insert = field_insert;
                                    }
                                    else if (j == 0)
                                    {
                                        string field_insert = "C" + rowValues[j] + " VARCHAR(50),";
                                        insert = field_insert;
                                    }
                                    else
                                    {
                                        string field_insert = " C" + rowValues[j] + " VARCHAR(50),";
                                        insert = field_insert;
                                    }
                                    cmd = cmd.Insert(cmd.Length - 1, insert);
                                }
                                goto HERE;
                            }

                        }
                    }

                }
            HERE:;
                bool auto_create = SQL_command(cmd, database);
            }
        }
        /// <summary>
        /// Chuyển đổi dữ liệu từ một ObservariableCollection<typeparamref name="T"/> thành dữ liệu Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable FillToDataTable<T>(ObservableCollection<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
           
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                if (type.Name == "ObservableCollection`1")
                {
                    Type type1 = typeof(string);
                    dataTable.Columns.Add(prop.Name, type1);
                }
                else
                {
                    dataTable.Columns.Add(prop.Name, type);
                }
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows

                    if (Props[i].PropertyType.Name == "ObservableCollection`1")
                    {
                        Type type1 = Props[i].PropertyType;
                        string a = JsonSerializer.Serialize(Props[i].GetValue(item, null), type1);
                        values[i] = a;
                    }
                    else
                    {
                        values[i] = Props[i].GetValue(item, null);
                    }
                   // values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }/// <summary>
        /// Chuyển đổi từ dữ liệu từ kiểu Datatable sang một ObsserCollection<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public  ObservableCollection<T> Conver_From_Data_Table_To_List<T>(DataTable dt)
        {
            ObservableCollection<T> data = new ObservableCollection<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public  T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
        private  T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            try
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                        {
                            if (pro.PropertyType == typeof(System.IO.Ports.Parity))
                            {
                                pro.SetValue(obj, (Parity)Enum.Parse(typeof(Parity), (string)dr[column.ColumnName]), null);
                            }
                            else if (pro.PropertyType == typeof(System.IO.Ports.StopBits))
                            {
                                pro.SetValue(obj, (StopBits)Enum.Parse(typeof(StopBits), (string)dr[column.ColumnName]), null);
                            }
                            else if (pro.PropertyType == typeof(ConntionTypes))
                            {
                                pro.SetValue(obj, (ConntionTypes)Enum.Parse(typeof(ConntionTypes), (string)dr[column.ColumnName]), null);
                            }
                            else if (pro.PropertyType == typeof(ModbusFunction))
                            {
                                pro.SetValue(obj, (ModbusFunction)Enum.Parse(typeof(ModbusFunction), (string)dr[column.ColumnName]), null);
                            }
                            else if (pro.PropertyType == typeof(DeviceStage))
                            {
                                pro.SetValue(obj, (DeviceStage)Enum.Parse(typeof(DeviceStage), (string)dr[column.ColumnName]), null);
                            }
                            else if (pro.PropertyType == typeof(byte[]))
                            {
                                try
                                {
                                    if ((string)dr[column.ColumnName] == string.Empty || (string)dr[column.ColumnName] == null)
                                    {
                                        pro.SetValue(obj, new byte[] { }, null);
                                    }
                                    else
                                    {
                                        pro.SetValue(obj, Encoding.UTF8.GetBytes(((string)dr[column.ColumnName])), null);
                                    }
                                }
                                catch (Exception ex)
                                {

                                    pro.SetValue(obj, new byte[] { }, null);
                                }


                            }
                            else if (pro.PropertyType == typeof(Status))
                            {
                                Status myStatus;
                                try
                                {
                                    Enum.TryParse((string)dr[column.ColumnName], out myStatus);
                                }
                                catch (Exception)
                                {

                                    myStatus = (Status)dr[column.ColumnName];
                                }


                                pro.SetValue(obj, myStatus, null);
                            }
                            else if (pro.PropertyType == typeof(TaskPriority))
                            {
                                pro.SetValue(obj, (TaskPriority)Enum.Parse(typeof(TaskPriority), (string)dr[column.ColumnName]), null);
                            }
                            else if (pro.PropertyType == typeof(System.Single))
                            {
                                pro.SetValue(obj, float.Parse(dr[column.ColumnName].ToString(), CultureInfo.InvariantCulture.NumberFormat), null);
                            }
                            else if (column.DataType == typeof(System.DBNull))
                            {
                                pro.SetValue(obj, ConvertFromDBVal<string>((string)dr[column.ColumnName]), null);
                            }
                            //else if (pro.PropertyType == typeof(Customer))
                            //{
                            //    pro.SetValue(obj,JsonSerializer.Deserialize<Customer>((string)dr[column.ColumnName]), null);
                            //}
                            //else if (pro.PropertyType == typeof(Works))
                            //{
                            //    pro.SetValue(obj, JsonSerializer.Deserialize<Works>((string)dr[column.ColumnName]), null);
                            //}
                            else if (pro.PropertyType.Name == "ObservableCollection`1")
                            {
                                Type type1 = pro.PropertyType;
                                object b = JsonSerializer.Deserialize(ConvertFromDBVal<string>((string)dr[column.ColumnName]), type1);
                                pro.SetValue(obj, b, null);
                            }
                            else if (column.DataType == typeof(System.Int32)|| column.DataType == typeof(System.Int64)|| column.DataType == typeof(System.Int16))
                            {
                                pro.SetValue(obj, Convert.ToInt32(dr[column.ColumnName].ToString()), null);
                            }
                            else
                            {
                                try
                                {
                                    pro.SetValue(obj, dr[column.ColumnName], null);
                                }
                                catch (Exception ex)
                                {

                                    pro.SetValue(obj, "", null);
                                }
                            }

                        }


                        else
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {

               
            }
            
            return obj;
        }
    }
}

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

namespace WPF_TEST.Class_Resource
{
    public class Sqlexcute
    {
        private static MySqlConnection SQL_Connection;
        public static string pwd { get; set; }
        //public static string pwd = "12345678";
        public string error_message;
        //public static string Server = "127.0.0.1";
        public static string Server { get; set; }
        public static string UId { get; set; }
        public static string Database { get { return "fwd63823_database"; } }
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
                SQL_Connection = new MySqlConnection(StrCon(Server, pwd));
                SQL_Connection.Open();
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
                using (SQL_Connection = new MySqlConnection(StrCon(Server, pwd)))
                {
                    SQL_Connection.Open();
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

                using (SQL_Connection = new MySqlConnection("Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none"))
                {
                    string str = "SELECT * FROM " + table + "";
                    MySqlDataAdapter adp = new MySqlDataAdapter(str, SQL_Connection);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(adp);

                    adp.Fill(dt);
                    error_message = string.Empty;
                    return dt;
                }

            }
            catch (Exception ex)
            {

                error_message = ex.Message;
                return dt;
            }
        }
        public DataTable Read_data(string database, string table)
        {
            DataTable dataTable = new DataTable();
            try
            {

                using (SQL_Connection = new MySqlConnection("Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none"))
                {
                    SQL_Connection.Open();
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

            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return dataTable;
            }
        }
        public bool SQL_command(string command, string database)
        {
            try
            {
                SQL_Connection = new MySqlConnection("Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none");
                SQL_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(command, SQL_Connection);

                cmd.ExecuteNonQuery();
                SQL_Connection.Close();
                error_message = string.Empty;
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

            using (SQL_Connection = new MySqlConnection("Server = " + Server + ";Database =" + database + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none"))
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
        }
        public void Check_Table(string database, string TableName,ref int check) 
        {
            int count = 2;
            using (SQL_Connection = new MySqlConnection(StrCon(Server, pwd)))
            {
                MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName), SQL_Connection);

                SQL_Connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {
                    count = reader.GetInt32(0);
                }
                SQL_Connection.Close();
            }
            check = count;
        }
        public void AutoCreateTable(DataTable dataTable, string database, string TableName, ref bool check,ref bool exist) 
        {
            string cmd;
            int count = 2;
            //*****************************************************
            // Code for processing
            using (SQL_Connection = new MySqlConnection(StrCon(Server, pwd))) 
            {
                MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName),SQL_Connection);

                SQL_Connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {
                     count = reader.GetInt32(0);
                }
                SQL_Connection.Close();
            }
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
                            sqlsc += string.Format(" VARCHAR({0}) ", dataTable.Columns[i].MaxLength == -1 ? "200" : dataTable.Columns[i].MaxLength.ToString());
                            break;
                    }
                    if (dataTable.Columns[i].AutoIncrement)
                        sqlsc += " IDENTITY(" + dataTable.Columns[i].AutoIncrementSeed.ToString() + "," + dataTable.Columns[i].AutoIncrementStep.ToString() + ") ";
                    if (!dataTable.Columns[i].AllowDBNull)
                        sqlsc += " NOT NULL ";
                    sqlsc += ",";
                }
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) +", PRIMARY KEY ("+ dataTable.Columns[0].ColumnName + "))";
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
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="table_Name"></param>
        /// <param name="Database"></param>
        /// <returns></returns>
        public MySqlDataAdapter GetData_FroM_Database(ref DataTable dataTable , string table_Name, string Database)
        {
            MySqlDataAdapter mySqlData;
            try
            {
               
                using (SQL_Connection = new MySqlConnection(StrCon_Database(Server, pwd, Database)))
                {
                    string Query = "SELECT * FROM " + table_Name + "";
                    mySqlData = new MySqlDataAdapter(Query, SQL_Connection);
                    MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlData);
                    mySqlData.Fill(dataTable);

                }
                error_message = string.Empty;
                return mySqlData;
            }
            catch (Exception ex)
            {

                error_message = ex.Message;
                return mySqlData = null;
            }

           
           
        }
        public void Create_JSon_Table(DataTable dataTable, string database, string TableName) 
        {
            string cmd;
            int count = 2;
            //*****************************************************
            // Code for processing
            using (SQL_Connection = new MySqlConnection(StrCon(Server, pwd)))
            {
                MySqlCommand command = new MySqlCommand(Check_Table_Exits(database, TableName), SQL_Connection);

                SQL_Connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {
                    count = reader.GetInt32(0);
                }
                SQL_Connection.Close();
            }
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
                cmd = sqlsc.Substring(0, sqlsc.Length - 1) + ")";
                var check = SQL_command(cmd, database);
            }
        }
        public void Update_Table_to_Host(ref MySqlDataAdapter mySqlDataAdapter, DataTable dataTable, string Database,string table_Name) 
        {
            try
            {
                mySqlDataAdapter = null;
                SQL_command("DELETE FROM " + table_Name + "",Database);
                using (SQL_Connection = new MySqlConnection(StrCon_Database(Server, pwd, Database)))
                {
                    if (mySqlDataAdapter == null) 
                    {
                        string Query = "SELECT * FROM " + table_Name + "";
                        mySqlDataAdapter = new MySqlDataAdapter(Query, SQL_Connection);
                        MySqlCommandBuilder mySqlCommand = new MySqlCommandBuilder(mySqlDataAdapter);
                    }
                    
                    mySqlDataAdapter.Update(dataTable);
                    error_message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
              
            }
           
        }
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
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
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

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName) 
                    {
                        if(pro.PropertyType == typeof(System.IO.Ports.Parity)) 
                        {
                            pro.SetValue(obj, (Parity)Enum.Parse(typeof(Parity), (string)dr[column.ColumnName]), null);
                        }
                        else if (pro.PropertyType == typeof(System.IO.Ports.StopBits)) 
                        {
                            pro.SetValue(obj, (StopBits)Enum.Parse(typeof(StopBits), (string)dr[column.ColumnName]), null);
                        }
                        else if(pro.PropertyType == typeof(ConntionTypes))
                        {
                            pro.SetValue(obj, (ConntionTypes)Enum.Parse(typeof(ConntionTypes), (string)dr[column.ColumnName]), null);
                        }
                        else if (pro.PropertyType == typeof(ModbusFunction))
                        {
                            pro.SetValue(obj, (ModbusFunction)Enum.Parse(typeof(ModbusFunction), (string)dr[column.ColumnName]), null);
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
                        else if (column.DataType == typeof(System.DBNull)) 
                        {
                            pro.SetValue(obj, ConvertFromDBVal<string>((string)dr[column.ColumnName]), null);
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
            return obj;
        }
    }
}

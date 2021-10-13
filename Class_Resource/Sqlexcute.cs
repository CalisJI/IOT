using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Class_Resource
{
    public class Sqlexcute
    {
        private static MySqlConnection SQL_Connection;
        public string pwd { get; set; }
        //public static string pwd = "12345678";
        public string error_message;
        //public static string Server = "127.0.0.1";
        public string Server { get; set; }
        public string UId { get; set; }
        //private string StrCon = "Server = " + Server + "; UId = root; Pwd = " + pwd + "; Pooling = false; Character Set=utf8";
        private string StrCon(string Server, string pwd)
        {
            string Set = "Server = " + Server + "; UId = " + UId + "; Pwd = " + pwd + "; Pooling = false; Character Set=utf8; SslMode=none";
            return Set;
        }
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
        public void AutoCreateTable(DataTable dataTable, string database, string TableName) 
        {
            string cmd = @"create table " + TableName + " ()";
            //*****************************************************
            // Code for processing

            //*****************************************************
            bool auto_create = SQL_command(cmd, database);
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
    }
}

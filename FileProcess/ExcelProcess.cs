using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.FileProcess
{
    public class ExcelProcess
    {
        public DataTableCollection DataTableCollection { get; private set; }
        private ObservableCollection <string> _pageExcel;
        List<string> item = new List<string>();
        public ObservableCollection<string> PageExcel 
        {
            get { return _pageExcel; }
            set { _pageExcel = value; }
        }
        public void Get_excel(string path , ref ObservableCollection<string> collection)
        {
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    DataTableCollection = dataSet.Tables;
                    item.AddRange(DataTableCollection.Cast<DataTable>().Select(t => t.TableName).ToArray<string>());
                    PageExcel = new ObservableCollection<string>();
                    foreach (var it in item)
                    {
                        PageExcel.Add(it);
                    }
                    collection = PageExcel;
                }
            }
        }
        public DataTable ReadCsvFile(string FileSaveWithPath)
        {

            DataTable dtCsv = new DataTable();
            string Fulltext;

            using (StreamReader sr = new StreamReader(FileSaveWithPath))
            {
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
                                    dtCsv.Columns.Add(rowValues[j]);
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr);
                            }
                        }
                    }
                }
            }

            return dtCsv;
        }
    }
}

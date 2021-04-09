using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WindowsFormsTest.Common;
using System.Data;
using System.Configuration;

namespace WindowsFormsTest
{
    public class ListBinding
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string programPath = ConfigurationManager.AppSettings.Get("ProgramPath");
        string selectQuery = ConfigurationManager.AppSettings.Get("SelectQuery");

        DataRow tableRow;
        DataColumn tableColumn = new DataColumn();

        public DataTable TableHistDataBind(DataTable tableDt)
        {
            try
            {
                string query = string.Format("{0}",selectQuery);
                tableDt = DBHandler.GetDataTable(query, connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tableDt;
        }

        public DataTable LogFileDataBind(DataTable tableDt)
        {
            try
            {
                if (Directory.Exists(programPath))
                {
                    DirectoryInfo di = new DirectoryInfo(programPath);
                    tableColumn.DataType = System.Type.GetType("System.String");
                    tableColumn.ColumnName = "Name";
                    tableDt.Columns.Add(tableColumn);

                    foreach (var items in di.GetDirectories())
                    {
                        tableRow = tableDt.NewRow();
                        tableRow["Name"] = items;
                        tableDt.Rows.Add(tableRow);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tableDt;
        }
    }
}

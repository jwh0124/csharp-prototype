using SQLiteDB.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataTable dt = DBHandler.GetSQLiteDataTable("SELECT * FROM member", connectionString);

            foreach(DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                
                Console.WriteLine(id);
            }
        }
    }
}

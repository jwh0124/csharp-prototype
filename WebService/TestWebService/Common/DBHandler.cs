using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TestWebService.Common
{
    public class DBHandler
    {
        public static DataTable GetDataTable(string query, string connectionString)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adt = new SqlDataAdapter(query, conn);
                    adt.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;
        }
    }

     
}
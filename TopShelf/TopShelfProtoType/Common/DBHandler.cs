using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TopShelfProtoType.Common
{
    public class DBHandler
    {
        public static int ExecuteNonQuery(string query,string connectionString)
        {
            int cnt = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = query;
                    cnt = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return cnt;
        }
    }
}

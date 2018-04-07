using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsTest.Common
{
    public class DBHandler
    {
        public static object ExecuteScalar(string query, string connectionString)
        {
            object result = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = conn.BeginTransaction(IsolationLevel.ReadUncommitted);

                try
                {
                    cmd.CommandText = query;
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        public static int ExecuteNonQuery(string query, string connectionString)
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

        public static void ExecuteSqlTransaction(string[] queries, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction trans = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.Transaction = trans;

                try
                {


                    for (int i = 0; i < queries.Length; i++)
                    {
                        cmd.CommandText = queries[i];
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();

                    throw ex;
                }
            }
        }

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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDB.Common
{
    public class DBHandler
    {
        // SQLite DB Connection Get Data
        public static DataTable GetSQLiteDataTable(string query, string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString, true))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    try
                    {
                        SQLiteDataAdapter sadt = new SQLiteDataAdapter(query, connectionString);
                        sadt.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        // SQLite DB Connection ExecuteNonQuery
        public static int ExecuteNonQuery(string query, string connectionString)
        {
            int result = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();
                try
                {
                    cmd.CommandText = query;
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
    }
}

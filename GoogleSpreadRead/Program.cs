using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Numerics;
using System.Threading;

namespace GoogleSpreadRead
{
    class Program
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";

        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            { // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //https://docs.google.com/spreadsheets/d/1gZIM8-GbbocTJL0osYCM4H1epi6Kke8d7wCQfsBFhQA/edit#gid=162993803
            //1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms 구글 예제
            //
            // Define request parameters.
            String spreadsheetId = "1gZIM8-GbbocTJL0osYCM4H1epi6Kke8d7wCQfsBFhQA";// 1) d/ ~~/edit 사이의 ID 를 말함
            String range = "CS_rawdata!A2:AB";// 2)범위 지정   "시트명!범위"  A2:F 끝까지;
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            DateTime now = DateTime.Now;

            if (values != null && values.Count > 0)//0이상이거나 null
            {
                foreach (var row in values)
                {

                    if (DateTime.Compare(DateTime.Parse(row[0].ToString()), now) < 0)
                    {
                        if(Convert.ToInt32(GetDate(DateTime.Parse(row[0].ToString()))) == 0)
                            Insert(row);
                    }
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        private static string GetDbConnection()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            string strConnection = builder.Build().GetConnectionString("DefaultConnection");

            return strConnection;                                           
        }
        private static object GetDate(DateTime date)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(GetDbConnection());
            conn.Open();

            using NpgsqlCommand cmd = new NpgsqlCommand("select count(*) from cs_daily where date = @date", conn);

            cmd.Parameters.AddWithValue("@date", date);

            var result = cmd.ExecuteScalar();
            return result;
        }

        private static void Insert(IList<Object> row)
        {
            try
            {
                if(Convert.ToDecimal(row[1].ToString()) != 0)
                {
                    using NpgsqlConnection conn = new NpgsqlConnection(GetDbConnection());
                    conn.Open();

                    using NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO cs_daily VALUES (" +
                           "@date, @order_cnt, @order_cnt_bh, @order_cnt_hpg, @order_cnt_act," +
                           "@cr, @cr_bh, @cr_hpg, @cr_act," +
                           "@call_inbound, @call_inbound_bh, @call_inbound_hpg, @call_inbound_act," +
                           "@call_inbound_suc, @call_inbound_suc_bh, @call_inbound_suc_hpg, @call_inbound_suc_act," +
                           "@call_inbound_rate, @call_inbound_rate_bh, @call_inbound_rate_hpg, @call_inbound_rate_act," +
                           "@direct, @chat, @total_inbound, @total_inbound_suc, @total_employee, @call_employee, @cpd)", conn);

                    cmd.Parameters.AddWithValue("@date", DateTime.Parse(row[0].ToString()));
                    cmd.Parameters.AddWithValue("@order_cnt", Convert.ToDecimal(row[1].ToString()));
                    cmd.Parameters.AddWithValue("@order_cnt_bh", Convert.ToDecimal(row[2].ToString()));
                    cmd.Parameters.AddWithValue("@order_cnt_hpg", Convert.ToDecimal(row[3].ToString()));
                    cmd.Parameters.AddWithValue("@order_cnt_act", Convert.ToDecimal(row[4].ToString()));
                    cmd.Parameters.AddWithValue("@cr", Convert.ToDecimal(row[5].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@cr_bh", Convert.ToDecimal(row[6].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@cr_hpg", Convert.ToDecimal(row[7].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@cr_act", Convert.ToDecimal(row[8].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@call_inbound", Convert.ToDecimal(row[9].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_bh", Convert.ToDecimal(row[10].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_hpg", Convert.ToDecimal(row[11].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_act", Convert.ToDecimal(row[12].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_suc", Convert.ToDecimal(row[13].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_suc_bh", Convert.ToDecimal(row[14].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_suc_hpg", Convert.ToDecimal(row[15].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_suc_act", Convert.ToDecimal(row[16].ToString()));
                    cmd.Parameters.AddWithValue("@call_inbound_rate", Convert.ToDecimal(row[17].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@call_inbound_rate_bh", Convert.ToDecimal(row[18].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@call_inbound_rate_hpg", Convert.ToDecimal(row[19].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@call_inbound_rate_act", Convert.ToDecimal(row[20].ToString().TrimEnd(new char[] { '%', ' ' })));
                    cmd.Parameters.AddWithValue("@direct", Convert.ToDecimal(row[21].ToString()));
                    cmd.Parameters.AddWithValue("@chat", Convert.ToDecimal(row[22].ToString()));
                    cmd.Parameters.AddWithValue("@total_inbound", Convert.ToDecimal(row[23].ToString()));
                    cmd.Parameters.AddWithValue("@total_inbound_suc", Convert.ToDecimal(row[24].ToString()));
                    cmd.Parameters.AddWithValue("@total_employee", Convert.ToDecimal(row[25].ToString()));
                    cmd.Parameters.AddWithValue("@call_employee", Convert.ToDecimal(row[26].ToString()));
                    cmd.Parameters.AddWithValue("@cpd", Convert.ToDecimal(row[27].ToString()));

                    int rows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {   
                Console.WriteLine("Error Row Date : " + row[0] + " Message : " + e.Message);
            }
        } 
    }
}

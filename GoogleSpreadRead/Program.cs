using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
            
            if (values != null && values.Count > 0)//0이상이거나 null
            {
                foreach (var row in values)
                {
                    
                    if (DateTime.Compare(DateTime.Parse(row[0].ToString()),DateTime.Parse(GetSeardate())) == 0)
                    {
                        // TODO : Database Save
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

        private static string GetSeardate()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var val = builder.Build().GetSection("SearchDate").Value;

            return val;
        }

        private static void Insert(IList<Object> row)
        {
            try
            {
                using NpgsqlConnection conn = new NpgsqlConnection(GetDbConnection());
                conn.Open();

                using NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO student(id,name) VALUES (" +
                       "@Id,@Name)", conn);
                cmd.Parameters.AddWithValue("@Id", row[1]);
                cmd.Parameters.AddWithValue("@Name", row[2]);

                int rows = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {   
                Console.WriteLine(e.Message);
            }
        } 
    }
}

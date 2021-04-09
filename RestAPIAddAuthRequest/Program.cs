using RestSharp;
using System;

namespace RestSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://172.16.190.199:5000");

            var request = new RestRequest("api/admin", Method.GET);
            request.AddHeader("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVqYmFlIiwibmJmIjoxNTkzNTA2NTk4LCJleHAiOjE1OTQxMTEzOTgsImlhdCI6MTU5MzUwNjU5OH0.uyCWuSs8kBzgo65e-271X8FVb_1z9VfcCn-WjMPuehU");


            var response = client.Execute(request);
        }
    }
}

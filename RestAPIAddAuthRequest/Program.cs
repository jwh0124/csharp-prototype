using RestSharp;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace RestSharpTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new RestClient("http://192.168.0.150:8080/");
            Console.WriteLine("Hello world");
            var login = new RestRequest("/api/login", Method.POST);
            login.AddHeader("Content-Type", "application/json");
            login.AddHeader("Cookie", ".ASPXAUTH=BCFD713BFE6500CCB0C745F9DB0EC68B8F2C4890D4A60FC5EB1BFDD04E4FE5D8343FD2CE88548D601158EC8959DB870A217EF0FB7CAB32CE990236E3C6991F21AE783C48D4B53431DA7BB82EE0AEBEB6; ASP.NET_SessionId=epnfsv5egzr2iivg144ji0yy; JSESSIONID=E60C4D7EC870955F2B0DCB607334BBD1");
            var loginInfo = @"{""User"":{""login_id"":""admin"",""password"":""admin3919!""}}";
            login.AddJsonBody(loginInfo);

            var response = await client.ExecuteAsync(login);
            string sessionId = response.Headers
                    .Where(x => x.Name == "bs-session-id")
                    .Select(x => x.Value)
                    .FirstOrDefault().ToString();

            Console.WriteLine(sessionId);
            
            var open = new RestRequest("/api/doors/open", Method.POST);
            open.AddHeader("Cookie", "ASP.NET_SessionId=epnfsv5egzr2iivg144ji0yy; .ASPXAUTH=BCFD713BFE6500CCB0C745F9DB0EC68B8F2C4890D4A60FC5EB1BFDD04E4FE5D8343FD2CE88548D601158EC8959DB870A217EF0FB7CAB32CE990236E3C6991F21AE783C48D4B53431DA7BB82EE0AEBEB6; bs-ta-session-id=s%3A6SxEsZGgzKEFbz9DeICtvoRw.AK4z5Vc9lRxbCoHPkB3DztSDZOFAAUwgNq%2BH3I8REt0; JSESSIONID=E60C4D7EC870955F2B0DCB607334BBD1; .ASPXAUTH=BCFD713BFE6500CCB0C745F9DB0EC68B8F2C4890D4A60FC5EB1BFDD04E4FE5D8343FD2CE88548D601158EC8959DB870A217EF0FB7CAB32CE990236E3C6991F21AE783C48D4B53431DA7BB82EE0AEBEB6; ASP.NET_SessionId=epnfsv5egzr2iivg144ji0yy; JSESSIONID=E60C4D7EC870955F2B0DCB607334BBD1");
            open.AddHeader("bs-session-id", sessionId);
            open.AddHeader("Content-Type", "application/json");
            var doorInfo = @"{""DoorCollection"":{""total"":1,""rows"":[{""id"":1}]}}";
            open.AddJsonBody(doorInfo);
            var openResponse = await client.ExecuteAsync(open);
            Console.WriteLine(openResponse.Content);
        }
    }
}

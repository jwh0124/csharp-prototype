using RestSharp;
using System;

namespace RestAPICallPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            IRestClient client = new RestClient("http://172.16.150.203:5000/");
            IRestRequest request = new RestRequest("auth/card/425DF736", Method.PUT);

            //request.AddParameter("No", "425DF736");
            Console.WriteLine(client.ExecuteAsync(request).Result.StatusCode);
        }
    }
}

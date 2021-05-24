using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace DataBaseTableInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                .AddJsonFile($"appsettings.json", true, true).Build();


            using (var context = new DatabaseContext(configuration.GetConnectionString("Default")))
            {
                EntityRepository repository = new EntityRepository(context);

                for (int i = 1; i <= 50000; i++)
                {
                    Entity newData = new Entity();
                    newData.userId = 1;
                    newData.deviceId = 1;
                    newData.result = 1;
                    newData.authType = 1;
                    newData.imageFile = "test";
                    newData.accessDt = DateTime.Now;
                    newData.reason = 1;
                    newData.cardNo = "321321";
                    repository.InsertData(newData);
                    Console.WriteLine("Insert Count : " + i);
                }
            }
        }
    }
}

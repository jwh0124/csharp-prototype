using CUPrototype;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestCUPrototype.Config
{
    public class TestControllerProvider :IDisposable
    {
        public TestServer testServer;
        public HttpClient Client { get; private set; }
        public TestControllerProvider()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("E:\\CUBOX\\Private\\CSharp\\CUPrototype\\appsettings.json").Build();

            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseConfiguration(configuration));
            
            Client = testServer.CreateClient();
        }

        public void Dispose()
        {
            testServer.Dispose();
            Client.Dispose();
        }
    }
}

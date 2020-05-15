using CUPrototype;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestCUPrototype.Config
{
    public class TestControllerProvider : IDisposable
    {
        public TestServer testServer;
        public HttpClient Client { get; private set; }
        public TestControllerProvider()
        {
            
            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            
            Client = testServer.CreateClient();
        }

        public void Dispose()
        {
            testServer.Dispose();
            Client.Dispose();
        }
    }
}

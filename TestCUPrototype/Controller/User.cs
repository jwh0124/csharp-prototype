using CUPrototype.Controller;
using CUPrototype.DTO;
using CUPrototype.Service;
using CUPrototype.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using TestCUPrototype.Config;
using Xunit;

namespace TestCUPrototype.Controller
{
    public class User : TestControllerProvider
    {
        
        [Fact]
        public void GetUserList()
        {
            var response = Client.GetAsync("/api/user");

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Fact]
        public void PostUser()
        {
            var response = Client.PostAsync("/api/user", new StringContent(JsonConvert.SerializeObject(new UserDto()
            {
                Name = "Jung"
            }),Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.Created, response.Result.StatusCode);
        }
    }
}

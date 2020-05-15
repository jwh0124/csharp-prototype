using CUPrototype.DTO;
using Newtonsoft.Json;
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
        public void GetUser()
        {
            var response = Client.GetAsync("/api/user/1");

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

        [Fact]
        public void PutUser()
        {
            var response = Client.PutAsync("/api/user/1", new StringContent(JsonConvert.SerializeObject(new UserDto()
            {
                Name = "Kim"
            }), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.NoContent, response.Result.StatusCode);
        }

        [Fact]
        public void DeleteUser()
        {
            var response = Client.DeleteAsync("/api/user/1");

            Assert.Equal(HttpStatusCode.NoContent, response.Result.StatusCode);
        }
    }
}

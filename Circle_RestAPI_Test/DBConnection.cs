using Circle_RestAPI.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Circle_RestAPI_Test
{
    public class DBConnection
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public DBConnection()
        {
            _configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();
            _context = _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(_configuration.GetConnectionString("DefaultConnection"), options =>
                options.EnableRetryOnFailure(1)).Options);
        }

        [Fact]
        [Trait("Database","Connect")]
        public void Database_Connect()
        {
            var connectionresult = _context.Database.CanConnect();

            Assert.True(connectionresult);
        }


        /*[Fact]
        [Trait("Database", "Connect")]
        public void Database_Connect_Failure()
        {
            Assert.Throws<RetryLimitExceededException>(() => _context.Database.CanConnect());
        }*/
    }
}

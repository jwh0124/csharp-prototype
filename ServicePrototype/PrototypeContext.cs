using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicePrototype.Models;
using System.IO;

namespace ServicePrototype
{
    public class PrototypeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO : GetConfiguration Common Integration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}

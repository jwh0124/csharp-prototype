using Microsoft.EntityFrameworkCore;
using ServicePrototype.Models;

namespace ServicePrototype
{
    public class PrototypeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=text.db");
        }

        public DbSet<User> Users { get; set; }
    }
}

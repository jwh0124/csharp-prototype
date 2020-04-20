using Microsoft.EntityFrameworkCore;
using testAutoHistory.Models;

namespace testAutoHistory
{
    public class UserDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=E:\\CUBOX\\Private\\CSharp\\testAutoHistory\\text.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EnableAutoHistory(null);
        }

        public DbSet<User> Users { get; set; }
    }
}

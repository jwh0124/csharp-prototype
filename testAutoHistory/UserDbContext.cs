using Microsoft.EntityFrameworkCore;
using testAutoHistory.Models;

namespace testAutoHistory
{
    public class UserDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=E:\\CUBOX\\prototype\\testAutoHistory\\text.db");
        }

        public DbSet<User> Users { get; set; }
    }
}

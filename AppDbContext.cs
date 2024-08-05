using Microsoft.EntityFrameworkCore;

namespace MyWebApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=cs38_db;user=cs38;password=cs38",
                new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}

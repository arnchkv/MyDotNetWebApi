using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using MyWebApi.Models;

namespace MyWebApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Load environment variables from .env file
            Env.Load();
            
            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var database = Environment.GetEnvironmentVariable("DB_DATABASE");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"server={server};database={database};user={user};password={password}";

            optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}

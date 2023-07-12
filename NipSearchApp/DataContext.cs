using Microsoft.EntityFrameworkCore;
using NipSearchApp.Models;

namespace NipSearchApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Subject> Subject { get; set; }
        public DbSet<Representatives> Representatives { get; set; }
        public DbSet<AuthorizedClerks> AuthorizedClerks { get; set; }
        public DbSet<Partners> Partners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other entity configurations...
        }
    }
}

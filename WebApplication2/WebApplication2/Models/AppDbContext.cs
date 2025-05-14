using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApplication2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
    }
}


using Microsoft.EntityFrameworkCore;
using ProductManagementSystemTest.Model;

namespace ProductManagementSystemNet.DBEntity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }


    }

}

using Microsoft.EntityFrameworkCore;
using OrderManagment.Models;

namespace OrderManagment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

    }
}

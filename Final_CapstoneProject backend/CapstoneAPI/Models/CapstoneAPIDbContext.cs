using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Models
{
    public class CapstoneAPIDbContext : DbContext
    {
        public DbSet<Register> Register { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<DeliveryPincode> DeliveryPincode { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<Product> Product { get; set; }

        public CapstoneAPIDbContext() : base() { }

        public CapstoneAPIDbContext(DbContextOptions<CapstoneAPIDbContext> options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    if (!builder.IsConfigured)
        //    {
        //        builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Capstone_DB;Integrated Security=True;");

        //    }
        //}
    }
}

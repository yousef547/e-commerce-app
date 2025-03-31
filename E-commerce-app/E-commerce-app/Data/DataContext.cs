
using E_commerce_app.Entities;
using Microsoft.EntityFrameworkCore;



namespace E_commerce_app.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderDetails { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder bulider) {
            base.OnModelCreating(bulider);

            bulider.Entity<Order>()
                .HasMany(ur => ur.OrderProducts)
                .WithOne(u => u.Order)
                .HasForeignKey(ur => ur.OrderId)
                .IsRequired();

            bulider.Entity<Product>()
            .HasMany(ur => ur.OrderProducts)
            .WithOne(u => u.Product)
            .HasForeignKey(ur => ur.ProductId)
            .IsRequired();


        }
    }
}

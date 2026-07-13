using System.Data.Entity;

namespace IsintuWebsite.Models
{
    // Code-first EF6 context, wired up to talk to MySQL through the connection
    // string named "IsintuDbContext" in Web.config.
    public class IsintuDbContext : DbContext
    {
        public IsintuDbContext() : base("name=IsintuDbContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Hire> Hires { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Order -> Delivery and Order -> Payment are both one-to-one,
            // so EF needs a bit of help figuring out the relationship.
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Delivery)
                .WithRequired(d => d.Order);

            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Payment)
                .WithRequired(p => p.Order);

            modelBuilder.Entity<OrderItem>()
                .HasOptional(oi => oi.Hire)
                .WithRequired(h => h.OrderItem);

            base.OnModelCreating(modelBuilder);
        }
    }
}

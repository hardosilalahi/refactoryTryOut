using Microsoft.EntityFrameworkCore;
using refactorytryout.Models;

namespace refactorytryout
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options): base(options){}

        public DbSet<Customer> Customer {get; set;}
        public DbSet<Driver> Driver {get; set;}
        public DbSet<Order> Order {get; set;}
        public DbSet<Product> Product {get; set;}
        public DbSet<Order_item> Order_item {get; set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Drivers>()
        //         .HasOne(p => p.Orders)
        //         .WithMany(b => b.Driver);
        // }
    }
}
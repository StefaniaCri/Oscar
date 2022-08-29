using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Oscar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers;
        public DbSet<Adress> Adresses;
        public DbSet<Order> Orders;
        public DbSet<Product> Products;
        public DbSet<ProductOrder> ProductOrders;
      

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //One to Many

            modelBuilder.Entity<Customer>()
               .HasMany(cust => cust.Orders)
               .WithOne(ord => ord.Customer);

            //One to One
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Adress)
                 .WithOne(adr => adr.Customer);

            //Many to Many
            modelBuilder.Entity<ProductOrder>().HasKey(po => new { po.OrderId, po.ProductId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(o => o.Order)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(dis => dis.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(dis => dis.Product)
                .WithMany(dis => dis.ProductOrders)
                .HasForeignKey(dis => dis.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

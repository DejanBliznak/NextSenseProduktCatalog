using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contex
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderID, od.ProductID });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderDate)
                .HasDatabaseName("IX_Order_OrderDate");

            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "Laptop", Price = 1000.00m, Manufacturer = "Dell" },
                new Product { ID = 2, Name = "Smartphone", Price = 800.00m, Manufacturer = "Samsung" },
                new Product { ID = 3, Name = "Headphones", Price = 150.00m, Manufacturer = "Sony" },
                new Product { ID = 4, Name = "Smartwatch", Price = 250.00m, Manufacturer = "Apple" },
                new Product { ID = 5, Name = "Monitor", Price = 300.00m, Manufacturer = "Dell" },
                new Product { ID = 6, Name = "Keyboard", Price = 50.00m, Manufacturer = "Dell" },
                new Product { ID = 7, Name = "Mouse", Price = 40.00m, Manufacturer = "Dell" },
                new Product { ID = 8, Name = "Tablet", Price = 500.00m, Manufacturer = "Apple" },
                new Product { ID = 9, Name = "External Hard Drive", Price = 120.00m, Manufacturer = "Samsung" },
                new Product { ID = 10, Name = "Printer", Price = 200.00m, Manufacturer = "Sony" }
 );
        }
    }
}

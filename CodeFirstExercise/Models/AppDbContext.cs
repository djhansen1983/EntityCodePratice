using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstExercise.Models
{
    public class AppDbContext : DbContext
    {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> Orderline { get; set; }

        public AppDbContext() { }//constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = @"server=localhost\sqlexpress;database=SalesDb28;trusted_connection=true;";
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(connStr);
            }

        } 

        //Fluent-API statements go here
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.Property("Code").HasMaxLength(8).IsRequired(true);
                e.HasIndex("Code").IsUnique();
            });

        }


    }
}

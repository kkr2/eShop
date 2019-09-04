using eShop.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Database
{
   public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<OrderStock> OrderStocks{ get; set; }
        public DbSet<StockOnHold> StockOnHolds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderStock>()
                .HasKey(a => new {a.StockId, a.OrderId});


        }

    }
}

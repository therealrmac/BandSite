using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BandSite.Models;

namespace BandSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Order>()
               .Property(b => b.DateCreated)
               .HasDefaultValueSql("GETDATE()");
            builder.Entity<Product>()
               .Property(b => b.DateCreated)
               .HasDefaultValueSql("GETDATE()");
            builder.Entity<Forum>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<ThreadPost>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

        }

        public DbSet<BandSite.Models.Order> Order { get; set; }

        public DbSet<BandSite.Models.Product> Product { get; set; }

        public DbSet<BandSite.Models.PaymentType> PaymentType { get; set; }

        public DbSet<BandSite.Models.ProductType> ProductType { get; set; }

        public DbSet<BandSite.Models.ShippingAddress> ShippingAddress { get; set; }

        public DbSet<BandSite.Models.Forum> Forum { get; set; }

        public DbSet<BandSite.Models.ThreadPost> ThreadPost { get; set; }

        public DbSet<BandSite.Models.Members> Members { get; set; }

        public DbSet<BandSite.Models.OrderProduct> OrderProduct { get; set; }
        
    }
}

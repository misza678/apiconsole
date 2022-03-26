using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiconsole.Models;
using apiconsole.Models.Repair;
using apiconsole.Models.CollectionCentre;
using apiconsole.IdentityAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using apiconsole.Models.Other;

namespace consolestoreapi.Models
{
    public class ConsoleStoreDbContext:IdentityDbContext<ApplicationUser>
    {
        public ConsoleStoreDbContext(DbContextOptions<ConsoleStoreDbContext>options):base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ShippingMetod> ShippingMetod { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Defect> Defect { get; set; }
        public DbSet<CollectionItem> CollectionItem { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<DefectModel> DefectModel { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Model>().HasMany(p => p.Defects).WithMany(p => p.Models).UsingEntity<DefectModel>(j => j.HasOne(pt => pt.Defect).WithMany(t => t.DefectModels).HasForeignKey(pt => pt.DefectID),
            j => j.HasOne(pt => pt.Model).WithMany(t => t.DefectModels).HasForeignKey(pt => pt.ModelID),
            j => { j.HasKey(t => new { t.ModelID, t.DefectID }); 
            });
            builder.Entity<CollectionItem>()
       .HasMany(c => c.Images)
       .WithOne(e => e.CollectionItem);
        }



    }
}

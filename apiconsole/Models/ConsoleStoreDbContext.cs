using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiconsole.Models;
using apiconsole.Models.Repair;

namespace consolestoreapi.Models
{
    public class ConsoleStoreDbContext:DbContext
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
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductsToView> ProductsToView { get; set; }
        public DbSet<MainProductsToView> MainProductToView { get; set; }
        public DbSet<Defect> Defect { get; set; }
  
    }
}

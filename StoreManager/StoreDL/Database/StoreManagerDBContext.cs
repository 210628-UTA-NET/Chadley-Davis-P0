using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.IO;

namespace StoreDL.Database
{
    public class StoreManagerDBContext : DbContext
    {
        public DbSet<StoreFront> StoreFronts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        static string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
        public StoreManagerDBContext()
        {

            //Get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Grabs our connectionString from our appsetting.json
            ConnectionString = configuration.GetConnectionString("DefaultConnection");            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(product => product.Category).HasConversion<int>();
        }
    }
}
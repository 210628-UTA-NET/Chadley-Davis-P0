using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
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

            modelBuilder.Entity<Order>().Property(order => order.OrderStatus).HasConversion<int>();

            modelBuilder
                .Entity<StoreFront>()
                .HasMany(p => p.Customers)
                .WithMany(p => p.StoreFronts)
                .UsingEntity(j => j.ToTable("StoreFrontCustomers"));

            modelBuilder.Entity<ContactInformation>().HasOne(c => c.Address).WithOne(a => a.ContactInformation);

            modelBuilder.Entity<StoreFront>().HasMany(s => s.Orders).WithOne(o => o.StoreFront);
            modelBuilder.Entity<Customer>().HasMany(o => o.Orders).WithOne(o => o.Customer);

            modelBuilder.Entity<Order>().HasMany(o => o.Details).WithOne(d => d.Order);

            modelBuilder.Entity<StoreFront>().HasMany(s => s.Inventory).WithOne(o => o.StoreFront);




        }
    }
}
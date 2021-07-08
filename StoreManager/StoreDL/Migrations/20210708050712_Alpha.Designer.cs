﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreDL.Database;

namespace StoreDL.Migrations
{
    [DbContext(typeof(StoreManagerDBContext))]
    [Migration("20210708050712_Alpha")]
    partial class Alpha
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Models.Entities.ContactInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("Models.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StoreFrontId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("StoreFrontId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.Entities.Detail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid?>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("Models.Entities.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Models.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StoreFrontId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StoreFrontId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StoreFrontId2")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StoreFrontId");

                    b.HasIndex("StoreFrontId1");

                    b.HasIndex("StoreFrontId2");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.Entities.StoreFront", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("InventoryId");

                    b.ToTable("StoreFronts");
                });

            modelBuilder.Entity("Models.Entities.ContactInformation", b =>
                {
                    b.HasOne("Models.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Models.Entities.Customer", b =>
                {
                    b.HasOne("Models.Entities.ContactInformation", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Models.Entities.StoreFront", null)
                        .WithMany("Customers")
                        .HasForeignKey("StoreFrontId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Models.Entities.Detail", b =>
                {
                    b.HasOne("Models.Entities.Inventory", null)
                        .WithMany("Details")
                        .HasForeignKey("InventoryId");

                    b.HasOne("Models.Entities.Order", null)
                        .WithMany("Details")
                        .HasForeignKey("OrderId");

                    b.HasOne("Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Models.Entities.Order", b =>
                {
                    b.HasOne("Models.Entities.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Models.Entities.StoreFront", null)
                        .WithMany("CompletedOrders")
                        .HasForeignKey("StoreFrontId");

                    b.HasOne("Models.Entities.StoreFront", null)
                        .WithMany("Pendingorders")
                        .HasForeignKey("StoreFrontId1");

                    b.HasOne("Models.Entities.StoreFront", null)
                        .WithMany("ShoppingCart")
                        .HasForeignKey("StoreFrontId2");
                });

            modelBuilder.Entity("Models.Entities.StoreFront", b =>
                {
                    b.HasOne("Models.Entities.ContactInformation", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Models.Entities.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.Navigation("Contact");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("Models.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.Entities.Inventory", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Models.Entities.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Models.Entities.StoreFront", b =>
                {
                    b.Navigation("CompletedOrders");

                    b.Navigation("Customers");

                    b.Navigation("Pendingorders");

                    b.Navigation("ShoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}
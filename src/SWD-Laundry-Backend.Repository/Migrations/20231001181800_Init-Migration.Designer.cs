﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWD_Laundry_Backend.Repository.Infrastructure;

#nullable disable

namespace SWD_Laundry_Backend.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231001181800_Init-Migration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Building", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuildingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserID");

                    b.HasIndex("BuildingID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WalletID")
                        .IsUnique()
                        .HasFilter("[WalletID] IS NOT NULL");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.LaundryStore", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserID");

                    b.ToTable("LaundryStores");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Amount")
                        .HasColumnType("smallint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CustomerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DeliveryTimeFrame")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpectedFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LaundryStoreID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("StaffID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("LaundryStoreID");

                    b.HasIndex("StaffID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.OrderHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DeliveryStatus")
                        .HasColumnType("int");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("LaundryStatus")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Staff_Trip", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuildingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("StaffID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeScheduleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TripCollect")
                        .HasColumnType("int");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingID");

                    b.HasIndex("StaffID");

                    b.HasIndex("TimeScheduleID");

                    b.ToTable("Staff_Trips");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("WalletID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WalletID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Wallet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Staff", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("TimeSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeFrame")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TimeSchedules");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Customer", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserID");

                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Building", "Building")
                        .WithMany("Customers")
                        .HasForeignKey("BuildingID");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels.ApplicationUser", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Wallet", "Wallet")
                        .WithOne("ApplicationUser")
                        .HasForeignKey("SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels.ApplicationUser", "WalletID");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.LaundryStore", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserID");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Order", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerID");

                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.LaundryStore", "LaundryStore")
                        .WithMany("Orders")
                        .HasForeignKey("LaundryStoreID");

                    b.HasOne("Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffID");

                    b.Navigation("Customer");

                    b.Navigation("LaundryStore");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.OrderHistory", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Order", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderID");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Payment", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Order", "Orders")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId");

                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Transaction", "Transaction")
                        .WithMany("Payments")
                        .HasForeignKey("TransactionId");

                    b.Navigation("Orders");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Staff_Trip", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Building", "Building")
                        .WithMany("Staff_Trips")
                        .HasForeignKey("BuildingID");

                    b.HasOne("Staff", "Staff")
                        .WithMany("Staff_Trips")
                        .HasForeignKey("StaffID");

                    b.HasOne("TimeSchedule", "TimeSchedule")
                        .WithMany("Staff_Trip")
                        .HasForeignKey("TimeScheduleID");

                    b.Navigation("Building");

                    b.Navigation("Staff");

                    b.Navigation("TimeSchedule");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Transaction", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletID");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Staff", b =>
                {
                    b.HasOne("SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserID");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Building", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Staff_Trips");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.LaundryStore", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Order", b =>
                {
                    b.Navigation("OrderHistories");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Transaction", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SWD_Laundry_Backend.Contract.Repository.Entity.Wallet", b =>
                {
                    b.Navigation("ApplicationUser");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Staff", b =>
                {
                    b.Navigation("Staff_Trips");
                });

            modelBuilder.Entity("TimeSchedule", b =>
                {
                    b.Navigation("Staff_Trip");
                });
#pragma warning restore 612, 618
        }
    }
}

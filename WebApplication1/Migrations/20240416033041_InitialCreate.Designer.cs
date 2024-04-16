﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240416033041_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("WebApplication1.Areas.BookingManagement.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Bookings", "Identity");
                });

            modelBuilder.Entity("WebApplication1.Areas.BookingManagement.Models.CarRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PricePerDay")
                        .HasColumnType("real");

                    b.Property<string>("RentalAgency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarRentals", "Identity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = true,
                            Model = "Toyota Camry",
                            PricePerDay = 70f,
                            RentalAgency = "Enterprise Rent-A-Car"
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = true,
                            Model = "Honda Civic",
                            PricePerDay = 60f,
                            RentalAgency = "Hertz"
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = true,
                            Model = "Ford Mustang",
                            PricePerDay = 120f,
                            RentalAgency = "Avis"
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = true,
                            Model = "Chevrolet Malibu",
                            PricePerDay = 80f,
                            RentalAgency = "Budget"
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = true,
                            Model = "Nissan Altima",
                            PricePerDay = 75f,
                            RentalAgency = "Alamo Rent A Car"
                        },
                        new
                        {
                            Id = 6,
                            IsAvailable = true,
                            Model = "Hyundai Elantra",
                            PricePerDay = 65f,
                            RentalAgency = "National Car Rental"
                        },
                        new
                        {
                            Id = 7,
                            IsAvailable = true,
                            Model = "Volkswagen Jetta",
                            PricePerDay = 70f,
                            RentalAgency = "Dollar Car Rental"
                        },
                        new
                        {
                            Id = 8,
                            IsAvailable = true,
                            Model = "Subaru Outback",
                            PricePerDay = 85f,
                            RentalAgency = "Thrifty Car Rental"
                        },
                        new
                        {
                            Id = 9,
                            IsAvailable = true,
                            Model = "BMW 3 Series",
                            PricePerDay = 150f,
                            RentalAgency = "Sixt Rent A Car"
                        },
                        new
                        {
                            Id = 10,
                            IsAvailable = true,
                            Model = "Mercedes-Benz C-Class",
                            PricePerDay = 180f,
                            RentalAgency = "Europcar"
                        },
                        new
                        {
                            Id = 11,
                            IsAvailable = true,
                            Model = "Audi A4",
                            PricePerDay = 160f,
                            RentalAgency = "Fox Rent A Car"
                        },
                        new
                        {
                            Id = 12,
                            IsAvailable = true,
                            Model = "Tesla Model 3",
                            PricePerDay = 250f,
                            RentalAgency = "Tesla"
                        },
                        new
                        {
                            Id = 13,
                            IsAvailable = true,
                            Model = "Jeep Wrangler",
                            PricePerDay = 100f,
                            RentalAgency = "U-Haul"
                        },
                        new
                        {
                            Id = 14,
                            IsAvailable = true,
                            Model = "GMC Yukon",
                            PricePerDay = 120f,
                            RentalAgency = "Penske Truck Rental"
                        },
                        new
                        {
                            Id = 15,
                            IsAvailable = true,
                            Model = "Toyota Prius",
                            PricePerDay = 50f,
                            RentalAgency = "Zipcar"
                        });
                });

            modelBuilder.Entity("WebApplication1.Areas.BookingManagement.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Flights", "Identity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8339),
                            DepartureTime = new DateTime(2024, 4, 15, 23, 30, 40, 231, DateTimeKind.Local).AddTicks(8267),
                            Destination = "Los Angeles",
                            FlightNumber = "ABC123",
                            Origin = "New York",
                            Price = 200f
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2024, 4, 16, 5, 30, 40, 231, DateTimeKind.Local).AddTicks(8351),
                            DepartureTime = new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8349),
                            Destination = "Chicago",
                            FlightNumber = "DEF456",
                            Origin = "Los Angeles",
                            Price = 250f
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2024, 4, 16, 6, 30, 40, 231, DateTimeKind.Local).AddTicks(8357),
                            DepartureTime = new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8355),
                            Destination = "Houston",
                            FlightNumber = "GHI789",
                            Origin = "Chicago",
                            Price = 280f
                        },
                        new
                        {
                            Id = 4,
                            ArrivalTime = new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8363),
                            DepartureTime = new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8361),
                            Destination = "Miami",
                            FlightNumber = "JKL012",
                            Origin = "Houston",
                            Price = 300f
                        },
                        new
                        {
                            Id = 5,
                            ArrivalTime = new DateTime(2024, 4, 16, 6, 30, 40, 231, DateTimeKind.Local).AddTicks(8368),
                            DepartureTime = new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8366),
                            Destination = "New York",
                            FlightNumber = "MNO345",
                            Origin = "Miami",
                            Price = 270f
                        },
                        new
                        {
                            Id = 6,
                            ArrivalTime = new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8373),
                            DepartureTime = new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8371),
                            Destination = "Paris",
                            FlightNumber = "PQR678",
                            Origin = "London",
                            Price = 350f
                        },
                        new
                        {
                            Id = 7,
                            ArrivalTime = new DateTime(2024, 4, 16, 5, 30, 40, 231, DateTimeKind.Local).AddTicks(8378),
                            DepartureTime = new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8376),
                            Destination = "Berlin",
                            FlightNumber = "STU901",
                            Origin = "Paris",
                            Price = 320f
                        },
                        new
                        {
                            Id = 8,
                            ArrivalTime = new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8383),
                            DepartureTime = new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8382),
                            Destination = "Rome",
                            FlightNumber = "VWX234",
                            Origin = "Berlin",
                            Price = 380f
                        },
                        new
                        {
                            Id = 9,
                            ArrivalTime = new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8389),
                            DepartureTime = new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8387),
                            Destination = "Madrid",
                            FlightNumber = "YZA567",
                            Origin = "Rome",
                            Price = 400f
                        },
                        new
                        {
                            Id = 10,
                            ArrivalTime = new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8394),
                            DepartureTime = new DateTime(2024, 4, 16, 0, 30, 40, 231, DateTimeKind.Local).AddTicks(8392),
                            Destination = "Barcelona",
                            FlightNumber = "BCD890",
                            Origin = "Madrid",
                            Price = 350f
                        },
                        new
                        {
                            Id = 11,
                            ArrivalTime = new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8399),
                            DepartureTime = new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8397),
                            Destination = "Amsterdam",
                            FlightNumber = "EFG123",
                            Origin = "Barcelona",
                            Price = 380f
                        },
                        new
                        {
                            Id = 12,
                            ArrivalTime = new DateTime(2024, 4, 16, 9, 30, 40, 231, DateTimeKind.Local).AddTicks(8404),
                            DepartureTime = new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8402),
                            Destination = "Dubai",
                            FlightNumber = "HIJ456",
                            Origin = "Amsterdam",
                            Price = 700f
                        },
                        new
                        {
                            Id = 13,
                            ArrivalTime = new DateTime(2024, 4, 16, 11, 30, 40, 231, DateTimeKind.Local).AddTicks(8409),
                            DepartureTime = new DateTime(2024, 4, 16, 6, 30, 40, 231, DateTimeKind.Local).AddTicks(8407),
                            Destination = "Singapore",
                            FlightNumber = "KLM789",
                            Origin = "Dubai",
                            Price = 800f
                        },
                        new
                        {
                            Id = 14,
                            ArrivalTime = new DateTime(2024, 4, 16, 8, 30, 40, 231, DateTimeKind.Local).AddTicks(8414),
                            DepartureTime = new DateTime(2024, 4, 16, 5, 30, 40, 231, DateTimeKind.Local).AddTicks(8412),
                            Destination = "Tokyo",
                            FlightNumber = "NOP012",
                            Origin = "Singapore",
                            Price = 750f
                        },
                        new
                        {
                            Id = 15,
                            ArrivalTime = new DateTime(2024, 4, 16, 13, 30, 40, 231, DateTimeKind.Local).AddTicks(8419),
                            DepartureTime = new DateTime(2024, 4, 16, 7, 30, 40, 231, DateTimeKind.Local).AddTicks(8417),
                            Destination = "Sydney",
                            FlightNumber = "QRS345",
                            Origin = "Tokyo",
                            Price = 900f
                        });
                });

            modelBuilder.Entity("WebApplication1.Areas.BookingManagement.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PricePerNight")
                        .HasColumnType("real");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotels", "Identity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = true,
                            Location = "New York City",
                            Name = "The Plaza Hotel",
                            PricePerNight = 400f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = true,
                            Location = "Chicago",
                            Name = "Hilton Chicago",
                            PricePerNight = 250f,
                            Rating = 4
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = true,
                            Location = "Los Angeles",
                            Name = "The Ritz-Carlton",
                            PricePerNight = 500f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = true,
                            Location = "Miami",
                            Name = "Miami Beach Resort",
                            PricePerNight = 300f,
                            Rating = 4
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = true,
                            Location = "London",
                            Name = "London Marriott Hotel",
                            PricePerNight = 350f,
                            Rating = 4
                        },
                        new
                        {
                            Id = 6,
                            IsAvailable = true,
                            Location = "Paris",
                            Name = "Paris Marriott Champs Elysees",
                            PricePerNight = 380f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 7,
                            IsAvailable = true,
                            Location = "Berlin",
                            Name = "Berlin Marriott Hotel",
                            PricePerNight = 300f,
                            Rating = 4
                        },
                        new
                        {
                            Id = 8,
                            IsAvailable = true,
                            Location = "Rome",
                            Name = "Rome Cavalieri, A Waldorf Astoria Hotel",
                            PricePerNight = 450f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 9,
                            IsAvailable = true,
                            Location = "Madrid",
                            Name = "The Westin Palace Madrid",
                            PricePerNight = 320f,
                            Rating = 4
                        },
                        new
                        {
                            Id = 10,
                            IsAvailable = true,
                            Location = "Barcelona",
                            Name = "W Barcelona",
                            PricePerNight = 400f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 11,
                            IsAvailable = true,
                            Location = "Amsterdam",
                            Name = "Amsterdam Marriott Hotel",
                            PricePerNight = 350f,
                            Rating = 4
                        },
                        new
                        {
                            Id = 12,
                            IsAvailable = true,
                            Location = "Dubai",
                            Name = "Jumeirah Emirates Towers",
                            PricePerNight = 500f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 13,
                            IsAvailable = true,
                            Location = "Singapore",
                            Name = "Marina Bay Sands",
                            PricePerNight = 550f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 14,
                            IsAvailable = true,
                            Location = "Tokyo",
                            Name = "The Peninsula Tokyo",
                            PricePerNight = 450f,
                            Rating = 5
                        },
                        new
                        {
                            Id = 15,
                            IsAvailable = true,
                            Location = "Sydney",
                            Name = "Four Seasons Hotel Sydney",
                            PricePerNight = 500f,
                            Rating = 5
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

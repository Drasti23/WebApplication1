using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication1.Areas.BookingManagement.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>

            {
                entity.ToTable(name: "UserRoles");

            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });


            builder.Entity<Flight>().HasData(
    
            new Flight { Id = 1, FlightNumber = "ABC123", Origin = "New York", Destination = "Los Angeles", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(5), Price = 200 },
            new Flight { Id = 2, FlightNumber = "DEF456", Origin = "Los Angeles", Destination = "Chicago", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(6), Price = 250 },
            new Flight { Id = 3, FlightNumber = "GHI789", Origin = "Chicago", Destination = "Houston", DepartureTime = DateTime.Now.AddHours(4), ArrivalTime = DateTime.Now.AddHours(7), Price = 280 },
            new Flight { Id = 4, FlightNumber = "JKL012", Origin = "Houston", Destination = "Miami", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(4), Price = 300 },
            new Flight { Id = 5, FlightNumber = "MNO345", Origin = "Miami", Destination = "New York", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(7), Price = 270 },
            new Flight { Id = 6, FlightNumber = "PQR678", Origin = "London", Destination = "Paris", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(3), Price = 350 },
            new Flight { Id = 7, FlightNumber = "STU901", Origin = "Paris", Destination = "Berlin", DepartureTime = DateTime.Now.AddHours(4), ArrivalTime = DateTime.Now.AddHours(6), Price = 320 },
            new Flight { Id = 8, FlightNumber = "VWX234", Origin = "Berlin", Destination = "Rome", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(5), Price = 380 },
            new Flight { Id = 9, FlightNumber = "YZA567", Origin = "Rome", Destination = "Madrid", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(4), Price = 400 },
            new Flight { Id = 10, FlightNumber = "BCD890", Origin = "Madrid", Destination = "Barcelona", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(2), Price = 350 },
            new Flight { Id = 11, FlightNumber = "EFG123", Origin = "Barcelona", Destination = "Amsterdam", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(5), Price = 380 },
            new Flight { Id = 12, FlightNumber = "HIJ456", Origin = "Amsterdam", Destination = "Dubai", DepartureTime = DateTime.Now.AddHours(5), ArrivalTime = DateTime.Now.AddHours(10), Price = 700 },
            new Flight { Id = 13, FlightNumber = "KLM789", Origin = "Dubai", Destination = "Singapore", DepartureTime = DateTime.Now.AddHours(7), ArrivalTime = DateTime.Now.AddHours(12), Price = 800 },
            new Flight { Id = 14, FlightNumber = "NOP012", Origin = "Singapore", Destination = "Tokyo", DepartureTime = DateTime.Now.AddHours(6), ArrivalTime = DateTime.Now.AddHours(9), Price = 750 },
            new Flight { Id = 15, FlightNumber = "QRS345", Origin = "Tokyo", Destination = "Sydney", DepartureTime = DateTime.Now.AddHours(8), ArrivalTime = DateTime.Now.AddHours(14), Price = 900 }

            );

            builder.Entity<Hotel>().HasData(
            
                new Hotel { Id = 1, Name = "The Plaza Hotel", Location = "New York City", Rating = 5, PricePerNight = 400, IsAvailable = true },
                new Hotel { Id = 2, Name = "Hilton Chicago", Location = "Chicago", Rating = 4, PricePerNight = 250, IsAvailable = true },
                new Hotel { Id = 3, Name = "The Ritz-Carlton", Location = "Los Angeles", Rating = 5, PricePerNight = 500, IsAvailable = true },
                new Hotel { Id = 4, Name = "Miami Beach Resort", Location = "Miami", Rating = 4, PricePerNight = 300, IsAvailable = true },
                new Hotel { Id = 5, Name = "London Marriott Hotel", Location = "London", Rating = 4, PricePerNight = 350, IsAvailable = true },
                new Hotel { Id = 6, Name = "Paris Marriott Champs Elysees", Location = "Paris", Rating = 5, PricePerNight = 380, IsAvailable = true },
                new Hotel { Id = 7, Name = "Berlin Marriott Hotel", Location = "Berlin", Rating = 4, PricePerNight = 300, IsAvailable = true },
                new Hotel { Id = 8, Name = "Rome Cavalieri, A Waldorf Astoria Hotel", Location = "Rome", Rating = 5, PricePerNight = 450, IsAvailable = true },
                new Hotel { Id = 9, Name = "The Westin Palace Madrid", Location = "Madrid", Rating = 4, PricePerNight = 320, IsAvailable = true },
                new Hotel { Id = 10, Name = "W Barcelona", Location = "Barcelona", Rating = 5, PricePerNight = 400, IsAvailable = true },
                new Hotel { Id = 11, Name = "Amsterdam Marriott Hotel", Location = "Amsterdam", Rating = 4, PricePerNight = 350, IsAvailable = true },
                new Hotel { Id = 12, Name = "Jumeirah Emirates Towers", Location = "Dubai", Rating = 5, PricePerNight = 500, IsAvailable = true },
                new Hotel { Id = 13, Name = "Marina Bay Sands", Location = "Singapore", Rating = 5, PricePerNight = 550, IsAvailable = true },
                new Hotel { Id = 14, Name = "The Peninsula Tokyo", Location = "Tokyo", Rating = 5, PricePerNight = 450, IsAvailable = true },
                new Hotel { Id = 15, Name = "Four Seasons Hotel Sydney", Location = "Sydney", Rating = 5, PricePerNight = 500, IsAvailable = true }
            );

            builder.Entity<CarRental>().HasData(
                new CarRental { Id = 1, Model = "Toyota Camry", RentalAgency = "Enterprise Rent-A-Car", PricePerDay = 70, IsAvailable = true },
                new CarRental { Id = 2, Model = "Honda Civic", RentalAgency = "Hertz", PricePerDay = 60, IsAvailable = true },
                new CarRental { Id = 3, Model = "Ford Mustang", RentalAgency = "Avis", PricePerDay = 120, IsAvailable = true },
                new CarRental { Id = 4, Model = "Chevrolet Malibu", RentalAgency = "Budget", PricePerDay = 80, IsAvailable = true },
                new CarRental { Id = 5, Model = "Nissan Altima", RentalAgency = "Alamo Rent A Car", PricePerDay = 75, IsAvailable = true },
                new CarRental { Id = 6, Model = "Hyundai Elantra", RentalAgency = "National Car Rental", PricePerDay = 65, IsAvailable = true },
                new CarRental { Id = 7, Model = "Volkswagen Jetta", RentalAgency = "Dollar Car Rental", PricePerDay = 70, IsAvailable = true },
                new CarRental { Id = 8, Model = "Subaru Outback", RentalAgency = "Thrifty Car Rental", PricePerDay = 85, IsAvailable = true },
                new CarRental { Id = 9, Model = "BMW 3 Series", RentalAgency = "Sixt Rent A Car", PricePerDay = 150, IsAvailable = true },
                new CarRental { Id = 10, Model = "Mercedes-Benz C-Class", RentalAgency = "Europcar", PricePerDay = 180, IsAvailable = true },
                new CarRental { Id = 11, Model = "Audi A4", RentalAgency = "Fox Rent A Car", PricePerDay = 160, IsAvailable = true },
                new CarRental { Id = 12, Model = "Tesla Model 3", RentalAgency = "Tesla", PricePerDay = 250, IsAvailable = true },
                new CarRental { Id = 13, Model = "Jeep Wrangler", RentalAgency = "U-Haul", PricePerDay = 100, IsAvailable = true },
                new CarRental { Id = 14, Model = "GMC Yukon", RentalAgency = "Penske Truck Rental", PricePerDay = 120, IsAvailable = true },
                new CarRental { Id = 15, Model = "Toyota Prius", RentalAgency = "Zipcar", PricePerDay = 50, IsAvailable = true }
           
            );
        }
    }
}


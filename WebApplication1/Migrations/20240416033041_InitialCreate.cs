using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Bookings",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<float>(type: "real", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<float>(type: "real", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "CarRentals",
                columns: new[] { "Id", "IsAvailable", "Model", "PricePerDay", "RentalAgency" },
                values: new object[,]
                {
                    { 1, true, "Toyota Camry", 70f, "Enterprise Rent-A-Car" },
                    { 2, true, "Honda Civic", 60f, "Hertz" },
                    { 3, true, "Ford Mustang", 120f, "Avis" },
                    { 4, true, "Chevrolet Malibu", 80f, "Budget" },
                    { 5, true, "Nissan Altima", 75f, "Alamo Rent A Car" },
                    { 6, true, "Hyundai Elantra", 65f, "National Car Rental" },
                    { 7, true, "Volkswagen Jetta", 70f, "Dollar Car Rental" },
                    { 8, true, "Subaru Outback", 85f, "Thrifty Car Rental" },
                    { 9, true, "BMW 3 Series", 150f, "Sixt Rent A Car" },
                    { 10, true, "Mercedes-Benz C-Class", 180f, "Europcar" },
                    { 11, true, "Audi A4", 160f, "Fox Rent A Car" },
                    { 12, true, "Tesla Model 3", 250f, "Tesla" },
                    { 13, true, "Jeep Wrangler", 100f, "U-Haul" },
                    { 14, true, "GMC Yukon", 120f, "Penske Truck Rental" },
                    { 15, true, "Toyota Prius", 50f, "Zipcar" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Flights",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "Destination", "FlightNumber", "Origin", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8339), new DateTime(2024, 4, 15, 23, 30, 40, 231, DateTimeKind.Local).AddTicks(8267), "Los Angeles", "ABC123", "New York", 200f },
                    { 2, new DateTime(2024, 4, 16, 5, 30, 40, 231, DateTimeKind.Local).AddTicks(8351), new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8349), "Chicago", "DEF456", "Los Angeles", 250f },
                    { 3, new DateTime(2024, 4, 16, 6, 30, 40, 231, DateTimeKind.Local).AddTicks(8357), new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8355), "Houston", "GHI789", "Chicago", 280f },
                    { 4, new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8363), new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8361), "Miami", "JKL012", "Houston", 300f },
                    { 5, new DateTime(2024, 4, 16, 6, 30, 40, 231, DateTimeKind.Local).AddTicks(8368), new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8366), "New York", "MNO345", "Miami", 270f },
                    { 6, new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8373), new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8371), "Paris", "PQR678", "London", 350f },
                    { 7, new DateTime(2024, 4, 16, 5, 30, 40, 231, DateTimeKind.Local).AddTicks(8378), new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8376), "Berlin", "STU901", "Paris", 320f },
                    { 8, new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8383), new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8382), "Rome", "VWX234", "Berlin", 380f },
                    { 9, new DateTime(2024, 4, 16, 3, 30, 40, 231, DateTimeKind.Local).AddTicks(8389), new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8387), "Madrid", "YZA567", "Rome", 400f },
                    { 10, new DateTime(2024, 4, 16, 1, 30, 40, 231, DateTimeKind.Local).AddTicks(8394), new DateTime(2024, 4, 16, 0, 30, 40, 231, DateTimeKind.Local).AddTicks(8392), "Barcelona", "BCD890", "Madrid", 350f },
                    { 11, new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8399), new DateTime(2024, 4, 16, 2, 30, 40, 231, DateTimeKind.Local).AddTicks(8397), "Amsterdam", "EFG123", "Barcelona", 380f },
                    { 12, new DateTime(2024, 4, 16, 9, 30, 40, 231, DateTimeKind.Local).AddTicks(8404), new DateTime(2024, 4, 16, 4, 30, 40, 231, DateTimeKind.Local).AddTicks(8402), "Dubai", "HIJ456", "Amsterdam", 700f },
                    { 13, new DateTime(2024, 4, 16, 11, 30, 40, 231, DateTimeKind.Local).AddTicks(8409), new DateTime(2024, 4, 16, 6, 30, 40, 231, DateTimeKind.Local).AddTicks(8407), "Singapore", "KLM789", "Dubai", 800f },
                    { 14, new DateTime(2024, 4, 16, 8, 30, 40, 231, DateTimeKind.Local).AddTicks(8414), new DateTime(2024, 4, 16, 5, 30, 40, 231, DateTimeKind.Local).AddTicks(8412), "Tokyo", "NOP012", "Singapore", 750f },
                    { 15, new DateTime(2024, 4, 16, 13, 30, 40, 231, DateTimeKind.Local).AddTicks(8419), new DateTime(2024, 4, 16, 7, 30, 40, 231, DateTimeKind.Local).AddTicks(8417), "Sydney", "QRS345", "Tokyo", 900f }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Hotels",
                columns: new[] { "Id", "IsAvailable", "Location", "Name", "PricePerNight", "Rating" },
                values: new object[,]
                {
                    { 1, true, "New York City", "The Plaza Hotel", 400f, 5 },
                    { 2, true, "Chicago", "Hilton Chicago", 250f, 4 },
                    { 3, true, "Los Angeles", "The Ritz-Carlton", 500f, 5 },
                    { 4, true, "Miami", "Miami Beach Resort", 300f, 4 },
                    { 5, true, "London", "London Marriott Hotel", 350f, 4 },
                    { 6, true, "Paris", "Paris Marriott Champs Elysees", 380f, 5 },
                    { 7, true, "Berlin", "Berlin Marriott Hotel", 300f, 4 },
                    { 8, true, "Rome", "Rome Cavalieri, A Waldorf Astoria Hotel", 450f, 5 },
                    { 9, true, "Madrid", "The Westin Palace Madrid", 320f, 4 },
                    { 10, true, "Barcelona", "W Barcelona", 400f, 5 },
                    { 11, true, "Amsterdam", "Amsterdam Marriott Hotel", 350f, 4 },
                    { 12, true, "Dubai", "Jumeirah Emirates Towers", 500f, 5 },
                    { 13, true, "Singapore", "Marina Bay Sands", 550f, 5 },
                    { 14, true, "Tokyo", "The Peninsula Tokyo", 450f, 5 },
                    { 15, true, "Sydney", "Four Seasons Hotel Sydney", 500f, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CarRentals",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Flights",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");
        }
    }
}

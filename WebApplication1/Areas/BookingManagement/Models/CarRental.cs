﻿namespace WebApplication1.Areas.BookingManagement.Models
{
    public class CarRental
    {
        public int Id { get; set; }

        public string? Model { get; set; }

        public string? RentalAgency { get; set; }

        public float PricePerDay { get; set; }

        public bool IsAvailable { get; set; }
    }
}

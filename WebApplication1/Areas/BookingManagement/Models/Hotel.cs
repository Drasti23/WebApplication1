namespace WebApplication1.Areas.BookingManagement.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public int Rating { get; set; }

        public float PricePerNight { get; set; }

        public bool IsAvailable { get; set; }
    }
}

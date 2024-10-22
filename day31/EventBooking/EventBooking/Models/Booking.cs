namespace EventBooking.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Event Event { get; set; }
    }
}

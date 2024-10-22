namespace EventBooking.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }=string.Empty;
        public DateTime EventDate { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; }
    }
}

namespace EventBooking.Models
{
    public class User
    {
     
            public int UserId { get; set; }
            public string UserName { get; set; }=string.Empty;
            public string Email { get; set; }=string.Empty;
        public byte[] Password { get; set; }

            // Navigation property
            public ICollection<Booking> Bookings { get; set; }
        
    }
}

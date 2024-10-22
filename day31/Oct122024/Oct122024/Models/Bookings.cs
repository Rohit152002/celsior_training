

namespace Oct122024.Models
{
    public class Bookings
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId  { get; set; }
        public Event Event { get; set; }
    }
}

namespace Oct122024.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Bookings> Bookings { get; set; }

        public User ()
        {
            Bookings= new List<Bookings>();
        }
    }
}


namespace DoctorAppointment.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialist { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        static int i = 0;
        public Doctor()
        {
            Id = 100 + i;
            i++;
        }
        public Doctor(int id, string Name, string Specialist, string Email, string Image)
        {
            this.Id = id;
            this.Specialist = Specialist;
            this.Name = Name;
            this.Email = Email;
            this.Image = Image;
        }
    }
}

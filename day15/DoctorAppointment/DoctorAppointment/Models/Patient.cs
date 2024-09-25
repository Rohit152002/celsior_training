namespace DoctorAppointment.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public double Phone { get; set; }

        static int i = 0;
        public Patient()
        {
            Id = 100 + i;
            i++;
        }
        public Patient(int id, string name, DateTime dateOfBirth, string email, string password, string gender, double phone)
        {
            this.Id = id;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.Phone = phone;
            this.Gender = gender;
            this.Phone = phone;
        }
    }
}

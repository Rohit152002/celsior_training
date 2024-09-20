using System.Globalization;

namespace DoctorList.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }
        public string? Speciality { get; set; }
        public string? Image { get; set; }

        public DoctorModel()
        {

        }

    }

}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SpecialistId { get; set; }
        [ForeignKey("SpecialistId")]
        public Specialist Specialist { get; set; }
        public string Gender { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;

        public double Phone { get; set; }
    }
}

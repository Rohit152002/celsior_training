using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal abstract class ClinicService
    {
        public List<Doctor> Doctors = new List<Doctor>();
        public List<Patient> Patients = new List<Patient>();
        public List<Appointment> Appointments = new List<Appointment>();
    }
}

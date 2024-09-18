using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal interface IPatientService
    {
        public Patient PatientLogin(string email, string password);
        public Patient PatientRegister();
        public void SeeAllDoctorList();
        public void BookAppointMent(int PatientId);
        public void ViewAppointMent(int appoinmentId);
    }
}

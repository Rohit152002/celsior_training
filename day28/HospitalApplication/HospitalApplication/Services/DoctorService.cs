using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApplication.Interfaces
using HospitalApplication.Context


namespace HospitalApplication.Services
{
    public class DoctorService: IDoctorService
    {
        ClinicContext Context = new ClinicContext();

        public Doctor DoctorLogin(string email, string password)
        {

        }
        public Doctor DoctorRegister()
        {

        }
    }

}

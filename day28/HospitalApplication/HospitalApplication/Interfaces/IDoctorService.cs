using HospitalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Interfaces
{
    internal interface IDoctorService
    {
        public Doctor DoctorLogin(string email, string password);
        public Doctor DoctorRegister();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal interface IDoctorService
    {
        public Doctor DoctorLogin(string email, string password);
        public Doctor DoctorRegister(string name,string gender, string specialist, DateTime dateOfBirth, string email, string password,double phone);
        public void ViewAllPatient();
        public void ViewAllAppointMent(int id);
    }
}

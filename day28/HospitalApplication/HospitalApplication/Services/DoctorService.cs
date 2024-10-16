using HospitalApplication.Context;
using HospitalApplication.Interfaces;
using HospitalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Services
{
    internal class DoctorService : IDoctorService
    {
        ClinicContext Context = new ClinicContext();

        public void DoctorLogin(string email, string password)
        {

        }
        Doctor PopulateNewDoctor()
        {
            Doctor doctor = new Doctor();

            Console.WriteLine("Enter the doctor's name:");
            doctor.Name = Console.ReadLine();

            Console.WriteLine("Enter the specialist ID:");
            doctor.SpecialistId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the doctor's email:");
            doctor.Email = Console.ReadLine();

            Console.WriteLine("Enter the doctor's gender:");
            doctor.Gender = Console.ReadLine();

            Console.WriteLine("Enter the doctor's phone number:");
            doctor.Phone = Convert.ToDouble(Console.ReadLine());

            return doctor;
        }

        public void DoctorRegister()
        {
            Doctor doctor = PopulateNewDoctor();
            Context.Doctors.Add(doctor);
            Context.SaveChanges();

        }

        public void PrintAllDoctor()
        {
            var doctors = Context.Doctors.ToList();
            int i = 1;
            foreach(Doctor doctor in doctors)
            {
                Console.WriteLine($"Name : {doctor.Name}\nEmail : {doctor.Email}\nSpecialist :{Context.Specialists.FirstOrDefault(s=>s.SpecialistId==doctor.SpecialistId).SpecialistName}");
                Console.WriteLine("===============================");


            }
        }
    }

}

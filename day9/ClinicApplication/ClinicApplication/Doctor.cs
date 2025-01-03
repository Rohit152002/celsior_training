﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialist { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email {  get; set; }
        public string Password {  get; set; }

        public double Phone { get; set; }

        static int i=0;
        public Doctor()
        {
            Id = 100 + i;
            i++;
        }

        public Doctor(string name, string spectialist, DateTime dateOfBirth, string Gender, string email, string password, double phone)
        {
            this.Name = name;
            this.Specialist = spectialist;
            this.DateOfBirth = dateOfBirth;
            this.Gender = Gender;
            this.Email = email;
           this.Password = password;
            this.Phone = phone;
        }

        public override string ToString()
        {
            return $"Doctor Id: {Id}\nDoctor Name: {Name},\nSpecialist: {Specialist},\nDate of Birth: {DateOfBirth.ToString("dd/MM/yyyy")},\nGender: {Gender},\nEmail: {Email},\nPhone: {Phone}";
        }
    }
}

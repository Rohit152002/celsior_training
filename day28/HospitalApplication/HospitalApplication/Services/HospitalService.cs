using HospitalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApplication.Services;
using HospitalApplication.Interfaces;
using HospitalApplication.Context;

namespace HospitalApplication.Services
{
    public class HospitalService
    {
        PatientService patientService = new PatientService();
        DoctorService doctorService = new DoctorService();
        ClinicContext context =  new ClinicContext();
        void PrintMenu()
        {
            Console.WriteLine("Enter a choice : ");
            Console.WriteLine("1. Book Appointment");
            Console.WriteLine("2. Register Patient");
            Console.WriteLine("3. Register Doctor");
            Console.WriteLine("4. Add Specialists");
            Console.WriteLine("5. Doctors List");
            Console.WriteLine("6. Specialist List");
        }

        public void StartHospitalService()
        {
            int choice = -1;
            do
            {
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        patientService.BookAppointMent();
                        break;
                    case 2:
                        patientService.RegisterPatient();
                        break;
                    case 3:
                        doctorService.DoctorRegister();
                        break;
                    case 4:
                        AddSpecialist();
                        break;
                    case 5:
                        doctorService.PrintAllDoctor();
                        break;
                    case 6:
                        PrintAllSpecialist();
                        break;
                    default:
                        break;
                }

            } while (choice != 0);
        }

        Specialist PopulateNewSpecialist()
        {
            Specialist specialist = new Specialist();
            Console.WriteLine("Enter a new specialist Name : ");
            specialist.SpecialistName = Console.ReadLine();
            var allSpecialist = context.Specialists.FirstOrDefault(c => c.SpecialistName == specialist.SpecialistName);
            if (allSpecialist != null) {
                throw new Exception("Already have a specialist");
            }
            return specialist;
        }
        void AddSpecialist()
        {
            Specialist specialist= PopulateNewSpecialist();
            context.Specialists.Add(specialist);
            context.SaveChanges();
        }

        void PrintAllSpecialist()
        {
            var allSpecialist = context.Specialists.ToList();
            int i = 1;
            foreach(Specialist specialist in allSpecialist)
            {
                Console.WriteLine($"{i}. {specialist.SpecialistName}");
                i++;
            }
        }

        
    }
}

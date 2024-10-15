using HospitalApplication.Context;
using HospitalApplication.Services;

namespace HospitalApplication
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            PatientService patientService = new PatientService();
            Console.WriteLine();
            patientService.BookAppointMent();
        }
    }
}

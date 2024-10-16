using HospitalApplication.Context;
using HospitalApplication.Services;

namespace HospitalApplication
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
      HospitalService service = new HospitalService();
            service.StartHospitalService();
        }
    }
}

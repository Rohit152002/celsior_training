using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Interfaces
{
    internal interface IPatientService
    {
        public void BookAppointMent();
        public void ViewAppointMent();

        public void RegisterPatient();
    }
}

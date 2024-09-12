using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Doctor
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string Hospital { get; set; }

        public Doctor()
        {
            
        }
        public Doctor(string name, string specialization,int experience , string hospital)
        {
            this.Name = name;
            this.Specialization = specialization;
            this.Experience = experience;
            this.Hospital = hospital;
        }


    }
}

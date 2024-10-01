using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    internal class Employee:IDisposable
    {
        public string Name { get; set; }
        List<string> Skills { get; set; }
        Leave leave = new Leave();

        public string this[int index]
        {
            get { return Skills[index]; }
            set  { Skills[index] = value; }
        }
        public int this[string valueName]
        {
            get
            {
                for (int i = 0; i < Skills.Count; i++)
                {
                    if (Skills[i] == valueName)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
        
        public Employee() {
            Console.WriteLine("Employee Created");
            Skills = new List<string>()
            { "Apple", "Mango ", "Sona"};
            leave.SickLeave = 10;
            leave.CasualLeave = 10;
        }

        ~Employee()
        {
            Console.WriteLine("Employee Destroyed");
        }

        public void Dispose()
        {
            Console.WriteLine("Employee Destroyed");
        }

        public bool AvailSickLeave(int days)
        {
            if (leave.SickLeave >= days)
            {
                leave.SickLeave -= days;
                return true;
            }
            return false;
        }

        class Leave
        {
            public int CasualLeave { get; set; }
            public int SickLeave { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Student
    {
        public int studentid { get; set; }
        public string name { get; set; }
        public DateTime dob { get   ; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }
        public Student(int studentid,string name, DateTime dob, long phoneNumber,string email)
        {
            this.studentid = studentid;
            this.name = name;
            this.dob= dob;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public void displayId()
        {
            Console.WriteLine($"ID : {this.studentid}");
            Console.WriteLine($"Name : {this.name}");
            Console.WriteLine($"Date of Birth : {this.dob}");
            Console.WriteLine($"Phone : {this.phoneNumber}");
            Console.WriteLine($"email : {this.email}");

        }
    }
}

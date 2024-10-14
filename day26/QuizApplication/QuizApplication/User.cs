using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal class User
    {
   
        public int Points { get; set; } = 0; 
        public  int CorrectAnswer { get; set; } = 0;

        public User ()
        {
    
        }

        public override string ToString()
        {
            return $"\nPoints={Points}\nTotal Correct Answer = {CorrectAnswer}/10\n\n";
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal class QuestionAnswer
    {
        public string Question { get; set; }
        public string Answer {  get; set; }
        public List<string> Options { get; set; }
    }
}

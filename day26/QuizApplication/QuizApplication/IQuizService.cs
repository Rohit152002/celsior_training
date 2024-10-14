using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal interface IQuizService
    {
        public List<QuestionAnswer> GetQuestionAnswers(string quizType);
        public void StartQuiz();
        public void AskQuiz(List<QuestionAnswer> quiz);
        public void ShowQuestionAnswer(List<QuestionAnswer> quiz);


    }
}

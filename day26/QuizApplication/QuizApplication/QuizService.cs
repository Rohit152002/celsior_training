using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuizApplication
{
    internal class QuizService : IQuizService
    {

        Movies moviesQuiz;
        Sports sportsQuiz;
        Geography geographyQuiz;
        Technology technologyQuiz;
        User user;

        public void Menu()
        {
            Console.WriteLine("Choice Your Category: ");
            Console.WriteLine("1. Sports");
            Console.WriteLine("2. Movies");
            Console.WriteLine("3. Geography");
            Console.WriteLine("4. Technology");
            Console.WriteLine("0. Exit");
        }

        public void StartQuiz()
        {
            int choice = -1;
            try
            {

                do
                {
                    Menu();
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            StartSportsQuiz();
                            break;
                        case 2:
                            StartMovieQuiz();
                            break;
                        case 3:
                            StartGeographyQuiz();
                            break;
                        case 4:
                            StartTechnologyQuiz();
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice");
                            break;
                    }

                } while (choice != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartMovieQuiz()
        {
            List<QuestionAnswer> quiz = GetQuestionAnswers("movies");
            AskQuiz(quiz);
         
        }
        public void StartSportsQuiz()
        {
            List<QuestionAnswer> quiz = GetQuestionAnswers("sports");
            AskQuiz(quiz);
       
        }
        public void StartGeographyQuiz()
        {

            List<QuestionAnswer> quiz = GetQuestionAnswers("geography");
            AskQuiz(quiz);
           
        }

        public void StartTechnologyQuiz()
        {
            List<QuestionAnswer> quiz = GetQuestionAnswers("technology");
            AskQuiz(quiz);
         
        }


        public void ShowQuestionAnswer(List<QuestionAnswer> quiz)
        {
            Console.WriteLine("Here is the correct Answer :- ");
            int index = 1;
            foreach (QuestionAnswer questionAnswer in quiz)
            {
                Console.WriteLine($"{index} {questionAnswer.Question}");
                Console.WriteLine($"Answer : {questionAnswer.Answer}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("============================================");
                Console.ResetColor();
                index++;
            }

        }
        public void AskQuiz(List<QuestionAnswer> quiz)
        {
            user = new User();
            int answer, index = 1;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();


            foreach (QuestionAnswer questionAnswer in quiz)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"{index}. {questionAnswer.Question}");
                int i = 1;
                foreach (var option in questionAnswer.Options)
                {
                    Console.Write($"{i}. {option}  ");
                    i++;
                }
                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("\nEnter your choice : ");
                    try
                    {
                        answer = Convert.ToInt32(Console.ReadLine());//1,2
                        if (answer != 0)
                        {
                            string getAnswerString = questionAnswer.Options[answer - 1];
                            if (getAnswerString != null)
                            {
                                if (questionAnswer.Answer.ToLower() == getAnswerString.ToLower())
                                {
                                    user.Points += 10;
                                    user.CorrectAnswer += 1;
                                }
                            }
                            validInput = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                    index++;
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine(user);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine("Press Enter to show Correct Answer :- ");
            Console.ReadLine(); 
            ShowQuestionAnswer(quiz);




        }

        public List<QuestionAnswer> GetQuestionAnswers(string quizType)
        {
            List<QuestionAnswer> questionAnswers;
            moviesQuiz = new Movies();
            sportsQuiz = new Sports();
            geographyQuiz = new Geography();
            technologyQuiz = new Technology();
            switch (quizType.ToLower())
            {
                case "movies":
                    questionAnswers = moviesQuiz.moviesQuestions;
                    break;
                case "sports":
                    questionAnswers = sportsQuiz.sportsQuestions;
                    break;
                case "geography":
                    questionAnswers = geographyQuiz.geographyQuestions;
                    break;
                case "technology":
                    questionAnswers = technologyQuiz.technologyQuestions;
                    break;
                default:
                    throw new ArgumentException("Invalid quiz type provided.");
            }

 
            return questionAnswers.OrderBy(x => new Random().Next()).Take(10).ToList();
        }
    }

}

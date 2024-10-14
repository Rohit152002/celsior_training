using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal class Movies
    {
         public List<QuestionAnswer> moviesQuestions { get; set; } = new List<QuestionAnswer>
{
    new QuestionAnswer { Question = "Which movie won the Best Film Oscar in 2023?", Answer = "Everything Everywhere All at Once", Options = new List<string> { "Everything Everywhere All at Once", "The Godfather", "Titanic", "Parasite" } },
    new QuestionAnswer { Question = "Who directed the movie 'Sholay'?", Answer = "Ramesh Sippy", Options = new List<string> { "Ramesh Sippy", "Rajkumar Hirani", "Karan Johar", "S.S. Rajamouli" } },
    new QuestionAnswer { Question = "Which Bollywood movie features the song 'Tum Hi Ho'?", Answer = "Aashiqui 2", Options = new List<string> { "Aashiqui 2", "Kabir Singh", "Dilwale Dulhania Le Jayenge", "3 Idiots" } },
    new QuestionAnswer { Question = "Who is known as the 'King of Bollywood'?", Answer = "Shah Rukh Khan", Options = new List<string> { "Salman Khan", "Aamir Khan", "Shah Rukh Khan", "Hrithik Roshan" } },
    new QuestionAnswer { Question = "In which movie did Aamir Khan play a college professor?", Answer = "Taare Zameen Par", Options = new List<string> { "Taare Zameen Par", "3 Idiots", "PK", "Dil" } },
    new QuestionAnswer { Question = "Which film features the iconic dialogue 'Mere paas maa hai'?", Answer = "Deewar", Options = new List<string> { "Deewar", "Sholay", "Don", "Karan Arjun" } },
    new QuestionAnswer { Question = "What is the highest-grossing Indian film of all time (as of 2023)?", Answer = "Dangal", Options = new List<string> { "Dangal", "Baahubali 2", "PK", "Chennai Express" } },
    new QuestionAnswer { Question = "Who won the National Film Award for Best Actor in 2021?", Answer = "Amitabh Bachchan", Options = new List<string> { "Rajkummar Rao", "Amitabh Bachchan", "Shahid Kapoor", "Irrfan Khan" } },
    new QuestionAnswer { Question = "Which movie features the character 'Bajrangi Bhaijaan'?", Answer = "Bajrangi Bhaijaan", Options = new List<string> { "Bajrangi Bhaijaan", "PK", "Sultan", "Dangal" } },
    new QuestionAnswer { Question = "Which actress starred opposite Aamir Khan in 'Dil'?", Answer = "Juhi Chawla", Options = new List<string> { "Karisma Kapoor", "Juhi Chawla", "Rani Mukerji", "Preity Zinta" } },
    new QuestionAnswer { Question = "What is the primary language of Bollywood films?", Answer = "Hindi", Options = new List<string> { "Hindi", "English", "Bengali", "Tamil" } },
    new QuestionAnswer { Question = "Who is known for her role in the movie 'Chennai Express'?", Answer = "Deepika Padukone", Options = new List<string> { "Kareena Kapoor", "Deepika Padukone", "Priyanka Chopra", "Katrina Kaif" } },
    new QuestionAnswer { Question = "Which film is based on the life of the cricketer M.S. Dhoni?", Answer = "M.S. Dhoni: The Untold Story", Options = new List<string> { "M.S. Dhoni: The Untold Story", "Dangal", "Lagaan", "Chakdey India" } },
    new QuestionAnswer { Question = "Which actor played the lead in 'Kabir Singh'?", Answer = "Shahid Kapoor", Options = new List<string> { "Shahid Kapoor", "Kartik Aaryan", "Ranbir Kapoor", "Hrithik Roshan" } },
    new QuestionAnswer { Question = "Who directed 'Gully Boy'?", Answer = "Zoya Akhtar", Options = new List<string> { "Zoya Akhtar", "Karan Johar", "Rajkumar Hirani", "S.S. Rajamouli" } },
    new QuestionAnswer { Question = "Which movie features the song 'Kala Chashma'?", Answer = "Baar Baar Dekho", Options = new List<string> { "Baar Baar Dekho", "Bajrangi Bhaijaan", "Dilwale", "Raees" } },
    new QuestionAnswer { Question = "What is the name of the 2016 film about a female wrestler?", Answer = "Dangal", Options = new List<string> { "Dangal", "Chakdey India", "Queen", "Panga" } },
    new QuestionAnswer { Question = "Which actress played the role of 'Naina Talwar' in 'Yeh Jawaani Hai Deewani'?", Answer = "Deepika Padukone", Options = new List<string> { "Katrina Kaif", "Deepika Padukone", "Alia Bhatt", "Shraddha Kapoor" } },
    new QuestionAnswer { Question = "What is the tagline of the movie 'PK'?", Answer = "Chalo, Let's Go", Options = new List<string> { "Chalo, Let's Go", "All is Well", "Bolo Har Har Mahadev", "Bande Mein Tha Dum" } },
    new QuestionAnswer { Question = "Who directed 'Baahubali: The Beginning'?", Answer = "S.S. Rajamouli", Options = new List<string> { "S.S. Rajamouli", "Karan Johar", "Rajkumar Hirani", "Mani Ratnam" } },
    new QuestionAnswer { Question = "Which film is known for the dialogue 'All is well'?", Answer = "3 Idiots", Options = new List<string> { "3 Idiots", "PK", "Dilwale", "Bajrangi Bhaijaan" } },
    new QuestionAnswer { Question = "Which movie features a character named 'Baba Rani Kalyani'?", Answer = "Baazigar", Options = new List<string> { "Baazigar", "Karan Arjun", "Chakdey India", "DDLJ" } },
    new QuestionAnswer { Question = "Which film stars Salman Khan as a spy?", Answer = "Ek Tha Tiger", Options = new List<string> { "Ek Tha Tiger", "Dabangg", "Bajrangi Bhaijaan", "Kick" } },
    new QuestionAnswer { Question = "What is the profession of the main character in 'Wake Up Sid'?", Answer = "Photographer", Options = new List<string> { "Photographer", "Student", "Cricketer", "Actor" } },
    new QuestionAnswer { Question = "Which actress played a double role in 'Judwaa 2'?", Answer = "Jacqueline Fernandez", Options = new List<string> { "Katrina Kaif", "Jacqueline Fernandez", "Alia Bhatt", "Deepika Padukone" } },
    new QuestionAnswer { Question = "What is the central theme of 'Kabir Singh'?", Answer = "Love and Obsession", Options = new List<string> { "Love and Obsession", "Friendship", "Family", "Sports" } },
    new QuestionAnswer { Question = "Which movie features the song 'Pehla Nasha'?", Answer = "Jo Jeeta Wohi Sikandar", Options = new List<string> { "Jo Jeeta Wohi Sikandar", "Dil", "Kabhi Khushi Kabhie Gham", "Hum Aapke Hain Koun" } },
    new QuestionAnswer { Question = "Which actress is known for her role in 'Queen'?", Answer = "Kangana Ranaut", Options = new List<string> { "Katrina Kaif", "Kangana Ranaut", "Alia Bhatt", "Deepika Padukone" } },
    new QuestionAnswer { Question = "What is the theme of 'Zindagi Na Milegi Dobara'?", Answer = "Friendship", Options = new List<string> { "Friendship", "Love", "Family", "Adventure" } },
    new QuestionAnswer { Question = "Which actor played the lead role in 'Gully Boy'?", Answer = "Ranveer Singh", Options = new List<string> { "Ranveer Singh", "Aamir Khan", "Shahid Kapoor", "Salman Khan" } },
    new QuestionAnswer { Question = "Which film revolves around the life of a con artist?", Answer = "Catch Me If You Can", Options = new List<string> { "Catch Me If You Can", "Dabangg", "M.S. Dhoni: The Untold Story", "Raees" } },
    new QuestionAnswer { Question = "Who is the director of 'Andaz Apna Apna'?", Answer = "Rajkumar Santoshi", Options = new List<string> { "Rajkumar Santoshi", "Karan Johar", "Rakesh Roshan", "S.S. Rajamouli" } },
    new QuestionAnswer { Question = "Which actress is known for her role in 'Dilwale Dulhania Le Jayenge'?", Answer = "Kajol", Options = new List<string> { "Kajol", "Kareena Kapoor", "Deepika Padukone", "Priyanka Chopra" } },
    new QuestionAnswer { Question = "Which movie is known for its dialogue 'Tujhe dekha to yeh jaana sanam'?", Answer = "Dilwale Dulhania Le Jayenge", Options = new List<string> { "Dilwale Dulhania Le Jayenge", "Kuch Kuch Hota Hai", "Kabhi Khushi Kabhie Gham", "Hum Tum" } }
};
        public Movies()
        {
            
        }
    }
}

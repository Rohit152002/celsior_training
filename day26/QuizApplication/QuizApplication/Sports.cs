using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal class Sports
    {
        public List<QuestionAnswer> sportsQuestions { get; set; } = new List<QuestionAnswer>
        {
    new QuestionAnswer { Question = "Which sport is known as 'the beautiful game'?", Answer = "Football", Options = new List<string> { "Cricket", "Football", "Basketball", "Hockey" } },
    new QuestionAnswer { Question = "Who is the captain of the Indian cricket team as of 2023?", Answer = "Rohit Sharma", Options = new List<string> { "Virat Kohli", "Rohit Sharma", "MS Dhoni", "Kapil Dev" } },
    new QuestionAnswer { Question = "What is the national sport of India?", Answer = "Hockey", Options = new List<string> { "Cricket", "Football", "Hockey", "Badminton" } },
    new QuestionAnswer { Question = "Who won the 2020 ICC T20 World Cup?", Answer = "Australia", Options = new List<string> { "India", "England", "Australia", "Pakistan" } },
    new QuestionAnswer { Question = "In which year did India win the Cricket World Cup?", Answer = "1983", Options = new List<string> { "1983", "2007", "2011", "2015" } },
    new QuestionAnswer { Question = "Which Indian athlete is known as 'Flying Sikh'?", Answer = "Milkha Singh", Options = new List<string> { "Milkha Singh", "P.T. Usha", "Saina Nehwal", "M.S. Dhoni" } },
    new QuestionAnswer { Question = "What is the main trophy awarded in the IPL?", Answer = "IPL Trophy", Options = new List<string> { "Champions Trophy", "IPL Trophy", "World Cup", "Asia Cup" } },
    new QuestionAnswer { Question = "Which sport uses terms like 'love', 'ace', and 'deuce'?", Answer = "Tennis", Options = new List<string> { "Tennis", "Cricket", "Football", "Hockey" } },
    new QuestionAnswer { Question = "Who holds the record for the highest runs in ODI cricket?", Answer = "Sachin Tendulkar", Options = new List<string> { "Sachin Tendulkar", "Virat Kohli", "Rohit Sharma", "Brian Lara" } },
    new QuestionAnswer { Question = "Which Indian state is famous for its contributions to Kabaddi?", Answer = "Maharashtra", Options = new List<string> { "Punjab", "Haryana", "Maharashtra", "Tamil Nadu" } },
    new QuestionAnswer { Question = "What is the full form of BCCI?", Answer = "Board of Control for Cricket in India", Options = new List<string> { "Board of Control for Cricket in India", "Board of Cricket Council India", "BCCI", "Board for Cricket in India" } },
    new QuestionAnswer { Question = "Who is the first Indian woman to win an Olympic medal?", Answer = "Karnam Malleswari", Options = new List<string> { "Mary Kom", "Karnam Malleswari", "P.T. Usha", "Saina Nehwal" } },
    new QuestionAnswer { Question = "Which sport is associated with the term 'offside'?", Answer = "Football", Options = new List<string> { "Football", "Cricket", "Hockey", "Tennis" } },
    new QuestionAnswer { Question = "What is the age limit for participating in the Olympic Games?", Answer = "No age limit", Options = new List<string> { "18", "21", "No age limit", "30" } },
    new QuestionAnswer { Question = "Which Indian city hosted the 2010 Commonwealth Games?", Answer = "New Delhi", Options = new List<string> { "Mumbai", "Bangalore", "Kolkata", "New Delhi" } },
    new QuestionAnswer { Question = "Who is the fastest runner in the world as of 2023?", Answer = "Usain Bolt", Options = new List<string> { "Usain Bolt", "Carl Lewis", "Tyson Gay", "Justin Gatlin" } },
    new QuestionAnswer { Question = "Which country won the FIFA World Cup in 2018?", Answer = "France", Options = new List<string> { "Germany", "Brazil", "Argentina", "France" } },
    new QuestionAnswer { Question = "Which Indian cricketer is known as 'The Wall'?", Answer = "Rahul Dravid", Options = new List<string> { "Rahul Dravid", "Sourav Ganguly", "Virat Kohli", "Sachin Tendulkar" } },
    new QuestionAnswer { Question = "What does F1 stand for in racing?", Answer = "Formula One", Options = new List<string> { "Formula One", "Formula Two", "Formula Racing", "Fast One" } },
    new QuestionAnswer { Question = "Who is the only player to score 100 international centuries?", Answer = "Sachin Tendulkar", Options = new List<string> { "Sachin Tendulkar", "Rohit Sharma", "Virat Kohli", "Brian Lara" } },
    new QuestionAnswer { Question = "Which sport is known for the Wimbledon tournament?", Answer = "Tennis", Options = new List<string> { "Cricket", "Tennis", "Football", "Golf" } },
    new QuestionAnswer { Question = "What is the governing body for football worldwide?", Answer = "FIFA", Options = new List<string> { "FIFA", "UEFA", "ICC", "BCCI" } },
    new QuestionAnswer { Question = "Who is the only Indian to win a medal in the Winter Olympics?", Answer = "Jagdish Singh", Options = new List<string> { "Jagdish Singh", "Vikram Singh", "Nisha Rawal", "Ashok Kumar" } },
    new QuestionAnswer { Question = "Which sport is associated with the Olympic rings?", Answer = "Olympic Games", Options = new List<string> { "Olympic Games", "FIFA World Cup", "Cricket World Cup", "NBA" } },
    new QuestionAnswer { Question = "What is the name of the trophy awarded to the winners of the Cricket World Cup?", Answer = "Cricket World Cup Trophy", Options = new List<string> { "Cricket World Cup Trophy", "Champions Trophy", "IPL Trophy", "Asia Cup Trophy" } },
    new QuestionAnswer { Question = "Which country is known for the sport of sumo wrestling?", Answer = "Japan", Options = new List<string> { "Japan", "China", "Korea", "India" } },
    new QuestionAnswer { Question = "What is the full form of ICC?", Answer = "International Cricket Council", Options = new List<string> { "Indian Cricket Council", "International Cricket Council", "International Champions Cup", "International Cricket Committee" } },
    new QuestionAnswer { Question = "Which is the oldest Olympic sport?", Answer = "Wrestling", Options = new List<string> { "Wrestling", "Boxing", "Athletics", "Sprinting" } },
    new QuestionAnswer { Question = "Which company is known for the phrase 'Just Do It'?", Answer = "Nike", Options = new List<string> { "Adidas", "Reebok", "Puma", "Nike" } },
    new QuestionAnswer { Question = "Who is the most decorated Olympian of all time?", Answer = "Michael Phelps", Options = new List<string> { "Usain Bolt", "Michael Phelps", "Carl Lewis", "Mark Spitz" } },
    new QuestionAnswer { Question = "What does the term 'home run' refer to in baseball?", Answer = "A hit that allows the batter to round all bases", Options = new List<string> { "A hit that allows the batter to round all bases", "A strikeout", "A foul ball", "A double play" } },
    new QuestionAnswer { Question = "Which country is home to the Olympic Games in 2024?", Answer = "France", Options = new List<string> { "USA", "France", "Japan", "China" } },
    new QuestionAnswer { Question = "What is the standard distance of a marathon?", Answer = "42.195 km", Options = new List<string> { "42 km", "42.195 km", "40 km", "45 km" } },
    new QuestionAnswer { Question = "What is the highest governing body for cricket?", Answer = "ICC", Options = new List<string> { "ICC", "BCCI", "FIFA", "NBA" } },
    new QuestionAnswer { Question = "Who is known for breaking the 100m sprint world record?", Answer = "Usain Bolt", Options = new List<string> { "Carl Lewis", "Usain Bolt", "Justin Gatlin", "Tyson Gay" } },
    new QuestionAnswer { Question = "What is the name of the Indian Premier League team based in Chennai?", Answer = "Chennai Super Kings", Options = new List<string> { "Mumbai Indians", "Chennai Super Kings", "Royal Challengers Bangalore", "Kolkata Knight Riders" } },
    new QuestionAnswer { Question = "Which sport is played on a court with a net in the middle?", Answer = "Badminton", Options = new List<string> { "Tennis", "Badminton", "Cricket", "Baseball" } },
    new QuestionAnswer { Question = "What is the term for a score of zero in tennis?", Answer = "Love", Options = new List<string> { "Zero", "Love", "Nil", "Nothing" } },
    new QuestionAnswer { Question = "Which sport features the Stanley Cup?", Answer = "Ice Hockey", Options = new List<string> { "Ice Hockey", "Football", "Basketball", "Baseball" } },
    new QuestionAnswer { Question = "Who is the famous female tennis player known as 'The Swiss Miss'?", Answer = "Martina Hingis", Options = new List<string> { "Steffi Graf", "Martina Hingis", "Maria Sharapova", "Venus Williams" } },
    new QuestionAnswer { Question = "What is the main goal of soccer?", Answer = "To score goals", Options = new List<string> { "To score goals", "To defend", "To assist", "To control the ball" } },
    new QuestionAnswer { Question = "Which country is known for the sport of cricket?", Answer = "England", Options = new List<string> { "India", "England", "Australia", "South Africa" } },
    new QuestionAnswer { Question = "What is the name of the trophy awarded to the winner of the UEFA Champions League?", Answer = "Champions League Trophy", Options = new List<string> { "Europa League Trophy", "Champions League Trophy", "FIFA Trophy", "UEFA Super Cup" } },
    new QuestionAnswer { Question = "Which Indian sports event is held every year in Kolkata?", Answer = "Kolkata Marathon", Options = new List<string> { "Kolkata Marathon", "IPL", "ISL", "Pro Kabaddi League" } }
};


        public Sports()
        {
            
        }
    }
}

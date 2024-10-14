using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal class Technology
    {
        public List<QuestionAnswer> technologyQuestions = new List<QuestionAnswer>
{
    new QuestionAnswer { Question = "What does AI stand for?", Answer = "Artificial Intelligence", Options = new List<string> { "Artificial Intelligence", "Automatic Integration", "Advanced Internet", "Applied Information" } },
    new QuestionAnswer { Question = "Which company developed the iPhone?", Answer = "Apple", Options = new List<string> { "Google", "Samsung", "Apple", "Microsoft" } },
    new QuestionAnswer { Question = "What is the name of the Google search algorithm?", Answer = "PageRank", Options = new List<string> { "PageRank", "RankPage", "SearchRank", "GoogleRank" } },
    new QuestionAnswer { Question = "What is the main programming language for web development?", Answer = "JavaScript", Options = new List<string> { "Python", "Java", "C++", "JavaScript" } },
    new QuestionAnswer { Question = "What does USB stand for?", Answer = "Universal Serial Bus", Options = new List<string> { "Universal Serial Bus", "Universal Service Bus", "Unified Serial Bus", "Universal System Bus" } },
    new QuestionAnswer { Question = "What is the most widely used operating system?", Answer = "Windows", Options = new List<string> { "Linux", "Windows", "MacOS", "Unix" } },
    new QuestionAnswer { Question = "What does HTTP stand for?", Answer = "HyperText Transfer Protocol", Options = new List<string> { "HyperText Transfer Protocol", "HighText Transfer Protocol", "HyperText Transmission Protocol", "HyperText Transfer Program" } },
    new QuestionAnswer { Question = "What is the main function of a web browser?", Answer = "To access the internet", Options = new List<string> { "To access the internet", "To create websites", "To send emails", "To store data" } },
    new QuestionAnswer { Question = "Which company is known for its search engine?", Answer = "Google", Options = new List<string> { "Bing", "Yahoo", "Google", "DuckDuckGo" } },
    new QuestionAnswer { Question = "What does SEO stand for?", Answer = "Search Engine Optimization", Options = new List<string> { "Search Engine Optimization", "Search Engine Operation", "Search Engagement Optimization", "Search Efficiency Operation" } },
    new QuestionAnswer { Question = "What is the full form of Wi-Fi?", Answer = "Wireless Fidelity", Options = new List<string> { "Wireless Fidelity", "Wide Fidelity", "Wired Fidelity", "Wireless Functionality" } },
    new QuestionAnswer { Question = "Which programming language is known for web backend development?", Answer = "PHP", Options = new List<string> { "Ruby", "Java", "PHP", "Python" } },
    new QuestionAnswer { Question = "What is the term for malicious software?", Answer = "Malware", Options = new List<string> { "Virus", "Malware", "Trojan", "Spyware" } },
    new QuestionAnswer { Question = "Which device is used to connect to the internet?", Answer = "Router", Options = new List<string> { "Switch", "Router", "Modem", "Hub" } },
    new QuestionAnswer { Question = "What is the purpose of a firewall?", Answer = "To protect networks", Options = new List<string> { "To protect networks", "To boost speed", "To connect devices", "To store data" } },
    new QuestionAnswer { Question = "Which social media platform is known for its character limit?", Answer = "Twitter", Options = new List<string> { "Facebook", "Instagram", "Twitter", "LinkedIn" } },
    new QuestionAnswer { Question = "What is the name of the first electronic computer?", Answer = "ENIAC", Options = new List<string> { "ENIAC", "UNIVAC", "Colossus", "IBM 701" } },
    new QuestionAnswer { Question = "What does URL stand for?", Answer = "Uniform Resource Locator", Options = new List<string> { "Universal Resource Locator", "Uniform Resource Locator", "Unified Resource Locator", "Uniform Resource Link" } },
    new QuestionAnswer { Question = "What is the primary function of an operating system?", Answer = "Manage hardware and software", Options = new List<string> { "Manage hardware and software", "Run applications", "Store files", "Connect to the internet" } },
    new QuestionAnswer { Question = "Which company is known for its Windows operating system?", Answer = "Microsoft", Options = new List<string> { "Apple", "Google", "Microsoft", "IBM" } },
    new QuestionAnswer { Question = "What does VPN stand for?", Answer = "Virtual Private Network", Options = new List<string> { "Virtual Private Network", "Virtual Protected Network", "Variable Public Network", "Virtual Public Network" } },
    new QuestionAnswer { Question = "Which technology is used for contactless payments?", Answer = "NFC", Options = new List<string> { "NFC", "QR Code", "Bluetooth", "Wi-Fi" } },
    new QuestionAnswer { Question = "What is the primary purpose of cloud storage?", Answer = "To store data online", Options = new List<string> { "To store data online", "To run applications", "To create websites", "To send emails" } },
    new QuestionAnswer { Question = "What programming language is primarily used for Android app development?", Answer = "Java", Options = new List<string> { "Swift", "Java", "C#", "Python" } },
    new QuestionAnswer { Question = "What is the function of a graphics card?", Answer = "Render images", Options = new List<string> { "Render images", "Store data", "Connect devices", "Process audio" } },
    new QuestionAnswer { Question = "Which is the most popular web browser as of 2023?", Answer = "Google Chrome", Options = new List<string> { "Firefox", "Safari", "Internet Explorer", "Google Chrome" } },
    new QuestionAnswer { Question = "What is an example of a programming language?", Answer = "Python", Options = new List<string> { "HTML", "CSS", "Python", "SQL" } },
    new QuestionAnswer { Question = "What does the term 'Big Data' refer to?", Answer = "Large volumes of data", Options = new List<string> { "Large volumes of data", "Data analytics", "Data visualization", "Data mining" } },
    new QuestionAnswer { Question = "What is the name of Apple's virtual assistant?", Answer = "Siri", Options = new List<string> { "Alexa", "Cortana", "Siri", "Google Assistant" } },
    new QuestionAnswer { Question = "What is the process of converting data into a code?", Answer = "Encryption", Options = new List<string> { "Decryption", "Encoding", "Encryption", "Decoding" } },
    new QuestionAnswer { Question = "What does the term 'IoT' stand for?", Answer = "Internet of Things", Options = new List<string> { "Internet of Technology", "Internet of Things", "Interface of Things", "Internet of Transactions" } },
    new QuestionAnswer { Question = "What is the function of a modem?", Answer = "Connect to the internet", Options = new List<string> { "Connect to the internet", "Store data", "Manage networks", "Run applications" } },
    new QuestionAnswer { Question = "What is the term for unauthorized access to a computer system?", Answer = "Hacking", Options = new List<string> { "Hacking", "Phishing", "Spoofing", "Malware" } },
    new QuestionAnswer { Question = "What is the function of a database?", Answer = "Store and manage data", Options = new List<string> { "Store and manage data", "Run applications", "Connect to the internet", "Create websites" } },
    new QuestionAnswer { Question = "What is the term for a program that damages or disrupts a computer?", Answer = "Malware", Options = new List<string> { "Virus", "Malware", "Trojan", "Worm" } }
};
    }
}

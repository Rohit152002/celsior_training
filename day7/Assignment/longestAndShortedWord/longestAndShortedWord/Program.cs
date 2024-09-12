using System.Linq.Expressions;

namespace longestAndShortedWord
{
    internal class Program
    {
        // Take a string from user the words seperated by comma(","). Seperate the words and find out the longest and the shortest word in it
        static void Main(string[] args)
        {
            try
            {

                string[] words;

                Console.WriteLine("Please enter a list of items separated by commas.");
                Console.WriteLine("For example : left, right, up, ...");

                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new ArgumentException("Input cannot be empty or whitespace");
                }

                if (!userInput.Contains(','))
                {
                    throw new FormatException("Input must be a comma-separated list of items.");
                }

                words = userInput.Split(',').Select(word => word.Trim()).Where(word => !string.IsNullOrEmpty(word)).ToArray(); 

                if (words.Length == 0)
                {
                    throw new InvalidOperationException("No valid words found.");
                }
                string shortest = words[0], longest = words[0];

                foreach (string word in words)
                {
                    if (word.Length < shortest.Length)
                    {
                        shortest = word;
                    }
                    else if (word.Length > longest.Length)
                    {
                        longest = word;
                    }
                }

                Console.WriteLine($"Shortest word is {shortest}");
                Console.WriteLine($"Longest word is {longest}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            { 
                Console.WriteLine($"Operation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}

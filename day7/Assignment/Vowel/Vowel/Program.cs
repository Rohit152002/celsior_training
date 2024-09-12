namespace Vowel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a list of items separated by commas.");
                Console.WriteLine("For example: left, right, up, down");

                string userInput = Console.ReadLine();

                Word wordList = new Word(userInput);

                var wordsWithLeastRepeatingVowels = wordList.WordsWithLeastRepeatingVowels();
                if (wordsWithLeastRepeatingVowels.Any())
                {
                    int minRepeatingVowels = wordsWithLeastRepeatingVowels
                        .Select(word => wordList.CountRepeatingVowels(word))
                        .FirstOrDefault(); 

                    Console.WriteLine($"Words with the least number of repeating vowels ({minRepeatingVowels}):");
                    foreach (var word in wordsWithLeastRepeatingVowels)
                    {
                        Console.WriteLine(word);
                    }
                }
                else
                {
                    Console.WriteLine("No words found with repeating vowels.");
                }
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}

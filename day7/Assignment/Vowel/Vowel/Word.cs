using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowel
{
    internal class Word
    {
        public string[] Words { get; set; }

        public Word(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be empty or whitespace.");
            }

            if (!input.Contains(','))
            {
                throw new FormatException("Input must be a comma-separated list of items.");
            }
            Words = input.Split(',').Select(word => word.Trim()).Where(word => !string.IsNullOrEmpty(word)).ToArray();

           if (Words.Length == 0)
            {
                throw new InvalidOperationException("No valid words found.");
            }

        }

        public int CountRepeatingVowels(string word)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int repeatCount = 0;

            // Count occurrences of each vowel
            foreach (char vowel in vowels)
            {
                int count = word.Count(ch => ch == vowel);
                if (count > 1)
                {
                    repeatCount++;
                }
            }

            return repeatCount;
        }

        public IEnumerable<string> WordsWithLeastRepeatingVowels()
        {
            List<string> resultWords = new List<string>();
            int minRepeatingVowels = int.MaxValue;

            foreach (string word in Words)
            {
                int count = CountRepeatingVowels(word);
                if (count < minRepeatingVowels)
                {
                    minRepeatingVowels = count;
                    resultWords.Clear(); 
                    resultWords.Add(word);
                }
                else if (count == minRepeatingVowels)
                {
                    resultWords.Add(word);
                }
            }

            return resultWords;
        }

    }
}

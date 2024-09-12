using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardValidation
{
    internal class CardValidator : ICardValidator
    {


        public string CardNumber { get; set; }

        public CardValidator(string cardNumber)
        {
            this.CardNumber = cardNumber;
        }

        public string Reverse(string cardNumber)
        {
            if(string.IsNullOrWhiteSpace(cardNumber))
            {
                throw new InvalidCardNumberExecption("Card Number cannot be null or empty");
            }
            return new string(cardNumber.Replace(" ","").Reverse().ToArray());
        }

        public int[] MultiplyEvenPosition(string reverseCardNumber)
        {
            int[] numbers= reverseCardNumber.Select(c=>int.Parse(c.ToString())).ToArray();
            for(int i=1;i<numbers.Length; i+=2)
            {
                numbers[i] *= 2;
            }
            return numbers;
        }

        public int[] SumTwoDigits(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int tens = numbers[i] / 10;
                int ones = numbers[i] % 10;
                numbers[i] = tens + ones;
            }
            return numbers;
        }

        public int SumAll(int[] numbers)
        {
            return numbers.Sum();
        }

   
        public bool IsValid()
        {
            try
            {
                if(CardNumber.Replace(" ","").Length !=16)
                {
                    throw new InvalidCardNumberExecption("Card number must be exactly 16 digits");
                }
                string reversedCardNumber = Reverse(CardNumber);
                int[] multipliedNumbers = MultiplyEvenPosition(reversedCardNumber);
                int[] summedNumbers = SumTwoDigits(multipliedNumbers);
                int totalSum = SumAll(summedNumbers);

                return (totalSum % 10 == 0);
            }catch(InvalidCardNumberExecption e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return false;
            }catch(Exception e)
            {
                Console.WriteLine($"Unexpected error : {e.Message}");
                return false;
            }
        }
    }
}

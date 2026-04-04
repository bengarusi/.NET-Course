using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_5
{
    public class Details
    {

        public static void PrintDetailas(string i_number)
        {
            AmountOfDigitsBiggerUnits(i_number);
            DigitsDivededBy4(i_number);
            MultiplyBiggetAndSmallestDigits(i_number);
            AmountOfDiffrentsDigits(i_number);
        }
        private static void AmountOfDigitsBiggerUnits(string i_number)
        {
            List<string> digitsBiggerUnits = new List<string>();
            int count = 0;
            char unitsDigit = i_number[i_number.Length-1];
            for (int i = 0; i < i_number.Length; i++)
            {
                if (i_number[i] > unitsDigit)
                {
                    count++;
                    digitsBiggerUnits.Add(i_number[i].ToString());
                }
            }
            string msg = String.Format("Digits bigger than the units digit: {0}: {1}", unitsDigit, string.Join(", ", digitsBiggerUnits));
            Console.WriteLine(msg);
        }

        private static void DigitsDivededBy4(string i_number)
        {
            int amountOfDigitsDevidedBy4 = 0;
            for (int i = 0; i < i_number.Length; i++)
            {
                if (i_number[i] % 4 == 0)
                {
                    amountOfDigitsDevidedBy4++;
                }
            }
            Console.WriteLine($"Amount of digits devided by 4: {amountOfDigitsDevidedBy4}");
        }

        private static void MultiplyBiggetAndSmallestDigits(string i_number)
        {
            int biggestDigit = 0;
            int smallestDigit = 9;

            for (int i = 0; i < i_number.Length; i++)
            {
                int currentDigit = i_number[i] - '0';

                if (currentDigit > biggestDigit)
                {
                    biggestDigit = currentDigit;
                }

                if (currentDigit < smallestDigit)
                {
                    smallestDigit = currentDigit;
                }
            }

            Console.WriteLine($"Multiplication of the biggest and smallest digits: {biggestDigit * smallestDigit}");
        }

        private static void AmountOfDiffrentsDigits(string i_number)
        {
            int amountOfDiffrentDigits = 0;

            for (int i = 0; i < i_number.Length; i++)
            {
                bool alreadySeen = false;

                for (int j = 0; j < i; j++)
                {
                    if (i_number[i] == i_number[j])
                    {
                        alreadySeen = true;
                        break;
                    }
                }

                if (!alreadySeen)
                {
                    amountOfDiffrentDigits++;
                }
            }

            Console.WriteLine($"Amount of different digits: {amountOfDiffrentDigits}");
        }
    }
}

using System;

namespace Ex01_1
{
    public class Program
    {
        public const int k_BinaryNumberLength = 7;
        public const int k_AmountOfNumbers = 4;

        public static void Main()
        {
            string[]   binaryNumbers = new string[k_AmountOfNumbers];
            int[]      numbers = new int[k_AmountOfNumbers];

            for (int i = 0; i < k_AmountOfNumbers; i++)
            {
                string binaryNumber;

                Console.WriteLine("Enter a 7 digit binary number:");
                binaryNumber = Console.ReadLine();

                if (!Validation.InputValidation(binaryNumber))
                {
                    i--;
                }
                else
                {
                    binaryNumbers[i] = binaryNumber;
                }
            }

            for (int i = 0; i < k_AmountOfNumbers; i++)
            {
                numbers[i] = BinaryToDecimalConverter.ConvertBinaryToDecimal(binaryNumbers[i]);
            }

            Statistics.PrintStatistics(binaryNumbers, numbers);
        }
    }
}
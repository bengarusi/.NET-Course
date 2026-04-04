using System;

namespace Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            string[] binaryNumbers = new string[Globals.k_AmountOfNumbers];
            int[] numbers = new int[Globals.k_AmountOfNumbers];

            for (int i = 0; i < Globals.k_AmountOfNumbers; i++)
            {
                Console.WriteLine("Enter a 7 digit binary number:");
                string binaryNumber = Console.ReadLine();

                if (!Validation.InputValidation(binaryNumber))
                {
                    i--;
                }
                else
                {
                    binaryNumbers[i] = binaryNumber;
                }
            }

            for (int i = 0; i < Globals.k_AmountOfNumbers; i++)
            {
                numbers[i] = BinaryToDecimalConverter.ConvertBinaryToDecimal(binaryNumbers[i]);
            }

            Statistics.PrintStatistics(binaryNumbers, numbers);
            Console.ReadLine();
        }
    }
}
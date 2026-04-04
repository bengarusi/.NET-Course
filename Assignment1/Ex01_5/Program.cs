using System;

namespace Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a 9-digit number:");
            string userInput = Console.ReadLine();

            while (!Validation.ValidateInput(userInput))
            {
                userInput = Console.ReadLine();
            }

            NumberStatistics.PrintStatistics(userInput);
            Console.ReadLine();
        }
    }
}
using System;

namespace Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string userInput;

            Console.WriteLine("Please enter a 9-digit number:");
            userInput = Console.ReadLine();

            while (!Validation.ValidateInput(userInput))
            {
                userInput = Console.ReadLine();
            }

            NumberStatistics.PrintStatistics(userInput);
        }
    }
}
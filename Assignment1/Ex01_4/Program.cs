using System;

namespace Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            string userInput;

            Console.WriteLine("Please enter a string of 8 characters: ");
            userInput = Console.ReadLine();

            while (!Validation.ValidateInput(userInput))
            {
                Console.WriteLine("Invalid input, please try again (8 characters exactly): ");
                userInput = Console.ReadLine();
            }

            InputAnalyzer.AnalyzeInput(userInput);
        }
    }
}
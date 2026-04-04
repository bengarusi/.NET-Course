using System;

namespace Ex01_4
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a string of 8 characters:");
            string userInput = Console.ReadLine();

            while (!Validation.ValidateInput(userInput))
            {
                Console.WriteLine("Invalid input, please try again (8 characters exactly):");
                userInput = Console.ReadLine();
            }

            InputAnalyzer.AnalyzeInput(userInput);
            Console.ReadLine();
        }
    }
}
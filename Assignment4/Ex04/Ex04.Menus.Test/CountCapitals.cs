using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ex04.Menus.Test
{
    public class CountCapitals : IMenuAction
    {
        public void Execute()
        {
            Console.WriteLine("Please enter a text:");
            string input = Console.ReadLine();
            int capitalCount = 0;
            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    capitalCount++;
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"> There are {capitalCount} capital letters in your text.\n");
        }
    }
}

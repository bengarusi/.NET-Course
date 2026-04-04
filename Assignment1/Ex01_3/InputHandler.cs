using System;
namespace Ex01_3
{
    public class InputHandler
    {
        private const int k_MinHeight = 4;
        private const int k_MaxHeight = 15;
        public static int GetValidTreeHeight()
        {
            
            int height;
            Console.Write($"Please enter tree height({k_MinHeight}-{k_MaxHeight}):");

            while (!isValidInput(Console.ReadLine(), out height))
            {
                Console.WriteLine($"Invalid input. Please enter a number between {k_MinHeight} and {k_MaxHeight}.");
                Console.Write("Try again: ");
            }

            return height;
        }

        public static bool isValidInput(string i_Input, out int o_Height)
        {
            return int.TryParse(i_Input,out o_Height) && o_Height >= k_MinHeight && o_Height <= k_MaxHeight;
        }
    }
}

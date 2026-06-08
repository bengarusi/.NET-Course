using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountCapitals : IMenuAction
    {
        public void Execute()
        {
            string input;
            int capitalCount = 0;

            Console.WriteLine("Please enter a text:");
            input = Console.ReadLine();

            foreach (char currentChar in input)
            {
                if (char.IsUpper(currentChar))
                {
                    capitalCount++;
                }
            }

            Console.WriteLine("There are {0} uppercase letters in your text.\n", capitalCount);
        }
    }
}
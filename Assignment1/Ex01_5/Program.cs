using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter 9 digits number");
            string number = Console.ReadLine();
            while (!Validation.ValidateInput(number))
            {
                Console.WriteLine("Invalid input, please try again (9 digits exactly):");
                number = Console.ReadLine();
            }
            Details.PrintDetailas(number);
        }

    }
}

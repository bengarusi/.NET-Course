
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class PrintMenu
    {
        public static void PrintMainMenu()
        {
           
            Console.WriteLine("===== Garage Management System =====");
            Console.WriteLine("1. Load vehicles from file");
            Console.WriteLine("2. Insert a new vehicle");
            Console.WriteLine("3. Display license plates");
            Console.WriteLine("4. Change vehicle status");
            Console.WriteLine("5. Inflate wheels to max");
            Console.WriteLine("6. Refuel vehicle");
            Console.WriteLine("7. Charge electric vehicle");
            Console.WriteLine("8. Display full vehicle details");
            Console.WriteLine("9. Exit");
            Console.WriteLine("====================================");
        }

    }
}
        

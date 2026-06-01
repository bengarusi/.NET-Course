
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class ConsoleOutputWriter
    {
        public void PrintMainMenu()
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

        public void PrintMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public void PrintError(string i_Message)
        {
            Console.WriteLine("Error: " + i_Message);
        }

        public void PrintSuccess(string i_Message)
        {
            Console.WriteLine("Success: " + i_Message);
        }

        public void PrintLicensePlates(List<string> i_LicensePlates)
        {
            if (i_LicensePlates.Count == 0)
            {
                Console.WriteLine("No vehicles found.");
            }
            else
            {
                Console.WriteLine("License plates:");

                foreach (string licensePlate in i_LicensePlates)
                {
                    Console.WriteLine(licensePlate);
                }
            }
        }

        public void PrintVehicleDetails(string i_Details)
        {
            Console.WriteLine("===== Vehicle Details =====");
            Console.WriteLine(i_Details);
            Console.WriteLine("===========================");
        }

        
        public void PrintEnumOptions(Type i_EnumType)
        {
            Console.WriteLine("Possible values:");

            foreach (string enumName in Enum.GetNames(i_EnumType))
            {
                Console.WriteLine(enumName);
            }
        }
        
    }
}
        

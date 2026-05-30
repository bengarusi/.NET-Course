using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;


// this is just a main i maid to test the loading opartion 
// can delete it in order to make ConsoleUI
namespace Ex03.ConsoleUI
{
    public class ConsoleApp
    {
        private readonly GarageManager r_GarageManager;

        public ConsoleApp()
        {
            r_GarageManager = new GarageManager();
        }

        public void Run()
        {
            try
            {
                string[] lines = File.ReadAllLines("VehiclesDB.txt");

                r_GarageManager.ImportVehiclesFromFile(lines);

                Console.WriteLine("Vehicles loaded successfully.");
                Console.WriteLine();

                List<string> licenseIds = r_GarageManager.GetAllLicenseIds();

                Console.WriteLine("Loaded license numbers:");
                foreach (string licenseId in licenseIds)
                {
                    Console.WriteLine(licenseId);
                }

                Console.WriteLine();
                Console.WriteLine("Full details test:");
                Console.WriteLine(r_GarageManager.GetFullVehicleDetails("64-281-95"));

                Console.WriteLine("Fuel motorcycle test:");
                Console.WriteLine(r_GarageManager.GetFullVehicleDetails("29-714-58"));

                Console.WriteLine("Electric motorcycle test:");
                Console.WriteLine(r_GarageManager.GetFullVehicleDetails("17-925-43"));

                Console.WriteLine("Fuel car test:");
                Console.WriteLine(r_GarageManager.GetFullVehicleDetails("64-281-95"));

                Console.WriteLine("Electric car test:");
                Console.WriteLine(r_GarageManager.GetFullVehicleDetails("46-389-72"));

                Console.WriteLine("Fuel truck test:");
                Console.WriteLine(r_GarageManager.GetFullVehicleDetails("93-672-18"));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
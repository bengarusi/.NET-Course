using Ex03.ConsoleUi;
using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ex03.ConsoleUI
{
    public class GarageActionsHandler
    {
        private static readonly string sr_DefaultVehiclesFileName = "VehiclesDB.txt";

        private readonly GarageManager r_GarageManager;

        public GarageActionsHandler(GarageManager i_GarageManager)
        {
            r_GarageManager = i_GarageManager;
        }

 
        public void HandleAction(eMenuOption i_MenuOption)
        {
            switch (i_MenuOption)
            {
                case eMenuOption.LoadFromFile:
                    loadVehiclesFromFile();
                    break;

                case eMenuOption.InsertVehicle:
                    insertNewVehicle();
                    break;

                case eMenuOption.DisplayFilteredLicenses:
                    displayLicensePlates();
                    break;

                case eMenuOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;

                case eMenuOption.InflateWheels:
                    inflateWheelsToMax();
                    break;

                case eMenuOption.Refuel:
                    refuelVehicle();
                    break;

                case eMenuOption.Charge:
                    chargeVehicle();
                    break;

                case eMenuOption.DisplayFullDetails:
                    displayVehicleDetails();
                    break;
            }
        }

        private bool checkVehicleInGarage(string i_LicenseNumber)
        {
            bool isInGarage = r_GarageManager.IsVehicleInGarage(i_LicenseNumber);

            if (!isInGarage)
            {
                Console.WriteLine("Vehicle with the specified license number was not found in the garage.");
            }

            return isInGarage;
        }
        private void loadVehiclesFromFile()
        {
            string[] lines = File.ReadAllLines(sr_DefaultVehiclesFileName);

            r_GarageManager.ImportVehiclesFromFile(lines);
        }

        private void insertNewVehicle()
        {
            Console.WriteLine("Please enter License Number:");
            string licenseNumber = Console.ReadLine();

            bool isLicenseEmpty = true;
            if (licenseNumber != null)
            {
                foreach (char c in licenseNumber)
                {
                    if (c != ' ')
                    {
                        isLicenseEmpty = false;
                        break;
                    }
                }
            }

            if (isLicenseEmpty)
            {
                Console.WriteLine("License number cannot be empty. Operation cancelled.");
                return;
            }

            if (r_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine(string.Format("Vehicle with license number {0} is already in the garage. Changing status to InRepair.", licenseNumber));
                r_GarageManager.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
            }
            else
            {
                NewVehicleData newVehicleData = new NewVehicleData();
                newVehicleData.LicenseNumber = licenseNumber;

                Console.WriteLine("Please enter Vehicle Type (e.g. FuelCar, ElectricCar, FuelMotorcycle, ElectricMotorcycle, FuelTruck):");
                newVehicleData.VehicleType = Console.ReadLine();

                try
                {
                    List<string> requiredFields = r_GarageManager.GetRequiredFieldsForType(newVehicleData.VehicleType);

                    Console.WriteLine("Please enter Model Name:");
                    newVehicleData.ModelName = Console.ReadLine();

                    Console.WriteLine("Please enter Owner Name:");
                    newVehicleData.OwnerName = Console.ReadLine();

                    Console.WriteLine("Please enter Owner Phone Number:");
                    newVehicleData.OwnerPhoneNumber = Console.ReadLine();

                    Console.WriteLine("Please enter Wheel Manufacturer:");
                    newVehicleData.WheelManufacturer = Console.ReadLine();

                    Console.WriteLine("Please enter current energy percentage (0-100):");
                    float number;
                    newVehicleData.EnergyPercentage = float.TryParse(Console.ReadLine(), out number) ? number : -1;

                    Console.WriteLine("Please enter wheels air pressure (applies to all wheels):");
                    newVehicleData.CurrentAirPressure = float.TryParse(Console.ReadLine(), out number) ? number : -1;

                    newVehicleData.UniqueFields = new List<string>();

                    foreach (string field in requiredFields)
                    {
                        Console.WriteLine(string.Format("Please enter {0}:", field));
                        newVehicleData.UniqueFields.Add(Console.ReadLine());
                    }

                    if (!ValidateInputs.ValidateNewVehicleData(newVehicleData))
                    {
                        Console.WriteLine("Invalid input data. Vehicle was not added to the garage.");
                    }
                    else
                    {
                        r_GarageManager.AddNewVehicle(newVehicleData);
                        Console.WriteLine("Vehicle successfully added to the garage.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed to add vehicle: {0}", ex.Message));
                }
            }
        }



        private void displayLicensePlates()
        {
            Console.WriteLine("Please enter filter option (All, InRepair, Repaired, Paid):");
            string filterOption = Console.ReadLine();
            eVehicleStatus vehicleStatus;
            List<string> licensePlates = new List<string>();

            if (filterOption == "All")
            {
               licensePlates = r_GarageManager.GetAllLicenseIds();
            }
            else if (Enum.TryParse(filterOption, out vehicleStatus))
            {
               licensePlates = r_GarageManager.GetLicenseIdsByStatus(vehicleStatus);
            }

            if (licensePlates == null)
            { 
                Console.WriteLine("Invalid filter option.");
            }
            else if (licensePlates.Count == 0)
            {
                Console.WriteLine("No vehicles found with the specified filter.");
            }
            else
            {
                Console.WriteLine("License plates:");
                foreach (string licenseNumber in licensePlates)
                {
                    Console.WriteLine(licenseNumber);
                }
            }

        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Please enter license number:");
            string licenseNumber = Console.ReadLine();
            if (checkVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Please enter new status (InRepair, Repaired, Paid):");
                string statusInput = Console.ReadLine();
                eVehicleStatus newStatus;
                if (Enum.TryParse(statusInput, out newStatus))
                {
                    r_GarageManager.ChangeVehicleStatus(licenseNumber, newStatus);
                }
                else
                {
                    Console.WriteLine("Invalid status input. Status was not changed.");
                }

            }
        }

        private void inflateWheelsToMax()
        {
            Console.WriteLine("Please enter license number:");
            string licenseNumber = Console.ReadLine();
            if (checkVehicleInGarage(licenseNumber))
            {
                try
                {
                    r_GarageManager.InflateVehicleWheelsToMax(licenseNumber);
                    Console.WriteLine("Wheels inflated to maximum air pressure.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed to inflate wheels: {0}", ex.Message));
                }
            }
        }

        private void refuelVehicle()
        {
            Console.WriteLine("Please enter license number:");
            string licenseNumber = Console.ReadLine();
            if (checkVehicleInGarage(licenseNumber))
            {
                eFuelType fuelType;
                Console.WriteLine("Please enter fuel type:");
                if (Enum.TryParse(Console.ReadLine(), out fuelType))
                {
                    Console.WriteLine("Please enter amount of fuel to add:");
                    float amount;
                    if (float.TryParse(Console.ReadLine(), out amount))
                    {
                        try
                        {
                            r_GarageManager.RefuelVehicle(licenseNumber, fuelType, amount);
                            Console.WriteLine("Vehicle refueled successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(string.Format("Refuel operation failed: {0}", ex.Message));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount input. Refuel operation cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid fuel type input. Refuel operation cancelled.");
                }
            }
        }

        private void chargeVehicle()
        {
            Console.WriteLine("Please enter license number:");
            string licenseNumber = Console.ReadLine();
            if (checkVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Please enter amount of minutes to charge:");
                float minutes;
                if (float.TryParse(Console.ReadLine(), out minutes))
                {
                    try
                    {
                        r_GarageManager.RechargeVehicle(licenseNumber, minutes);
                        Console.WriteLine("Vehicle charged successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("Charge operation failed: {0}", ex.Message));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount input. Charge operation cancelled.");
                }
            }
        }

        private void displayVehicleDetails()
        {
            Console.WriteLine("Please enter license number:");
            string licenseNumber = Console.ReadLine();
            if (checkVehicleInGarage(licenseNumber))
            {
                string details = r_GarageManager.GetFullVehicleDetails(licenseNumber);
                Console.WriteLine("Vehicle details:");
                Console.WriteLine(details);
            }
        }

    }
}
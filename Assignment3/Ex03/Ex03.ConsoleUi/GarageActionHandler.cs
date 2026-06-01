using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ex03.ConsoleUI
{
    public class GarageActionsHandler
    {
        private const string k_DefaultVehiclesFileName = "VehiclesDB.txt";

        private readonly GarageManager r_GarageManager;
        //private readonly ConsoleInputReader r_InputReader;
        private readonly ConsoleOutputWriter r_OutputWriter;

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
                    DisplayLicensePlates();
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
            string[] lines = File.ReadAllLines(k_DefaultVehiclesFileName);
            r_GarageManager.ImportVehiclesFromFile(lines);

            r_OutputWriter.PrintSuccess("Vehicles loaded from file.");
        }

        private void insertNewVehicle()
        {
            Console.WriteLine("Please enter License Number:");
            string licenseNumber = Console.ReadLine();

            if (r_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine(string.Format("Vehicle with license number {0} is already in the garage. Changing status to InRepair.", licenseNumber));
                r_GarageManager.GetVehicleRecord(licenseNumber).VehicleStatus = eVehicleStatus.InRepair;
                return;
            }

            NewVehicleData newVehicleData = new NewVehicleData();
            newVehicleData.LicenseNumber = licenseNumber;

            Console.WriteLine("Please enter Vehicle Type (e.g. FuelCar, ElectricCar, FuelMotorcycle, ElectricMotorcycle, FuelTruck):");
            newVehicleData.VehicleType = Console.ReadLine();

            Console.WriteLine("Please enter Model Name:");
            newVehicleData.ModelName = Console.ReadLine();

            Console.WriteLine("Please enter Owner Name:");
            newVehicleData.OwnerName = Console.ReadLine();

            Console.WriteLine("Please enter Owner Phone Number:");
            newVehicleData.OwnerPhoneNumber = Console.ReadLine();

            Console.WriteLine("Please enter Wheel Manufacturer:");
            newVehicleData.WheelManufacturer = Console.ReadLine();

            Console.WriteLine("Please enter current energy percentage (0-100):");
            newVehicleData.EnergyPercentage = float.Parse(Console.ReadLine());

            Console.WriteLine("Please enter wheels air pressure (applies to all wheels):");
            newVehicleData.CurrentAirPressure = float.Parse(Console.ReadLine());

            newVehicleData.UniqueFields = new List<string>();
            List<string> requiredFields = r_GarageManager.GetRequiredFieldsForType(newVehicleData.VehicleType);

            foreach (string field in requiredFields)
            {
                Console.WriteLine(string.Format("Please enter {0}:", field));
                newVehicleData.UniqueFields.Add(Console.ReadLine());
            }

            if (!ValidateNewVehicleData(newVehicleData))
            {
                Console.WriteLine("Invalid input data. Vehicle was not added to the garage.");
                return;//or loop until valid data is entered
            }

            r_GarageManager.AddNewVehicle(newVehicleData);
            Console.WriteLine("Vehicle successfully added to the garage.");

        }

        private bool ValidateNewVehicleData(NewVehicleData i_DataToValidate)
        {
            bool isValid = true;

            if (i_DataToValidate == null)
            {
                isValid = false;
            }
            else
            {
                string licenseNumber = i_DataToValidate.LicenseNumber;
                string modelName = i_DataToValidate.ModelName;
                string ownerName = i_DataToValidate.OwnerName;
                string ownerPhoneNumber = i_DataToValidate.OwnerPhoneNumber;
                string wheelManufacturer = i_DataToValidate.WheelManufacturer;

                bool hasOnlyDigits = true;
                bool hasOnlyLettersSpacesOrDash = true;
                bool hasOnlyPhoneDigits = true;
                bool hasLetterOrDigitInModel = false;
                bool hasLetterInManufacturer = false;
                bool hasNonSpaceLicense = false;
                bool hasNonSpaceModel = false;
                bool hasNonSpaceOwnerName = false;
                bool hasNonSpacePhone = false;
                bool hasNonSpaceManufacturer = false;

                // License number validation: not empty, not only spaces, only digits
                if (licenseNumber == null || licenseNumber.Length == 0)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < licenseNumber.Length; i++)
                    {
                        char currentChar = licenseNumber[i];

                        if (currentChar != ' ')
                        {
                            hasNonSpaceLicense = true;
                        }

                        if (currentChar < '0' || currentChar > '9')
                        {
                            hasOnlyDigits = false;
                        }
                    }

                    if (!hasNonSpaceLicense || !hasOnlyDigits)
                    {
                        isValid = false;
                    }
                }

                // Model name validation: not empty, not only spaces, contains at least one letter or digit
                if (modelName == null || modelName.Length == 0)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < modelName.Length; i++)
                    {
                        char currentChar = modelName[i];

                        if (currentChar != ' ')
                        {
                            hasNonSpaceModel = true;
                        }

                        if ((currentChar >= '0' && currentChar <= '9') ||
                            (currentChar >= 'a' && currentChar <= 'z') ||
                            (currentChar >= 'A' && currentChar <= 'Z'))
                        {
                            hasLetterOrDigitInModel = true;
                        }
                    }

                    if (!hasNonSpaceModel || !hasLetterOrDigitInModel)
                    {
                        isValid = false;
                    }
                }

                // Owner name validation: not empty, not only spaces, only English letters, spaces or '-'
                if (ownerName == null || ownerName.Length == 0)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < ownerName.Length; i++)
                    {
                        char currentChar = ownerName[i];

                        if (currentChar != ' ')
                        {
                            hasNonSpaceOwnerName = true;
                        }

                        if (!((currentChar >= 'a' && currentChar <= 'z') ||
                              (currentChar >= 'A' && currentChar <= 'Z') ||
                              currentChar == ' ' ||
                              currentChar == '-'))
                        {
                            hasOnlyLettersSpacesOrDash = false;
                        }
                    }

                    if (!hasNonSpaceOwnerName || !hasOnlyLettersSpacesOrDash)
                    {
                        isValid = false;
                    }
                }

                // Phone number validation: not empty, only digits, length 9-10
                if (ownerPhoneNumber == null || ownerPhoneNumber.Length == 0)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < ownerPhoneNumber.Length; i++)
                    {
                        char currentChar = ownerPhoneNumber[i];

                        if (currentChar != ' ')
                        {
                            hasNonSpacePhone = true;
                        }

                        if (currentChar < '0' || currentChar > '9')
                        {
                            hasOnlyPhoneDigits = false;
                        }
                    }

                    if (!hasNonSpacePhone ||
                        !hasOnlyPhoneDigits ||
                        ownerPhoneNumber.Length < 9 ||
                        ownerPhoneNumber.Length > 10)
                    {
                        isValid = false;
                    }
                }

                // Wheel manufacturer validation: not empty, not only spaces, contains at least one English letter
                if (wheelManufacturer == null || wheelManufacturer.Length == 0)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < wheelManufacturer.Length; i++)
                    {
                        char currentChar = wheelManufacturer[i];

                        if (currentChar != ' ')
                        {
                            hasNonSpaceManufacturer = true;
                        }

                        if ((currentChar >= 'a' && currentChar <= 'z') ||
                            (currentChar >= 'A' && currentChar <= 'Z'))
                        {
                            hasLetterInManufacturer = true;
                        }
                    }

                    if (!hasNonSpaceManufacturer || !hasLetterInManufacturer)
                    {
                        isValid = false;
                    }
                }

                // Energy percentage validation
                if (i_DataToValidate.EnergyPercentage < 0 ||
                    i_DataToValidate.EnergyPercentage > 100)
                {
                    isValid = false;
                }

                // Air pressure validation
                if (i_DataToValidate.CurrentAirPressure < 0)
                {
                    isValid = false;
                }

                // Vehicle type validation
                try
                {
                    Vehicle tempVehicle = VehicleCreator.CreateVehicle(
                        i_DataToValidate.VehicleType,
                        null,
                        null);

                    if (tempVehicle == null)
                    {
                        isValid = false;
                    }
                }
                catch
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private void DisplayLicensePlates()
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
           if(checkVehicleInGarage(licenseNumber))
            {
                r_GarageManager.InflateVehicleWheelsToMax(licenseNumber);
                Console.WriteLine("Wheels inflated to maximum air pressure.");
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
                        r_GarageManager.RefuelVehicle(licenseNumber, fuelType, amount);
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
                    r_GarageManager.RechargeVehicle(licenseNumber, minutes);
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
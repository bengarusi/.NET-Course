using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicleRecord> r_VehiclesInGarage =new Dictionary<string, GarageVehicleRecord>();

        // ----- Operation 1: load the system from the DB file -----
        public void ImportVehiclesFromFile(string[] i_Lines)
        {
            List<NewVehicleData> vehiclesData = VehicleFileLoader.ParseLines(i_Lines);
            foreach (NewVehicleData data in vehiclesData)
            {
                AddNewVehicle(data);
            }
        }

        // ----- Operation 2 -----
        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetRequiredFieldsForType(string i_VehicleType) // maybe not needed, just to tell the user what to enter for each type of vehicle
        {
            Vehicle vehicle = VehicleCreator.CreateVehicle(i_VehicleType, null, null);
            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            return vehicle.GetRequiredFields();
        }

        public void EnterNewVehicle()
        {
            Console.WriteLine("Please enter License Number:");
            string licenseNumber = Console.ReadLine();

            if (IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine(string.Format("Vehicle with license number {0} is already in the garage. Changing status to InRepair.", licenseNumber));
                r_VehiclesInGarage[licenseNumber].VehicleStatus = eVehicleStatus.InRepair; 
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
            List<string> requiredFields = GetRequiredFieldsForType(newVehicleData.VehicleType);

            foreach (string field in requiredFields)
            {
                Console.WriteLine(string.Format("Please enter {0}:", field));
                newVehicleData.UniqueFields.Add(Console.ReadLine());
            }

            if(!ValidateNewVehicleData(newVehicleData))
            {
                Console.WriteLine("Invalid input data. Vehicle was not added to the garage.");
                return;//or loop until valid data is entered
            }

            AddNewVehicle(newVehicleData);
            Console.WriteLine("Vehicle successfully added to the garage.");

        }

        public bool ValidateNewVehicleData(NewVehicleData i_DataToValidate)
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

        public void AddNewVehicle(NewVehicleData i_NewVehicleToAdd)
        {
            Vehicle vehicle = VehicleCreator.CreateVehicle(
                i_NewVehicleToAdd.VehicleType, i_NewVehicleToAdd.LicenseNumber, i_NewVehicleToAdd.ModelName);
            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            vehicle.SetEnergyPercentage(i_NewVehicleToAdd.EnergyPercentage);
            vehicle.SetWheelsData(i_NewVehicleToAdd.WheelManufacturer, i_NewVehicleToAdd.CurrentAirPressure);
            vehicle.InitializeUniqueData(i_NewVehicleToAdd.UniqueFields);

            GarageVehicleRecord record = new GarageVehicleRecord(
                vehicle, i_NewVehicleToAdd.OwnerName, i_NewVehicleToAdd.OwnerPhoneNumber);

            r_VehiclesInGarage[vehicle.LicenseNumber] = record;
        }

        // ----- Operation 3 -----
        public List<string> GetAllLicenseIds()
        {
            return new List<string>(r_VehiclesInGarage.Keys);
        }

        public List<string> GetLicenseIdsByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseIds = new List<string>();

            foreach (GarageVehicleRecord record in r_VehiclesInGarage.Values)
            {
                if (record.VehicleStatus == i_VehicleStatus)
                {
                    licenseIds.Add(record.Vehicle.LicenseNumber);
                }
            }

            return licenseIds;
        }

        // ----- Operation 4 -----
        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
            GarageVehicleRecord record = getVehicleRecord(i_LicenseNumber);

            record.VehicleStatus = i_NewVehicleStatus;
        }

        // ----- Operation 5 -----
        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            GarageVehicleRecord record = getVehicleRecord(i_LicenseNumber);

            record.Vehicle.InflateAllWheelsToMax();
        }

        // ----- Operation 6 -----
        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToAdd)
        { 
            FuelEngine engine = getVehicleRecord(i_LicenseNumber).Vehicle.Engine as FuelEngine;

            if (engine == null)
            {
                throw new ArgumentException("This vehicle is not fuel-powered.");
            }

            engine.Refuel(i_AmountToAdd, i_FuelType);

        }

        // ----- Operation 7 (input is minutes; the model stores hours) -----
        public void RechargeVehicle(string i_LicenseNumber, float i_MinutesToAdd)
        {
            //!!!!!! need to do - this is not generic maybe can do it better way !!!!!!
            ElectricEngine engine = getVehicleRecord(i_LicenseNumber).Vehicle.Engine as ElectricEngine;

            if (engine == null)
            {
                throw new ArgumentException("This vehicle is not electric.");
            }

            engine.Charge(i_MinutesToAdd / 60f);

        }

        // ----- Operation 8 -----
        public string GetFullVehicleDetails(string i_LicenseNumber)
        {
            GarageVehicleRecord record = getVehicleRecord(i_LicenseNumber);

            return record.ToString();
        }

        // ----- Utils -----
        private GarageVehicleRecord getVehicleRecord(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException(
                    string.Format("Vehicle with license number {0} was not found in the garage.", i_LicenseNumber));
            }

            return r_VehiclesInGarage[i_LicenseNumber];
        }

    }

}
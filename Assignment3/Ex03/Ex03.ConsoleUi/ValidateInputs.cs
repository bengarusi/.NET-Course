using Ex03.GarageLogic;

using System;

namespace Ex03.ConsoleUI
{
    public static class ValidateInputs
    {
        public static bool ValidateInputNotEmpty(NewVehicleData i_DataToValidate)
        {
            string showInvalidDataMessage = "Invalid input for field: {0}. Vehicle data is not valid.\n";
            bool isValid = true;
            string errorMessages = "";

            if (i_DataToValidate == null)
            {
                errorMessages += "Vehicle data is null.\n";
                isValid = false;
            }
            else
            {
                string licenseNumber = i_DataToValidate.LicenseNumber;
                string modelName = i_DataToValidate.ModelName;
                string ownerName = i_DataToValidate.OwnerName;
                string ownerPhoneNumber = i_DataToValidate.OwnerPhoneNumber;
                string wheelManufacturer = i_DataToValidate.WheelManufacturer;
                if (IsEmpty(licenseNumber))
                {
                    errorMessages += string.Format(showInvalidDataMessage, "License Number");
                    isValid = false;
                }
                if (IsEmpty(modelName))
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Model Name");
                    isValid = false;
                }
                if (IsEmpty(ownerName))
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Owner Name");
                    isValid = false;
                }
                if (IsEmpty(ownerPhoneNumber))
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Owner Phone Number");
                    isValid = false;
                }
                if (IsEmpty(wheelManufacturer))
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Wheel Manufacturer");
                    isValid = false;
                }
            }
            if (!isValid)
            {
                Console.WriteLine("\nErrors encountered:");
                Console.Write(errorMessages);
            }
            return isValid;
        }


        public static bool IsEmpty(string i_StringToCheck)
        {
            return i_StringToCheck == null || i_StringToCheck.Length == 0;
        }
    }
}
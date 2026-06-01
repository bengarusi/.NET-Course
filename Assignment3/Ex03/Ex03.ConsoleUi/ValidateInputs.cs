using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUi
{
    public static class ValidateInputs
    {
        public static bool ValidateNewVehicleData(NewVehicleData i_DataToValidate)
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
                    errorMessages += string.Format(showInvalidDataMessage, "License Number");
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
                        errorMessages += string.Format(showInvalidDataMessage, "License Number");
                        isValid = false;
                    }
                }

                // Model name validation: not empty, not only spaces, contains at least one letter or digit
                if (modelName == null || modelName.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Model Name");
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
                        errorMessages += string.Format(showInvalidDataMessage, "Model Name");
                        isValid = false;
                    }
                }

                // Owner name validation: not empty, not only spaces, only English letters, spaces or '-'
                if (ownerName == null || ownerName.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Owner Name");
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
                        errorMessages += string.Format(showInvalidDataMessage, "Owner Name");
                        isValid = false;
                    }
                }

                // Phone number validation: not empty, only digits, length 9-10
                if (ownerPhoneNumber == null || ownerPhoneNumber.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Owner Phone Number");
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
                        errorMessages += string.Format(showInvalidDataMessage, "Owner Phone Number");
                        isValid = false;
                    }
                }

                // Wheel manufacturer validation: not empty, not only spaces, contains at least one English letter
                if (wheelManufacturer == null || wheelManufacturer.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Wheel Manufacturer");
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
                        errorMessages += string.Format(showInvalidDataMessage, "Wheel Manufacturer");
                        isValid = false;
                    }
                }

                // Energy percentage validation
                if (i_DataToValidate.EnergyPercentage < 0 ||
                    i_DataToValidate.EnergyPercentage > 100)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Energy Percentage");
                    isValid = false;
                }

                // Air pressure validation
                if (i_DataToValidate.CurrentAirPressure < 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Current Air Pressure");
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
                        errorMessages += string.Format(showInvalidDataMessage, "Vehicle Type");
                        isValid = false;
                    }
                }
                catch
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Vehicle Type");
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
    }
}

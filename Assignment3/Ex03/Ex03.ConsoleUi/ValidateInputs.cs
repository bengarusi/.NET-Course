using Ex03.GarageLogic;

using System;

namespace Ex03.ConsoleUI
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

                // License number validation: not empty, only digits
                if (licenseNumber == null || licenseNumber.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "License Number");
                    isValid = false;
                }
                else
                {
                    bool onlyDigits = true;

                    foreach (char c in licenseNumber)
                    {
                        if (!char.IsDigit(c))
                        {
                            onlyDigits = false;
                            break;
                        }
                    }

                    if (!onlyDigits)
                    {
                        errorMessages += string.Format(showInvalidDataMessage, "License Number");
                        isValid = false;
                    }
                }

                // Model name validation: not empty, at least one letter or digit
                if (modelName == null || modelName.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Model Name");
                    isValid = false;
                }
                else
                {
                    bool hasLetterOrDigit = false;
                    bool hasNonSpace = false;

                    foreach (char c in modelName)
                    {
                        if (c != ' ')
                        {
                            hasNonSpace = true;
                        }

                        if (char.IsLetter(c) || char.IsDigit(c))
                        {
                            hasLetterOrDigit = true;
                        }
                    }

                    if (!hasNonSpace || !hasLetterOrDigit)
                    {
                        errorMessages += string.Format(showInvalidDataMessage, "Model Name");
                        isValid = false;
                    }
                }

                // Owner name validation: not empty, only letters, spaces or dashes
                if (ownerName == null || ownerName.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Owner Name");
                    isValid = false;
                }
                else
                {
                    bool hasOnlyLettersSpacesOrDash = true;
                    bool hasNonSpace = false;

                    foreach (char c in ownerName)
                    {
                        if (c != ' ')
                        {
                            hasNonSpace = true;
                        }

                        if (!char.IsLetter(c) && c != ' ' && c != '-')
                        {
                            hasOnlyLettersSpacesOrDash = false;
                            break;
                        }
                    }

                    if (!hasNonSpace || !hasOnlyLettersSpacesOrDash)
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
                    bool onlyDigits = true;

                    foreach (char c in ownerPhoneNumber)
                    {
                        if (!char.IsDigit(c))
                        {
                            onlyDigits = false;
                            break;
                        }
                    }

                    if (!onlyDigits || ownerPhoneNumber.Length < 9 || ownerPhoneNumber.Length > 10)
                    {
                        errorMessages += string.Format(showInvalidDataMessage, "Owner Phone Number");
                        isValid = false;
                    }
                }

                // Wheel manufacturer validation: not empty, at least one letter
                if (wheelManufacturer == null || wheelManufacturer.Length == 0)
                {
                    errorMessages += string.Format(showInvalidDataMessage, "Wheel Manufacturer");
                    isValid = false;
                }
                else
                {
                    bool hasLetter = false;
                    bool hasNonSpace = false;

                    foreach (char c in wheelManufacturer)
                    {
                        if (c != ' ')
                        {
                            hasNonSpace = true;
                        }

                        if (char.IsLetter(c))
                        {
                            hasLetter = true;
                        }
                    }

                    if (!hasNonSpace || !hasLetter)
                    {
                        errorMessages += string.Format(showInvalidDataMessage, "Wheel Manufacturer");
                        isValid = false;
                    }
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
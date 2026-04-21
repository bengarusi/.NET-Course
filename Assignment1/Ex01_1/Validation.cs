using System;

namespace Ex01_1
{
    public class Validation
    {
        public static bool InputValidation(string i_BinaryNumber)
        {
            bool isValid = true;

            if (i_BinaryNumber.Length != Program.k_BinaryNumberLength)
            {
                Console.WriteLine("Invalid input, try again");
                isValid = false;
            }
            else
            {
                foreach (char c in i_BinaryNumber)
                {
                    if (c != '0' && c != '1')
                    {
                        Console.WriteLine("Invalid input, try again");
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
using System;

namespace Ex01_5
{
    public class Validation
    {
        public static bool ValidateInput(string i_UserInput)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_UserInput) || i_UserInput.Length != 9)
            {
                isValid = false;
            }
            else
            {
                foreach (char c in i_UserInput)
                {
                    if (!char.IsDigit(c))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
using System;

namespace Ex01_4
{
    public class Validation
    {
        const int k_MaximumDesiredLength = 8;
        public static bool ValidateInput(string i_UserInput)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_UserInput) || i_UserInput.Length != k_MaximumDesiredLength)
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool IsUserInputNumeric(string i_UserInput)
        {
            bool isNumeric = true;

            foreach (char c in i_UserInput)
            {
                if (!char.IsDigit(c))
                {
                    isNumeric = false;
                    break;
                }
            }

            return isNumeric;
        }

        public static bool IsUserInputEnglishLetters(string i_UserInput)
        {
            bool isOnlyLetters = true;

            foreach (char c in i_UserInput)
            {
                if (!char.IsLetter(c))
                {
                    isOnlyLetters = false;
                    break;
                }
            }

            return isOnlyLetters;
        }

        public static bool IsPalindromeRecursive(string i_UserInput)
        {
            bool     isPalindromeResult = true;
            string   upperInput = i_UserInput.ToUpper();

            if (upperInput.Length <= 1)
            {
                isPalindromeResult = true;
            }
            else if (upperInput[0] != upperInput[upperInput.Length - 1])
            {
                isPalindromeResult = false;
            }
            else
            {
                isPalindromeResult = IsPalindromeRecursive(upperInput.Substring(1, upperInput.Length - 2));
            }

            return isPalindromeResult;
        }
    }
}
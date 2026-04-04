using System;
using System.Text;

namespace Ex01_4
{
    public class InputAnalyzer
    {
        public static void AnalyzeInput(string i_UserInput)
        {
            StringBuilder reportBuilder = new StringBuilder();
            bool isPalindrome = Validation.IsPalindromeRecursive(i_UserInput);

            if (isPalindrome)
            {
                reportBuilder.AppendLine(string.Format("Is Palindrome: Yes"));
            }
            else
            {
                reportBuilder.AppendLine(string.Format("Is Palindrome: No"));
            }

            if (Validation.IsUserInputNumeric(i_UserInput))
            {
                int numericValue;

                int.TryParse(i_UserInput, out numericValue);
                if (numericValue % 4 == 0)
                {
                    reportBuilder.Append("Is divisible by 4: Yes");
                }
                else
                {
                    reportBuilder.Append("Is divisible by 4: No");
                }
            }
            else if (Validation.IsUserInputEnglishLetters(i_UserInput))
            {
                int upperLetterCounter = 0;
                bool isDescending = true;

                for (int i = 0; i < i_UserInput.Length; i++)
                {
                    if (char.IsUpper(i_UserInput[i]))
                    {
                        upperLetterCounter++;
                    }

                    if (i < i_UserInput.Length - 1)
                    {
                        if (char.ToLower(i_UserInput[i]) < char.ToLower(i_UserInput[i + 1]))
                        {
                            isDescending = false;
                        }
                    }
                }

                reportBuilder.AppendLine(string.Format("Number of uppercase letters: {0}", upperLetterCounter));
                if (isDescending)
                {
                    reportBuilder.Append("Is descending: Yes");
                }
                else
                {
                    reportBuilder.Append("Is descending: No");
                }
            }

            Console.WriteLine(reportBuilder.ToString());
        }
    }
}
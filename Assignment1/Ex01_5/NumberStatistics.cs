using System;
using System.Text;

namespace Ex01_5
{
    public class NumberStatistics
    {
        public static void PrintStatistics(string i_UserInput)
        {
            StringBuilder reportBuilder = new StringBuilder();

            reportBuilder.AppendLine(getDigitsBiggerThanUnits(i_UserInput));
            reportBuilder.AppendLine(getDigitsDividedBy4(i_UserInput));
            reportBuilder.AppendLine(getMultiplyBiggestAndSmallest(i_UserInput));
            reportBuilder.AppendLine(getAmountOfUniqueDigits(i_UserInput));

            Console.WriteLine(reportBuilder.ToString());
        }

        private static string getDigitsBiggerThanUnits(string i_Number)
        {
            int count = 0;
            int unitsDigit = (int)char.GetNumericValue(i_Number[i_Number.Length - 1]);

            for (int i = 0; i < i_Number.Length - 1; i++)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);

                if (currentDigit > unitsDigit)
                {
                    count++;
                }
            }

            return string.Format("Amount of digits bigger than the units digit ({0}): {1}", unitsDigit, count);
        }

        private static string getDigitsDividedBy4(string i_Number)
        {
            int count = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);

                if (currentDigit % 4 == 0)
                {
                    count++;
                }
            }

            return string.Format("Amount of digits divisible by 4: {0}", count);
        }

        private static string getMultiplyBiggestAndSmallest(string i_Number)
        {
            int maxDigit = 0;
            int minDigit = 9;

            for (int i = 0; i < i_Number.Length; i++)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);
                maxDigit = Math.Max(maxDigit, currentDigit);
                minDigit = Math.Min(minDigit, currentDigit);
            }

            return string.Format("Multiplication of biggest ({0}) and smallest ({1}) digits: {2}", maxDigit, minDigit, maxDigit * minDigit);
        }

        private static string getAmountOfUniqueDigits(string i_Number)
        {
            int uniqueCount = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                bool isFirstOccurrence = true;

                for (int j = 0; j < i; j++)
                {
                    if (i_Number[i] == i_Number[j])
                    {
                        isFirstOccurrence = false;
                        break;
                    }
                }

                if (isFirstOccurrence)
                {
                    uniqueCount++;
                }
            }

            return string.Format("Amount of unique digits: {0}", uniqueCount);
        }
    }
}
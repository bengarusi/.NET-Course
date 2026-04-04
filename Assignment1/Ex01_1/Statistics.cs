using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_1
{
    internal class Statistics
    {

        public static void PrintStatistics(string[] i_BinaryNumbers, int[] i_DecimalValues)
        {
           printNumbersByDescending(i_DecimalValues, i_BinaryNumbers);
            average(i_DecimalValues);
            longestBitRun(i_BinaryNumbers);
            numberOfOnesBits(i_BinaryNumbers);
            getMostTransitions(i_BinaryNumbers, i_DecimalValues);
            numbersDevidedBy4(i_DecimalValues, i_BinaryNumbers);
           
        }

        private static void printNumbersByDescending(int[] numbers, string[] binaryNumbers)
        {
            List<(int DecimalValue, string BinaryValue)> numbersWithBinary = new List<(int DecimalValue, string BinaryValue)>();
            for (int i = 0; i < Globals.NumberOfBinaryNumbers; i++)
            {
                numbersWithBinary.Add((numbers[i], binaryNumbers[i]));
            }
            var sortedNumbers = numbersWithBinary.OrderByDescending(x => x.DecimalValue);

            List<string> formattedNumbers = new List<string>();

            foreach (var number in sortedNumbers)
            {
                formattedNumbers.Add(string.Format("{0} ({1})", number.DecimalValue, number.BinaryValue));
            }

            Console.WriteLine(
                string.Format("Decimal numbers in descending order: {0}",
                string.Join(", ", formattedNumbers))
            );
        }
        private static void average(int[] numbers)
        {
            float sum = 0;
            for (int i = 0; i < Globals.NumberOfBinaryNumbers; i++)
            {
                sum += numbers[i];
            }
            string msg = String.Format("Average: {0:f}", sum / Globals.NumberOfBinaryNumbers);
           Console.WriteLine( msg );
        }


        private static void longestBitRun(string[] numbers)
        {
            List<string> numbersWithLongestBitRun = new List<string>();
            int longestBitSequence = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int zeroSequence = 0;
                int oneSequence = 0;
                int longestInCurrentNumber = 1;

                for (int j = 0; j < Globals.BinaryNumberLength; j++)
                {
                    if (numbers[i][j] == '0')
                    {
                        zeroSequence++;
                        oneSequence = 0;

                        if (zeroSequence > longestInCurrentNumber)
                        {
                            longestInCurrentNumber = zeroSequence;
                        }
                    }
                    else if (numbers[i][j] == '1')
                    {
                        oneSequence++;
                        zeroSequence = 0;

                        if (oneSequence > longestInCurrentNumber)
                        {
                            longestInCurrentNumber = oneSequence;
                        }
                    }
                }

                if (longestInCurrentNumber > longestBitSequence)
                {
                    longestBitSequence = longestInCurrentNumber;
                    numbersWithLongestBitRun.Clear();
                    numbersWithLongestBitRun.Add(numbers[i]);
                }
                else if (longestInCurrentNumber == longestBitSequence)
                {
                    numbersWithLongestBitRun.Add(numbers[i]);
                }
            }

            string msg = string.Format(
                "Longest bit sequence: {0} ({1})",
                longestBitSequence,
                string.Join(", ", numbersWithLongestBitRun));

            Console.WriteLine(msg);
        }



        private static void numberOfOnesBits(string[] numbers)
        {
            int numberOfOnes = 0;
            for (int i = 0; i < Globals.NumberOfBinaryNumbers; i++)
            {
                for (int j = 0; j < Globals.BinaryNumberLength; j++)
                {
                    if (numbers[i][j] == '1')
                    {
                        numberOfOnes++;
                    }
                }
            }
            Console.WriteLine($"Total 1-bits: {numberOfOnes}");
        }

        private static void getMostTransitions(string[] i_BinaryNumbers, int[] i_DecimalValues)
        {
            int maxTransitions = -1;
            string maxTransitionsBinary = "";
            int maxTransitionsDecimal = 0;

            for (int i = 0; i < Globals.NumberOfBinaryNumbers; i++)
            {
                int transitions = countTransitions(i_BinaryNumbers[i]);
                bool isNewMax = transitions >= maxTransitions;

                if (isNewMax)
                {
                    if (transitions == maxTransitions)
                    {
                        if (i_DecimalValues[i] < maxTransitionsDecimal)
                        {
                            maxTransitions = transitions;
                            maxTransitionsBinary = i_BinaryNumbers[i];
                            maxTransitionsDecimal = i_DecimalValues[i];
                        }
                    }
                    else
                    {
                        maxTransitions = transitions;
                        maxTransitionsBinary = i_BinaryNumbers[i];
                        maxTransitionsDecimal = i_DecimalValues[i];
                    }
                }
            }
            string msg = String.Format("Number with the most transitions: {0} ({1}) - {2} transitions", maxTransitionsDecimal,maxTransitionsBinary, maxTransitions);
            Console.WriteLine(msg);


        }

        private static int countTransitions(string i_Binary)
        {
            int transitions = 0;

            for (int i = 1; i < Globals.BinaryNumberLength; i++)
            {
                bool isBitChanged = i_Binary[i] != i_Binary[i - 1];

                if (isBitChanged)
                {
                    transitions++;
                }
            }

            return transitions;
        }
        private static void numbersDevidedBy4(int[] numbers, string[] binaryNumbers)
        {
            int numbersDevidedBy4 = 0;
            List<string> binaryNumbersDivededBy4 = new List<string>();
            for (int i = 0; i < Globals.NumberOfBinaryNumbers; i++)
            {
                if (numbers[i] % 4 == 0)
                {
                    numbersDevidedBy4++;
                    binaryNumbersDivededBy4.Add(binaryNumbers[i]);
                }
            }
            string msg = numbersDevidedBy4 == 0
                  ? string.Format("Number of decimal values divisible by 4: {0}", numbersDevidedBy4)
                  : string.Format("Number of decimal values divisible by 4: {0} ({1})",
                  numbersDevidedBy4,
                  string.Join(", ", binaryNumbersDivededBy4));

            Console.WriteLine(msg);
        }

    }
}
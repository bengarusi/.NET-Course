using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01_1
{
    internal class Statistics
    {
        public static void PrintStatistics(string[] i_BinaryNumbers, int[] i_DecimalValues)
        {
            printNumbersByDescending(i_DecimalValues, i_BinaryNumbers);
            printAverage(i_DecimalValues);
            printLongestBitRun(i_BinaryNumbers);
            printNumberOfOnesBits(i_BinaryNumbers);
            printMostTransitions(i_BinaryNumbers, i_DecimalValues);
            printNumbersDividedBy4(i_DecimalValues, i_BinaryNumbers);
        }

        private static void printNumbersByDescending(int[] i_Numbers, string[] i_BinaryNumbers)
        {
            List<(int DecimalValue, string BinaryValue)> numbersWithBinary = new List<(int DecimalValue, string BinaryValue)>();

            for (int i = 0; i < Program.k_AmountOfNumbers; i++)
            {
                numbersWithBinary.Add((i_Numbers[i], i_BinaryNumbers[i]));
            }

            var sortedNumbers = numbersWithBinary.OrderByDescending(x => x.DecimalValue);
            List<string> formattedNumbers = new List<string>();

            foreach (var number in sortedNumbers)
            {
                formattedNumbers.Add(string.Format("{0} ({1})", number.DecimalValue, number.BinaryValue));
            }

            string finalOutput = string.Format("Decimal numbers in descending order: {0}", string.Join(", ", formattedNumbers));

            Console.WriteLine(finalOutput);
        }

        private static void printAverage(int[] i_Numbers)
        {
            float sum = 0;

            for (int i = 0; i < Program.k_AmountOfNumbers; i++)
            {
                sum += i_Numbers[i];
            }

            string msg = string.Format("Average: {0:f2}", sum / Program.k_AmountOfNumbers);

            Console.WriteLine(msg);
        }

        private static void printLongestBitRun(string[] i_Numbers)
        {
            List<string>   numbersWithLongestBitRun = new List<string>();
            int            longestBitSequence = 1;

            for (int i = 0; i < i_Numbers.Length; i++)
            {
                int zeroSequence = 0;
                int oneSequence = 0;
                int longestInCurrentNumber = 1;

                for (int j = 0; j < Program.k_BinaryNumberLength; j++)
                {
                    if (i_Numbers[i][j] == '0')
                    {
                        zeroSequence++;
                        oneSequence = 0;
                        if (zeroSequence > longestInCurrentNumber)
                        {
                            longestInCurrentNumber = zeroSequence;
                        }
                    }
                    else
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
                    numbersWithLongestBitRun.Add(i_Numbers[i]);
                }
                else if (longestInCurrentNumber == longestBitSequence)
                {
                    numbersWithLongestBitRun.Add(i_Numbers[i]);
                }
            }

            string msg = string.Format("Longest bit sequence: {0} ({1})", longestBitSequence, string.Join(", ", numbersWithLongestBitRun));

            Console.WriteLine(msg);
        }

        private static void printNumberOfOnesBits(string[] i_Numbers)
        {
            int numberOfOnes = 0;

            for (int i = 0; i < Program.k_AmountOfNumbers; i++)
            {
                for (int j = 0; j < Program.k_BinaryNumberLength; j++)
                {
                    if (i_Numbers[i][j] == '1')
                    {
                        numberOfOnes++;
                    }
                }
            }

            Console.WriteLine(string.Format("Total 1-bits: {0}", numberOfOnes));
        }

        private static void printMostTransitions(string[] i_BinaryNumbers, int[] i_DecimalValues)
        {
            int      maxTransitions = -1;
            string   maxTransitionsBinary = string.Empty;
            int      maxTransitionsDecimal = 0;

            for (int i = 0; i < Program.k_AmountOfNumbers; i++)
            {
                int currentTransitions = countTransitions(i_BinaryNumbers[i]);

                if (currentTransitions > maxTransitions)
                {
                    maxTransitions = currentTransitions;
                    maxTransitionsBinary = i_BinaryNumbers[i];
                    maxTransitionsDecimal = i_DecimalValues[i];
                }
                else if (currentTransitions == maxTransitions)
                {
                    if (i_DecimalValues[i] < maxTransitionsDecimal)
                    {
                        maxTransitionsBinary = i_BinaryNumbers[i];
                        maxTransitionsDecimal = i_DecimalValues[i];
                    }
                }
            }

            string msg = string.Format("Number with most transitions: {0} ({1}) - {2} transitions", maxTransitionsDecimal, maxTransitionsBinary, maxTransitions);

            Console.WriteLine(msg);
        }

        private static int countTransitions(string i_Binary)
        {
            int transitionsCount = 0;

            for (int i = 1; i < Program.k_BinaryNumberLength; i++)
            {
                if (i_Binary[i] != i_Binary[i - 1])
                {
                    transitionsCount++;
                }
            }

            return transitionsCount;
        }

        private static void printNumbersDividedBy4(int[] i_Numbers, string[] i_BinaryNumbers)
        {
            int             countDividedBy4 = 0;
            List<string>    binaryMatches = new List<string>();

            for (int i = 0; i < Program.k_AmountOfNumbers; i++)
            {
                if (i_Numbers[i] % 4 == 0)
                {
                    countDividedBy4++;
                    binaryMatches.Add(i_BinaryNumbers[i]);
                }
            }

            string msg = string.Format("Numbers divisible by 4: {0}", countDividedBy4);

            if (countDividedBy4 > 0)
            {
                msg = string.Format("Numbers divisible by 4: {0} ({1})", countDividedBy4, string.Join(", ", binaryMatches));
            }

            Console.WriteLine(msg);
        }
    }
}
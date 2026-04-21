using System;

namespace Ex01_2
{
    public class LetterTreeUtils
    {
        private const int k_AlphabetSize = 26;
        private const int k_LastRowsCount = 2;
        private const int k_TrunkWidth = 3;

        public static void PrintLetterTree(int i_MaxHeight)
        {
            int currentLetterIndex = 0; // A->0, B->1, ..., Z->25, then wrap around to A again

            for (int i = 1; i <= i_MaxHeight; i++)
            {
                printTreeRow(i, i_MaxHeight, ref currentLetterIndex);
            }
        }

        private static void printTreeRow(int i_RowNumber, int i_MaxHeight, ref int io_LetterIndex)
        {
            bool      isLastTwoRows = i_RowNumber >= i_MaxHeight - 1;
            int       leadingSpaces = getLeadingSpacesCount(i_RowNumber, i_MaxHeight);

            printSpaces(leadingSpaces);

            if (isLastTwoRows)
            {
                char       currentLetter = (char)('A' + (io_LetterIndex % k_AlphabetSize));
                Console.Write("|" + currentLetter + '|');
            }
            else
            {
                int letterInRow = getLettersCountInRow(i_RowNumber);
                printLettersInRow(letterInRow, ref io_LetterIndex);
            }

            Console.WriteLine();
        }

        private static void printLettersInRow(int i_Count, ref int io_LetterIndex)
        {
            for (int i = 0; i < i_Count; i++)
            {
                char currentLetter = (char)('A' + (io_LetterIndex % k_AlphabetSize));

                if (i > 0)
                {
                    Console.Write(' ');
                }

                Console.Write(currentLetter);
                io_LetterIndex++;
            }
        }

        private static int getLettersCountInRow(int i_RowNumber)
        {
            return 2 * i_RowNumber - 1;
        }

        private static void printSpaces(int i_LeadingSpaces)
        {
            for (int i = 0; i < i_LeadingSpaces; i++)
            {
                Console.Write(' ');
            }
        }

        private static int getLeadingSpacesCount(int i_RowNumber, int i_MaxHeight)
        {
            int    normalRows = i_MaxHeight - k_LastRowsCount;
            int    maxLettersInRow = 2 * normalRows - 1;
            int    maxWidthIncludingSpaces = maxLettersInRow + (maxLettersInRow - 1);
            bool   isLastTwoRows = i_RowNumber >= i_MaxHeight - 1;
            int    currentRowWidth;

            if (isLastTwoRows)
            {
                currentRowWidth = k_TrunkWidth;
            }
            else
            {
                int letters = getLettersCountInRow(i_RowNumber);
                currentRowWidth = letters + (letters - 1); 
            }

            int leadingSpaces = (maxWidthIncludingSpaces - currentRowWidth) / 2;

            return leadingSpaces;
        }
    }
}
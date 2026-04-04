using System;

namespace Ex01_2
{
    public class LetterTreeUtils
    {
        private const int k_AlphabetSize = 26;
        private const int k_LastRowsCount = 2;

        public static void PrintLetterTree(int i_MaxHeight)
        {
            int currentLetterIndex = 0; // represents the index of the next letter to print, starting from 'A'
            for (int i = 1; i <= i_MaxHeight; i++)
            {
                printTreeRow(i, i_MaxHeight, ref currentLetterIndex);
            }
        }

        private static void printTreeRow(int i_RowNumber, int i_MaxHeight, ref int io_LetterIndex)
        {
            bool      isLastTwoRows = i_RowNumber >= i_MaxHeight - 1;
            int       letterInRow = getLettersCountInRow(i_RowNumber, i_MaxHeight);
            int       leadingSpaces = getLeadingSpacesCount(i_RowNumber, i_MaxHeight);

            printSpaces(leadingSpaces);

            if (isLastTwoRows)
            {
                int        usedLetters = getTotalLettersUntilRowNubmer(i_MaxHeight - 2);
                char       currentLetter = (char)('A' + (usedLetters % k_AlphabetSize));

                Console.Write("|" + currentLetter + '|');
                io_LetterIndex += letterInRow;
            }
            else
            {
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

        private static int getLettersCountInRow(int i_RowNumber, int i_MaxHeight)
        {
            bool     isLastTwoRows = i_RowNumber >= i_MaxHeight - 1;
            int      lettersCount;

            if (isLastTwoRows)
            {
                lettersCount = getRemainingLettersCount(i_MaxHeight);
            }
            else
            {
                lettersCount = 2 * i_RowNumber - 1;
            }

            return lettersCount;
        }

        private static int getRemainingLettersCount(int i_MaxHeight)
        {
            int  usedLetters = getTotalLettersUntilRowNubmer(i_MaxHeight - 2);
            int  remainingLetters = k_AlphabetSize - (usedLetters % k_AlphabetSize);

            if (remainingLetters == k_AlphabetSize)
            {
                remainingLetters = 0;
            }

            return remainingLetters;
        }

        private static int getTotalLettersUntilRowNubmer(int i_RowCount)
        {
            /// Sun of(2*1 -1) for i=1 to rowCount=rowCount^2
            return i_RowCount * i_RowCount;
        }

        private static void printSpaces(int leadingSpaces)
        {
            for (int i = 0; i < leadingSpaces; i++)
            {
                Console.Write(' ');
            }
        }

        private static int getLeadingSpacesCount(int i_RowNumber, int i_MaxHeight)
        {
            int    normalRows = i_MaxHeight - k_LastRowsCount;
            int    maxLettersInRow = 2 * normalRows - 1;
            int    maxWidth = maxLettersInRow + (maxLettersInRow - 1);
            bool   isLastTwoRows = i_RowNumber >= i_MaxHeight - 1;
            int    currentWidth;

            if (isLastTwoRows)
            {
                currentWidth = 3;
            }
            else
            {
                int letters = getLettersCountInRow(i_RowNumber, i_MaxHeight);
                currentWidth = letters + (letters - 1); // 1 space between letters
            }

            int    leadingSpaces = (maxWidth - currentWidth) / 2;

            return leadingSpaces;
        }
    }
}

using System;

namespace Ex01_2
{
    public class LetterTreeUtils
    {
        private const int k_AlphabetSize = 26;
        private const int k_LastRowsCount = 2;
        private const int k_SpecialRowWidth = 3;
        public static void printLetterTree(int i_Height)
        {
            int currentLetterIndex = 0;
            for (int i = 1; i <= i_Height; i++)
            {
                printTreeRow(i,i_Height,ref currentLetterIndex);
            }

        }

        private static void printTreeRow(int i_RowNumber, int i_TotalHeight, ref int io_LetterIndex)
        {
            int letterInRow = getLettersCountInRow(i_RowNumber, i_TotalHeight);
            bool isLastTwoRows = i_RowNumber >= i_TotalHeight - 1;

            int leadingSpaces = getLeadingSpacesCount(i_RowNumber,i_TotalHeight);

            printSpaces(leadingSpaces);

            if (isLastTwoRows)
            {
                int usedLetters = getTotalLettersUpToRow(i_TotalHeight - 2);
                char currentLetter = (char)('A' + (usedLetters % k_AlphabetSize));
                int letterCount = letterInRow;

                Console.Write("|" + currentLetter + '|');
                io_LetterIndex += letterInRow;
            }
            else
            {
                printLettersInRow(letterInRow, ref io_LetterIndex);
            }
            Console.WriteLine();
        }


        private static void printLettersInRow(int i_Count,ref int io_LetterIndex)
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

        private static int getLettersCountInRow(int i_RowNumber, int i_TotalHeight)
        {
            bool isLastTwoRows = i_RowNumber >= i_TotalHeight - 1;
            int lettersCount;

            if (isLastTwoRows)
            {
                lettersCount = getTotalLettersUpToRow(i_TotalHeight - 2);
                int usedLetters = getTotalLettersUpToRow(i_RowNumber - 2);
                lettersCount = (int)Math.Ceiling((26.0 - (usedLetters % 26)) + (usedLetters % 26));
                lettersCount = getRaminingLettersCount(i_TotalHeight);

            }
            else
            {
                lettersCount =2* i_RowNumber - 1;
            }

            return lettersCount;
        }

        private static int getRaminingLettersCount(int i_TotalHeight)
        {
            const int k_AlphabetSize = 26;
            int usedLetters = getTotalLettersUpToRow(i_TotalHeight - 2);
            int remainingLetters = k_AlphabetSize - (usedLetters % k_AlphabetSize);

            if (remainingLetters == k_AlphabetSize)
            {
                remainingLetters = 0;
            }

            return remainingLetters;
        }

        private static int getTotalLettersUpToRow(int i_RowCount)
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

        private static int getLeadingSpacesCount(int i_RowNumber, int i_TotalHeight)
        {
            int normalRows=i_TotalHeight - k_LastRowsCount;
            int maxLettersInRow = 2 * normalRows - 1;
            int maxWidth = maxLettersInRow + (maxLettersInRow - 1);
            int currentWidth;
            bool isLastTwoRows = i_RowNumber >= i_TotalHeight - 1;

            if (isLastTwoRows)
            {
                currentWidth = 3;
            }
            else
            {
                int letters = getLettersCountInRow(i_RowNumber, i_TotalHeight);

                currentWidth = letters + (letters - 1); // 1 space between letters
            }
            int leadingSpaces = (maxWidth - currentWidth) / 2;
            return leadingSpaces;
        }

    }
}

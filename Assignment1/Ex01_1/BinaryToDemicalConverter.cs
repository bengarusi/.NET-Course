using System;

namespace Ex01_1
{
    public class BinaryToDecimalConverter
    {
        public static int ConvertBinaryToDecimal(string i_BinaryNumber)
        {
            int decimalNumber = 0;

            for (int i = 0; i < Program.k_BinaryNumberLength; i++)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, Program.k_BinaryNumberLength - 1 - i);
                }
            }

            return decimalNumber;
        }
    }
}
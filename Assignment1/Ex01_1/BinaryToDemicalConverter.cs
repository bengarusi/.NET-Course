using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex01_1
{
    public class BinaryToDemicalConverter
    {
        

        public static int ConvertBinaryToDecimal(string i_BinaryNumber)
        {
            int decimalNumber = 0;
            for (int i = 0; i < Globals.BinaryNumberLength; i++)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, Globals.BinaryNumberLength - 1 - i);
                }
            }
            return decimalNumber;
        }
    }
}

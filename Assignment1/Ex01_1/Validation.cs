using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_1
{
    public class Validation
    {
        public static bool InputValidateion(string i_BinaryNumber)
        {
            if (i_BinaryNumber.Length != Globals.BinaryNumberLength)
            {
                Console.WriteLine("Invalid input, try again");
                return false;
            }
            else
            {
                foreach (char c in i_BinaryNumber)
                {
                    if (c != '0' && c != '1')
                    {
                        Console.WriteLine("Invalid input, try again");
                        return false;
                    }
                }

            }
            return true;
        }
    }
}

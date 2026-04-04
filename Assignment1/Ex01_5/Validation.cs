using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_5
{
    public class Validation
    {
        public static bool ValidateInput(string i_UserInput)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(i_UserInput) || i_UserInput.Length != 9)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}

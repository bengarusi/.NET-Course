using System;


namespace Ex01_1
{
   public class Program
    {
        public static void Main(string[] args)
        {   string[] binaryNumbers = new String[Globals.NumberOfBinaryNumbers];
            int[] numbers = new int[Globals.NumberOfBinaryNumbers];
            for (int inputNumbers = 0; inputNumbers < Globals.NumberOfBinaryNumbers; inputNumbers++)
            {
               Console.WriteLine("Enter a 7 digit binary number");
               string binaryNumber = Console.ReadLine();
               if(!Validation.InputValidateion(binaryNumber))
                {
                    inputNumbers--;
                }
               else
                {
                    binaryNumbers[inputNumbers] = binaryNumber;
                }
            }
            for(int i=0; i < Globals.NumberOfBinaryNumbers; i++)
            {
                numbers[i] = BinaryToDemicalConverter.ConvertBinaryToDecimal(binaryNumbers[i]);
            }
           Statistics.PrintStatistics(binaryNumbers,numbers);

        }
    }
}
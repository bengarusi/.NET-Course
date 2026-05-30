/*
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class ConsoleInputReader
    {
        public string ReadNonEmptyString(string i_Message)
        {
            string input;

            do
            {
                Console.Write(i_Message);
                input = Console.ReadLine();

                if (input != null)
                {
                    input = input.Trim();
                }

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                }
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }

        public int ReadInt(string i_Message)
        {
            int result;
            string input;

            input = ReadNonEmptyString(i_Message);

            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Invalid integer number.");
                input = ReadNonEmptyString(i_Message);
            }

            return result;
        }

        public int ReadIntInRange(string i_Message, int i_MinValue, int i_MaxValue)
        {
            int result = ReadInt(i_Message);

            while (result < i_MinValue || result > i_MaxValue)
            {
                Console.WriteLine(
                    string.Format(
                        "Please enter a number between {0} and {1}.",
                        i_MinValue,
                        i_MaxValue));

                result = ReadInt(i_Message);
            }

            return result;
        }

        public float ReadFloat(string i_Message)
        {
            float result;
            string input;

            input = ReadNonEmptyString(i_Message);

            while (!float.TryParse(input, out result))
            {
                Console.WriteLine("Invalid number.");
                input = ReadNonEmptyString(i_Message);
            }

            return result;
        }

        public bool ReadBool(string i_Message)
        {
            bool result;
            string input;

            input = ReadNonEmptyString(i_Message + " (true/false): ");

            while (!bool.TryParse(input, out result))
            {
                Console.WriteLine("Invalid value. Please enter true or false.");
                input = ReadNonEmptyString(i_Message + " (true/false): ");
            }

            return result;
        }

        public bool ReadYesNo(string i_Message)
        {
            string input;
            bool answer = false;
            bool isValidInput = false;

            while (!isValidInput)
            {
                input = ReadNonEmptyString(i_Message + " (y/n): ");

                if (input == "y" || input == "Y")
                {
                    answer = true;
                    isValidInput = true;
                }
                else if (input == "n" || input == "N")
                {
                    answer = false;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter y or n.");
                }
            }

            return answer;
        }

        public string ReadStringFromOptions(string i_Message, List<string> i_Options)
        {
            int choice;

            Console.WriteLine(i_Message);

            for (int i = 0; i < i_Options.Count; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}", i + 1, i_Options[i]));
            }

            choice = ReadIntInRange("Choose option: ", 1, i_Options.Count);

            return i_Options[choice - 1];
        }

        public string ReadEnumValue(string i_Message, Type i_EnumType)
        {
            string input;
            bool isValidInput = false;

            Console.WriteLine(i_Message);
            Console.WriteLine("Possible values:");

            foreach (string enumName in Enum.GetNames(i_EnumType))
            {
                Console.WriteLine(enumName);
            }

            input = ReadNonEmptyString("Enter value: ");

            while (!isValidInput)
            {
                if (Enum.IsDefined(i_EnumType, input))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid value.");
                    input = ReadNonEmptyString("Enter value: ");
                }
            }

            return input;
        }
    }
}
*/
namespace Ex04.Menus.Interfaces
{
    internal class ConsoleMenuRenderer
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void PrintTitle(string i_Title)
        {
            string titleToPrint = string.Format("** {0} **", i_Title);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(titleToPrint);
            Console.ResetColor();

            printSeparator(titleToPrint.Length);
        }

        public static void PrintMenuItems(List<MenuItem> i_MenuItems)
        {
            int index = 1;

            foreach (MenuItem item in i_MenuItems)
            {
                Console.WriteLine("{0}. {1}", index, item.Title);
                index++;
            }
        }

        public static void PrintZeroOption(string i_Text)
        {
            Console.WriteLine("0. {0}", i_Text);
        }

        public static void PrintChoiceRequest(int i_MinValue, int i_MaxValue, bool i_IsMainMenu)
        {
            string zeroOptionText = i_IsMainMenu ? "or 0 to exit" : "or 0 to go back";

            Console.WriteLine("Please enter your choice ({0}-{1} {2}): ", i_MinValue, i_MaxValue, zeroOptionText);
            Console.Write(">> ");
        }

        public static void PrintInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }

        private static void printSeparator(int i_Length)
        {
            for (int i = 0; i < i_Length; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}

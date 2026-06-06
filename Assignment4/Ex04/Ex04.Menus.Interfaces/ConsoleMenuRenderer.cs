using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ConsoleMenuRenderer
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }   
        
        public static void PrintTitle(string i_Title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("** {0} **", i_Title);
            Console.ResetColor();
            Console.WriteLine("------------------------");
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

        public static void PrintChoiceRequest(int i_MinValue , int i_MaxValue , string i_Text)
        {
            Console.Write("Please enter your choice ({0}-{1} ,{2}): ", i_MinValue , i_MaxValue, i_Text);
        }

        public static void PrintInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
}

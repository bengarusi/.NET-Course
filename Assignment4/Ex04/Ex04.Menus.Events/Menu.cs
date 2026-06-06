using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Events
{
    internal class Menu
    {
        private readonly string r_Title;
        private readonly List<MenuItem> r_MenuItems;
        private readonly bool r_IsMainMenu;

        public Menu(string i_Title, bool i_IsMainMenu)
        {
            r_Title = i_Title;
            r_MenuItems = new List<MenuItem>();
            r_IsMainMenu = i_IsMainMenu;
        }

        internal void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }

        internal void Show()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                printMenu();
                int userChoice = getValidChoiceFromUser();
                if (isExitOrBackChoosen(userChoice))
                {
                    shouldExit = true;
                }
                else
                {
                    Console.WriteLine("\n");
                    executeChoice(userChoice);
                }
            }
        }

        private void printMenu()
        {
            ConsoleMenuRenderer.PrintTitle(r_Title);
            ConsoleMenuRenderer.PrintMenuItems(r_MenuItems);
            if (r_IsMainMenu)
            {
                ConsoleMenuRenderer.PrintZeroOption("Exit");
            }
            else
            {
                ConsoleMenuRenderer.PrintZeroOption("Back");
            }
        }

        private int getValidChoiceFromUser()
        {
            int userChoice = 0;
            bool isValidChoice = false;
            while (!isValidChoice)
            {
                ConsoleMenuRenderer.PrintChoiceRequest(1, r_MenuItems.Count, r_IsMainMenu);
                string input = Console.ReadLine();
                if (int.TryParse(input, out userChoice) && userChoice >= 0 && userChoice <= r_MenuItems.Count)
                {
                    isValidChoice = true;
                }
                else
                {
                    ConsoleMenuRenderer.PrintInvalidChoiceMessage();
                }
            }
            return userChoice;

        }

        private void executeChoice(int i_Choice)
        {
            MenuItem selectedItem = r_MenuItems[i_Choice - 1];
            selectedItem.Execute();

        }

        private bool isExitOrBackChoosen(int i_Choice)
        {
            return i_Choice == 0;
        }

      
    }
}

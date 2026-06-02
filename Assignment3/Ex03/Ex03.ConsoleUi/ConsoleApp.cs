using Ex03.GarageLogic;
using System;
  
namespace Ex03.ConsoleUI
{
    public class ConsoleApp
    {
        private readonly GarageManager r_GarageManager;
        private readonly GarageActionsHandler r_GarageActionsHandler;
       
        public ConsoleApp()
        {
            r_GarageManager = new GarageManager();
            r_GarageActionsHandler = new GarageActionsHandler(r_GarageManager);
        }

        public void Run()
        { 
            Console.WriteLine("Welcome to the Garage Management System!");
            bool exit = false;

            while (!exit)
            {
                PrintMenu.PrintMainMenu();

                string userInput = Console.ReadLine();
                int userChoice;

                if (!int.TryParse(userInput, out userChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (userChoice < 1 || userChoice > 9)
                {
                    Console.WriteLine("Invalid menu option. Please choose a number between 1 and 9.");
                    continue;
                }

                eMenuOption selectedOption = (eMenuOption)userChoice;

                r_GarageActionsHandler.HandleAction(selectedOption);

                if (selectedOption == eMenuOption.Exit)
                {
                    exit = true;
                }
            }
        }
    }
}
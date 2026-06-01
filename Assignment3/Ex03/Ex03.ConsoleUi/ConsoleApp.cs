using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;    



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
                eMenuOption eOptionType = (eMenuOption)Enum.Parse(typeof(eMenuOption), Console.ReadLine());
                r_GarageActionsHandler.HandleAction(eOptionType);
                exit = eOptionType == eMenuOption.Exit;
            }
        }
    }
}
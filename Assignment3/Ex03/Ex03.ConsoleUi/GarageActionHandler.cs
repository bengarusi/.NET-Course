/*
 Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ex03.ConsoleUI
{
    public class GarageActionsHandler
    {
        private const string k_DefaultVehiclesFileName = "VehiclesDB.txt";

        private readonly GarageManager r_GarageManager;
        private readonly ConsoleInputReader r_InputReader;
        private readonly ConsoleOutputWriter r_OutputWriter;





        public void HandleAction(eMenuOption i_MenuOption)
        {
            switch (i_MenuOption)
            {
                case eMenuOption.LoadFromFile:
                    loadVehiclesFromFile();
                    break;

                case eMenuOption.InsertVehicle:
                    insertNewVehicle();
                    break;

                case eMenuOption.DisplayFilteredLicenses:
                    displayLicensePlates();
                    break;

                case eMenuOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;

                case eMenuOption.InflateWheels:
                    inflateWheelsToMax();
                    break;

                case eMenuOption.Refuel:
                    refuelVehicle();
                    break;

                case eMenuOption.Charge:
                    chargeVehicle();
                    break;

                case eMenuOption.DisplayDetails:
                    displayVehicleDetails();
                    break;
            }
        }

        private void loadVehiclesFromFile()
        {
            string[] lines = File.ReadAllLines(k_DefaultVehiclesFileName);
            r_GarageManager.ImportVehiclesFromFile(lines);

            r_OutputWriter.PrintSuccess("Vehicles loaded from file.");
        }

    }
    }*/
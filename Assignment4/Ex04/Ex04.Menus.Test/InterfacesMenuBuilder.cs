using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfacesMenuBuilder
    {
        public static MainMenu BuildMainMenu()
        {
            MainMenu MainMenu = new MainMenu("Interfaces Main Menu");

            SubMenuItem DateTimeSubMenu = MainMenu.AddSubMenuItem("Show Current Date/Time");
            DateTimeSubMenu.AddActionItem("Show Current Date", new ShowCurrentDate());
            DateTimeSubMenu.AddActionItem("Show Current Time", new ShowCurrentTime());
            
            SubMenuItem VersionAndCapitals = MainMenu.AddSubMenuItem("Version and Capitals");
            VersionAndCapitals.AddActionItem("Count Capitals", new CountCapitals());
            VersionAndCapitals.AddActionItem("Show Version", new ShowVersion());
            return MainMenu;
        }
    }
}

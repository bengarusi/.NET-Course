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
            MainMenu MainMenu = new MainMenu("Main Menu");
            SubMenuItem DateTimeSubMenu = MainMenu.AddSubMenuItem("Show Date/Time");
            DateTimeSubMenu.AddActionItem("ShowCurrentDate", new ShowCurrentDate());
            DateTimeSubMenu.AddActionItem("ShowCurrentTime", new ShowCurrentTime());
            SubMenuItem VersionAndCapitals = MainMenu.AddSubMenuItem("Version and Capitals");
            VersionAndCapitals.AddActionItem("Count Capitals", new CountCapitals());
            VersionAndCapitals.AddActionItem("Show Version", new ShowVersion());
            return MainMenu;
        }
    }
}

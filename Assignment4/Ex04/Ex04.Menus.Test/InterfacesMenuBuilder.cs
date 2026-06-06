using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfacesMenuBuilder
    {
        public static MainMenu BuildMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Interfaces Main Menu");

            SubMenuItem dateTimeSubMenu = mainMenu.AddSubMenuItem("Show Current Date/Time");
            dateTimeSubMenu.AddActionItem("Show Current Date", new ShowCurrentDate());
            dateTimeSubMenu.AddActionItem("Show Current Time", new ShowCurrentTime());
            
            SubMenuItem versionAndCapitals = mainMenu.AddSubMenuItem("Version and Capitals");
            versionAndCapitals.AddActionItem("Count Capitals", new CountCapitals());
            versionAndCapitals.AddActionItem("Show Version", new ShowVersion());

            return mainMenu;
        }
    }
}

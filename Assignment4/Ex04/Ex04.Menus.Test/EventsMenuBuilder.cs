using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    public class EventsMenuBuilder
    {
        public static MainMenu BuildMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Events Main Menu");

            SubMenuItem dateTimeSubMenu = mainMenu.AddSubMenuItem("Show Current Date/Time");
            
            ActionMenuItem showDateAction = dateTimeSubMenu.AddActionItem("Show Current Date");
            showDateAction.MenuItemSelected += new ShowCurrentDate().Execute;
            ActionMenuItem showTimeAction = dateTimeSubMenu.AddActionItem("Show Current Time");
            showTimeAction.MenuItemSelected += new ShowCurrentTime().Execute;

            SubMenuItem versionAndCapitals = mainMenu.AddSubMenuItem("Version and Capitals");
            
            ActionMenuItem countCapitalsAction = versionAndCapitals.AddActionItem("Count Capitals");
            countCapitalsAction.MenuItemSelected += new CountCapitals().Execute;
            ActionMenuItem showVersionAction = versionAndCapitals.AddActionItem("Show Version");
            showVersionAction.MenuItemSelected += new ShowVersion().Execute;

            return mainMenu;
        }
    }
}
using System;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;


namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()   
        {
            Interfaces.MainMenu InterfacesMenu = InterfacesMenuBuilder.BuildMainMenu();
            InterfacesMenu.Show();

            Console.Clear();

            Events.MainMenu EventsMenu = EventsMenuBuilder.BuildMainMenu();
            EventsMenu.Show();
        }
    }
}
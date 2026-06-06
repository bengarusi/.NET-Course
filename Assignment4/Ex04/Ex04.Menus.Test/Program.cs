

using System;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MainMenu mainMenu = InterfacesMenuBuilder.BuildMainMenu();
            mainMenu.Show();
        }
    }
}
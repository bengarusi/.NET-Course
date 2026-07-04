namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()   
        {
            Interfaces.MainMenu interfacesMenu = InterfacesMenuBuilder.BuildMainMenu();
            interfacesMenu.Show();

            Console.Clear();

            Events.MainMenu eventsMenu = EventsMenuBuilder.BuildMainMenu();
            eventsMenu.Show();
        }
    }
}
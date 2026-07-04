using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IMenuAction
    {
        public void Execute()
        {
            Console.WriteLine("App Version: 26.2.4.7310");
            Console.WriteLine();
        }
    }
}
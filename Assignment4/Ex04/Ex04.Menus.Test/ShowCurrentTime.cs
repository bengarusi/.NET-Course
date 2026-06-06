using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowCurrentTime : IMenuAction
    {
        public void Execute()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine();
        }
    }
}
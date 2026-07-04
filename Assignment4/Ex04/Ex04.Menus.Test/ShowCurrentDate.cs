using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowCurrentDate : IMenuAction
    {
        public void Execute()
        {
            Console.WriteLine("Current Date is {0}", DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine();
        }
    }
}
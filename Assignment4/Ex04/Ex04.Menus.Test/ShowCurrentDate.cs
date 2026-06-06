using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowCurrentDate : IMenuItemObserver
    {
        public void Execute(MenuItem i_MenuItem)
        {
            Console.WriteLine($"Current date is {DateTime.Now.ToShortDateString()}");
            Console.WriteLine("\n");
        }
    }
}

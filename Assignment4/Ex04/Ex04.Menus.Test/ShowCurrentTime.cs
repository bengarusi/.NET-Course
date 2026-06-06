using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowCurrentTime : IMenuItemObserver
    {
        public void Execute(MenuItem i_MenuItem)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("\n");
        }
    }
}

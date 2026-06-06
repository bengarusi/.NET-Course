using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IMenuAction
    {
        public void Execute()
        {
            Console.WriteLine("> App Version: 26.2.4.7310");
            Console.WriteLine("\n");
        }
    }
}

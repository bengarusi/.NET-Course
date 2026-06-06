using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowCurrentDate : IMenuAction
    {
        public void Execute()
        {
            Console.WriteLine(DateTime.Now.ToString("'> Current Date is 'dd/MM/yyyy"));
           // Console.WriteLine($"Current Date is {DateTime.Now.ToShortDateString()}");
            Console.WriteLine("\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItem
    {
        private readonly IMenuItemObserver r_Observer;

        public ActionMenuItem(string i_Title, IMenuItemObserver i_Observer) : base(i_Title)
        {
            r_Observer = i_Observer;
        }

        public override void Execute()
        {
            ConsoleMenuRenderer.ClearScreen();
            r_Observer.Execute(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItem
    {
        private readonly IMenuAction r_MenuAction;

        public ActionMenuItem(string i_Title, IMenuAction i_MenuAction) : base(i_Title)
        {
            r_MenuAction = i_MenuAction;
        }

        public override void Execute()
        {
            ConsoleMenuRenderer.ClearScreen();
            r_MenuAction.Execute();
        }
    }
}

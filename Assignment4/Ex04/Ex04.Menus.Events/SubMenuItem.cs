using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Events
{
    public class SubMenuItem : MenuItem
    {
        private readonly Menu r_SubMenu;
        public SubMenuItem(string i_Title) : base(i_Title)
        {
            r_SubMenu = new Menu(i_Title, false);
        }

        public SubMenuItem AddSubMenuItem(string i_Title)
        {
            SubMenuItem subMenuItem = new SubMenuItem(i_Title);
            r_SubMenu.AddMenuItem(subMenuItem);
            return subMenuItem;
        }

        public void AddSubMenu(SubMenuItem subMenuItem)
        {
            r_SubMenu.AddMenuItem(subMenuItem);
        }

        public ActionMenuItem AddActionItem(string i_Title)
        {
            ActionMenuItem actionItem = new ActionMenuItem(i_Title);
            r_SubMenu.AddMenuItem(actionItem);
            return actionItem;
        }

        public override void Execute()
        {
            ConsoleMenuRenderer.ClearScreen();
            r_SubMenu.Show();
            ConsoleMenuRenderer.ClearScreen();
        }
        
    }
}

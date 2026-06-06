using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly Menu r_MainMenu;

        public MainMenu(string i_Title)
        {
            r_MainMenu = new Menu(i_Title, true);
        }


        public SubMenuItem AddSubMenuItem (string i_Title)
        {
            SubMenuItem subMenuItem = new SubMenuItem(i_Title);
            r_MainMenu.AddMenuItem(subMenuItem);
            return subMenuItem;
        }

        public void AddSubMenu (SubMenuItem subMenuItem)
        {
            r_MainMenu.AddMenuItem(subMenuItem);
        }

        public ActionMenuItem AddActionItem(string i_Title)
        {
            ActionMenuItem actionItem = new ActionMenuItem(i_Title);
            r_MainMenu.AddMenuItem(actionItem);
            return actionItem;
        }

        public void Show()
        {
            ConsoleMenuRenderer.ClearScreen();
            r_MainMenu.Show();
        }
    }
}

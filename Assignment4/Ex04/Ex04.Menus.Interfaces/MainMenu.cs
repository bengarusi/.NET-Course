namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly Menu r_MainMenu;

        public MainMenu(string i_Title)
        {
            const bool v_IsMainMenu = true;
            r_MainMenu = new Menu(i_Title, v_IsMainMenu);
        }

        public SubMenuItem AddSubMenuItem(string i_Title)
        {
            SubMenuItem subMenuItem = new SubMenuItem(i_Title);
            r_MainMenu.AddMenuItem(subMenuItem);

            return subMenuItem;
        }

        public void AddActionItem(string i_Title, IMenuAction i_Observer)
        {
            ActionMenuItem actionItem = new ActionMenuItem(i_Title, i_Observer);

            r_MainMenu.AddMenuItem(actionItem);
        }

        public void Show()
        {
            ConsoleMenuRenderer.ClearScreen();
            r_MainMenu.Show();
        }
    }
}

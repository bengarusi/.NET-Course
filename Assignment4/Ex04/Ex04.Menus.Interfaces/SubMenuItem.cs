namespace Ex04.Menus.Interfaces
{
    public class SubMenuItem : MenuItem
    {
        private readonly Menu r_SubMenu;

        public SubMenuItem(string i_Title) : base(i_Title)
        {
            const bool v_IsMainMenu = true;
            r_SubMenu = new Menu(i_Title, !v_IsMainMenu);
        }

        public SubMenuItem AddSubMenuItem(string i_Title) // Not in use now but will be more convenient to use in the future
        {
            SubMenuItem subMenuItem = new SubMenuItem(i_Title);
            r_SubMenu.AddMenuItem(subMenuItem);

            return subMenuItem;
        }

        public void AddActionItem(string i_Title, IMenuAction i_Observer)
        {
            ActionMenuItem actionItem = new ActionMenuItem(i_Title, i_Observer);

            r_SubMenu.AddMenuItem(actionItem);
        }

        public override void Execute()
        {
            ConsoleMenuRenderer.ClearScreen();
            r_SubMenu.Show();
            ConsoleMenuRenderer.ClearScreen();
        }  
    }
}

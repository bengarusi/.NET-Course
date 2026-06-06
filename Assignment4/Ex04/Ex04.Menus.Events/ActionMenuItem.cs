namespace Ex04.Menus.Events
{
    public class ActionMenuItem : MenuItem
    {
        public event Action MenuItemSelected;

        public ActionMenuItem(string i_Title) : base(i_Title)
        {
        }

        public override void Execute()
        {
            ConsoleMenuRenderer.ClearScreen();
            OnMenuItemSelected();
        }

        protected virtual void OnMenuItemSelected()
        {
            MenuItemSelected?.Invoke();
        }
    }
}

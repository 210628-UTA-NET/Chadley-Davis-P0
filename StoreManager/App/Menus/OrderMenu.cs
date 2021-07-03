namespace App.Menus
{
    internal class OrderMenu : IMenu
    {
        public string Header { get { return Constants.Order; } }
        public bool Repeat { get; set; }

        public OrderMenu()
        {
            Repeat = true;
        }
        public void Menu()
        {
            throw new System.NotImplementedException();
        }

        public MenuType YourChoice()
        {
            throw new System.NotImplementedException();
        }
    }
}
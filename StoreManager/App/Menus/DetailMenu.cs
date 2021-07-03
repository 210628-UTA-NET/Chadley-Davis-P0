namespace App.Menus
{
    internal class DetailMenu : IMenu
    {
        public string Header { get { return Constants.Detail; } }

        public bool Repeat { get; set; }

        public DetailMenu()
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
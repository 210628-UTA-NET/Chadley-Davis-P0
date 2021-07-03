namespace App.Menus
{
    internal class AddressMenu : IMenu
    {
        public bool Repeat { get; set; }
        public string Header { get { return Constants.Address; } }

        public AddressMenu()
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
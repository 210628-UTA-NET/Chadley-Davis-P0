namespace App.Menus
{
    internal class ProductMenu : IMenu
    {
        public string Header { get { return Constants.Product; } }

        public bool Repeat { get; set; }
        
        public ProductMenu()
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
using System;
using System.Collections.Generic;

namespace App.Menus
{
    internal class CustomerMenu : IMenu
    {
        public string Header { get { return Constants.Customer; } }

        Dictionary<MenuType, Func<IMenu>> menus = new Dictionary<MenuType, Func<IMenu>>() {
            { MenuType.MainMenu, () => new MainMenu() },
            { MenuType.ContactInformationMenu, () => new ContactInformationMenu() },
            { MenuType.StoreFrontMenu, () => new OrderMenu() }
        };



        public CustomerMenu()
        {

        }
        public void Menu()
        {
            throw new System.NotImplementedException();
        }

        public MenuType MakeChoice()
        {
            throw new System.NotImplementedException();
        }
    }
}
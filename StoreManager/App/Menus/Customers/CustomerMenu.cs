using App.Menus.ContactInformation;
using App.Menus.StoreFronts;
using System;
using System.Collections.Generic;

namespace App.Menus.Customers
{
    internal class CustomerMenu : IMenu
    {
        public string Header { get { return Constants.Customer; } }

        Dictionary<MenuType, Func<IMenu>> menus = new Dictionary<MenuType, Func<IMenu>>() {
            { MenuType.StoreFrontsMenu, () => new StoreFrontsMenu() },
            { MenuType.ContactInformationMenu, () => new ContactInformationMenu() },
            { MenuType.StoreFrontMenu, () => null }
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
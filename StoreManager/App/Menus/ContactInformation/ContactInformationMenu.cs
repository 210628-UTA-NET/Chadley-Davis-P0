using App.Menus.Addresses;
using App.Menus.StoreFronts;
using System;
using System.Collections.Generic;

namespace App.Menus.ContactInformation
{
    internal class ContactInformationMenu : IMenu
    {
        public string Header { get { return Constants.Contact; } }

        Dictionary<MenuType, Func<IMenu>> menus = new Dictionary<MenuType, Func<IMenu>>() {
            { MenuType.StoreFrontsMenu, () => new StoreFrontsMenu() },
            { MenuType.AddressMenu, () => new AddressMenu() },
        };


        public ContactInformationMenu()
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
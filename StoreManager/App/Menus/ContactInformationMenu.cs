using System;
using System.Collections.Generic;

namespace App.Menus
{
    internal class ContactInformationMenu : IMenu
    {
        public string Header { get { return Constants.Main; } }

        Dictionary<MenuType, Func<IMenu>> menus = new Dictionary<MenuType, Func<IMenu>>() {
            { MenuType.MainMenu, () => new MainMenu() },
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
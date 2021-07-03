using System;
using StoreModels;
using System.Collections.Generic;
using App.Menus;

namespace App
{
    class Program
    {
        static bool Continue { get; set; }
        static IFactory Factory { get; set; }
        static HashSet<Customer> Customers { get; set; }
        static HashSet<StoreFront> StoreFronts { get; set; }

        static Dictionary<MenuType, Func<IMenu>> Menus = new Dictionary<MenuType, Func<IMenu>>() {
                { MenuType.MainMenu, () => Factory.GetMenu(MenuType.MainMenu) },
                { MenuType.StoreFrontMenu, () => Factory.GetMenu(MenuType.StoreFrontMenu) },
                { MenuType.CustomerMenu, () => Factory.GetMenu(MenuType.CustomerMenu) },
                { MenuType.AddressMenu, () => Factory.GetMenu(MenuType.AddressMenu) },
                { MenuType.ContactInformationMenu, () => Factory.GetMenu(MenuType.ContactInformationMenu) },
                { MenuType.DetailMenu, () => Factory.GetMenu(MenuType.ExitMenu) },
                { MenuType.OrderMenu, () => Factory.GetMenu(MenuType.ExitMenu) },
                { MenuType.ProductMenu, () => Factory.GetMenu(MenuType.ExitMenu) },
                { MenuType.SelectStoreFrontMenu, () => Factory.GetMenu(MenuType.ExitMenu) },
                { MenuType.ExitMenu, () => Factory.GetMenu(MenuType.ExitMenu) }
            };
        static void Main(string[] args)
        {
            IMenu currentMenu = new MainMenu();
            MenuType currentMenuType = MenuType.MainMenu;
            Factory = new MenuFactory();

            do
            {
                Console.Clear();
                Console.WriteLine(currentMenu.Header);
                currentMenu.Menu();
                currentMenuType = currentMenu.YourChoice();
                currentMenu = Menus[currentMenuType].Invoke();

            } while (currentMenu.Repeat);
        }
    }
}

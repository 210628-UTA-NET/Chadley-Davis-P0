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
                { MenuType.DetailMenu, () => Factory.GetMenu(MenuType.DetailMenu) },
                { MenuType.OrderMenu, () => Factory.GetMenu(MenuType.OrderMenu) },
                { MenuType.ProductMenu, () => Factory.GetMenu(MenuType.ProductMenu) },
                { MenuType.SelectStoreFrontMenu, () => Factory.GetMenu(MenuType.SelectStoreFrontMenu) },
                { MenuType.ExitMenu, () => 
                    {
                        ExitMenu menu = new ExitMenu();
                        menu.Menu();
                        menu.MakeChoice();

                        return menu.Repeat ? Factory.CurrentMenu() : Factory.LastMenu() ;
                    }
                },
                { MenuType.Exit, () => null }
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
                //Writes Menu Output to Screen
                currentMenu.Menu();
                //Records Next Menu Type from Menu
                currentMenuType = currentMenu.MakeChoice();
                //Execute Func defined in Menus
                currentMenu = Menus[currentMenuType].Invoke();

            } while (currentMenu != null);
        }
    }
}

using System;
using StoreModels;
using System.Collections.Generic;
using App.Menus;

namespace App
{
    class Program
    {
        static IFactory Factory { get; set; }

        static Dictionary<MenuType, Func<IMenu>> Menus = new Dictionary<MenuType, Func<IMenu>>() {
                { MenuType.MainMenu, () => Factory.GetMenu(MenuType.MainMenu) },
                { MenuType.StoreFrontMenu, () => Factory.GetMenu(MenuType.StoreFrontMenu) },
                { MenuType.StoreFrontsMenu, () => Factory.GetMenu(MenuType.StoreFrontsMenu) },
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
                        return menu.Repeat 
                            ? Factory.CurrentMenu() 
                            : Factory.LastMenu();
                    }
                }
            };
        static void Main(string[] args)
        {
            IMenu currentMenu;
            MenuType currentMenuType = MenuType.MainMenu;
            Factory = new MenuFactory();
            currentMenu = Menus[currentMenuType].Invoke();
            do
            {
                //Execute Func defined in Menus
                if(currentMenu != null)
                {
                    Console.Clear();
                    Console.WriteLine(currentMenu.Header);
                    //Writes Menu Output to Screen
                    currentMenu.Menu();
                    //Records Next Menu Type from Menu
                    currentMenuType = currentMenu.MakeChoice();
                    currentMenu = Menus[currentMenuType].Invoke();
                }
                

            } while (currentMenu != null);
        }
    }
}

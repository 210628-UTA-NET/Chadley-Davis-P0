using System;
using StoreModels;
using System.Collections.Generic;
using App.Menus;

namespace App
{
    class Program
    {
        static IFactory Factory { get; set; }

        static void Main(string[] args)
        {
            IMenu currentMenu;
            MenuType currentMenuType = MenuType.MainMenu;
            Factory = new MenuFactory();
            currentMenu = Factory.GetMenu(currentMenuType);
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
                    currentMenu = Factory.GetMenu(currentMenuType);
                }
                

            } while (currentMenu != null);
        }
    }
}

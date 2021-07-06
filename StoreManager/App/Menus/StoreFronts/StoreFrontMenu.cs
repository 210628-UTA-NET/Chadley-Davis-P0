using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;

namespace App.Menus.StoreFronts
{
    internal class StoreFrontMenu : IMenu
    {
        public StoreFront StoreFront { get; set; }
        public string Header { get { return Constants.StoreFront; } }

        Dictionary<string, MenuType> MenuSelections = new Dictionary<string, MenuType>(){
            { "1", MenuType.StoreFrontMenu },
            { "0", MenuType.ExitMenu }
        };



        public StoreFrontMenu(DBModel dB, StoreFront storeFront)
        {

            StoreFront = storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Manager");
            Console.WriteLine();
            Console.WriteLine("Store Info");
            Console.Write($"Store Name: {StoreFront.Id}");
            Console.WriteLine("Please select an option.");

            Console.WriteLine("[1] Manage Products");
            Console.WriteLine("[2] Manage Customers");
            Console.WriteLine("[0] Exit");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();
            
            return MenuSelections[userInput];
        }
    }
}
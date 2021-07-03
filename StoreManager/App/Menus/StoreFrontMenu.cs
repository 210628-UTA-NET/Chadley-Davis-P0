using StoreModels;
using System;
using System.Collections.Generic;

namespace App.Menus
{
    internal class StoreFrontMenu : IMenu
    {
        public string Header { get { return Constants.StoreFront; } }

        Dictionary<string, MenuType> MenuSelections = new Dictionary<string, MenuType>(){
            { "1", MenuType.StoreFrontMenu },
            { "0", MenuType.ExitMenu }
        };

        public bool Repeat { get; set; }

        public StoreFrontMenu()
        {
            Repeat = true;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Manager!");
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[1] Manage Stores");
            Console.WriteLine("[2] Manage Customers");
            Console.WriteLine("[0] Exit");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
            return MenuSelections[userInput];
        }
    }
}
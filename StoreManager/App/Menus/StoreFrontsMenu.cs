using StoreModels;
using System;
using System.Collections.Generic;

namespace App.Menus
{
    internal class StoreFrontsMenu : IMenu
    {
        
        public string Header { get { return Constants.StoreList; } }

        Dictionary<string, MenuType> MenuSelections = new Dictionary<string, MenuType>(){
            { "1", MenuType.StoreFrontMenu },
            { "0", MenuType.ExitMenu }
        };

        public List<StoreFront> Stores { get; set; }


        public StoreFrontsMenu()
        {

        }
        public void Menu()
        {
            Console.WriteLine("Store List!");
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[1] Manage Store");
            Console.WriteLine("[2] Search Store");
            Console.WriteLine("[0] Exit");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();

            return MenuSelections[userInput];
        }
    }
}
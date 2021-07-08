
using Models.Entities;
using System;
using System.Collections.Generic;

namespace App.Menus.StoreFronts
{
    internal class StoreFrontMenu : IMenu
    {
        public StoreFront StoreFront { get; set; }
        public string Header { get { return Constants.StoreFront; } }

        Dictionary<string, MenuType> MenuSelections = new Dictionary<string, MenuType>(){
            { "D", MenuType.EditStoreFrontMenu },
            { "0", MenuType.ExitMenu }
        };



        public StoreFrontMenu(StoreFront storeFront)
        {

            StoreFront = storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Manager");
            Console.WriteLine();
            if(StoreFront != null)
            {
                Console.WriteLine("Store Info");

                Console.WriteLine($"Store Id: {StoreFront.Id}");
                Console.WriteLine($"Store Name: {StoreFront.Name}");
                if (StoreFront.Contact != null)
                {
                    Console.WriteLine($"Contact Information: ");
                    Console.WriteLine(StoreFront.Contact.ToString());

                }

            }
            Console.WriteLine("Please select an option.");

            Console.WriteLine("[A] Manage Products");
            Console.WriteLine("[B] Manage Inventory");
            Console.WriteLine("[C] Manage Customers");
            Console.WriteLine("[D] Manage Store");
            Console.WriteLine("[0] Exit");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();
            if (!MenuSelections.ContainsKey(userInput))
                return MenuType.None;
            return MenuSelections[userInput];
        }
    }
}
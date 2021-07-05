using StoreBL;
using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace App.Menus
{
    internal class StoreFrontsMenu : IMenu
    {

        public string Header { get { return Constants.StoreList; } }

        Dictionary<string, Func<MenuType>> MenuSelections = new Dictionary<string, Func<MenuType>>(){
            { "A", () => MenuType.SearchStoreFrontMenu },
            { "B", () => MenuType.GetStoreFrontMenu },
            { "C", () => MenuType.AddStoreFrontMenu },
            { "0", () => MenuType.ExitMenu }
        };

        public List<StoreFront> StoreFronts { get; set; }
        public StoreFront SelectedStoreFront { get; set; }
        private StoreFrontBL storeFrontBL { get; set; }

        public StoreFrontsMenu(DBModel dB)
        {

            storeFrontBL = new StoreFrontBL(dB);
            StoreFronts = storeFrontBL.GetAll(new StoreFront());
        }
        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[A] Search Store By Name");
            Console.WriteLine("[B] Get Store By Id");
            Console.WriteLine("[C] Add New Store");
            int count = 1;
            Console.WriteLine("Store List!");
            StoreFronts.ForEach(storeFront => {
                Console.WriteLine($"[{count++}] Select Store {storeFront.Id} - {storeFront.Name}");
            });
            Console.WriteLine("[0] Exit");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();
            if (Regex.IsMatch(userInput, @"(?!0)^\d+$"))
            {
                int.TryParse(userInput, out int index);
                SelectedStoreFront = StoreFronts[index];
                return MenuType.StoreFrontMenu;
            }
            else
            {
                return MenuSelections[userInput].Invoke();
            }
        }
    }
}
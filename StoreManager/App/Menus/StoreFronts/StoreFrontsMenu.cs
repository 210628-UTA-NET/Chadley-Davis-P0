using StoreBL;
using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace App.Menus.StoreFronts
{
    internal class StoreFrontsMenu : IMenu
    {

        public string Header { get { return Constants.StoreList; } }
        static string SearchTerm { get; set; }
        static Guid StoreFrontId { get; set; }
        Dictionary<string, Func<MenuType>> MenuSelections = new Dictionary<string, Func<MenuType>>(){
            { "A", () => {
                SearchStoreFrontMenu menu = new SearchStoreFrontMenu();
                menu.Menu();
                menu.MakeChoice();
                SearchTerm = menu.SearchTerm;                
                return MenuType.None;
            } },
            { "B", () => MenuType.StoreFrontMenu },
            { "C", () => MenuType.AddStoreFrontMenu },
            { "0", () => MenuType.ExitMenu }
        };

        static List<StoreFront> StoreFronts { get; set; }
        public StoreFront StoreFront { get; set; }
        private StoreFrontBL storeFrontBL { get; set; }
        private static DBModel dbModel { get; set; }
        public StoreFrontsMenu(DBModel dB)
        {

            storeFrontBL = new StoreFrontBL(dB);
            var storeFronts = storeFrontBL.GetAll(new StoreFront() { Id = StoreFrontId, Name = SearchTerm });
            while (!storeFronts.IsCompleted);
            
            StoreFronts = storeFronts.Result;


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
            //if non-zero integer
            if (Regex.IsMatch(userInput, @"(?!0)^\d+$"))
            {
                int.TryParse(userInput, out int index);
                StoreFront = StoreFronts[index];
                return MenuType.StoreFrontMenu;
            }
            else if (userInput == "B")
            {
                GetStoreFrontMenu getSFMenu = new GetStoreFrontMenu();
                getSFMenu.Menu();
                getSFMenu.MakeChoice();
                if(getSFMenu.StoreFrontId != Guid.Empty)
                    StoreFront = StoreFronts.FirstOrDefault(sf => sf.Id == getSFMenu.StoreFrontId);
                return MenuSelections[userInput].Invoke();
            }
            else
            {

                return MenuSelections[userInput].Invoke();
            }
        }
    }
}
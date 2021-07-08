using Microsoft.EntityFrameworkCore;
using Models.Entities;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            { "B", () => 
            {
                Console.WriteLine("Please enter the Store's Unique ID.");
                Guid id;
                while(Guid.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please enter a valid unique identifier.");
                }

                StoreFront = StoreFronts.FirstOrDefault(sf => sf.Id == id);
                return MenuType.StoreFrontMenu; 
            } },
            { "C", () => {
                StoreFront = new StoreFront();
                var storeFront = storeFrontBL.Add(StoreFront);
                while(!storeFront.IsCompleted);
                StoreFront = storeFront.Result;
                return MenuType.StoreFrontMenu;
            } },
            { "0", () => MenuType.ExitMenu }
        };

        static List<StoreFront> StoreFronts { get; set; }
        internal static StoreFront StoreFront { get; set; }
        private static StoreFrontBL storeFrontBL { get; set; }

        public StoreFrontsMenu()
        {
            storeFrontBL = new StoreFrontBL();
            var storeFrontTask = storeFrontBL.GetAll();
            while(!storeFrontTask.IsCompleted);
            StoreFronts = storeFrontTask.Result;
        }
        public void Menu()
        {
            var storeFrontTask = storeFrontBL.GetAll();
            while (!storeFrontTask.IsCompleted) ;
            StoreFronts = storeFrontTask.Result;

            Console.WriteLine();
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[A] Search Store By Name");
            Console.WriteLine("[B] Get Store By Id");
            Console.WriteLine("[C] Add New Store");
            int count = 1;
            Console.WriteLine("Store List!");
            StoreFronts.ForEach(storeFront => {
                Console.WriteLine($"Id: {storeFront.Id}");
                Console.WriteLine($"Name: {storeFront.Name}");
                Console.WriteLine();
            });
            Console.WriteLine("[0] Exit");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();
            //if non-zero integer
            if (!MenuSelections.ContainsKey(userInput))
                return MenuType.None;
            return MenuSelections[userInput].Invoke();
            
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public class MainMenu : IMenu
    {
        public string Header { get { return Constants.Main; } }

        Dictionary<string, MenuType> MenuSelections = new Dictionary<string, MenuType>(){
            { "1", MenuType.StoreFrontsMenu },
            { "0", MenuType.ExitMenu }
        };
        public MenuType PreviousMenu { get; private set; }

        public MainMenu()
        {

        }

        
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Manager!");
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[1] Manage Stores");
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

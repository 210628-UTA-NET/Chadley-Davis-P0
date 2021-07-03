using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    internal class ExitMenu : IMenu
    {
        public string Header { get { return Constants.Exit; } }

        public bool Repeat { get; set; }


        Dictionary<string, bool> MenuSelections = new Dictionary<string, bool>() {
            { "Y", false },
            { "N", true }
        };

        public ExitMenu()
        {
            Repeat = true;
        }
        public void Menu()
        {
            Repeat = true;
            Console.WriteLine("Are you sure you wish to exit.");
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[Y] Exit Current Menu");
            Console.WriteLine("[N] Remain In Current Menu");

        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
            Repeat = MenuSelections[userInput];
            return MenuType.ExitMenu;
        }
    }
}

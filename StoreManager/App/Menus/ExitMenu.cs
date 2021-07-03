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

        static MenuType CurrentType { get; set; } = MenuType.MainMenu;

        static Dictionary<string, bool> MenuSelections = new Dictionary<string, bool>() {
            { "Y", false },
            { "N", true }
        };

        public ExitMenu()
        {
            //CurrentType = menu.GetType();
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

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();  
            Repeat = MenuSelections[userInput];
            return MenuType.ExitMenu;
        }
    }
}

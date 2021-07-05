using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Menus
{
    internal class SearchStoreFrontMenu
    {
        public StoreFront StoreFront { get; set; }
        public string Header { get { return Constants.StoreFront; } }


        private List<StoreFront> storeFronts { get; set; }
        private int selectedIndex { get; set; }
        public StoreFront SelectedStoreFront { get { return storeFronts[selectedIndex]; } }
        public SearchStoreFrontMenu(DBModel dB, string searchTerm)
        {

        }
        public void Menu()
        {
            Console.WriteLine("Enter Search Term:");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();
            //If the input is non-zero number


            return MenuType.None;
        }
    }
}

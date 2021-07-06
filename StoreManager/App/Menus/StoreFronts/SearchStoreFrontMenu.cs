using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Menus.StoreFronts
{
    internal class SearchStoreFrontMenu
    {
        public string Header { get { return Constants.StoreFront; } }
        public string SearchTerm { get; set; }
        public SearchStoreFrontMenu()
        {

        }
        public void Menu()
        {
            Console.WriteLine("Enter Search Term:");
        }

        public MenuType MakeChoice()
        {
            SearchTerm = Console.ReadLine();
            //If the input is non-zero number


            return MenuType.None;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus.StoreFronts
{
    internal class GetStoreFrontMenu : IMenu
    {
        public string Header { get { return Constants.StoreFront; } }
        public Guid StoreFrontId { get; set; }
        public GetStoreFrontMenu()
        {

        }
        public void Menu()
        {
            Console.WriteLine("Enter StoreFront Id: ");
        }

        public MenuType MakeChoice()
        {
            Guid.TryParse(Console.ReadLine(), out Guid result);            
            StoreFrontId = result;
            return MenuType.None;
        }
    }
}

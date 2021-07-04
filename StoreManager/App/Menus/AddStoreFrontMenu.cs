using StoreBL;
using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public class AddStoreFrontMenu : IMenu
    {
        StoreFrontBL storeFrontBL { get; set; }
        StoreFront storeFront;
        public StoreFront StoreFront { get { return storeFront; } }
        public string Header { get { return Constants.AddStore; } }
        public DBModel dBContext { get; set; } 
        public AddStoreFrontMenu(DBModel dB)
        {
            dBContext = dB;

        }
        public MenuType MakeChoice()
        {
            return MenuType.StoreFrontMenu;
        }

        public void Menu()
        {
            storeFront = new StoreFront()
            {
                Id = Guid.NewGuid()
            };
            storeFrontBL = new StoreFrontBL(dBContext);
            storeFrontBL.Add(storeFront);
            //No Output
        }
    }
}

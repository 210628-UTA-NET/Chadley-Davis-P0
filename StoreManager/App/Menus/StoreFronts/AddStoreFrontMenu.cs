using StoreBL;
using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus.StoreFronts
{
    public class AddStoreFrontMenu : IMenu
    {
        StoreFrontBL storeFrontBL { get; set; }
        public StoreFront StoreFront { get; set; }
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
            StoreFront = new StoreFront()
            {
                Id = Guid.NewGuid(),
                Name = "",
                LastUpdate = DateTime.UtcNow
            };
            storeFrontBL = new StoreFrontBL(dBContext);
            storeFrontBL.Add(StoreFront);

            //No Output
        }
    }
}

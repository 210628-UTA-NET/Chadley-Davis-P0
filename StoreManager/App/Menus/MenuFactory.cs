using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public class MenuFactory : IFactory
    {
        Dictionary<MenuType, Func<IMenu>> menus = new Dictionary<MenuType, Func<IMenu>>() {
            { MenuType.MainMenu, () => new MainMenu() },
            { MenuType.CustomerMenu, () => new CustomerMenu() },
            { MenuType.AddressMenu, () => new AddressMenu() },
            { MenuType.ContactInformationMenu, () => new ContactInformationMenu() },
            { MenuType.StoreFrontMenu, () => new StoreFrontMenu() },
            { MenuType.OrderMenu, () => new OrderMenu() },
            { MenuType.ProductMenu, () => new ProductMenu() },
            { MenuType.DetailMenu, () => new DetailMenu() },
            { MenuType.ExitMenu, () => new ExitMenu() }
        };  
        public IMenu GetMenu(MenuType menu)
        {
            return menus[menu].Invoke();
        }
    }
}

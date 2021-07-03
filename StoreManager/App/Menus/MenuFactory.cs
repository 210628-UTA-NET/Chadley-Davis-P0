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

        Stack<IMenu> MenuStack { get; set; }

        Dictionary<MenuType, Func<IMenu>> menus = new Dictionary<MenuType, Func<IMenu>>() {
            { MenuType.MainMenu, () => new MainMenu() },
            { MenuType.CustomerMenu, () => new CustomerMenu() },
            { MenuType.AddressMenu, () => new AddressMenu() },
            { MenuType.ContactInformationMenu, () => new ContactInformationMenu() },
            { MenuType.StoreFrontMenu, () => new StoreFrontMenu() },
            { MenuType.StoreFrontsMenu, () => new StoreFrontsMenu() },
            { MenuType.OrderMenu, () => new OrderMenu() },
            { MenuType.ProductMenu, () => new ProductMenu() },
            { MenuType.DetailMenu, () => new DetailMenu() },
            { MenuType.ExitMenu, () => new ExitMenu() }
        };  
        public MenuFactory()
        {
            MenuStack = new Stack<IMenu>();
        }
        public IMenu GetMenu(MenuType menuType)
        {
            IMenu menu = menus[menuType].Invoke();
            MenuStack.Push(menu);
            return menu;
        }
        public IMenu CurrentMenu()
        {
            return MenuStack.LastOrDefault();
        }
        public IMenu LastMenu()
        {
            IMenu menu;
            MenuStack.TryPop(out menu);
            return CurrentMenu();
        }
    }
}

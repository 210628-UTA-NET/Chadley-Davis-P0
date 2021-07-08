using App.Menus.Addresses;
using App.Menus.ContactInformation;
using App.Menus.Customers;
using App.Menus.Details;
using App.Menus.Orders;
using App.Menus.Products;
using App.Menus.StoreFronts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public class MenuFactory : IFactory
    {
        static StoreFront StoreFront { get; set; }
        static StoreFrontBL StoreFrontBL { get; set; }

        #region MenuConstructors
        /// <summary>
        /// Return null to Return to Previous Menu (Pop off Stack)
        /// Dynamics to be executed for various function types
        /// </summary>
        static Dictionary<MenuType, Func<IMenu, IMenu>> menus = new Dictionary<MenuType, Func<IMenu, IMenu>>() {
            { MenuType.CustomerMenu, (currentMenu) => new CustomerMenu() },
            { MenuType.AddressMenu, (currentMenu) => new AddressMenu() },
            { MenuType.ContactInformationMenu, (currentMenu) => new ContactInformationMenu() },
            { MenuType.StoreFrontMenu, (currentMenu) => new StoreFrontMenu(StoreFrontsMenu.StoreFront) },
            { MenuType.StoreFrontsMenu, (currentMenu) => new StoreFrontsMenu() },
            { MenuType.OrderMenu, (currentMenu) => new OrderMenu() },
            { MenuType.ProductMenu, (currentMenu) => new ProductMenu() },
            { MenuType.DetailMenu, (currentMenu) => new DetailMenu() },
            { MenuType.EditStoreFrontMenu, (currentMenu) => new EditStoreFrontMenu(((StoreFrontMenu)currentMenu).StoreFront) },
            { MenuType.AddStoreFrontMenu, (currentMenu) => new StoreFrontMenu(StoreFrontsMenu.StoreFront) },
            { MenuType.ExitMenu, (currentMenu) => {
                ExitMenu menu = new ExitMenu();
                menu.Menu();
                menu.MakeChoice();
                if(!menu.Repeat)
                    Pop();
                return null;
            } },
            { MenuType.None, (currentMenu) => null }
        };
        #endregion

        public MenuFactory()
        {
            
            IFactory.MenuStack = new Stack<IMenu>();

        }
        public IMenu GetMenu(MenuType menuType)
        {
            IMenu current = Peek();
            IMenu menu = menus[menuType].Invoke(current);
            if(menu != null)
                Push(menu);
            return Peek();
        }
        public static IMenu Pop()
        {
            IMenu menu;
            IFactory.MenuStack.TryPop(out menu);
            return menu;
        }

        public void Push(IMenu menu)
        {
            IFactory.MenuStack.Push(menu);
        }
        public IMenu Peek()
        {
            IFactory.MenuStack.TryPeek(out IMenu menu);
            return menu;
        }

    }
}

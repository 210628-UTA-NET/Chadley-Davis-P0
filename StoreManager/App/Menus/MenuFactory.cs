using StoreDL;
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
        static StoreFront StoreFront { get; set; }

        #region MenuConstructors
        /// <summary>
        /// Return null to Return to Previous Menu (Pop off Stack)
        /// Dynamics to be executed for various function types
        /// </summary>
        static Dictionary<MenuType, Func<IMenu, IMenu>> menus = new Dictionary<MenuType, Func<IMenu, IMenu>>() {
            { MenuType.MainMenu, (currentMenu) => new MainMenu() },
            { MenuType.CustomerMenu, (currentMenu) => new CustomerMenu() },
            { MenuType.AddressMenu, (currentMenu) => new AddressMenu() },
            { MenuType.ContactInformationMenu, (currentMenu) => new ContactInformationMenu() },
            { MenuType.StoreFrontMenu, (currentMenu) => new StoreFrontMenu(IFactory.DataBaseModel, StoreFront) },
            { MenuType.StoreFrontsMenu, (currentMenu) => new StoreFrontsMenu(IFactory.DataBaseModel) },
            { MenuType.OrderMenu, (currentMenu) => new OrderMenu() },
            { MenuType.ProductMenu, (currentMenu) => new ProductMenu() },
            { MenuType.DetailMenu, (currentMenu) => new DetailMenu() },
            { MenuType.AddStoreFrontMenu, (currentMenu) => {
                AddStoreFrontMenu menu = new AddStoreFrontMenu(IFactory.DataBaseModel);
                menu.Menu();
                StoreFront = menu.StoreFront;
                StoreFrontMenu storeFrontMenu = new StoreFrontMenu(IFactory.DataBaseModel, StoreFront);
                return menus[MenuType.StoreFrontMenu].Invoke(currentMenu);
            } },
            { MenuType.SearchStoreFrontMenu, (currentMenu) => {
                SearchStoreFrontMenu menu = new SearchStoreFrontMenu(IFactory.DataBaseModel);
                menu.Menu();
                menu.MakeChoice();
                return null;
            } },
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
            IFactory.DataBaseModel = new DBModel();
            IFactory.MenuStack = new Stack<IMenu>();
        }
        public IMenu GetMenu(MenuType menuType)
        {
            IMenu current = Pop();
            IMenu previous = Peek();
            Push(current);
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

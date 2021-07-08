using StoreDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public interface IFactory
    {
        protected static Stack<IMenu> MenuStack { get; set; }

        IMenu GetMenu(MenuType menu);


    }
}

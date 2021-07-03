using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public interface IFactory
    {
        IMenu GetMenu(MenuType menu);
    }
}

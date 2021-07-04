using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public class SubFactory : IFactory
    {
        public IMenu GetMenu(MenuType menu)
        {
            throw new NotImplementedException();
        }
    }
}

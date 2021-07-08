using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public class MainMenu : IMenu
    {
        public string Header => Constants.Main;
        public void Menu()
        {

        }

        public MenuType MakeChoice()
        {
            throw new NotImplementedException();
        }

    }
}

using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus
{
    public enum MenuType
    {
        
        ExitMenu = 0,
        MainMenu = 1,
        AddressMenu = 2,
        ContactInformationMenu = 3,
        CustomerMenu = 4,
        DetailMenu = 5,
        OrderMenu = 6,
        ProductMenu = 7,
        StoreFrontMenu = 8,
        SelectStoreFrontMenu = 9,
        StoreFrontsMenu = 10,
        AddStoreFrontMenu = 11,
        AddStoreFrontsMenu = 12,
        None = 13,
        GetStoreFrontMenu = 14,
        SearchStoreFrontMenu = 15,
        EditStoreFrontMenu = 16
    }
    public interface IMenu
    {
        string Header { get; }

        /// <summary>
        /// Will display the overall menu of the class and the choices you can make in that menu class
        /// </summary>
        void Menu();

        /// <summary>
        /// This methog will record the user's choice and change your meny based on their input
        /// </summary>
        /// <returns>Returns a value that will dictate what menu to change to</returns>
        MenuType MakeChoice();

    }
}

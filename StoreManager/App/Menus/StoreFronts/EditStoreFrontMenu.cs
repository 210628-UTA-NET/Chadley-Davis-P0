using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Menus.StoreFronts
{
    internal class EditStoreFrontMenu : IMenu
    {
        public string Header { get { return Constants.EditStore; } }
        Dictionary<string, Func<StoreFrontBL, StoreFront, StoreFront>> MenuSelections = new Dictionary<string, Func<StoreFrontBL, StoreFront, StoreFront>>(){
            { "A", (storeFrontBL, storeFront) => {
                Console.WriteLine("Enter Name:");
                storeFront.Name = Console.ReadLine();
               return storeFront; 
            } },
            { "B", (storeFrontBL, storeFront) => {
                
                //Contact InformationMenu
               return storeFront; 
            } },
            { "C", (storeFrontBL, storeFront) => {
                //Save to database here
                var result = storeFrontBL.Update(storeFront);
                while (!result.IsCompleted) ;
                storeFront = result.Result;
               return null;
            } },
            { "0", (storeFrontBL, storeFront) => {
               return null;
            } }
        };
        public Guid StoreFrontId { get; set; }
        StoreFrontBL storeFrontBL { get; }
        public StoreFront StoreFront { get; set; }
        public EditStoreFrontMenu(StoreFront storeFront)
        {
            //storeFrontBL = new StoreFrontBL();
            //StoreFront = storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("Please make a selection: ");
            Console.WriteLine($"Store Id: {StoreFront.Id}");
            Console.WriteLine($"Store Name: {StoreFront.Name}");
            Console.WriteLine("[A] to Change Store Name");
            Console.WriteLine("[B] to Change Store ContactInformation");
            Console.WriteLine("[C] to Save and Exit");
            Console.WriteLine("[0] to Cancel");
        }

        public MenuType MakeChoice()
        {
            string userInput = Console.ReadLine();

            if (!MenuSelections.ContainsKey(userInput))
                return MenuType.None;
            StoreFront = MenuSelections[userInput].Invoke(storeFrontBL, StoreFront);
            if (StoreFront == null)
                return MenuType.ExitMenu;
            return MenuType.None;
        }
    }
}

using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class DBModel
    {
        public DBModel()
        {
            StoreFronts = new List<StoreFront>();
            Addresses = new List<Address>();
            ContactInformation = new List<ContactInformation>();
            Customers = new List<Customer>();
            Details = new List<Detail>();
            Inventories = new List<Inventory>();
            Orders = new List<Order>();
            Products = new List<Product>();
        }

        public List<StoreFront> StoreFronts { get; set; }
        public List<Address> Addresses { get; set; }
        public List<ContactInformation> ContactInformation { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Detail> Details { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
 
    }
}

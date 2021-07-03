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
        public List<Address> Addresses { get; set; }
        public List<ContactInformation> ContactInformation { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<StoreFront> StoreFronts { get; set; }

    }
}

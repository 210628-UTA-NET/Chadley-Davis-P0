using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class StoreFront
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ContactInformation Contact { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<Order> ShoppingCart { get; set; }
        public virtual List<Order> Pendingorders { get; set; }

        public virtual List<Order> CompletedOrders { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}

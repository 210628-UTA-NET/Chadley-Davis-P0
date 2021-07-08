using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StoreFront
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ContactInformation Contact { get; set; }

        public List<Inventory> Inventory { get; set; }
        public List<Order> Orders { get; set; }
        public ICollection<Customer> Customers { get; set; }
        
        public DateTime LastUpdate { get; set; }
    }
}

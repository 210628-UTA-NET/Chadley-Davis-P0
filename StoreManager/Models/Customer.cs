using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {

        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactInformation Contact { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<StoreFront> StoreFronts { get; set; }
    }

}

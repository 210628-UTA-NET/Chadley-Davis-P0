using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Customer
    {

        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ContactInformation Contact { get; set; }
        public virtual List<Order> Orders { get; set; }
        public DateTime LastUpdate { get; set; }
    }

}

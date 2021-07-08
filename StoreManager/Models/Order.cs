using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<Detail> Details { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public StoreFront StoreFront { get; set; }
        public Customer Customer { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public virtual List<Detail> Details { get; set; }
    }
}

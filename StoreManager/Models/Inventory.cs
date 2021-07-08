using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Inventory
    {

        [Key]
        public Guid Id { get; set; }

        public int Count { get; set; }

        public virtual List<Detail> Details { get; set; }

    }
}

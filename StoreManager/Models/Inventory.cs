using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Inventory
    {

        [Key]
        public Guid Id { get; set; }

        public int Count { get; set; }

        public Product Product { get; set; }

        public StoreFront StoreFront { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Detail
    {

        [Key]
        public Guid Id { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
        public DateTime LastUpdate { get; set; }

        public Order Order { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Detail
    {

        [Key]
        public Guid Id { get; set; }
        public int Count { get; set; }
        public virtual Product Product { get; set; }
        public DateTime LastUpdate { get; set; }


    }
}

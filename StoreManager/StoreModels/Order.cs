using System;
using System.Collections.Generic;
using System.Linq;
using StoreModels;

namespace StoreModels
{
    public class Order
    {
        public List<Detail> Details { get; private set; }
        public Address Location { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Order(Address orderLocation)
        {
            Location = orderLocation;
            OrderDate = DateTime.UtcNow;
            Details = new List<Detail>();   
        }
        public decimal Total()
        {
            return Details.Sum(d => d.Total());
        }
    }

}
using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreManager
{
    public class Order
    {
        public List<Detail> Details { get; private set; }
        public Address Location { get; private set; }
        public Order()
        {
            
        }
    }

}
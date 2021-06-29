using System;

namespace StoreManager
{
    public class Order
    {
        public List<OrderDetail> Details { get; private set; }
        public Address Location { get; private set; }
        public Order()
        {
            
        }
    }

}
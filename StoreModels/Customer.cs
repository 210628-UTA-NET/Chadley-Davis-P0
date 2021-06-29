using System;
using System.Collections.Generic;
namespace StoreManager
{
    public class Customer
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public ContactInformation ContactInformation { get; private set; }
        public List<Order> Orders { get; private set; }
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Orders = new List<Order>();
        }

        public void SetAddress(ContactInformation contactInformation)
        {
            ContactInformation = contactInformation;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }

}
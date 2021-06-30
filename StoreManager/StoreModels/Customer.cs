using System;
using System.Collections.Generic;
namespace StoreModels
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
        
        public override bool Equals(Object obj)
        {
            return obj is Customer && this == (Customer)obj;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode() ^ ContactInformation.GetHashCode();
        }
        /// <summary>
        /// Compares Two Customers for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if Customers Have Same Name and Category</returns>
        public static bool operator ==(Customer x, Customer y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName && x.ContactInformation == y.ContactInformation;
        }

        public static bool operator !=(Customer x, Customer y)
        {
            return !(x == y);
        }
    }
    
}
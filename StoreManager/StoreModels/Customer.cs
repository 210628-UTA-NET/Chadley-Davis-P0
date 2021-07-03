using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreModels
{
    public class Customer
    {
        #region Properties

        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public Guid ContactInformationId
        {
            get
            {
                return ContactInformation != null
                    ? ContactInformation.Id
                    : Guid.Empty;
            }
        }
        public ContactInformation ContactInformation { get; set; }

        #region Order Properties
        public List<Guid> PendingOrderIds
        {
            get
            {
                return PendingOrders != null
                    ? PendingOrders.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
        }
        public Queue<Order> PendingOrders { get; set; }

        public List<Guid> CompletedOrderIds
        {
            get
            {
                return CompletedOrders != null
                    ? CompletedOrders.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
        }
        public List<Order> CompletedOrders { get; set; }
        public List<Guid> OrderIds
        {
            get
            {
                return Orders != null
                    ? Orders.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
        }
        public List<Order> Orders
        {
            get
            {
                List<Order> orders = new List<Order>();
                orders.AddRange(PendingOrders);
                orders.AddRange(CompletedOrders);
                return orders;
            }
        }
        #endregion

        #endregion

        #region Constructors
        public Customer()
        {
            PendingOrders = new Queue<Order>();
            CompletedOrders = new List<Order>();
        }
        public Customer(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PendingOrders = new Queue<Order>();
            CompletedOrders = new List<Order>();
        }
        #endregion

        #region Methods
        public void SetAddress(ContactInformation contactInformation)
        {
            ContactInformation = contactInformation;
        }


        #region Order Methods
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        #endregion

        #region Overrides

        public override bool Equals(Object obj)
        {
            return obj is Customer && this == (Customer)obj;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        /// <summary>
        /// Compares Two Customers for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if Customers Have Same Id</returns>
        public static bool operator ==(Customer x, Customer y)
        {
            return x.Id == y.Id;
        }

        public static bool operator !=(Customer x, Customer y)
        {
            return !(x == y);
        }

        #endregion



        #endregion






    }
    
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace StoreModels
{
    public class Customer
    {
        #region Properties

        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
        [NotMapped]
        public Guid ContactInformationId
        {
            get
            {
                return ContactInformation != null
                    ? ContactInformation.Id
                    : Guid.Empty;
            }
            set
            {
                ContactInformation.Id = value;
            }
        }
        [JsonIgnore]
        [NotMapped]
        public virtual ContactInformation ContactInformation { get; set; } = new ContactInformation();
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        #region Order Properties

        [NotMapped]
        public List<Guid> PendingOrderIds
        {
            get
            {
                return PendingOrders != null
                    ? PendingOrders.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
            set
            {
                foreach (Guid id in value)
                {
                    PendingOrders.Add(new Order() { Id = id });
                }
            }
        }

        
        [JsonIgnore]
        [NotMapped]
        public virtual List<Order> PendingOrders { get; set; }

        [NotMapped]
        public List<Guid> CompletedOrderIds
        {
            get
            {
                return CompletedOrders != null
                    ? CompletedOrders.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
            set
            {
                foreach (Guid id in value)
                {
                    CompletedOrders.Add(new Order() { Id = id });
                }
            }
        }
        [JsonIgnore]
        [NotMapped]
        public virtual List<Order> CompletedOrders { get; set; } = new List<Order>();

        [JsonIgnore]
        [NotMapped]
        public List<Guid> OrderIds
        {
            get
            {
                return Orders != null
                    ? Orders.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
        }
        [JsonIgnore]
        [NotMapped]
        public virtual List<Order> Orders
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

        }
        public Customer(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;

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
            PendingOrders.Add(order);
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
            return x?.Id == y?.Id;
        }

        public static bool operator !=(Customer x, Customer y)
        {
            return !(x == y);
        }

        #endregion



        #endregion

    }
    
}
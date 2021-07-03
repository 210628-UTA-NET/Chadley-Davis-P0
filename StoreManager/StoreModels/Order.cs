using System;
using System.Collections.Generic;
using System.Linq;
using StoreModels;

namespace StoreModels
{
    public class Order
    {
        #region Properties

        public Guid Id { get; set; }

        public List<Guid> DetailIds
        {
            get
            {
                return Details != null
                    ? Details.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
        }
        public List<Detail> Details { get; set; }
        public Guid LocationId
        {
            get
            {
                return Location != null
                    ? Location.Id
                    : Guid.Empty;
            }
        }
        public Address Location { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomertId { get; set; }
        public Customer Customer { get; set; }

        public Guid StoreFrontId { get; set; }
        public StoreFront StoreFront { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructors

        public Order()
        {

        }
        public Order(Guid id, Address orderLocation)
        {
            Id = id;
            Location = orderLocation;
            OrderDate = DateTime.UtcNow;
            Details = new List<Detail>();
        }

        #endregion

        #region Methods
        public decimal Total()
        {
            return Details.Sum(d => d.Total());
        }

        #region Overrides

        public override bool Equals(Object obj)
        {
            return obj is Order && this == (Order)obj;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        /// <summary>
        /// Compares Two Products for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if Products Have Same Name and Category</returns>
        public static bool operator ==(Order x, Order y)
        {
            return x.Id == y.Id;
        }

        public static bool operator !=(Order x, Order y)
        {
            return !(x == y);
        }

        #endregion

        #endregion



    }

}
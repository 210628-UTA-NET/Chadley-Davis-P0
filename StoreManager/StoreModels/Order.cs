using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using StoreModels;

namespace StoreModels
{
    public class Order
    {
        #region Properties

        public Guid Id { get; set; } = Guid.NewGuid();

        public List<Guid> DetailIds
        {
            get
            {
                return Details != null
                    ? Details.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
            set
            {
                foreach(Guid id in value)
                {
                    Details.Add(new Detail() { Id = id });
                }
            }
        }
        [JsonIgnore]
        public List<Detail> Details { get; set; } = new List<Detail>();
        public Guid LocationId 
        { 
            get 
            { 
                return Location != null 
                    ? Location.Id 
                    : Guid.Empty; 
            }
            set
            {
                Location.Id = value;
            }
        }

        [JsonIgnore]
        public Address Location { get; set; } = new Address();
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public Guid CustomertId 
        { 
            get 
            { 
                return Customer != null 
                    ? Customer.Id 
                    : Guid.Empty;
            }
            set
            {
                Customer.Id = value;
            }
        }
        [JsonIgnore]
        public Customer Customer { get; set; } = new Customer();

        public Guid StoreFrontId 
        { 
            get 
            { 
                return StoreFront != null 
                    ? StoreFront.Id 
                    : Guid.Empty;
            }
            set
            {
                StoreFront.Id = value;
            }
        }
        [JsonIgnore]
        public StoreFront StoreFront { get; set; } = new StoreFront();
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
        #endregion

        #region Constructors

        public Order()
        {

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
            return x?.Id == y?.Id;
        }

        public static bool operator !=(Order x, Order y)
        {
            return !(x == y);
        }

        #endregion

        #endregion



    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace StoreModels
{
    public class StoreFront
    {
        #region Properties
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";

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

        [NotMapped]

        public List<Guid> ProductIds
        {
            get
            {
                return Products != null
                    ? Products.Select(product => product.Id).ToList()
                    : new List<Guid>();
            }
            set
            {
                foreach(Guid id in value)
                {
                    Products.Add(new Product() { Id = id });
                }
            }
        }


        [JsonIgnore]
        [NotMapped]
        public virtual List<Product> Products { get; set; } = new List<Product>();

        [NotMapped]
        public List<Guid> InventoryIds
        {
            get
            {
                return Inventories != null
                    ? Inventories.Select(inventory => inventory.Id).ToList()
                    : new List<Guid>();
            }
            set 
            {
                foreach(Guid id in value)
                {
                    Inventories.Add(new Inventory() { Id = id });
                }
            }

        }


        [JsonIgnore]
        [NotMapped]
        public virtual List<Inventory> Inventories { get; set; } = new List<Inventory>();
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        #region Order Properties

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

        #endregion
        [NotMapped]
        public List<Guid> CustomerIds
        {
            get
            {
                return Customers != null
                    ? Customers.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
            set
            {
                foreach(Guid id in value)
                {
                    Customers.Add(new Customer() { Id = id });
                }
            }
        }


        [JsonIgnore]
        [NotMapped]
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();
        #endregion

        #region Constructors
        public StoreFront()
        {

        }
        #endregion

        #region Methods
        public void SetAddress(ContactInformation contactInformation)
        {
            ContactInformation = contactInformation;
        }

        #region Inventory Methods
        public void AddInventory(Product product, uint amount)
        {
            if (Inventories.Exists(p => p.Product == product))
            {
                Inventories.First(p => p.Product == product).Count += amount;
            }
            else
            {
                Inventories.Add(new Inventory() { Product = product, Count = amount });
            }
        }
        public void RemoveInventory(Product product, uint amount)
        {
            if (Inventories.Exists(p => p.Product == product))
            {
                if (Inventories.First(p => p.Product == product).Count >= amount)
                    Inventories.First(p => p.Product == product).Count -= amount;
                else
                {
                    throw new Exception($"Not enough {product.Name}s in inventory. On-Hand: {Inventories.First(p => p.Product == product).Count}.");
                }
            }
            else
            {
                throw new Exception("Product not included in inventory. Unable to remove.");
            }
        }

        #endregion

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        #region Order Methods

        public void AddOrder(Order order)
        {
            PendingOrders.Add(order);
        }
        public void ProcessNextOrder()
        {
            //Perform Order processing tasks here
            Order order = PendingOrders[0];
            PendingOrders.RemoveAt(0);
            CompletedOrders.Add(order);
        }

        #endregion

        #region Overrides
        public override bool Equals(Object obj)
        {
            return obj is StoreFront && this == (StoreFront)obj;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        /// <summary>
        /// Compares Two StoreFronts for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if StoreFronts Have Same Name and Category</returns>
        public static bool operator ==(StoreFront x, StoreFront y)
        {
            return x?.Id == y?.Id;
        }

        public static bool operator !=(StoreFront x, StoreFront y)
        {
            return !(x == y);
        }
        #endregion

        #endregion



    }

}
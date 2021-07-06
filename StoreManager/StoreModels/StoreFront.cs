using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace StoreModels
{
    public class StoreFront
    {
        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }

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

            }
        }

        [JsonIgnore]
        public ContactInformation ContactInformation { get; set; }


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

            }
        }


        [JsonIgnore]
        public List<Product> Products { get; set; }

        public List<Guid> InventoryIds
        {
            get
            {
                return Inventory != null
                    ? Inventory.Select(inventory => inventory.Id).ToList()
                    : new List<Guid>();
            }
            set 
            {
            
            }

        }


        [JsonIgnore]
        public List<Inventory> Inventory { get; set; }
        public DateTime LastUpdate { get; set; }

        #region Order Properties

        [JsonIgnore]
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

            }
        }

        [JsonIgnore]
        public Queue<Order> PendingOrders { get; set; }


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

            }
        }

        [JsonIgnore]
        public List<Order> CompletedOrders { get; set; }

        #endregion
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

            }
        }


        [JsonIgnore]
        public List<Customer> Customers { get; set; }
        #endregion

        #region Constructors
        public StoreFront()
        {
            Id = Guid.Empty;
            Name = "";
            ContactInformation = new ContactInformation();
            Inventory = new List<Inventory>();
            PendingOrders = new Queue<Order>();
            CompletedOrders = new List<Order>();
            Customers = new List<Customer>();
            Products = new List<Product>();
        }
        public StoreFront(Guid id, string name)
        {
            Id = id;
            Name = name;
            ContactInformation = new ContactInformation();
            Inventory = new List<Inventory>();
            PendingOrders = new Queue<Order>();
            CompletedOrders = new List<Order>();
            Customers = new List<Customer>();
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
            if (Inventory.Exists(p => p.Product == product))
            {
                Inventory.First(p => p.Product == product).Count += amount;
            }
            else
            {
                Inventory.Add(new Inventory() { Product = product, Count = amount });
            }
        }
        public void RemoveInventory(Product product, uint amount)
        {
            if (Inventory.Exists(p => p.Product == product))
            {
                if (Inventory.First(p => p.Product == product).Count >= amount)
                    Inventory.First(p => p.Product == product).Count -= amount;
                else
                {
                    throw new Exception($"Not enough {product.Name}s in inventory. On-Hand: {Inventory.First(p => p.Product == product).Count}.");
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
            PendingOrders.Enqueue(order);
        }
        public void ProcessNextOrder()
        {
            //Perform Order processing tasks here

            CompletedOrders.Add(PendingOrders.Dequeue());
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
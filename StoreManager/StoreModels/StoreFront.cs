using System;
using System.Collections.Generic;
using System.Linq;


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
        }

        public ContactInformation ContactInformation { get; set; }

        public List<Guid> InventoryIds
        {
            get
            {
                return Inventory != null
                    ? Inventory.Keys.Select(product => product.Id).ToList()
                    : new List<Guid>();
            }
        }
        public Dictionary<Product, int> Inventory { get; set; }

        #region Order Properties

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

        #endregion

        public List<Guid> CustomerIds
        {
            get
            {
                return Customers != null
                    ? Customers.Select(order => order.Id).ToList()
                    : new List<Guid>();
            }
        }

        public HashSet<Customer> Customers { get; set; }
        #endregion

        #region Constructors
        public StoreFront()
        {
            Inventory = new Dictionary<Product, int>();
            PendingOrders = new Queue<Order>();
            CompletedOrders = new List<Order>();
            Customers = new HashSet<Customer>();

        }
        public StoreFront(Guid id, string name)
        {
            Id = id;
            Name = name;
            Inventory = new Dictionary<Product, int>();
            PendingOrders = new Queue<Order>();
            CompletedOrders = new List<Order>();
            Customers = new HashSet<Customer>();
        }

        #endregion

        #region Methods
        public void SetAddress(ContactInformation contactInformation)
        {
            ContactInformation = contactInformation;
        }

        #region Inventory Methods
        public void AddInventory(Product product, int amount)
        {
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += amount;
            }
            else
            {
                Inventory.Add(product, amount);
            }
        }
        public void RemoveInventory(Product product, int amount)
        {
            if (Inventory.ContainsKey(product))
            {
                if (Inventory[product] >= amount)
                    Inventory[product] -= amount;
                else
                {
                    throw new Exception($"Not enough {product.Name}s in inventory. On-Hand: {Inventory[product]}.");
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
            return x.Id == y.Id;
        }

        public static bool operator !=(StoreFront x, StoreFront y)
        {
            return !(x == y);
        }
        #endregion

        #endregion



    }

}
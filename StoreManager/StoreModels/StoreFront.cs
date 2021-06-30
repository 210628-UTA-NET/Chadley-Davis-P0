using System;
using System.Collections.Generic;
using System.Linq;
using StoreModels;
namespace StoreModels
{
    public class StoreFront
    {
        public string Name { get; private set; }

        public ContactInformation ContactInformation { get; private set; }
        public Dictionary<Product, int> Inventory { get; private set; }
        
        public Queue<Order> PendingOrders { get; private set; }
        public Queue<Order> CompletedOrders { get; private set; }
        public List<Customer> Customers { get; private set; }
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

        public StoreFront(string name)
        {
            Name = name;
            
            Inventory = new Dictionary<Product, int>();
            Orders = new List<Order>();
            PendingOrders = new Queue<Order>(); 
            CompletedOrders = new Queue<Order>();
            Customers = new List<Customer>();
        }        
        public void SetAddress(ContactInformation contactInformation)
        {
            ContactInformation = contactInformation;
        }
        public void AddInventory(Product product, int amount)
        {
            if(Inventory.ContainsKey(product))
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
            if(Inventory.ContainsKey(product))
            {
                if(Inventory[product] >= amount)
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
        
        public void AddOrder(Order order)
        {            
            PendingOrders.Enqueue(order);
        }
        public void ProcessNextOrder()
        {
            //Perform Order processing tasks here
            
            CompletedOrders.Add(PendingOrders.Dequeue());
        }
        

        public override bool Equals(Object obj)
        {
            return obj is StoreFront && this == (StoreFront)obj;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * Category.GetHashCode();
        }
        /// <summary>
        /// Compares Two StoreFronts for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if StoreFronts Have Same Name and Category</returns>
        public static bool operator ==(StoreFront x, StoreFront y)
        {
            return x.Name == y.Name && x.ContactInformation == y.ContactInformation;
        }

        public static bool operator !=(StoreFront x, StoreFront y)
        {
            return !(x == y);
        }
    }

}
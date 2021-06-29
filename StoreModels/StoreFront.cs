using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreManager
{
    public class StoreFront
    {
        public string Name { get; private set; }

        public ContactInformation ContactInformation { get; private set; }
        public Dictionary<Product, int> Inventory { get; set; }
        public StoreFront(string name)
        {
            Name = name;
            ProductEqualityComparer productEqC = new ProductEqualityComparer();
            Inventory = new Dictionary<Product, int>(productEqC);
            
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
    }

}
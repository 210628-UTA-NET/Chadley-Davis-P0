using System;

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
            if(Inventory[product] != null)
            {
                Inventory[product].Value += amount;
            }
            else
            {
                Inventory.Add(product, amount);
            }
        }
        public void RemoveInventory(Product product, int amount)
        {
            if(Inventory[product] != null)
            {
                if(Inventory[product].Value >= amount)
                    Inventory[product].Value -= amount;
                else
                {
                    throw Exception($"Not enough {product.Name}s in inventory. On-Hand: {Inventory[product].Value}.");
                }
            }
            else
            {
                throw Exception("Product not included in inventory. Unable to remove.");
            }
        }
    }

}
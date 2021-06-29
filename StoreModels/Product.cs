using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreManager
{
    public class Product
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product p1, Product p2)
        {
            if (p2 == null && p1 == null)
            return true;
            else if (p1 == null || p2 == null)
            return false;
            else if(p1.Name == p2.Name)
                return true;
            else
                return false;
        }

        public int GetHashCode(Product p)
        {
            return p.Name.GetHashCode();
        }
    }
}
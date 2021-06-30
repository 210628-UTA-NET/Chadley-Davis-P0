using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreModels
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
        public Product(int id, string name, string description, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public override bool Equals(Object obj)
        {
            return obj is Product && this == (Product)obj;
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
        public static bool operator ==(Product x, Product y)
        {
            return x.Name == y.Name && x.Category == y.Category;
        }

        public static bool operator !=(Product x, Product y)
        {
            return !(x == y);
        }
    }
    
}
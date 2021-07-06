using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreModels
{
    public class Product
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Guid StoreFrontId { get { return StoreFront != null ? StoreFront.Id : Guid.Empty; } }
        public StoreFront StoreFront { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructors
        public Product()
        {

        }
        public Product(Guid id, string name, string description, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }

        #endregion

        #region Methods

        public void SetPrice(decimal price)
        {
            Price = price;
        }

        #region Overrides

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
            return x?.Id == y?.Id;
        }

        public static bool operator !=(Product x, Product y)
        {
            return !(x == y);
        }

        #endregion


        #endregion



    }
    
}
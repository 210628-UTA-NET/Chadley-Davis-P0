﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModels
{
    public class Inventory
    {

        public Guid Id { get; set; }
        public Guid ProductId { get { return Product != null ? Product.Id : Guid.Empty; } }

        public Product Product { get; set; }

        public uint Count { get; set; }



        #region Overrides
        public override bool Equals(Object obj)
        {
            return obj is Inventory && this == (Inventory)obj;
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
        public static bool operator ==(Inventory x, Inventory y)
        {
            return x?.Id == y?.Id;
        }

        public static bool operator !=(Inventory x, Inventory y)
        {
            return !(x == y);
        }
        #endregion
    }
}

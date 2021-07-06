using System;
using System.Text.Json.Serialization;

namespace StoreModels
{
    public class Detail
    {
        #region Properties

        public Guid Id { get; set; }

        public Guid ProductId
        {
            get
            {
                return Product != null
                    ? Product.Id
                    : Guid.Empty;
            }
        }
        [JsonIgnore]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId
        {
            get
            {
                return Order != null
                    ? Order.Id
                    : Guid.Empty;
            }
        }
        [JsonIgnore]
        public Order Order { get; set; }
        public DateTime LastUpdate { get; set; }

        #endregion
        #region Constructors

        public Detail()
        {

        }
        public Detail(Guid id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        #endregion
        #region Methods

        public void ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
        public decimal Total()
        {
            return Product.Price * Quantity;
        }

        #region Overrides

        public override bool Equals(Object obj)
        {
            return obj is Detail && this == (Detail)obj;
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
        public static bool operator ==(Detail x, Detail y)
        {
            return x?.Id == y?.Id;
        }

        public static bool operator !=(Detail x, Detail y)
        {
            return !(x == y);
        }

        #endregion


        #endregion




    }

}
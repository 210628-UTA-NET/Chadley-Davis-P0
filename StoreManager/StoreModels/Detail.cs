using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoreModels
{
    public class Detail
    {
        #region Properties

        public Guid Id { get; set; } = Guid.NewGuid();

        [NotMapped]
        public Guid ProductId
        {
            get
            {
                return Product != null
                    ? Product.Id
                    : Guid.Empty;
            }
            set
            {
                Product.Id = value;
            }
        }
        [JsonIgnore]
        [NotMapped]
        public virtual Product Product { get; set; } = new Product();
        public int Quantity { get; set; } = 0;

        [NotMapped]
        public Guid OrderId
        {
            get
            {
                return Order != null
                    ? Order.Id
                    : Guid.Empty;
            }
            set
            {
                Order.Id = value;
            }
        }
        [JsonIgnore]
        [NotMapped]
        public virtual Order Order { get; set; } = new Order();
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        #endregion
        #region Constructors

        public Detail()
        {

        }
        public Detail(Guid id, Product product, int quantity, Order order)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            Order = order;
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
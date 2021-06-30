using System;

namespace StoreModels
{
    public class Detail
    {
        public int Id { get; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Detail(int id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
        public void ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
        public decimal Total()
        {
            return Product.Price * Quantity;
        }
    }

}
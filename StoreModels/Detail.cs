using System;

namespace StoreManager
{
    public class Detail
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Detail(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public void ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }

}
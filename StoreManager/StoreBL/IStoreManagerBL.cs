using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{

    /// <summary>
    /// StoreManager model CRUD
    /// Readies Data For Client View
    /// </summary>
    public interface IStoreManagerBL
    {
        DBModel DBContext { get; set; }
        List<StoreFront> GetStoreFronts(string searchTerm);
        StoreFront GetStoreFront(Guid id);
        StoreFront AddStoreFront(StoreFront storeFront);
        List<Product> GetProducts(StoreFront storeFront);
        Product GetProduct(Guid id);
        Product AddProduct(Product product);
        List<Order> GetOrders(Customer customer);
        List<Order> GetOrders(StoreFront storeFront);
        List<Order> GetOrders(StoreFront storeFront, Customer customer);
        Order GetOrder(Guid id);
        Order AddOrder(Order order);
        List<Detail> GetDetails(Order order);
        Detail GetDetail(Guid id);
        Detail AddDetail(Detail detail);
        List<Customer> GetCustomers(StoreFront storeFront);
        Customer GetCustomer(Guid id);
        Customer AddCustomer(Customer customer);
        ContactInformation GetContactInformation(Customer customer);
        ContactInformation GetContactInformation(StoreFront storeFront);
        ContactInformation GetContactInformation(Guid id);
        Address GetAddress(ContactInformation contactInformation);
        Address GetAddress(Guid id);
    }
}

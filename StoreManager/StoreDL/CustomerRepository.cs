using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using StoreModels;

namespace StoreDL
{
    public class CustomerRepository : IRepository<Customer>
    {
        private const string _filePath = "./../StoreDL/Database/Customers.json";
        private string _jsonString;

        public DBModel _DBContext { get; set; }

        public Task<Customer> Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll(Customer match)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
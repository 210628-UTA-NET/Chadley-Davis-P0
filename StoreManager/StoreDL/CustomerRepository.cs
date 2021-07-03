using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModels;

namespace StoreDL
{
    public class CustomerRepository : IRepository<Customer>
    {
        private const string _filePath = "./../StoreDL/Database/Customers.json";
        private string _jsonString;

        public DBModel _DBContext { get; set; }

        public Customer Add(Customer p_rest)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }
            using (FileStream s = File.Open(_filePath, FileMode.Open))
            {
                var results = JsonSerializer.DeserializeAsync<List<Customer>>(s);
                customers.AddRange(results.Result);

                //This will return a list of restaurant from the jsonString that came from 
            }
            return customers;
        }

        public Customer Get(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
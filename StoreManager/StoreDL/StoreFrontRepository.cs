using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModels;

namespace StoreDL
{
    public class StoreFrontRepository : IRepository<StoreFront>
    {
        private const string _filePath = "./../StoreDL/Database/StoreModels.json";
        private string _jsonString;

        public DBModel _DBContext { get; set; }

        public StoreFrontRepository(DBModel _dbContext)
        {
            _DBContext = _dbContext;
        }
        public StoreFront Add(StoreFront p_rest)
        {
            throw new System.NotImplementedException();
        }

        public List<StoreFront> GetAll()
        {
            List<StoreFront> storeFronts = new List<StoreFront>();
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }
            
            return storeFronts;
        }

        public StoreFront Get(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
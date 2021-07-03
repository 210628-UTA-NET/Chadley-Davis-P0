using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using StoreModels;

namespace StoreDL
{
    public class StoreFrontRepository : IRepository<StoreFront>
    {
        private const string _filePath = "./../StoreDL/Database/StoreFronts.json";
        private string _jsonString;

        public DBModel _DBContext { get; set; }

        public StoreFrontRepository(DBModel _dbContext)
        {
            _DBContext = _dbContext;
        }
        public StoreFront Add(StoreFront storeFront)
        {
            try
            {
                _jsonString = File.ReadAllText(_filePath);


                using (FileStream s = File.Open(_filePath, FileMode.Open))
                {
                    var results = JsonSerializer.DeserializeAsync<DBModel>(s);
                    storeFront.Id = Guid.NewGuid();
                    results.Result.StoreFronts.Add(storeFront);                    
                    JsonSerializer.SerializeAsync(s, results.Result);

                }
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            return storeFront;
        }

        public List<StoreFront> GetAll(StoreFront match)
        {
            List<StoreFront> storeFronts = new List<StoreFront>();
            try
            {
                _jsonString = File.ReadAllText(_filePath);


                using (FileStream s = File.Open(_filePath, FileMode.Open))
                {
                    var results = JsonSerializer.DeserializeAsync<List<StoreFront>>(s);
                    storeFronts.AddRange(results.Result);

                    //This will return a list of restaurant from the jsonString that came from 
                }
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StoreModels;

namespace StoreDL
{
    public class StoreFrontRepository : IRepository<StoreFront>
    {
        private const string _filePath = "/../../../../StoreDL/Database/StoreManager.json";
        private string _jsonString;

        public DBModel _DBContext { get; set; }

        public StoreFrontRepository(DBModel _dbContext)
        {
            _DBContext = _dbContext;
        }
        public async Task<StoreFront> Add(StoreFront storeFront)
        {
            try
            {
                using FileStream createStream = File.OpenRead(Environment.CurrentDirectory + _filePath);
                DBModel results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);
                await createStream.DisposeAsync();
                results.StoreFronts.Add(storeFront);
                using FileStream updateStream = File.OpenWrite(Environment.CurrentDirectory + _filePath);
                await JsonSerializer.SerializeAsync<DBModel>(updateStream, results);
                await updateStream.DisposeAsync();
                //storeFronts = results.StoreFronts;


                
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            return storeFront;
        }

        public async Task<List<StoreFront>> GetAll(StoreFront match)
        {
            List<StoreFront> storeFronts = new List<StoreFront>();
            try
            {
                using FileStream createStream = File.OpenRead(Environment.CurrentDirectory + _filePath);
                var results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);
                storeFronts = results.StoreFronts;
                await createStream.DisposeAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }
            
            return storeFronts;
        }

        public async Task<StoreFront> Get(Guid Id)
        {

            StoreFront storeFront = new StoreFront();
            try
            {
                using FileStream createStream = File.OpenWrite(_filePath);
                var results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);
                storeFront = results.StoreFronts.First(sf => sf.Id == Id);
                await createStream.DisposeAsync();
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            return storeFront;
        }


    }
}
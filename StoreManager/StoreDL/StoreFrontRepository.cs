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


        public DBModel _DBContext { get; set; }

        public StoreFrontRepository(DBModel _dbContext)
        {
            _DBContext = _dbContext;
        }
        public async Task<StoreFront> Add(StoreFront storeFront)
        {
            try
            {
                DBModel results = new DBModel();
                using (FileStream createStream = File.OpenRead(Environment.CurrentDirectory + _filePath))
                {
                    results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);

                    results.StoreFronts.Add(storeFront);
                    createStream.Dispose();
                }

                using (FileStream updateStream = File.OpenWrite(Environment.CurrentDirectory + _filePath))
                {
                    var jsonresult = JsonSerializer.SerializeAsync<DBModel>(updateStream, results);
                }
                
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
                using (FileStream createStream = File.OpenRead(Environment.CurrentDirectory + _filePath))
                {
                    
                    var results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);

                    if (results.StoreFronts != null)
                        storeFronts = results.StoreFronts.Where(s => s.Name != null && (s.Name == "" || s.Name.Contains(match.Name))).ToList();
                }
                
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
                using (FileStream createStream = File.OpenRead(Environment.CurrentDirectory + _filePath))
                {
                    var results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);

                    if(results != null)
                        storeFront = results.StoreFronts.First(sf => sf.Id == Id);
                }
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            return storeFront;
        }

        public async Task<StoreFront> Update(StoreFront storeFront)
        {

            try
            {
                DBModel results = new DBModel();
                using (FileStream createStream = File.OpenRead(Environment.CurrentDirectory + _filePath))
                {
                    results = await JsonSerializer.DeserializeAsync<DBModel>(createStream);
                }
                bool removed = results.StoreFronts.Remove(storeFront); 
                results.StoreFronts.Add(storeFront);
                using (FileStream updateStream = File.OpenWrite(Environment.CurrentDirectory + _filePath))
                {
                    await JsonSerializer.SerializeAsync<DBModel>(updateStream, results);
                }
                

            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            return storeFront;

        }
    }
}
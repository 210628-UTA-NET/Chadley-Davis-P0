using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StpreModels;

namespace StoreDL
{
    public class StoreFrontRepository : IRepository<StoreFront>
    {
        private const string _filePath = "./../StoreDL/Database/StoreFronts.json";
        private string _jsonString;
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
            using (FileStream s = File.Open(_filePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        StoreFront storeFront = serializer.Deserialize<StoreFront>(reader);
                        storeFronts.Add(storeFront);
                    }
                }
            }
            //This will return a list of restaurant from the jsonString that came from 
            return JsonSerializer.Deserialize<List<Restaurant>>(_jsonString);
        }

        public StoreFront Get(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
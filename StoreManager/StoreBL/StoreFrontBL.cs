using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public class StoreFrontBL : IBL<StoreFront>
    {


        private IRepository<StoreFront> Repo { get; set; }

        public StoreFrontBL()
        {
            if (Repo == null)
                Repo = new StoreFrontRepository(new DBModel());
            
        }
        public StoreFrontBL(DBModel db)
        {
            if (Repo == null)
                Repo = new StoreFrontRepository(db);
        }


        public StoreFront Add(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public StoreFront Get(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAll(StoreFront searchItem)
        {
            Repo._DBContext.StoreFronts.AddRange(Repo.GetAll(new StoreFront() { Name = searchItem.Name }));
            return Repo._DBContext.StoreFronts.Where(sf => sf.Name.ToLower().Contains(searchItem.Name)).ToList();
        }

        public void Remove(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public StoreFront Update(StoreFront item)
        {
            throw new NotImplementedException();
        }
    }
}

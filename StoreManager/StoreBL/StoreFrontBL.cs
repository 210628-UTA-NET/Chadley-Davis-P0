using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public class StoreFrontBL : BL<StoreFront>
    {
        public StoreFrontBL(DBModel db) : base(db)
        {
            Repo = new StoreFrontRepository(db);
        }

        IRepository<StoreFront> Repo { get; set; }

        public override async Task<StoreFront> Add(StoreFront item)
        {
            var result = await Repo.Add(item);
            Repo._DBContext.StoreFronts.Add(result);
            return result;
        }

        public override async Task<StoreFront> Get(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<StoreFront>> GetAll(StoreFront searchItem)
        {
            var result = await Repo.GetAll(searchItem);
            Repo._DBContext.StoreFronts.AddRange(result);
            return Repo._DBContext.StoreFronts;
        }


        public override async Task Remove(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public override async Task<StoreFront> Update(StoreFront item)
        {
            StoreFront result = await Repo.Update(item);
            return result;
        }
    }
}

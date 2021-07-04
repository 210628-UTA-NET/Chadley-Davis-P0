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

        public override StoreFront Add(StoreFront item)
        {
            var result = Repo.Add(item);
            Repo._DBContext.StoreFronts.Add(result.Result);
            return result.Result;
        }

        public override StoreFront Get(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public override List<StoreFront> GetAll(StoreFront searchItem)
        {
            var result = Repo.GetAll(new StoreFront() { Name = searchItem.Name });
            Repo._DBContext.StoreFronts.AddRange(result.Result);
            return Repo._DBContext.StoreFronts;
        }


        public override void Remove(StoreFront item)
        {
            throw new NotImplementedException();
        }

        public override StoreFront Update(StoreFront item)
        {
            throw new NotImplementedException();
        }
    }
}

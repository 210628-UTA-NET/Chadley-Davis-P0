﻿using StoreDL;
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

        public async override Task<List<StoreFront>> GetAll(StoreFront searchItem)
        {
            var result = await Repo.GetAll(searchItem);
            Repo._DBContext.StoreFronts.AddRange(result);
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

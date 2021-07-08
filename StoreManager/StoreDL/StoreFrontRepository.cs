using Microsoft.EntityFrameworkCore;
using Models.Entities;
using StoreDL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class StoreFrontRepository : IRepository<StoreFront>
    {

        protected StoreManagerDBContext DBContext { get; set; }
        public StoreFrontRepository()
        {
            if (DBContext == null)
                DBContext = new StoreManagerDBContext();
        }
        public StoreFrontRepository(StoreManagerDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public async Task<StoreFront> Add(StoreFront item)
        {
            DBContext.StoreFronts.Add(item);
            await DBContext.SaveChangesAsync();
            return item;
        }

        public async Task<StoreFront> Get(Guid Id)
        {
            return await DBContext.StoreFronts.FirstOrDefaultAsync(sf => sf.Id == Id);
        }

        public async Task<List<StoreFront>> GetAll(StoreFront match)
        {
            return await DBContext.StoreFronts.ToListAsync();
        }

        public async Task Update(StoreFront item)
        {
            DBContext.StoreFronts.Update(item);
            await DBContext.SaveChangesAsync();

        }
    }
}

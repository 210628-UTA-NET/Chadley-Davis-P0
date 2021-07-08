using Microsoft.EntityFrameworkCore;
using Models.Entities;
using StoreDL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public class StoreFrontBL : IBL<StoreFront>
    {
        StoreManagerDBContext DBContext { get; set; }
        public StoreFrontBL()
        {
            DBContext = new StoreManagerDBContext();
        }
        public async Task<StoreFront> Add(StoreFront item)
        {
            await DBContext.StoreFronts.AddAsync(item);
            await DBContext.SaveChangesAsync();
            return item;
        }

        public async Task<StoreFront> Get(Guid id)
        {
            return await DBContext.StoreFronts.FirstOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<List<StoreFront>> GetAll()
        {
            return await DBContext.StoreFronts.ToListAsync();
        }

        public async Task Remove(StoreFront item)
        {
            DBContext.StoreFronts.Remove(item);
            await DBContext.SaveChangesAsync();
        }

        public async Task<StoreFront> Update(StoreFront item)
        {
            DBContext.StoreFronts.Update(item);
            await DBContext.SaveChangesAsync();
            return item;
        }
    }
}

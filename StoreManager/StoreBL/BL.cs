using StoreDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public abstract class BL<T>
    {
        protected DBModel dBModel { get; set; }

        public BL(DBModel dB)
        {
            dBModel = dB;
        }
        public abstract Task<T> Add(T item);

        public abstract Task<T> Get(T item);

        public abstract Task<List<T>> GetAll(T searchItem);

        public abstract Task Remove(T item);

        public abstract Task<T> Update(T item);
    }
}

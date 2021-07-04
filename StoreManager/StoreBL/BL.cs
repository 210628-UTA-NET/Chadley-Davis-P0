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
        public abstract T Add(T item);

        public abstract T Get(T item);

        public abstract List<T> GetAll(T searchItem);

        public abstract void Remove(T item);

        public abstract T Update(T item);
    }
}

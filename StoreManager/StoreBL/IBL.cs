using StoreDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    interface IBL<T>
    {
        T Add(T item);
        T Update(T item);
        void Remove(T item);

        T Get(T item);
        List<T> GetAll(T searchItem);
    }
}

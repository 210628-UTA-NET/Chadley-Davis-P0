using StoreDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public interface IBL<T>
    {

        Task<T> Add(T item);

        Task<T> Get(Guid id);

        Task<List<T>> GetAll();

        Task Remove(T item);

        Task<T> Update(T item);
    }
}

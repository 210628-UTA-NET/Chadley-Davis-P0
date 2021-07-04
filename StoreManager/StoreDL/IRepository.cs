using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreModels;

namespace StoreDL
{
    /// <summary>
    /// It is responsible for accessing our database (in this case it will be a JSON file stored in our folder)
    /// </summary>
    public interface IRepository<T>
    {
        DBModel _DBContext { get; }
        /// <summary>
        /// Gets a list of T stored in our database
        /// </summary>
        /// <returns>Returns a list of T</returns>
        Task<List<T>> GetAll(T match);

        /// <summary>
        /// It will get a specific T
        /// </summary>
        /// <param name="p_rest">This T object will be used to check the properties that should match in the database</param>
        /// <returns>Will return the T object from the database</returns>
        Task<T> Get(Guid Id);

        /// <summary>
        /// It will add a T in our database
        /// </summary>
        /// <param name="p_rest">This is the T object that will be added to the database</param>
        /// <returns>Will return the T object we just added</returns>
        Task<T> Add(T item);
    }
}

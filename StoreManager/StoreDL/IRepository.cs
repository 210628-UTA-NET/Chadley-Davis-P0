using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    /// <summary>
    /// It is responsible for accessing our database (in this case it will be a JSON file stored in our folder)
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets a list of T stored in our database
        /// </summary>
        /// <returns>Returns a list of T</returns>
        List<T> GetAll();

        /// <summary>
        /// It will get a specific T
        /// </summary>
        /// <param name="p_rest">This T object will be used to check the properties that should match in the database</param>
        /// <returns>Will return the T object from the database</returns>
        T Get(int Id);

        /// <summary>
        /// It will add a T in our database
        /// </summary>
        /// <param name="p_rest">This is the T object that will be added to the database</param>
        /// <returns>Will return the T object we just added</returns>
        T Add(T item);
    }
}

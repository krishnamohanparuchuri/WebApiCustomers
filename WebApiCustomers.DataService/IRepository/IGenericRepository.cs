using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCustomers.DataService.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //get all entities
        Task<IEnumerable<T>> All();
        
        // get specific entity based on ID
        Task<T> GetById(Guid id);
        
        // create a new entity
        Task<bool> Add(T entity);
        
        // delete the specific entity
        Task<bool> Delete(Guid id,string userId);
        
        // updating an entity
        Task<bool> Upsert(T entity);

    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    // Interface of the GenericRepository methods that I can make us of. 
    public interface IGenericRepository<T> where T : BaseEntity
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
    }
}
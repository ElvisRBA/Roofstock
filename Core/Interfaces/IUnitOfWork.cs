using System;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    // Interface of the UnitOfWork methods that I can make us of. 
    public interface IUnitOfWork : IDisposable
    {
         IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
         Task<int> Complete();
    }
}
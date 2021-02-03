using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    // Here is the implementation of the IUnitOfWork Interface and in here is where the changes are tracked, and updated to the database.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoofstockContext _context;
        private Hashtable _repositories;
        public UnitOfWork(RoofstockContext context)
        {
            _context = context;
        }

        // This method is responsible of saving the changes, and its atomic, all the tracked changes happen or none.
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        // This method is responsible of tracking the changes from an especific the entity.
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }
    }
}
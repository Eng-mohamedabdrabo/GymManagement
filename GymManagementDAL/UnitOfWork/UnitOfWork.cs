using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.implementation;
using GymManagementDAL.Reposetories.interfaces;

namespace GymManagementDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContexts _dbContext;

        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(GymDbContexts dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepositoryInterface<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_dbContext);
                _repositories[type] = repository;
            }

            return (IGenericRepositoryInterface<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}

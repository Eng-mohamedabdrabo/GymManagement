using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.implementation
{
    public class GenericRepository<TEntity> : IGenericRepositoryInterface<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly GymDbContexts _dbContexts;
        public GenericRepository(GymDbContexts dbContext)
        {
            _dbContexts = dbContext;
        }
        public void Add(TEntity iEntity)
        {
            _dbContexts.Set<TEntity>().Add(iEntity);
        }

        public void Delete(TEntity iEntity)
        {
            _dbContexts.Set<TEntity>().Remove(iEntity);
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
            if (condition is null)
                return _dbContexts.Set<TEntity>().AsNoTracking().ToList();
            else
                return _dbContexts.Set<TEntity>().AsNoTracking().Where(condition);
        }

        public TEntity GetById(int id) => _dbContexts.Set<TEntity>().Find(id);
      

        public void Update(TEntity iEntity)
        {
            _dbContexts.Set<TEntity>().Update(iEntity);
        }
    }
}

using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepositoryInterface<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new();
        int SaveChanges();
    }
}

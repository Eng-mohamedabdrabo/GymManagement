using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.implementation
{
    internal class GenericRepository<TEntity> : IGenericRepositoryInterface
        where TEntity : BaseEntity, new()
    {
    }
}

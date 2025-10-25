using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    public interface IGenericRepositoryInterface<IEntity> 
        where IEntity : BaseEntity , new()
    {
        IEnumerable<IEntity> GetAll(Func<IEntity,bool>? condition = null);

        IEntity GetById(int id);

        void Add(IEntity iEntity);
        void Update(IEntity iEntity);
        void Delete(IEntity iEntity);
    }
}

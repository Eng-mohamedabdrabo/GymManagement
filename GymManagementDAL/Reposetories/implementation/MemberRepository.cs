using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.implementation
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly GymDbContexts _dbContext;
        public int AddMembers(Members member)
        {
            _dbContext.Members.Add(member);
            return _dbContext.SaveChanges();
        }

        public int DeleteMember(int id)
        {
          var member =  _dbContext.Members.Find(id);

            if (member is null)
                return 0;

            _dbContext.Members.Remove(member);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<Members> GetAllMembers() => _dbContext.Members.ToList();


        public Members GetMember(int id) => _dbContext.Members.Find(id);
       

        public int UpdateMembers(Members member)
        {
            _dbContext.Members.Update(member);
            return _dbContext.SaveChanges();
        }
    }
}

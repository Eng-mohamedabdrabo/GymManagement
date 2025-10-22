using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.implementation
{
    internal class SessionRepository : ISessionsInterface
    {
        private readonly GymDbContexts _dbContext;
        public int AddSession(Sessions Session)
        {
            _dbContext.Sessions.Add(Session);
            return _dbContext.SaveChanges();
        }

        public int DeleteSession(int id)
        {
           var session = _dbContext.Sessions.Find(id);
            if (session is null)
                return 0;
            _dbContext.Sessions.Remove(session);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Sessions> GetAllSessions() => _dbContext.Sessions.ToList();

        public Sessions GetSession(int id) => _dbContext.Sessions.Find(id);
        

        public int UpdateSession(Sessions Session)
        {
            _dbContext.Sessions.Update(Session);
            return _dbContext.SaveChanges();
        }
    }
}

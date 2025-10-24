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
    public class PlanRepository : IPlansInterface
    {
        private readonly GymDbContexts _dbContext;
        public PlanRepository(GymDbContexts dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Plans> GetAllPlans() => _dbContext.Plans.ToList();
       

        public Plans GetPlan(int id) => _dbContext.Plans.Find(id);
        

        public int UpdatePlan(Plans Plan)
        {
            _dbContext.Plans.Update(Plan);
            return _dbContext.SaveChanges();
        }
    }
}

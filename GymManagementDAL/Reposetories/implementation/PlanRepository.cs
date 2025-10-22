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
    internal class PlanRepository : IPlansInterface
    {
        private readonly GymDbContexts _dbContext;
        public int AddPlan(Plans Plan)
        {
            _dbContext.Plans.Add(Plan);
            return _dbContext.SaveChanges();
        }

        public int DeletePlan(int id)
        {
            var plan = _dbContext.Plans.Find(id);

            if (plan is null)
                return 0;

            _dbContext.Plans.Remove(plan);
            return _dbContext.SaveChanges();
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

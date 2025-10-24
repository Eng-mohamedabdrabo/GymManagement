using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    public interface IPlansInterface
    {
        //GETALL
        IEnumerable<Plans> GetAllPlans();
        //GETBYID
        Plans GetPlan(int id);
        //UPDATE
        int UpdatePlan(Plans Plan);
       
    }
}

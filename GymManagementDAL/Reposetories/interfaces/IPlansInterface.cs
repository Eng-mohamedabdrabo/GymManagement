using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    internal interface IPlansInterface
    {
        //GETALL
        IEnumerable<Plans> GetAllPlans();
        //GETBYID
        Plans GetPlan(int id);
        //ADD
        int AddPlan(Plans Plan);
        //UPDATE
        int UpdatePlan(Plans Plan);
        //DELETE
        int DeletePlan(int id);
    }
}

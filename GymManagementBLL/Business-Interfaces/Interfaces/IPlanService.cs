using GymManagementBLL.View_Models.Plan_View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Interfaces
{
    internal interface IPlanService
    {
        IEnumerable<PlanViewModel> GetAllPlans();

        PlanViewModel? GetPlanDetails(int PlanId);

        PlanToUpdateViewModel? GetPlanToUpdate(int PlanId);

        bool UpdatePlan(int planId, PlanToUpdateViewModel planToUpdate);

        bool Toggle(int planId);
    }
}

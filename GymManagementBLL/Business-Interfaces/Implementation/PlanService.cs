using GymManagementBLL.Business_Interfaces.Interfaces;
using GymManagementBLL.View_Models.Plan_View_Models;
using GymManagementDAL.Entities;
using GymManagementDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Implementation
{
    internal class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var plans = _unitOfWork.GetRepository<Plans>().GetAll(x => x.IsActive == true);

            if (plans is null || !plans.Any())
                return [];

            return plans.Select(x => new PlanViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                DurationDays = x.DurationDays,
                Price = x.Price,
                IsActive = x.IsActive
            });
        }

        public PlanViewModel? GetPlanDetails(int planId)
        {
            var plan = _unitOfWork.GetRepository<Plans>().GetById(planId);

            if (plan is null || !plan.IsActive || HasActiveMemberShip(planId))
                return null;

            return new PlanViewModel
            {
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
                IsActive = plan.IsActive
            };
        }


        public PlanToUpdateViewModel? GetPlanToUpdate(int planId)
        {
            var plan = _unitOfWork.GetRepository<Plans>().GetById(planId);

            if (plan is null || !plan.IsActive)
                return null;

            return new PlanToUpdateViewModel
            {
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price
            };
        }


        public bool Toggle(int planId)
        {
            try
            {
                var planRepo = _unitOfWork.GetRepository<Plans>();
                var plan = planRepo.GetById(planId);

                if (plan is null)
                    return false;

                (plan.IsActive, plan.UpdatedAt) = (!plan.IsActive, DateTime.Now);

                planRepo.Update(plan);
                var result = _unitOfWork.SaveChanges();

                return result > 0;
            }
            catch (Exception )
            {
                return false;
            }
        }


        public bool UpdatePlan(int planId, PlanToUpdateViewModel planToUpdate)
        {
            try
            {
                var plan = _unitOfWork.GetRepository<Plans>().GetById(planId);

                if (plan is null || !plan.IsActive)
                    return false;

                plan.Name = planToUpdate.Name;
                plan.Description = planToUpdate.Description;
                plan.DurationDays = planToUpdate.DurationDays;
                plan.Price = planToUpdate.Price;
                plan.UpdatedAt = DateTime.Now;

                _unitOfWork.GetRepository<Plans>().Update(plan);
                var result = _unitOfWork.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #region Helper
        bool HasActiveMemberShip(int planId)
        {
           var memberShipStatus = _unitOfWork.GetRepository<Memberships>()
                .GetAll(X => X.PlansId == planId && X.Status == "Active").Any();
            return memberShipStatus ;
        }
        #endregion
    }
}

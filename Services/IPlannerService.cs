using NetworkPlanner.Model;
using NetworkPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Services
{
    public interface IPlannerService
    {
        PlanViewModel GeneratePlan(PlanViewModel plan);
        Task SavePlanAsync(PlanViewModel planViewModel, string userName);
        Task<IEnumerable<PlanForListViewModel>> GetUsersPlansAsync(string userId);
        Task<Plan> GetPlanAsync(int planId);
    }
}

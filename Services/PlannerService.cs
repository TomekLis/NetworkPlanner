using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetworkPlanner.Data;
using NetworkPlanner.Helpers;
using NetworkPlanner.Model;
using NetworkPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Services
{
    public class PlannerService : IPlannerService
    {
        private readonly ICalculationService _calculationService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public PlannerService(ICalculationService calculationService, IMapper mapper, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _calculationService = calculationService;
            _mapper = mapper;
        }
        public PlanViewModel GeneratePlan(PlanViewModel plan)
        {
            plan.Cirf = _calculationService.CalculateCirf(plan.RequiredCi, plan.Grid.CellShape);
            plan.ClusterSize = _calculationService.FindMinimalNValue(plan.Cirf, plan.Grid.CellShape);
            plan.ChannelReuseDistnace = _calculationService.CalculateReuseDistance(plan.Cirf, plan.CellRange);
            plan.SystemCapacity = plan.Grid.Cells.Count * _calculationService.CalculateCellCapacity(plan.ChannelMax, plan.ChannelMin, plan.ClusterSize);
            plan.Eirp = _calculationService.CalculateEirp(plan.TransmitterPower, plan.CableLoss, plan.AntennaGain);

            return plan;
        }

        public async Task<Plan> GetPlanAsync(int planId)
        {
            var plan = await _dbContext.Plans
                .Include(p => p.User)
                .Include(p => p.Grid)
                    .ThenInclude(g => g.Cells).ThenInclude(c => c.Vertices).ThenInclude(x => x.LatLng)
                .Include(p => p.Grid).
                    ThenInclude(g => g.Cells).ThenInclude(c => c.Center)
                .Where(x => x.Id == planId).AsNoTracking().FirstOrDefaultAsync();
            return plan;
        }

        public async Task<IEnumerable<PlanForListViewModel>> GetUsersPlansAsync(string userId)
        {
            var plansViewModel = await _dbContext.Plans.Where(x => x.User.UserName == userId).AsNoTracking().ToListAsync();
            var plans = _mapper.Map<IEnumerable<PlanForListViewModel>>(plansViewModel);
            return plans;
        }

        public async Task SavePlanAsync(PlanViewModel planViewModel, string userName)
        {
            var plan = _mapper.Map<Plan>(planViewModel);
            plan.User = _dbContext.AppUsers.FirstOrDefault(x => x.UserName == userName);
            await _dbContext.Plans.AddAsync(plan);
            await _dbContext.SaveChangesAsync();
        }
    }
}


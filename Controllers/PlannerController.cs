using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NetworkPlanner.Services;
using NetworkPlanner.ViewModels;
using System.Security.Claims;
using AutoMapper;
using System.Linq;

namespace NetworkPlanner.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlannerController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly IPlannerService _plannerService;
        private readonly IMapper _mapper;
        public PlannerController(ICalculationService calculationService, IPlannerService plannerService, IMapper mapper)
        {
            _calculationService = calculationService;
            _plannerService = plannerService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("calculateCellRadius")]
        public IActionResult CalculateCellRadius(CellRadiusCalculationViewModel cellRadiusCalculationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cellRadius = _calculationService.CalculateCellRadius(cellRadiusCalculationViewModel);
            return new OkObjectResult(cellRadius);
        }
        [AllowAnonymous]
        [HttpPost("generatePlan")]
        public IActionResult GeneratePlan(PlanViewModel planViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            planViewModel = _plannerService.GeneratePlan(planViewModel);
            return new OkObjectResult(planViewModel);
        }

        [HttpPost("savePlan")]
        public async Task<IActionResult> SavePlanAsync(PlanViewModel planViewModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _plannerService.SavePlanAsync(planViewModel, userId);
            return Ok();
        }

        [HttpGet("getPlans")]
        public async Task<IActionResult> GetPlans()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var usersPlans = await _plannerService.GetUsersPlansAsync(userId);
            return new OkObjectResult(usersPlans);
        }

        [HttpGet("getPlan/{id}")]
        public async Task<IActionResult> GetPlan(int id)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var usersPlan = await _plannerService.GetPlanAsync(id);
            if(userName != usersPlan.User.UserName)
            {
                return new UnauthorizedResult();
            }
            var plan = _mapper.Map<PlanViewModel>(usersPlan);
            foreach (var cell in plan.Grid.Cells)
            {
                cell.Vertices = cell.Vertices.OrderBy(x => x.Position).ToList();
            }
            return new OkObjectResult(plan);
        }
    }
}

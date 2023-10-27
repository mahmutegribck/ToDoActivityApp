using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using ToDoActivityAppAPI.Business.Activities;
using ToDoActivityAppAPI.Business.Activities.DTOs;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        private readonly UserManager<ApplicationUser> _userManager;

        public ActivityController(IActivityService activityService, UserManager<ApplicationUser> userManager)
        {
            _activityService = activityService;
            _userManager = userManager;
         }


        [HttpPatch]
        [Route("[action]/{activityId}")]
        public async Task<IActionResult> ActivityDone(int activityId)
        {
            var activityDone = await _activityService.ActivityDone(activityId);
            if (activityDone != null)
            {
                return Ok(activityDone);
            }

            return NotFound();

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityDTO createActivityDTO)
        {
            
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var activity = await _activityService.CreateActivity(currentUser.Id, createActivityDTO);

                if (activity != null)
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();

        }

        [HttpDelete]
        [Route("[action]/{activityId}")]
        public async Task<IActionResult> DeleteActivity(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                await _activityService.DeleteActivity(currentUser.Id, activityId);
                return Ok();
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllActivities()
        {
            return Ok(await _activityService.GetAllActivities());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUserActivities()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.GetAllUserActivities(currentUser.Id));
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("[action]/{activityId}")]
        public async Task<IActionResult> GetUserActivityById(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.GetUserActivityById(currentUser.Id, activityId));
            }
            return Unauthorized();
        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateActivity(int activityId, [FromBody] UpdateActivityDTO updateActivityDTO)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.UpdateActivity(activityId, currentUser.Id, updateActivityDTO));
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserActiviesDone()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.GetUserActiviesDone(currentUser.Id));
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserActiviesNotDone()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.GetUserActiviesNotDone(currentUser.Id));
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserActiviesByNumberOfDays(int MinDay, int MaxDay)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.GetUserActiviesByNumberOfDays(currentUser.Id, MinDay, MaxDay));
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserActiviesByButget(int MinButget, int MaxButget)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return Ok(await _activityService.GetUserActiviesByButget(currentUser.Id, MinButget, MaxButget));
            }
            return Unauthorized();
        }

        //[HttpPatch]
        //[Route("[action]/{activityId}")]
        //public async Task<IActionResult> 
    }
}

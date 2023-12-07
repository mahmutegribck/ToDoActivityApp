using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using ToDoActivityAppAPI.Business.Activities;
using ToDoActivityAppAPI.Business.Activities.DTOs;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        private readonly UserManager<ApplicationUser> _userManager;

        public ActivityController(IActivityService activityService, UserManager<ApplicationUser> userManager)
        {
            _activityService = activityService;
            _userManager = userManager;
        }



        [HttpPatch("[action]/{activityId}")]
        public async Task<IActionResult> ActivityDone(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (activityId != 0 && await _activityService.ActivityDone(currentUser.Id, activityId))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpPatch("[action]/{activityId}")]
        public async Task<IActionResult> ActivityNotDone(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (activityId != 0 && await _activityService.ActivityNotDone(currentUser.Id, activityId))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityDTO createActivityDTO)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (await _activityService.CreateActivity(currentUser.Id, createActivityDTO))
                {
                    return Ok();
                }

            }
            return Unauthorized();
        }


        [HttpDelete("[action]/{activityId}")]
        public async Task<IActionResult> DeleteUserActivityById(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (await _activityService.DeleteUserActivityById(currentUser.Id, activityId))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpDelete("[action]/")]
        public async Task<IActionResult> DeleteUserAllActivitiesById([FromQuery] int[] activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (await _activityService.DeleteUserAllActivitiesById(currentUser.Id, activityId))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUserAllActivities()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (await _activityService.DeleteUserAllActivities(currentUser.Id))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActivities()
        {
            var allActivities = await _activityService.GetAllActivities();
            if (allActivities.Count != 0)
            {
                return Ok(allActivities);
            }
            return NotFound();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserActivities()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var allUserActivities = await _activityService.GetAllUserActivities(currentUser.Id);
                if (allUserActivities.Count != 0)
                {
                    return Ok(allUserActivities);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]/{activityId}")]
        public async Task<IActionResult> GetUserActivityById(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivityById = await _activityService.GetUserActivityById(currentUser.Id, activityId);
                if (userActivityById != null)
                {
                    return Ok(userActivityById);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpPut("[action]/{activityId}")]
        public async Task<IActionResult> UpdateActivity(int activityId, [FromBody] UpdateActivityDTO updateActivityDTO)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (await _activityService.UpdateActivity(activityId, currentUser.Id, updateActivityDTO))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserActivitiesDone()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActiviesDone = await _activityService.GetUserActivitiesDone(currentUser.Id);
                if (userActiviesDone.Count != 0)
                {
                    return Ok(userActiviesDone);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserActivitiesNotDone()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivitiesNotDone = await _activityService.GetUserActivitiesNotDone(currentUser.Id);
                if (userActivitiesNotDone.Count != 0)
                {
                    return Ok(userActivitiesNotDone);
                }
                return NotFound();

            }
            return Unauthorized();
        }
        

        [HttpGet("[action]/{minDay}/{maxDay}")]
        public async Task<IActionResult> GetUserActivitiesByNumberOfDays(int minDay, int maxDay)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivitiesByNumberOfDays = await _activityService.GetUserActivitiesByNumberOfDays(currentUser.Id, minDay, maxDay);
                if (userActivitiesByNumberOfDays.Count != 0 && minDay >= 0 && maxDay >= 0 && maxDay >= minDay)
                {
                    return Ok(userActivitiesByNumberOfDays);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]/{minBudget}/{maxBudget}")]
        public async Task<IActionResult> GetUserActivitiesByButget(int minBudget, int maxBudget)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivitiesByButget = await _activityService.GetUserActivitiesByButget(currentUser.Id, minBudget, maxBudget);
                if (userActivitiesByButget.Count != 0 && minBudget >= 0 && maxBudget >= 0 && maxBudget >= minBudget)
                {
                    return Ok(userActivitiesByButget);
                }
                return NotFound();
            }
            return Unauthorized();
        }
    }
}

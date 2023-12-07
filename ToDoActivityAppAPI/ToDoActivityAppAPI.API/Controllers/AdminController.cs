using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using ToDoActivityAppAPI.Business.AdminActivities;
using ToDoActivityAppAPI.Business.AdminActivities.DTOs;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminActivityService _adminActivityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IAdminActivityService adminActivityService, UserManager<ApplicationUser> userManager)
        {
            _adminActivityService = adminActivityService;
            _userManager = userManager;
        }
        /*
        
        
       
        Task<GetAdminActivityDTO> GetAdminActivityById(string identityUserId, int id);
        Task<List<GetAdminActivityDTO>> GetAllAdminActivities(string identityUserId);
        Task<GetAdminActivityDTO> GetRandomAdminActivity(string identityUserId);*/

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAdminActivity([FromBody] CreateAdminActivityDTO createAdminActivityDTO)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (await _adminActivityService.CreateAdminActivity(currentUser.Id, createAdminActivityDTO))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpPut("[action]/{activityId}")]
        public async Task<IActionResult> UpdateAdminActivity([FromQuery] int activityId, [FromBody] UpdateAdminActivityDTO updateAdminActivityDTO)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (await _adminActivityService.UpdateAdminActivity(activityId, currentUser.Id, updateAdminActivityDTO))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpPatch("[action]/{activityId}/{imageUrl}")]
        public async Task<IActionResult> AddAdminActivityImage([FromQuery] int activityId, [FromQuery] string imageUrl)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (await _adminActivityService.AddAdminActivityImage(activityId, currentUser.Id, imageUrl))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpDelete("[action]/{activityId}")]
        public async Task<IActionResult> DeleteAdminActivityById([FromQuery]int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (await _adminActivityService.DeleteAdminActivityById(currentUser.Id, id))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAdminAllActivitiesById( [FromBody]int[] id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser != null)
            {
                if(await _adminActivityService.DeleteAdminAllActivitiesById(currentUser.Id,id))
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }

        [HttpGet("[action]/{activityId}")]
        public async Task<IActionResult> GetAdminActivityById([FromQuery] int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var adminActivity = await _adminActivityService.GetAdminActivityById(currentUser.Id, id);
                if (adminActivity != null)
                {
                    return Ok(adminActivity);
                }
                return NotFound();
            }
            return Unauthorized();

        }


    }
}

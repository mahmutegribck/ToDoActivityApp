using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoActivityAppAPI.Business.Users.DTOs;
using ToDoActivityAppAPI.Business.Users;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;


        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;

        }



        [HttpGet]
        [Route("[action]")]
        
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users.Count > 0)
            {
                return Ok(users);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var user = await _userService.GetUser(currentUser.Id);

                if (user != null)
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }


        [HttpGet]
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUser(id);

            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }


        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateApplicationUserDto model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var result = await _userService.UpdateUser(currentUser, model);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }



        [HttpDelete]
        [Route("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var result = await _userService.DeleteUser(currentUser.Id);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();

        }
    }
}

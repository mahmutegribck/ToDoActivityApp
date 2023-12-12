using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoActivityAppAPI.Business.Auth;
using ToDoActivityAppAPI.Business.Auth.DTOs;
using ToDoActivityAppAPI.Business.Auth.ResponseModel;
using ToDoActivityAppAPI.Business.Jwt.DTOs;
using ToDoActivityAppAPI.Entity;

namespace ToDoActivityAppAPI.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                RegisterResponse result = await _authService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(ErrorMsg.InvalidProperties);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                LoginResponse result = await _authService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest(ErrorMsg.InvalidProperties);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> LoginWithRefreshToken([FromBody] string refreshToken)
        {
            JwtTokenDTO? tokens = await _authService.LoginWithRefreshToken(refreshToken);
            if (tokens != null)
            {
                return Ok(tokens);
            }
           return Unauthorized();
        }


        [HttpPost("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            if (ModelState.IsValid)
            {
                LoginResponse result = await _authService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            return BadRequest(ErrorMsg.InvalidProperties);
        }
    }
}

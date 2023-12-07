using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Auth.DTOs;
using ToDoActivityAppAPI.Business.Auth.ResponseModel;
using ToDoActivityAppAPI.Business.Jwt;
using ToDoActivityAppAPI.Business.Jwt.DTOs;
using ToDoActivityAppAPI.Entity;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Business.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IJwtService jwtService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return new LoginResponse
                    {
                        Message = ErrorMsg.NoUserEmail,
                        IsSuccess = false,
                    };
                }
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new LoginResponse
                    {
                        Message = ErrorMsg.InvalidPassword,
                        IsSuccess = false,
                    };

                JwtTokenDTO token = await _jwtService.CreateJwtToken(user);

                return new LoginResponse
                {
                    JwtTokenDTO = token,
                    Message = Msg.LoginSucces,
                    IsSuccess = true,

                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JwtTokenDTO?> LoginWithRefreshToken(string refreshToken)
        {
            return await _jwtService.GenerateRefreshTokenWithJwtToken(refreshToken);
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterDto model)
        {
            try
            {
                if (model == null)
                {
                    throw new NullReferenceException(ErrorMsg.NullModel);
                }
                if (model.Password != model.ConfirmPassword)
                    return new RegisterResponse
                    {
                        Message = Msg.ConfirmPasswordNotMatch,
                        IsSuccess = false,
                    };

                ApplicationUser newUser = _mapper.Map<ApplicationUser>(model);
                newUser.Id = Guid.NewGuid().ToString();
                newUser.UserName = newUser.Name + " " + newUser.Surname;

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return new RegisterResponse
                    {
                        Message = Msg.UserCreated,
                        IsSuccess = true,
                    };
                }

                return new RegisterResponse
                {
                    Message = ErrorMsg.UserNotCreated,
                    IsSuccess = false,

                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LoginResponse> ResetPasswordAsync(ResetPasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = ErrorMsg.NoUserEmail,
                    };

                if (model.NewPassword != model.ConfirmPassword)
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = ErrorMsg.EmailNotConfirm,
                    };

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                if (result.Succeeded)
                    return new LoginResponse
                    {
                        Message = Msg.ResetPasswordSuccess,
                        IsSuccess = true,
                    };

                return new LoginResponse
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    IsSuccess = false
                };
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

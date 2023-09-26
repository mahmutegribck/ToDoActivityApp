using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Auth.DTOs;
using ToDoActivityAppAPI.Business.Auth.ResponseModel;

namespace ToDoActivityAppAPI.Business.Auth
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterDto model);
        Task<LoginResponse> LoginUserAsync(LoginDto model);
        Task<LoginResponse> ResetPasswordAsync(ResetPasswordDto model);
    }
}

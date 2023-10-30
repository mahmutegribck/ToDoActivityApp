using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Users.DTOs;
using ToDoActivityAppAPI.DataAccess.Users;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Business.Users
{
    public interface IUserService
    {
        Task<List<GetApplicationUserDto>> GetAllUsers();
        Task<GetApplicationUserDto> GetUser(string id);
        Task<IdentityResult> UpdateUser(ApplicationUser user, UpdateApplicationUserDto model);
        Task<IdentityResult> DeleteUser(string id);

    }
}

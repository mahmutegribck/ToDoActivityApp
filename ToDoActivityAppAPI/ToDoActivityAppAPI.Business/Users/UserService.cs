﻿using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<List<GetApplicationUserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var getUsers = _mapper.Map<List<GetApplicationUserDto>>(users);
            return getUsers;
        }

        public async Task<GetApplicationUserDto> GetUser(string id)
        {
            var user = await _userRepository.GetUser(id);
            var getUser = _mapper.Map<GetApplicationUserDto>(user);
            return getUser;
        }

        public async Task<IdentityResult> UpdateUser(ApplicationUser user, UpdateApplicationUserDto model)
        {
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Birthdate = model.Birthdate;
            user.Location = model.Location;

            return await _userRepository.UpdateUser(user);
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}

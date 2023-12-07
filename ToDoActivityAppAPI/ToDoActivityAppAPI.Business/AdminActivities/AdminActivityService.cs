using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.AdminActivities.DTOs;
using ToDoActivityAppAPI.DataAccess.AdminActivities;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.Business.AdminActivities
{
    public class AdminActivityService : IAdminActivityService
    {
        private readonly IAdminActivityRepository _adminActivityRepository;
        private readonly IMapper _mapper;
        public AdminActivityService(IAdminActivityRepository adminActivityRepository, IMapper mapper)
        {
            _adminActivityRepository = adminActivityRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAdminActivity(string identityUserId, CreateAdminActivityDTO createAdminActivityDTO)
        {
            AdminActivity crateAdminActivity = _mapper.Map<AdminActivity>(createAdminActivityDTO);
            crateAdminActivity.ApplicationUserId = identityUserId;

            return await _adminActivityRepository.CreateAdminActivity(crateAdminActivity);

        }

        public async Task<bool> DeleteAdminActivityById(string identityUserId, int id)
        {
            return await _adminActivityRepository.DeleteAdminActivityById(identityUserId, id);
        }

        public async Task<bool> DeleteAdminAllActivitiesById(string identityUserId, int[] id)
        {
            return await _adminActivityRepository.DeleteAdminAllActivitiesById(identityUserId, id);
        }

        public async Task<GetAdminActivityDTO> GetAdminActivityById(string identityUserId, int id)
        {
            return _mapper.Map<GetAdminActivityDTO>(await _adminActivityRepository.GetAdminActivityById(identityUserId, id));
        }

        public async Task<List<GetAdminActivityDTO>> GetAllAdminActivities(string identityUserId)
        {
            return _mapper.Map<List<GetAdminActivityDTO>>(await _adminActivityRepository.GetAllAdminActivities(identityUserId));
        }

        public async Task<GetAdminActivityDTO> GetRandomAdminActivity(string identityUserId)
        {
            return _mapper.Map<GetAdminActivityDTO>(await _adminActivityRepository.GetRandomAdminActivity());
        }

        public async Task<bool> UpdateAdminActivity(int activityId, string identityUserId, UpdateAdminActivityDTO updateAdminActivityDTO)
        {
            return await _adminActivityRepository.UpdateAdminActivity(activityId, identityUserId, _mapper.Map<AdminActivity>(updateAdminActivityDTO));
        }

        public async Task<bool> AddAdminActivityImage(int activityId, string identityUserId, string imageUrl)
        {
            return await _adminActivityRepository.AddAdminActivityImage(activityId, identityUserId, imageUrl);
        }
    
    }
}

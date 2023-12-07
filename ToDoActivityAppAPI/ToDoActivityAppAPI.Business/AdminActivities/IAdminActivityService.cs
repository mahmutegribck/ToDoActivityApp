using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.AdminActivities.DTOs;

namespace ToDoActivityAppAPI.Business.AdminActivities
{
    public interface IAdminActivityService
    {
        Task<bool> CreateAdminActivity(string identityUserId, CreateAdminActivityDTO createAdminActivityDTO);
        Task<bool> UpdateAdminActivity(int activityId, string identityUserId, UpdateAdminActivityDTO updateAdminActivityDTO);
        Task<bool> AddAdminActivityImage(int activityId, string identityUserId, string imageUrl);
        Task<bool> DeleteAdminActivityById(string identityUserId, int id);
        Task<bool> DeleteAdminAllActivitiesById(string identityUserId, int[] id);
        Task<GetAdminActivityDTO> GetAdminActivityById(string identityUserId, int id);
        Task<List<GetAdminActivityDTO>> GetAllAdminActivities(string identityUserId);
        Task<GetAdminActivityDTO> GetRandomAdminActivity(string identityUserId);
    }
}

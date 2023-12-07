using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.AdminActivities
{
    public interface IAdminActivityRepository
    {
        Task<bool> CreateAdminActivity(AdminActivity adminActivity);
        Task<bool> UpdateAdminActivity(int activityId, string identityUserId, AdminActivity adminActivity);
        Task<bool> UpdateAdminActivityImage(int activityId, string identityUserId, string imageUrl);
        Task<bool> DeleteAdminActivityById(string identityUserId, int id);
        Task<bool> DeleteAdminAllActivitiesById(string identityUserId, int[] id);
        Task<bool> DeleteAdminAllActivities(string identityUserId);
        Task<AdminActivity> GetAdminActivityById(string identityUserId, int id);
        Task<List<AdminActivity>> GetAllAdminActivities(string identityUserId);
        Task<AdminActivity> GetRandomAdminActivity();
        Task<bool> AddAdminActivityImage(int activityId, string identityUserId, string imageUrl);
        Task<bool> DeleteAdminActivityImage(int activityId, string identityUserId);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Activities.DTOs;

namespace ToDoActivityAppAPI.Business.Activities
{
    public interface IActivityService
    {      
        Task<bool> CreateActivity(string IdentityUserId, CreateActivityDTO createActivityDTO);
        Task<bool> UpdateActivity(int activityId, string IdentityUserId, UpdateActivityDTO updateActivityDTO);
        Task<bool> DeleteUserActivityById(string IdentityUserId, int activityId);
        Task<bool> DeleteUserAllActivitiesById(string IdentityUserId, int[] activityId);
        Task<bool> DeleteUserAllActivities(string IdentityUserId);
        Task<bool> ActivityDone(string IdentityUserId, int activityId);
        Task<bool> ActivityNotDone(string IdentityUserId, int activityId);
        Task<List<GetActivityDTO>> GetAllActivities();
        Task<GetActivityDTO> GetUserActivityById(string IdentityUserId, int activityId);
        Task<List<GetActivityDTO>> GetAllUserActivities(string IdentityUserId);
        Task<List<GetActivityDTO>> GetUserActivitiesDone(string IdentityUserId);
        Task<List<GetActivityDTO>> GetUserActivitiesNotDone(string IdentityUserId);
        Task<List<GetActivityDTO>> GetUserActivitiesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay);
        Task<List<GetActivityDTO>> GetUserActivitiesByButget(string IdentityUserId, double MinButget, double MaxButget);

        Task<List<string>> GetUserActivityTitles(string identityUserId);
    }
}

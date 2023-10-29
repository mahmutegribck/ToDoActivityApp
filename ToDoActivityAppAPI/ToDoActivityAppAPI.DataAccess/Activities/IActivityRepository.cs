using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Activities
{
    public interface IActivityRepository
    {
        Task<bool> CreateActivity(Activity activity);
        Task<bool> UpdateActivity(int activityId, string IdentityUserId, Activity activity);
        Task<bool> DeleteUserActivityById(string IdentityUserId, int id);
        Task<bool> DeleteUserAllActivitiesById(string IdentityUserId, int[] id);
        Task<bool> DeleteUserAllActivities(string IdentityUserId);
        Task<bool> ActivityDone(string IdentityUserId, int id);
        Task<bool> ActivityNotDone(string IdentityUserId, int id);
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetUserActivityById(string IdentityUserId, int id);
        Task<List<Activity>> GetAllUserActivities(string IdentityUserId);
        Task<List<Activity>> GetUserActivitiesDone(string IdentityUserId);
        Task<List<Activity>> GetUserActivitiesNotDone(string IdentityUserId);
        Task<List<Activity>> GetUserActivitiesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay);
        Task<List<Activity>> GetUserActivitiesByButget(string IdentityUserId, double MinButget, double MaxButget);
    }
}

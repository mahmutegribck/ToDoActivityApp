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
        Task<bool> UpdateActivity(int activityId, string identityUserId, Activity activity);
        Task<bool> DeleteUserActivityById(string identityUserId, int id);
        Task<bool> DeleteUserAllActivitiesById(string identityUserId, int[] id);
        Task<bool> DeleteUserAllActivities(string identityUserId);
        Task<bool> ActivityDone(string identityUserId, int id);
        Task<bool> ActivityNotDone(string identityUserId, int id);
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetUserActivityById(string identityUserId, int id);
        Task<List<Activity>> GetAllUserActivities(string identityUserId);
        Task<List<Activity>> GetUserActivitiesDone(string identityUserId);
        Task<List<Activity>> GetUserActivitiesNotDone(string identityUserId);
        Task<List<Activity>> GetUserActivitiesByNumberOfDays(string identityUserId, int MinDay, int MaxDay);
        Task<List<Activity>> GetUserActivitiesByButget(string identityUserId, double MinButget, double MaxButget);
    }
}

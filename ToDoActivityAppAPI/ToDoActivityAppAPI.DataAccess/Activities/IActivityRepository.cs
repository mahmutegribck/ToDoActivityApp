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
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetUserActivityById(string IdentityUserId, int id);
        Task CreateActivity(Activity activity);
        Task UpdateActivity(string IdentityUserId, Activity activity);
        Task DeleteActivity(string IdentityUserId, int id);
        Task<List<Activity>> GetAllUserActivities(string IdentityUserId);
        Task<Activity> ActivityDone(int id);
        Task<List<Activity>> GetUserActiviesDone(string IdentityUserId);
        Task<List<Activity>> GetUserActiviesNotDone(string IdentityUserId);
        Task<List<Activity>> GetUserActiviesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay);
    }
}

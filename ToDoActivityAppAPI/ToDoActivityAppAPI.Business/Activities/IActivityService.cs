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
        Task<List<GetActivityDTO>> GetAllActivities();
        Task<GetActivityDTO> GetUserActivityById(string IdentityUserId, int id);
        Task<GetActivityDTO> CreateActivity(string IdentityUserId, CreateActivityDTO createActivityDTO);
        Task<GetActivityDTO> UpdateActivity(int activityId, string IdentityUserId, UpdateActivityDTO updateActivityDTO);
        Task DeleteActivity(string IdentityUserId, int activityId);
        Task<List<GetActivityDTO>> GetAllUserActivities(string IdentityUserId);
        Task ActivityDone(string IdentityUserId, int id);
        Task ActivityNotDone(string IdentityUserId, int id);
        Task<List<GetActivityDTO>> GetUserActiviesDone(string IdentityUserId);
        Task<List<GetActivityDTO>> GetUserActiviesNotDone(string IdentityUserId);
        Task<List<GetActivityDTO>> GetUserActiviesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay);
        Task<List<GetActivityDTO>> GetUserActiviesByButget(string IdentityUserId, double MinButget, double MaxButget);
    }
}

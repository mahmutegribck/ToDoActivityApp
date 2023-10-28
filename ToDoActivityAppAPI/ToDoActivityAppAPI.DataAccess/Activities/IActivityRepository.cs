﻿using System;
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
        Task<Activity> CreateActivity(Activity activity);
        Task<Activity> UpdateActivity(int activityId, string IdentityUserId, Activity activity);
        Task DeleteActivity(string IdentityUserId, int id);
        Task<List<Activity>> GetAllUserActivities(string IdentityUserId);
        Task ActivityDone(string IdentityUserId, int id);
        Task ActivityNotDone(string IdentityUserId, int id);
        Task<List<Activity>> GetUserActiviesDone(string IdentityUserId);
        Task<List<Activity>> GetUserActiviesNotDone(string IdentityUserId);
        Task<List<Activity>> GetUserActiviesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay);
        Task<List<Activity>> GetUserActiviesByButget(string IdentityUserId, double MinButget, double MaxButget);
    }
}

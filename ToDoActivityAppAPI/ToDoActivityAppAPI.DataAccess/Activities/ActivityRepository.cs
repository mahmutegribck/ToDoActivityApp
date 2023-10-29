using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Activities
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ToDoActivityAppAPIDbContext _context;

        public ActivityRepository(ToDoActivityAppAPIDbContext context)
        {
            _context = context;
        }



        public async Task<bool> ActivityDone(string IdentityUserId, int id)
        {
            var activityDone = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.ActivityId == id).FirstOrDefaultAsync();

            if (activityDone != null)
            {
                activityDone.Done = true;
                _context.Activities.Update(activityDone);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> ActivityNotDone(string IdentityUserId, int id)
        {
            var activityDone = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.ActivityId == id).FirstOrDefaultAsync();

            if (activityDone != null)
            {
                activityDone.Done = false;
                _context.Activities.Update(activityDone);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> CreateActivity(Activity activity)
        {
            if (activity != null)
            {
                activity.CreateTime = DateTime.UtcNow;
                activity.UpdateTime = null;
                activity.DayNumbers = (activity.EndTime - activity.StartTime)?.Days;
                await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> DeleteUserActivityById(string IdentityUserId, int id)
        {
            var deleteActivity = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.ActivityId == id).FirstOrDefaultAsync();

            if (deleteActivity != null)
            {
                _context.Activities.Remove(deleteActivity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> DeleteUserAllActivitiesById(string IdentityUserId, int[] id)
        {
            List<Activity> deleteActivities = new();

            foreach (var activityId in id)
            {
                var deleteUserActivity = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.ActivityId == activityId).FirstOrDefaultAsync();
                if (deleteUserActivity != null)
                {
                    deleteActivities.Add(deleteUserActivity);
                }
                //continue;
            }

            if (deleteActivities.Count > 0)
            {
                foreach (var deleteActivity in deleteActivities)
                {
                    _context.Activities.Remove(deleteActivity);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> DeleteUserAllActivities(string IdentityUserId)
        {
            var deleteUserActivity = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId).ToListAsync();

            if (deleteUserActivity.Count > 0)
            {
                foreach (var deleteActivity in deleteUserActivity)
                {
                    _context.Activities.Remove(deleteActivity);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<List<Activity>> GetAllActivities()
        {
            var activities = await _context.Activities.OrderByDescending(a => a.CreateTime).ToListAsync();

            return activities;
        }


        public async Task<List<Activity>> GetAllUserActivities(string IdentityUserId)
        {
            var userActivities = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId).OrderByDescending(a => a.CreateTime).ToListAsync();

            return userActivities;
        }


        public async Task<Activity> GetUserActivityById(string IdentityUserId, int id)
        {
            var userActivity = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.ActivityId == id).FirstOrDefaultAsync();

            return userActivity;

        }


        public async Task<bool> UpdateActivity(int activityId, string IdentityUserId, Activity activity)
        {
            var activityUpdate = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.ActivityId == activityId).FirstOrDefaultAsync();

            if (activityUpdate != null)
            {
                activityUpdate.Title = activity.Title;
                activityUpdate.Text = activity.Text;
                activityUpdate.CreateTime = activityUpdate.CreateTime;
                activityUpdate.UpdateTime = DateTime.UtcNow;
                activityUpdate.StartTime = activity.StartTime;
                activityUpdate.EndTime = activity.EndTime;
                activityUpdate.DayNumbers = (activity.EndTime - activity.StartTime)?.Days;
                activityUpdate.Budget = activity.Budget;
                activityUpdate.Location = activity.Location;
                activityUpdate.Timed = activity.Timed;

                _context.Activities.Update(activityUpdate);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<List<Activity>> GetUserActivitiesDone(string IdentityUserId)
        {
            var userDoneActivities = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.Done == true).ToListAsync();

            return userDoneActivities;
        }


        public async Task<List<Activity>> GetUserActivitiesNotDone(string IdentityUserId)
        {
            var userNotDoneActivities = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.Done == false).ToListAsync();

            return userNotDoneActivities;
        }


        public async Task<List<Activity>> GetUserActivitiesByNumberOfDays(string IdentityUserId, int minDay, int maxDay)
        {
            var activies = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.DayNumbers >= minDay && a.DayNumbers <= maxDay).ToListAsync();

            return activies;
        }


        public async Task<List<Activity>> GetUserActivitiesByButget(string IdentityUserId, double minButget, double maxButget)
        {
            var activies = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.Budget > minButget && a.Budget < maxButget).ToListAsync();

            return activies;
        }

    }
}

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



        public async Task<bool> ActivityDone(string identityUserId, int id)
        {
            var activityDone = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == id).OrderByDescending(a => a.CreateTime).FirstOrDefaultAsync();

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


        public async Task<bool> ActivityNotDone(string identityUserId, int id)
        {
            var activityDone = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == id).OrderByDescending(a => a.CreateTime).FirstOrDefaultAsync();

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


        public async Task<bool> DeleteUserActivityById(string identityUserId, int id)
        {
            var deleteActivity = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == id).FirstOrDefaultAsync();
            //var del = await _context.Activities.Include(x => x.Images)
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


        public async Task<bool> DeleteUserAllActivitiesById(string identityUserId, int[] id)
        {
            List<Activity> deleteActivities = new();

            foreach (var activityId in id)
            {
                var deleteUserActivity = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == activityId).FirstOrDefaultAsync();
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


        public async Task<bool> DeleteUserAllActivities(string identityUserId)
        {
            var deleteUserActivity = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId).ToListAsync();

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


        public async Task<List<Activity>> GetAllUserActivities(string identityUserId)
        {
            var userActivities = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId).OrderByDescending(a => a.CreateTime).ToListAsync();

            return userActivities;
        }


        public async Task<Activity> GetUserActivityById(string identityUserId, int id)
        {
            var userActivity = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == id).FirstOrDefaultAsync();

            return userActivity;

        }


        public async Task<bool> UpdateActivity(int activityId, string identityUserId, Activity activity)
        {
            var activityUpdate = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == activityId).FirstOrDefaultAsync();

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


        public async Task<List<Activity>> GetUserActivitiesDone(string identityUserId)
        {
            var userDoneActivities = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.Done == true).ToListAsync();

            return userDoneActivities;
        }


        public async Task<List<Activity>> GetUserActivitiesNotDone(string identityUserId)
        {
            var userNotDoneActivities = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.Done == false).ToListAsync();

            return userNotDoneActivities;
        }


        public async Task<List<Activity>> GetUserActivitiesByNumberOfDays(string identityUserId, int minDay, int maxDay)
        {
            var activies = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.DayNumbers >= minDay && a.DayNumbers <= maxDay).ToListAsync();

            return activies;
        }


        public async Task<List<Activity>> GetUserActivitiesByButget(string identityUserId, double minButget, double maxButget)
        {
            var activies = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.Budget >= minButget && a.Budget <= maxButget).ToListAsync();

            return activies;
        }

    }
}

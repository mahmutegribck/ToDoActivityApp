using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Activities
{
    internal class ActivityRepository : IActivityRepository
    {
        private readonly ToDoActivityAppAPIDbContext _context;

        public ActivityRepository(ToDoActivityAppAPIDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> ActivityDone(int id)
        {
            var activityDone = await _context.Activities.FindAsync(id);

            if (activityDone != null)
            {
                activityDone.ActivityDone = true;
                _context.Activities.Update(activityDone);
                await _context.SaveChangesAsync();
                return activityDone;
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task CreateActivity(Activity activity)
        {
            if (activity != null)
            {
                activity.CreateTime = DateTime.Now;
                await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Activity could not be created");
            }

        }

        public async Task DeleteActivity(string IdentityUserId, int id)
        {
            var deleteActivity = await _context.Activities.FindAsync(id);

            if (deleteActivity != null)
            {
                if (deleteActivity.ApplicationUserId == IdentityUserId)
                {
                    _context.Activities.Remove(deleteActivity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User is not delete this activity");
                }
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            var activities = await _context.Activities.OrderByDescending(a => a.CreateTime).ToListAsync();

            if(activities.Count > 0)
            {
                return activities;
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task<List<Activity>> GetAllUserActivities(string IdentityUserId)
        {
            var userActivities = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId).OrderByDescending(a => a.CreateTime).ToListAsync();

            if (userActivities.Count > 0)
            {
                return userActivities;
            }
            else
            {
                throw new Exception("Not Found User Activity");
            }
        }

        public async Task<Activity> GetUserActivityById(string IdentityUserId, int id)
        {
            var userActivity = await _context.Activities.FindAsync(id);

            if(userActivity != null)
            {
                if(userActivity.ApplicationUserId == IdentityUserId)
                {
                    return userActivity;
                }
                else
                {
                    throw new Exception("Not Found User Activity");
                }
            }
            else
            {
                throw new Exception("Not Found User Activity");
            }

        }

        public async Task UpdateActivity(string IdentityUserId, Activity activity)
        {
            var activityUpdate = await _context.Activities.FindAsync(activity.ActivityId);

            if(activityUpdate != null)
            {
                if(activityUpdate.ApplicationUserId == IdentityUserId)
                {
                    activityUpdate.Title = activity.Title;
                    activityUpdate.Text = activity.Text;
                    activityUpdate.CreateTime = activity.CreateTime;
                    activityUpdate.StartTime = activity.StartTime;
                    activityUpdate.EndTime = activity.EndTime;
                    activityUpdate.DayNumbers = activity.DayNumbers;
                    activityUpdate.Budget = activity.Budget;
                    activityUpdate.Location = activity.Location;
                    activityUpdate.Timed = activity.Timed;
                       
                    _context.Activities.Update(activityUpdate);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new Exception("User can not update this activity");
                }
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }
    }
}

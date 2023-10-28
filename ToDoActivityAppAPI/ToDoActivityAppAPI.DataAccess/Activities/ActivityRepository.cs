﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task ActivityDone(string IdentityUserId, int id)
        {
            var activityDone = await _context.Activities.FindAsync(id);

            if (activityDone != null)
            {
                if (activityDone.ApplicationUserId == IdentityUserId)
                {
                    activityDone.Done = false;
                    _context.Activities.Update(activityDone);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User is not change this activity");
                }
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task ActivityNotDone(string IdentityUserId, int id)
        {
            var activityDone = await _context.Activities.FindAsync(id);

            if (activityDone != null)
            {
                if (activityDone.ApplicationUserId == IdentityUserId)
                {
                    activityDone.Done = false;
                    _context.Activities.Update(activityDone);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User is not change this activity");
                }
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task<Activity> CreateActivity(Activity activity)
        {
            if (activity != null)
            {
                activity.CreateTime = DateTime.UtcNow;
                activity.DayNumbers = (activity.EndTime - activity.StartTime)?.Days;
                await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();
                return activity;
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

            if (activities.Count > 0)
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

            if (userActivity != null)
            {
                if (userActivity.ApplicationUserId == IdentityUserId)
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

        public async Task<Activity> UpdateActivity(int activityId, string IdentityUserId, Activity activity)
        {
            var activityUpdate = await _context.Activities.FindAsync(activityId);

            if (activityUpdate != null)
            {
                if (activityUpdate.ApplicationUserId == IdentityUserId)
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
                    return activityUpdate;

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


        public async Task<List<Activity>> GetUserActiviesDone(string IdentityUserId)
        {
            var userDoneActivities = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.Done == true).ToListAsync();

            if (userDoneActivities.Count > 0)
            {
                return userDoneActivities;
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task<List<Activity>> GetUserActiviesNotDone(string IdentityUserId)
        {
            var userNotDoneActivities = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.Done == false).ToListAsync();

            if (userNotDoneActivities.Count > 0)
            {
                return userNotDoneActivities;
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task<List<Activity>> GetUserActiviesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay)
        {
            var activies = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.DayNumbers > MinDay && a.DayNumbers < MaxDay).ToListAsync();

            if (activies.Count > 0)
            {
                return activies;
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }

        public async Task<List<Activity>> GetUserActiviesByButget(string IdentityUserId, double MinButget, double MaxButget)
        {
            var activies = await _context.Activities.Where(a => a.ApplicationUserId == IdentityUserId && a.Budget > MinButget && a.Budget < MaxButget).ToListAsync();

            if (activies.Count > 0)
            {
                return activies;
            }
            else
            {
                throw new Exception("Not Found Activity");
            }
        }
    }
}

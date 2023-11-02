using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.AdminActivities
{
    public class AdminActivityRepository : IAdminActivityRepository
    {
        private readonly ToDoActivityAppAPIDbContext _context;

        public AdminActivityRepository(ToDoActivityAppAPIDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAdminActivity(AdminActivity adminActivity)
        {
            if (adminActivity != null)
            {
                await _context.AdminActivities.AddAsync(adminActivity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAdminActivityById(string identityUserId, int id)
        {
            var deleteAdminActivity = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == id).FirstOrDefaultAsync();
            if (deleteAdminActivity != null)
            {
                _context.AdminActivities.Remove(deleteAdminActivity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteAdminAllActivitiesById(string identityUserId, int[] id)
        {
            List<AdminActivity> deleteAdminActivities = new();
            //var deleteUserActivity = await _context.Activities.Where(a => a.ApplicationUserId == identityUserId && a.ActivityId == activityId).FirstOrDefaultAsync();
            
            foreach (var delId in id)
            {
                var deleteAdminActivity = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == delId).FirstOrDefaultAsync();
                if(deleteAdminActivity != null)
                {
                    deleteAdminActivities.Add(deleteAdminActivity); 
                }
            }

            if(deleteAdminActivities.Count>0)
            {
                foreach (var deleteActiviy in deleteAdminActivities)
                {
                    _context.AdminActivities.Remove(deleteActiviy);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public async Task<AdminActivity> GetAdminActivityById(string identityUserId, int id)
        {
            var adminActivity = await _context.AdminActivities.Where(a=> a.ApplicationUserId == identityUserId && a.Id == id).FirstOrDefaultAsync();
            return adminActivity;
        }

        public Task<List<AdminActivity>> GetAllAdminActivities(string identityUserId)
        {
            var adminActivities = _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId).ToListAsync();
            return adminActivities;
        }

        public Task<AdminActivity> GetRandomAdminActivity()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAdminActivity(int activityId, string identityUserId, AdminActivity adminActivity)
        {
            throw new NotImplementedException();
        }
    }
}

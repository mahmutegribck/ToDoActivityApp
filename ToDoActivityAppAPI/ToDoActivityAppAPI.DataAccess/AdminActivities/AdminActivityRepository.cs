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


        public async Task<bool> UpdateAdminActivity(int activityId, string identityUserId, AdminActivity adminActivity)
        {
            var updateAdminActivty = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == activityId).FirstOrDefaultAsync();

            if (updateAdminActivty != null)
            {
                updateAdminActivty.Title = adminActivity.Title;
                updateAdminActivty.Text = adminActivity.Text;
                updateAdminActivty.Location = adminActivity.Location;
                updateAdminActivty.ImageURL = adminActivity.ImageURL;

                _context.AdminActivities.Update(updateAdminActivty);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }


        public async Task<bool> UpdateAdminActivityImage(int activityId, string identityUserId, string imageUrl)
        {
            var updateAdminActivtyImage = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == activityId).FirstOrDefaultAsync();
            if(updateAdminActivtyImage != null)
            {
                updateAdminActivtyImage.ImageURL = imageUrl;

                _context.AdminActivities.Update(updateAdminActivtyImage);
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
                if (deleteAdminActivity != null)
                {
                    deleteAdminActivities.Add(deleteAdminActivity);
                }
            }

            if (deleteAdminActivities.Count > 0)
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


        public async Task<bool> DeleteAdminAllActivities(string identityUserId)
        {
            List<AdminActivity> deleteAdminActivities = new();

            deleteAdminActivities = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId).ToListAsync();

            if(deleteAdminActivities.Count > 0)
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
            var adminActivity = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == id).FirstOrDefaultAsync();
            return adminActivity;
        }


        public Task<List<AdminActivity>> GetAllAdminActivities(string identityUserId)
        {
            var adminActivities = _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId).ToListAsync();
            return adminActivities;
        }


        public async Task<AdminActivity> GetRandomAdminActivity()
        {
            var random = new Random();
            var totalAdminActivities = await _context.AdminActivities.CountAsync();

            int randomIndex = random.Next(totalAdminActivities);
            var randomAdminActivity = await _context.AdminActivities.Skip(randomIndex).Take(1).FirstOrDefaultAsync();

            return randomAdminActivity;
        }

        

        public async Task<bool> AddAdminActivityImage(int activityId, string identityUserId, string imageUrl)
        {
            var updateAdminActivty = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == activityId).FirstOrDefaultAsync();

            if (updateAdminActivty != null)
            {
                updateAdminActivty.ImageURL = imageUrl;

                _context.AdminActivities.Update(updateAdminActivty);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<bool> DeleteAdminActivityImage(int activityId, string identityUserId)
        {
            var deleteAdminActivityImage = await _context.AdminActivities.Where(a => a.ApplicationUserId == identityUserId && a.Id == activityId).FirstOrDefaultAsync();

            if(deleteAdminActivityImage != null)
            {
                deleteAdminActivityImage.ImageURL = null;

                _context.AdminActivities.Update(deleteAdminActivityImage);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}

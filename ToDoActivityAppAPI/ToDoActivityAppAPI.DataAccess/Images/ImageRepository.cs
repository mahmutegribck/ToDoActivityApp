using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Images
{
    public class ImageRepository : IImageRepository
    {
        private readonly ToDoActivityAppAPIDbContext _context;

        public ImageRepository(ToDoActivityAppAPIDbContext context)
        {
            _context = context;
        }

        public async Task AddImage(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllActivityImages(int activityId)
        {
            var images = await _context.Images.Where(i => i.ActivityId == activityId).ToListAsync();

            foreach (var image in images)
            {
                _context.Images.Remove(image);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActivityImages(int[] imageID, int activityId)
        {
            var images = await _context.Images.Where(i => i.ActivityId == activityId).ToListAsync();

            foreach (var image in images)
            {
                if (imageID.Contains(image.Id))
                {
                    _context.Images.Remove(image);
                }
            }
            await _context.SaveChangesAsync();

        }

        public async Task<List<Image>> GetActivityImagesById(int activityId)
        {
            List<Image> images = await _context.Images.Where(i => i.ActivityId == activityId).ToListAsync();

            return images;
        }

        public async Task ImageMakeFavorite(int[] imageID)
        {
            foreach (var imageid in imageID)
            {
                var image = await _context.Images.FindAsync(imageid);
                image.IsFavorite = true;
                _context.Images.Update(image);
            }
            await _context.SaveChangesAsync();
        }
    }
}

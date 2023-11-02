using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Images
{
    public interface IImageRepository
    {
        Task AddImage(Image image);
        Task DeleteImage(int imageId);
        Task DeleteAllActivityImages(int activityId);
        Task DeleteActivityImages(int[] imageID, int activityId);
        Task ImageMakeFavorite(int[] imageID);
        Task ImageMakeNotFavorite(int[] imageID);
        Task<List<Image>> GetActivityImagesById(int activityId);
        Task<List<Image>> GetUserActivityAllImages(int activityId, string identityUserId);
        Task<List<Image>> GetUserActivityAllFavoriteImages(int activityId, string identityUserId);
        Task<List<Image>> GetUserAllImages(string identityUserId);
        Task<List<Image>> GetUserAllFavoriteImages(string identityUserId);
    }
}

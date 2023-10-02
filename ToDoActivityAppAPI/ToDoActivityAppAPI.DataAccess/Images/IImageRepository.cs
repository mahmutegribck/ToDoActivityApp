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

        Task<List<Image>> GetActivityImagesById(int activityId);
    }
}

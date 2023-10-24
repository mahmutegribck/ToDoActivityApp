using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Images.DTOs;

namespace ToDoActivityAppAPI.Business.Images
{
    public interface IImageService
    {

        Task AddImage(AddImageDTO addImageDTO);
        Task DeleteImage(int imageId);
        Task DeleteAllActivityImages(int activityId);
        Task DeleteActivityImages(int[] imageID, int activityId);
        Task ImageMakeFavorite(int[] imageID);
        Task<List<GetImageDTO>> GetActivityImagesById(int activityId);
    }
}

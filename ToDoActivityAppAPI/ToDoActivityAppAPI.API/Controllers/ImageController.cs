using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoActivityAppAPI.Business.Images;
using ToDoActivityAppAPI.Business.Images.DTOs;

namespace ToDoActivityAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddImage([FromForm] AddImageDTO addImageDTO)
        {
            if (addImageDTO == null)
                return NotFound();

            await _imageService.AddImage(addImageDTO);
            return Ok();

        }

        [HttpPatch]
        [Route("[action]")]
        //Resim favorile
        public async Task<IActionResult> ImageMakeFavorite(int[] imageID)
        {
            if (imageID == null)
                return NotFound();

            await _imageService.ImageMakeFavorite(imageID);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteAllActivityImages(int activityId)
        {
            if (activityId == 0)
                return NotFound();

            await _imageService.DeleteAllActivityImages(activityId);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (imageId == 0)
                return NotFound();

            await _imageService.DeleteImage(imageId);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteActivityImages(int[] imageId, int activityId)
        {
            if (imageId == null)
                return NotFound();

            await _imageService.DeleteActivityImages(imageId, activityId);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetActivityImagesById(int activityId)
        {
            if (activityId == 0)
                return NotFound();
            
            return Ok(await _imageService.GetActivityImagesById(activityId));

        }
    }
}

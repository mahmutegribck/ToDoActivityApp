using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoActivityAppAPI.Business.Images;
using ToDoActivityAppAPI.Business.Images.DTOs;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(IImageService imageService, UserManager<ApplicationUser> userManager)
        {
            _imageService = imageService;
            _userManager = userManager;
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> AddImage([FromForm] AddImageDTO addImageDTO)
        {
            if (addImageDTO == null)
                return NotFound();

            await _imageService.AddImage(addImageDTO);
            return Ok();

        }


        [HttpPatch("[action]")]
        public async Task<IActionResult> ImageMakeFavorite([FromBody] int[] imageID)
        {
            if (imageID == null)
                return NotFound();

            await _imageService.ImageMakeFavorite(imageID);
            return Ok();
        }


        [HttpPatch("[action]")]
        public async Task<IActionResult> ImageMakeNotFavorite([FromBody] int[] imageID)
        {
            if (imageID == null)
                return NotFound();

            await _imageService.ImageMakeNotFavorite(imageID);
            return Ok();
        }

        [HttpDelete("[action]/{activityId}")]
        public async Task<IActionResult> DeleteAllActivityImages(int activityId)
        {
            if (activityId == 0)
                return NotFound();

            await _imageService.DeleteAllActivityImages(activityId);
            return Ok();
        }


        [HttpDelete("[action]/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (imageId == 0)
                return NotFound();

            await _imageService.DeleteImage(imageId);
            return Ok();
        }


        [HttpDelete("[action]/{activityId}")]
        public async Task<IActionResult> DeleteActivityImages([FromBody] int[] imageId, int activityId)
        {
            if (imageId == null)
                return NotFound();

            await _imageService.DeleteActivityImages(imageId, activityId);
            return Ok();
        }


        [HttpGet("[action]/{activityId}")]
        public async Task<IActionResult> GetActivityImagesById(int activityId)
        {
            if (activityId == 0)
                return NotFound();
            
            return Ok(await _imageService.GetActivityImagesById(activityId));

        }


        [HttpGet("[action]/{activityId}")]
        public async Task<IActionResult> GetUserActivityAllImages(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivityAllImages = await _imageService.GetUserActivityAllImages(activityId, currentUser.Id);

                if (userActivityAllImages.Count > 0)
                {
                    return Ok(userActivityAllImages);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]/{activityId}")]
        public async Task<IActionResult> GetUserActivityAllFavoriteImages(int activityId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivityAllImages = await _imageService.GetUserActivityAllFavoriteImages(activityId, currentUser.Id);

                if (userActivityAllImages.Count > 0)
                {
                    return Ok(userActivityAllImages);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserAllImages()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivityAllImages = await _imageService.GetUserAllImages(currentUser.Id);

                if (userActivityAllImages.Count > 0)
                {
                    return Ok(userActivityAllImages);
                }
                return NotFound();
            }
            return Unauthorized();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserAllFavoriteImages()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var userActivityAllImages = await _imageService.GetUserAllFavoriteImages(currentUser.Id);

                if (userActivityAllImages.Count > 0)
                {
                    return Ok(userActivityAllImages);
                }
                return NotFound();
            }
            return Unauthorized();
        }
    }
}

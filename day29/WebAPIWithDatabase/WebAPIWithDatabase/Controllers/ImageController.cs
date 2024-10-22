using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithDatabase.Interfaces;

namespace WebAPIWithDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService=imageService;
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(int productId, string  imageUrl)
        {
            try
            {
                int id= await _imageService.AddImages(productId, imageUrl);
                return Ok(id);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

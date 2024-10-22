using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;
namespace WebAPIWithDatabase.Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<int,Image> _imageRepository;
        public ImageService(IRepository<int, Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<int> AddImages(int productId, string imageUrl)
        {
            try
            {
                Image image = new Image();
                image.ProductId = productId;
                image.ImageUrl = imageUrl;
                var addedImage = await _imageRepository.Add(image);
                return addedImage.Id;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

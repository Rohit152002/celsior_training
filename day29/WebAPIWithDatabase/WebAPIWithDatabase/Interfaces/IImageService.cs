namespace WebAPIWithDatabase.Interfaces
{
    public interface IImageService
    {
        Task<int> AddImages(int productId, string imageUrl);
    }
}

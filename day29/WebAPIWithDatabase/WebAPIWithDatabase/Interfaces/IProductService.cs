using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Interfaces
{
    public interface IProductService
    {
        Task<int>  AddProduct(ProductDTO product);
        Task<ProductDTO> UpdateProduct(int productId, float price);
        Task<IEnumerable<ProductDTO>> ViewAllProducts();
        Task<ProductDTO> GetProductById(int productId);
    }
}

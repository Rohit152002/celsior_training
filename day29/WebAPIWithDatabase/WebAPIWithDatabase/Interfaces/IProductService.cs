using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Interfaces
{
    public interface IProductService
    {
        Task<int>  AddProduct(ProductDTO product);
        Task<ProductDTO> UpdateProduct(int productId, float price);
        Task<IEnumerable<ProductDTO>> ViewAllProducts();
        Task<Product> GetProductById(int productId);
        public Task<bool> AddNewProduct(ProductDTO product);

    }
}

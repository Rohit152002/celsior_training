using AutoMapper;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Models.DTO;
namespace WebAPIWithDatabase.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile() {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}

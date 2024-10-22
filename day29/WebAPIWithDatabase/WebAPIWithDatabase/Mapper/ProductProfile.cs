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
            CreateMap<Models.Product, Models.DTO.ProductDTO>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Models.DTO.ProductDTO, Models.Product>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        }
    }
}

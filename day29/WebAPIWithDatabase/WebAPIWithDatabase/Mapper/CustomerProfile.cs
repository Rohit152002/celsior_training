using AutoMapper;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Models.DTO;
namespace WebAPIWithDatabase.Mapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }   
    }
}

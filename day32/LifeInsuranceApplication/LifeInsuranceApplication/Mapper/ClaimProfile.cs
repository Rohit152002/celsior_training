
using AutoMapper;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Mapper
{
    public class ClaimProfile:Profile
    {
        public ClaimProfile()
        {
            CreateMap<ClaimResponseDTO, CustomerClaim>();
            CreateMap<CustomerClaim, ClaimResponseDTO>();
        }
    }
}
using AutoMapper;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Mapper
{
    public class ClaimTypeProfile:Profile
    {
        public ClaimTypeProfile()
        {
            CreateMap<ClaimTypeDTO, ClaimType>();
            CreateMap<ClaimType,ClaimTypeDTO>();
        }
    }
}
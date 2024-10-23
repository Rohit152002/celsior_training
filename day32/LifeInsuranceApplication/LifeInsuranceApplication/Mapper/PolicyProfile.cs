using AutoMapper;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Mapper
{
    public class PolicyProfile:Profile
    {
        public PolicyProfile()
        {
            CreateMap<Policy,PolicyDTO>();
            CreateMap<PolicyDTO,Policy>();
        }
    }
}
using AutoMapper;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Services
{
    public class ClaimTypeService : IClaimTypeService
    {
        private readonly IRepository<int, ClaimType> _repository;
        private readonly IMapper _mapper;
        public ClaimTypeService(IRepository<int, ClaimType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateNewClaimType(ClaimTypeDTO claimType)
        {
            try
            {
                var claimdata = _mapper.Map<ClaimType>(claimType);
                var claimTypeNew = await _repository.Create(claimdata);
                return claimTypeNew;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClaimTypeDTO> DeleteClaimsType(int claimTypeId)
        {
            try
            {
                ClaimType claimType = await _repository.Delete(claimTypeId);
                var claimdata = _mapper.Map<ClaimTypeDTO>(claimType);
                return claimdata;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClaimTypeDTO>> GetAllClaims()
        {
            try
            {
                var claims =  _mapper.Map<IEnumerable<ClaimTypeDTO>>(await _repository.GetAll());
                return claims;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ClaimTypeDTO> GetClaimById(int claimTypeId)
        {
            try
            {
                var claimType = await _repository.Get(claimTypeId);
                var claimdata = _mapper.Map<ClaimTypeDTO>(claimType);
                return claimdata;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
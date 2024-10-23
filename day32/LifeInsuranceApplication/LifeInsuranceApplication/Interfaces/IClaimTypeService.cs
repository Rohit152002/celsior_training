using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Interface
{
    public interface IClaimTypeService
    {
        public Task<int> CreateNewClaimType(ClaimTypeDTO claimType);
        public Task<ClaimTypeDTO> DeleteClaimsType(int claimTypeId);
        public Task<IEnumerable<ClaimTypeDTO>> GetAllClaims();
        public Task<ClaimTypeDTO> GetClaimById(int claimTypeId);
    }
}
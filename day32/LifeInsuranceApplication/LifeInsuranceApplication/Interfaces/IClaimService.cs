using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Interface
{
    public interface IClaimService
    {
        public Task<int> RequestNewClaim(ClaimDTO claimDTO);
        public Task<IEnumerable<ClaimResponseDTO>> GetClaims();
        public Task<CustomerClaim> UpdateClaimStatus(UpdateStatusDTO updateStatusDTO);
    }
}
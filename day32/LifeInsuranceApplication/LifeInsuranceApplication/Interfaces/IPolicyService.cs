using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Interface
{
    public interface IPolicyService
    {
        public Task<int> CreateNewPolicy(PolicyDTO policy);
        public Task<PolicyDTO> DeletePolicy(int policyId);
        public Task<IEnumerable<PolicyDTO>> GetAllPolicies();
        public Task<PolicyDTO> GetPolicyById(int policyId);
    }
}
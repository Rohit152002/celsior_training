using AutoMapper;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IRepository<int, Policy> _repository;
        private readonly IMapper _mapper;
        public PolicyService(IRepository<int, Policy> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> CreateNewPolicy(PolicyDTO policy)
        {
            try
            {
                var policydata =  _mapper.Map<Policy>(policy);
                var policyRepository = await _repository.Create(policydata);
                
                return policyRepository;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PolicyDTO> DeletePolicy(int policyId)
        {
            try
            {
                Policy policy = await _repository.Delete(policyId);
                var policydata =  _mapper.Map<PolicyDTO>(policy);
                return policydata;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PolicyDTO>> GetAllPolicies()
        {
            try
            {
                var policies = await _repository.GetAll();
                var policydata =  _mapper.Map<IEnumerable<PolicyDTO>>(policies);
                return policydata;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<PolicyDTO> GetPolicyById(int policyId)
        {
            try{
                Policy policy = await _repository.Get(policyId);
                if (policy == null){
                    throw new Exception("Not found");
                }
                var policydata =  _mapper.Map<PolicyDTO>(policy);
                return policydata;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
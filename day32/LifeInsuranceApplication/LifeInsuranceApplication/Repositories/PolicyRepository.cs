using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class PolicyRepository : IRepository<int, Policy>
    {
        private readonly InsuranceContext _context;
                private readonly ILogger<PolicyRepository> _logger;
        public PolicyRepository(InsuranceContext context, ILogger<PolicyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(Policy entity)
        {
            try
            {
                _context.Policies.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception)
            {
                _logger.LogError("Cannot created");
                throw new Exception("Cannot be created policy ");
            }
        }

        public async Task<Policy> Delete(int key)
        {
            try{
                Policy policy = await Get(key);
             
                 _context.Policies.Remove(policy);
                 await _context.SaveChangesAsync();
                 return policy;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Policy> Get(int key)
        {
            try
            {
                Policy policy = await _context.Policies.FirstOrDefaultAsync(x => x.Id == key);
                if (policy != null)
                {
                    return policy;
                }
                throw new Exception("There is no policy ");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Policy>> GetAll()
        {
            try
            {
                var policies = await _context.Policies.ToListAsync();
                if (policies.Count == 0)
                {
                    throw new Exception("There is no Policies");
                }
                return policies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Policy> Update(int key, Policy entity)
        {
             var policy = await Get(key);
            
               policy.PolicyNumber = entity.PolicyNumber;
               await _context.SaveChangesAsync();
               return policy;
            
            
        }
    }
}
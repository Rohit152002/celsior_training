using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class ClaimRepository : IRepository<int, CustomerClaim>
    {
        private readonly InsuranceContext _context;
        private readonly ILogger<ClaimRepository> _logger;
        public ClaimRepository(InsuranceContext context, ILogger<ClaimRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(CustomerClaim entity)
        {
              try
            {
                _context.CustomerClaims.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception)
            {
                _logger.LogError("Cannot created");
                throw new Exception("Cannot be created policy ");
            }
        }

        public async Task<CustomerClaim> Delete(int key)
        {
            try{
                CustomerClaim claims = await Get(key);
                 _context.CustomerClaims.Remove(claims);
                 await _context.SaveChangesAsync();
                 return claims;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomerClaim> Get(int key)
        {
            try
            {
                CustomerClaim claim = await _context.CustomerClaims.FirstOrDefaultAsync(x => x.Id == key);
                if (claim != null)
                {
                    return claim;
                }
                throw new Exception("There is no policy ");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CustomerClaim>> GetAll()
        {
             try
            {
                var claimTypes = await _context.CustomerClaims.ToListAsync();
                if (claimTypes.Count == 0)
                {
                    throw new Exception("There is no claimTypes");
                }
                return claimTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomerClaim> Update(int key, CustomerClaim entity)
        {
            try
            {

             var claims = await Get(key);
            claims.ClaimantName = entity.ClaimantName;
            claims.ClaimantEmail = entity.ClaimantEmail;
            claims.status = entity.status;
               await _context.SaveChangesAsync();
               return claims;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
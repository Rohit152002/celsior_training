using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class ClaimRepository : IRepository<int, Claim>
    {
        private readonly InsuranceContext _context;
        private readonly ILogger<ClaimRepository> _logger;
        public ClaimRepository(InsuranceContext context, ILogger<ClaimRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(Claim entity)
        {
              try
            {
                _context.Claims.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception)
            {
                _logger.LogError("Cannot created");
                throw new Exception("Cannot be created policy ");
            }
        }

        public async Task<Claim> Delete(int key)
        {
            try{
                Claim claims = await Get(key);
                 _context.Claims.Remove(claims);
                 await _context.SaveChangesAsync();
                 return claims;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Claim> Get(int key)
        {
            try
            {
                Claim claim = await _context.Claims.FirstOrDefaultAsync(x => x.Id == key);
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

        public async Task<IEnumerable<Claim>> GetAll()
        {
             try
            {
                var claimTypes = await _context.Claims.ToListAsync();
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

        public async Task<Claim> Update(int key, Claim entity)
        {
             var claims = await Get(key);
            
               claims.ClaimantName = entity.ClaimantName;
               claims.ClaimantEmail= entity.ClaimantEmail;
               await _context.SaveChangesAsync();
               return claims;
            
        }
    }
}
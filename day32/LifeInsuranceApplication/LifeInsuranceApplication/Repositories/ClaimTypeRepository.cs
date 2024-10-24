using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class ClaimTypeRepository : IRepository<int, ClaimType>
    {
        private readonly InsuranceContext _context;
                private readonly ILogger<ClaimTypeRepository> _logger;
        public ClaimTypeRepository(InsuranceContext context, ILogger<ClaimTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Create(ClaimType entity)
        {
            try
            {
                _context.ClaimTypes.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception)
            {
                _logger.LogError("Cannot created");
                throw new Exception("Cannot be created claim ");
            }
        }

        public async Task<ClaimType> Delete(int key)
        {
            try{
                ClaimType claims = await Get(key);
               _context.ClaimTypes.Remove(claims);
                 await _context.SaveChangesAsync();
                 return claims;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClaimType> Get(int key)
        {
            try
            {
                ClaimType claim = await _context.ClaimTypes.FirstOrDefaultAsync(x => x.Id == key);
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

        public async Task<IEnumerable<ClaimType>> GetAll()
        {
            try
            {
                var claimTypes = await _context.ClaimTypes.ToListAsync();
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

        public async Task<ClaimType> Update(int key, ClaimType entity)
        {
             var claimType = await Get(key);
            //if (claimType != null)
            //{
               claimType.ClaimName = entity.ClaimName;
               await _context.SaveChangesAsync();
               return claimType;
            //}
            
        }
    }
}
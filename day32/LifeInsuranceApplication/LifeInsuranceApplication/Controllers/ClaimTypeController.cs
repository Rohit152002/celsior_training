using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeInsuranceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimTypeController : ControllerBase
    {
        private readonly IClaimTypeService _claimTypeService;
        public ClaimTypeController(IClaimTypeService claimTypeService)
        {
            _claimTypeService = claimTypeService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateClaimAsync(ClaimTypeDTO claimTypeDTO)
        {
            try
            {
                var claimType = await _claimTypeService.CreateNewClaimType(claimTypeDTO);
                return Ok(new ResponseNewCreated{
                    Id=claimType,
                    Message="A new claim type is created "
                });
            }
            catch (Exception ex)
            {
                
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAllClaimAsync()
        {
            try
            {
                var claimsType= await _claimTypeService.GetAllClaims();
                return Ok(claimsType);
            }
            catch (Exception ex)
            {
                
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError,ex.Message));
                
            }
        }

    }
}

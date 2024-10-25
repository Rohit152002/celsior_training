using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeInsuranceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;
        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpPost]
        public async Task<ActionResult> ClaimNewAsync([FromForm] ClaimDTO claimDTO)
        {
            try
            {
                var claim= await _claimService.RequestNewClaim(claimDTO);
                return Ok(new ResponseNewCreated
                { Id=claim,
                Message="A new Claim has been requested"});
            }
            catch (Exception ex)
            {
               return BadRequest(StatusCode(500,ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetClaimAsync()
        {
            try{
                var claims = await _claimService.GetClaims();
                return Ok(claims);
            }catch(Exception ex)
            {
                return BadRequest(StatusCode(500,ex.Message));
            }
        }
    }
}

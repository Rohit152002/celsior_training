using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Misc;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeInsuranceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;
        private readonly IEmailSender _emailSender;
        public ClaimController(IClaimService claimService, IEmailSender emailSender)
        {
            _claimService = claimService;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Authorize]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPatch]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult> UpdateStatusClaim(UpdateStatusDTO updateStatusDTO)
        {
            try
            {
                var claims = await _claimService.UpdateClaimStatus(updateStatusDTO);
                var message = new Message(new string[] { "nilamanilaishram1979@gmail.com" }, "TaskUpdated", "Your Policy is updated successfully.");
                _emailSender.SendEmail(message);
                Console.WriteLine("email is send");
                return Ok(claims);
            }
            catch(Exception ex)
            {
                return BadRequest(StatusCode(500, ex.Message));
            }
        }
    }
}

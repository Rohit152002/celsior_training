

using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeInsuranceApplication.Controller
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolicyAsync(PolicyDTO policyDTO)
        {
            try
            {
                var policy = await _policyService.CreateNewPolicy(policyDTO);
                return Ok(new ResponseNewCreated
                {
                    Id = policy,
                    Message = "A new policy is created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPolicyAsync()
        {
            try
            {
                var policies = await _policyService.GetAllPolicies();
                return Ok(policies);
            }
            catch (Exception)
            {
                return BadRequest(StatusCode(StatusCodes.Status400BadRequest));
            }
        }
    }
}
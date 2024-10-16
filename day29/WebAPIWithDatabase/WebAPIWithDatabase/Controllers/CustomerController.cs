using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPIWithDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBasicServices _customerService;

        public CustomerController(ICustomerBasicServices customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDTO customer)
        {
            try
            {
                var customerId = await _customerService.CreateCustomer(customer);
                return Ok(customerId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
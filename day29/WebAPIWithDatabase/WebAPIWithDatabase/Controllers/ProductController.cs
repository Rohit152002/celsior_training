using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Controllers
{
    [Route("api/[controller]")]  // /api/product
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            try
            {
                var result = await _productService.AddProduct(product);
                _logger.LogInformation("Product Added");
                ResponseNewProduct response = new ResponseNewProduct();
                response.ProductId = result;
                response.Message = "Product is added";
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var products = await _productService.ViewAllProducts();
                return Ok(products);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet("getproductbyId")]
        public async Task<IActionResult> GetProductByID(int productId)
        {
            try
            {
                var product =await  _productService.GetProductById(productId);
                return Ok(product);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePriceByProductID(int productId, float price)
        {
            try
            {

            var product = await _productService.UpdateProduct(productId, price);
            return Ok(product);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

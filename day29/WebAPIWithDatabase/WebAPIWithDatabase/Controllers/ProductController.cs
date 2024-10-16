using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]

        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            try
            {
                var productId = await _productService.AddProduct(product);
                return Ok(productId);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
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

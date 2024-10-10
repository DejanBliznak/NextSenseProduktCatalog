using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace NextSenseProduktCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService  _productService;
        private IConfiguration _configuration;



        public ProductController(
            IProductService productService,
            IConfiguration configuration
            )
        {
            _productService = productService;
            _configuration = configuration;
        }

        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts()
        {           
            try
            {
                var products = await _productService.GetProducts();
                return new JsonResult(products);
            }
            catch (Exception ex)
            {               
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductdetails")]
        public async Task<IActionResult> GetProductDetails(int productId)
        {

            try
            {
                var product = await _productService.GetProductDetails(productId);
                return new JsonResult(product);
            }
            catch (Exception ex)
            {               
                return BadRequest();
            }
        }
       
    }
}

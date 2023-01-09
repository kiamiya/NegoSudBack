using Buisness;
using Common.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/products
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productBusiness;

        public ProductController(ILogger<ProductController> logger, IProductService productBusiness)
        {
            _logger = logger;
            _productBusiness = productBusiness;
        }

        [HttpGet("{id}", Name = "Get product")]
        public async Task<ProductDTO> Get(int id)
        {
            return await _productBusiness.Get(id);
        }

        [HttpGet("", Name = "Get all product")]
        public async Task<List<ProductDTO>> GetAll()
        {
            return await _productBusiness.GetAll();
        }

        [HttpPost("", Name = "Create product")]
        public async Task<ProductDTO> Add(CreateProductDTO product)
        {
            return await _productBusiness.Add(product);
        }

        [HttpPut("", Name = "Update product")]
        public async Task<ProductDTO> Update(UpdateProductDTO product)
        {
            return await _productBusiness.Update(product);
        }

        [HttpDelete("{id}", Name = "Delete product")]
        public async Task Delete(int id)
        {
            await _productBusiness.Delete(id);
        }
    }
}

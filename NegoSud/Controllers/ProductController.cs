using Buisness;
using Common.DTO.Product;
using Common.DTO.User;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/products
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productBusiness;
        private readonly IUserService _userBusiness;

        public ProductController(ILogger<ProductController> logger, IProductService productBusiness, IUserService userService)
        {
            _logger = logger;
            _productBusiness = productBusiness;
            _userBusiness = userService;
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

            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }

            return await _productBusiness.Add(product);
        }

        [HttpPut("", Name = "Update product")]
        public async Task<ProductDTO> Update(UpdateProductDTO product)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }
            return await _productBusiness.Update(product);
        }

        [HttpDelete("{id}", Name = "Delete product")]
        public async Task Delete(int id)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return;
            }
            await _productBusiness.Delete(id);
        }

        private async Task<UserDTO> GetLoggedUser()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string b64 = token.ToString().Split(" ")[1];
            string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(b64));
            string email = decoded.Split(":")[0];
            string pass = decoded.Split(":")[1];

            if (!(await _userBusiness.Login(email, pass)))
            {
                return null;
            }
            return await _userBusiness.GetSelfUser(email);
        }
    }
}

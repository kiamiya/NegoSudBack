using Buisness;
using Common.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/users
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userBusiness;

        public UserController(ILogger<UserController> logger, IUserService userBusiness)
        {
            _logger = logger;
            _userBusiness = userBusiness;
        }

        [HttpGet("{id}", Name = "Get user")]
        public async Task<UserDTO> Get(int id)
        {
            return await _userBusiness.Get(id);
        }

        [HttpGet("", Name = "Get all user")]
        public async Task<List<UserDTO>> GetAll()
        {
            return await _userBusiness.GetAll();
        }

        [HttpPost("", Name = "Create user")]
        public async Task<UserDTO> Add(CreateUserDTO user)
        {
            return await _userBusiness.Add(user);
        }

        [HttpPut("", Name = "Update user")]
        public async Task<UserDTO> Update(UpdateUserDTO user)
        {
            return await _userBusiness.Update(user);
        }

        [HttpDelete("{id}", Name = "Delete user")]
        public async Task Delete(int id)
        {
            await _userBusiness.Delete(id);
        }
    }
}

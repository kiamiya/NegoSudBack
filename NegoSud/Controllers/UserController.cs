using Buisness;
using Common.DTO.User;
using Common.Model;
using DataAccess.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpGet("{me:alpha}", Name = "Get self user")]
        public async Task<UserDTO> Get(string me)
        {
            if (me != "me") return null;
            return await GetLoggedUser();
        }

        [HttpGet("{id}", Name = "Get user")]
        public async Task<UserDTO> Get(int id)
        {

            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }

            return await _userBusiness.Get(id);
        }

        [HttpGet("", Name = "Get all user")]
        public async Task<List<UserDTO>> GetAll()
        {

            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }

            return await _userBusiness.GetAll();
        }

        [HttpPost("", Name = "Create user")]
        public async Task<UserDTO> Add(CreateUserDTO user)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                user.Role = (int)Role.User;
            }

            return await _userBusiness.Add(user);
        }

        [HttpPut("", Name = "Update user")]
        public async Task<UserDTO> Update(UpdateUserDTO user)
        {

            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                user.Role = (int)Role.User;
            }

            return await _userBusiness.Update(user);
        }

        [HttpDelete("{id}", Name = "Delete user")]
        public async Task Delete(int id)
        {

            UserDTO self = await GetLoggedUser();

            if ((self == null || self.Role != (int)Role.Admin) && self.Id != id)
            {
                return;
            }

            await _userBusiness.Delete(id);
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

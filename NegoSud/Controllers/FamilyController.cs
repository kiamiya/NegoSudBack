using Buisness;
using Common.DTO.Family;
using Common.DTO.User;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/familys
    [ApiController]
    [Route("families")]
    public class FamilyController : Controller
    {
        private readonly ILogger<FamilyController> _logger;
        private readonly IFamilyService _familyBusiness;
        private readonly IUserService _userBusiness;

        public FamilyController(ILogger<FamilyController> logger, IFamilyService familyBusiness, IUserService userService)
        {
            _logger = logger;
            _familyBusiness = familyBusiness;
            _userBusiness = userService;
        }

        [HttpGet("{id}", Name = "Get family")]
        public async Task<FamilyDTO> Get(int id)
        {
            return await _familyBusiness.Get(id);
        }

        [HttpGet("", Name = "Get all family")]
        public async Task<List<FamilyDTO>> GetAll()
        {
            return await _familyBusiness.GetAll();
        }

        [HttpPost("", Name = "Create family")]
        public async Task<FamilyDTO> Add(CreateFamilyDTO family)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }
            return await _familyBusiness.Add(family);
        }

        [HttpPut("", Name = "Update family")]
        public async Task<FamilyDTO> Update(UpdateFamilyDTO family)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }
            return await _familyBusiness.Update(family);
        }

        [HttpDelete("{id}", Name = "Delete family")]
        public async Task Delete(int id)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return;
            }
            await _familyBusiness.Delete(id);
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

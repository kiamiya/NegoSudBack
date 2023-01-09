using Buisness;
using Common.DTO.Fournisseur;
using Common.DTO.User;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/fournisseurs
    [ApiController]
    [Route("fournisseurs")]
    public class FournisseurController : Controller
    {
        private readonly ILogger<FournisseurController> _logger;
        private readonly IFournisseurService _fournisseurBusiness;
        private readonly IUserService _userBusiness;

        public FournisseurController(ILogger<FournisseurController> logger, IFournisseurService fournisseurBusiness, IUserService userService)
        {
            _logger = logger;
            _fournisseurBusiness = fournisseurBusiness;
            _userBusiness = userService;
        }

        [HttpGet("{id}", Name = "Get fournisseur")]
        public async Task<FournisseurDTO> Get(int id)
        {
            return await _fournisseurBusiness.Get(id);
        }

        [HttpGet("", Name = "Get all fournisseur")]
        public async Task<List<FournisseurDTO>> GetAll()
        {
            return await _fournisseurBusiness.GetAll();
        }

        [HttpPost("", Name = "Create fournisseur")]
        public async Task<FournisseurDTO> Add(CreateFournisseurDTO fournisseur)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }
            return await _fournisseurBusiness.Add(fournisseur);
        }

        [HttpPut("", Name = "Update fournisseur")]
        public async Task<FournisseurDTO> Update(UpdateFournisseurDTO fournisseur)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return null;
            }
            return await _fournisseurBusiness.Update(fournisseur);
        }

        [HttpDelete("{id}", Name = "Delete fournisseur")]
        public async Task Delete(int id)
        {
            UserDTO self = await GetLoggedUser();

            if (self == null || self.Role != (int)Role.Admin)
            {
                return;
            }
            await _fournisseurBusiness.Delete(id);
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

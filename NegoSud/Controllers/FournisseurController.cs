using Buisness;
using Common.DTO.Fournisseur;
using Microsoft.AspNetCore.Mvc;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/fournisseurs
    [ApiController]
    [Route("fournisseurs")]
    public class FournisseurController : Controller
    {
        private readonly ILogger<FournisseurController> _logger;
        private readonly IFournisseurService _fournisseurBusiness;

        public FournisseurController(ILogger<FournisseurController> logger, IFournisseurService fournisseurBusiness)
        {
            _logger = logger;
            _fournisseurBusiness = fournisseurBusiness;
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
            return await _fournisseurBusiness.Add(fournisseur);
        }

        [HttpPut("", Name = "Update fournisseur")]
        public async Task<FournisseurDTO> Update(UpdateFournisseurDTO fournisseur)
        {
            return await _fournisseurBusiness.Update(fournisseur);
        }

        [HttpDelete("{id}", Name = "Delete fournisseur")]
        public async Task Delete(int id)
        {
            await _fournisseurBusiness.Delete(id);
        }
    }
}

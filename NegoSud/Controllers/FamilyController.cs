using Buisness;
using Common.DTO.Family;
using Microsoft.AspNetCore.Mvc;

namespace NegoSud.Controllers
{

    // POST 127.0.0.1:5000/familys
    [ApiController]
    [Route("families")]
    public class FamilyController : Controller
    {
        private readonly ILogger<FamilyController> _logger;
        private readonly IFamilyService _familyBusiness;

        public FamilyController(ILogger<FamilyController> logger, IFamilyService familyBusiness)
        {
            _logger = logger;
            _familyBusiness = familyBusiness;
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
            return await _familyBusiness.Add(family);
        }

        [HttpPut("", Name = "Update family")]
        public async Task<FamilyDTO> Update(UpdateFamilyDTO family)
        {
            return await _familyBusiness.Update(family);
        }

        [HttpDelete("{id}", Name = "Delete family")]
        public async Task Delete(int id)
        {
            await _familyBusiness.Delete(id);
        }
    }
}

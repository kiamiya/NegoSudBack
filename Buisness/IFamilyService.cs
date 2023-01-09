using Common.DTO.Family;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness
{
    public interface IFamilyService
    {
        Task<FamilyDTO> Add(CreateFamilyDTO user);
        Task Delete(int id);
        Task<FamilyDTO> Update(UpdateFamilyDTO userDTO);
        Task<FamilyDTO> Get(int id);
        Task<List<FamilyDTO>> GetAll();
    }
}

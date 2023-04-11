using Common.DTO.Panier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness
{
    public interface IPanierService
    {
        Task<PanierDTO> Add(CreatePanierDTO user);
        Task Delete(int id);
        Task<PanierDTO> Update(UpdatePanierDTO userDTO);
        Task<PanierDTO> Get(int id);
        Task<List<PanierDTO>> GetAll();
    }
}

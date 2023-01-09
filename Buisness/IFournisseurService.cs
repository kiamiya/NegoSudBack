using Common.DTO.Fournisseur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness
{
    public interface IFournisseurService
    {
        Task<FournisseurDTO> Add(CreateFournisseurDTO user);
        Task Delete(int id);
        Task<FournisseurDTO> Update(UpdateFournisseurDTO userDTO);
        Task<FournisseurDTO> Get(int id);
        Task<List<FournisseurDTO>> GetAll();
    }
}

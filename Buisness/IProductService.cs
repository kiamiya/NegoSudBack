using Common.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness
{
    public interface IProductService
    {
        Task<ProductDTO> Add(CreateProductDTO user);
        Task Delete(int id);
        Task<ProductDTO> Update(UpdateProductDTO userDTO);
        Task<ProductDTO> Get(int id);
        Task<List<ProductDTO>> GetAll();
    }
}

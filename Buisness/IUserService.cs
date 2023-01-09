using Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness
{
    public interface IUserService
    {
        Task<UserDTO> Add(CreateUserDTO user);
        Task Delete(int id);
        Task<UserDTO> Update(UpdateUserDTO userDTO);
        Task<UserDTO> Get(int id);
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetSelfUser(string email);
        Task<bool> Login(string email, string password);
    }
}

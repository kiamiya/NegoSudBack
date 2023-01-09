using AutoMapper;
using Buisness;
using Common.DTO.User;
using Common.Model;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        private IMapper _mapper;
        private IUnitOfWork _worker;
        
        public UserService(IRepository<User> userRepository, IMapper mapper, IUnitOfWork worker)
        {
            _worker = worker;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Add(CreateUserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userRepository.Add(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task Delete(int id)
        {
            var userToDelete = _userRepository.Get(id);
            _userRepository.Delete(userToDelete);
            await _worker.SaveIntoDbContextAsync();
        }

        public async Task<UserDTO> Update(UpdateUserDTO userDTO)
        {
            var user = _userRepository.Get(userDTO.Id);
            var userEntity = _mapper.Map(userDTO, user);
            _userRepository.Update(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<UserDTO> Get(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}

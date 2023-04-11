using AutoMapper;
using Buisness;
using Common.DTO.Panier;
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
    public class PanierService : IPanierService
    {
        private IRepository<Panier> _userRepository;
        private IMapper _mapper;
        private IUnitOfWork _worker;

        public PanierService(IRepository<Panier> userRepository, IMapper mapper, IUnitOfWork worker)
        {
            _worker = worker;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<PanierDTO> Add(CreatePanierDTO user)
        {
            var userEntity = _mapper.Map<Panier>(user);
            _userRepository.Add(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<PanierDTO>(userEntity);
        }

        public async Task Delete(int id)
        {
            var userToDelete = _userRepository.Get(id);
            _userRepository.Delete(userToDelete);
            await _worker.SaveIntoDbContextAsync();
        }

        public async Task<PanierDTO> Update(UpdatePanierDTO userDTO)
        {
            var user = _userRepository.Get(userDTO.Id);
            var userEntity = _mapper.Map(userDTO, user);
            _userRepository.Update(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<PanierDTO>(userEntity);
        }

        public async Task<PanierDTO> Get(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<PanierDTO>(user);
        }

        public async Task<List<PanierDTO>> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<PanierDTO>>(users);
        }
    }
}

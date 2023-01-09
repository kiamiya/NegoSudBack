using AutoMapper;
using Buisness;
using Common.DTO.Fournisseur;
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
    public class FournisseurService : IFournisseurService
    {
        private IRepository<Fournisseur> _userRepository;
        private IMapper _mapper;
        private IUnitOfWork _worker;
        
        public FournisseurService(IRepository<Fournisseur> userRepository, IMapper mapper, IUnitOfWork worker)
        {
            _worker = worker;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<FournisseurDTO> Add(CreateFournisseurDTO user)
        {
            var userEntity = _mapper.Map<Fournisseur>(user);
            _userRepository.Add(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<FournisseurDTO>(userEntity);
        }

        public async Task Delete(int id)
        {
            var userToDelete = _userRepository.Get(id);
            _userRepository.Delete(userToDelete);
            await _worker.SaveIntoDbContextAsync();
        }

        public async Task<FournisseurDTO> Update(UpdateFournisseurDTO userDTO)
        {
            var user = _userRepository.Get(userDTO.Id);
            var userEntity = _mapper.Map(userDTO, user);
            _userRepository.Update(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<FournisseurDTO>(userEntity);
        }

        public async Task<FournisseurDTO> Get(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<FournisseurDTO>(user);
        }

        public async Task<List<FournisseurDTO>> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<FournisseurDTO>>(users);
        }
    }
}

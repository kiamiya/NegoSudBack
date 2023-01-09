using AutoMapper;
using Buisness;
using Common.DTO.Family;
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
    public class FamilyService : IFamilyService
    {
        private IRepository<Family> _userRepository;
        private IMapper _mapper;
        private IUnitOfWork _worker;
        
        public FamilyService(IRepository<Family> userRepository, IMapper mapper, IUnitOfWork worker)
        {
            _worker = worker;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<FamilyDTO> Add(CreateFamilyDTO user)
        {
            var userEntity = _mapper.Map<Family>(user);
            _userRepository.Add(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<FamilyDTO>(userEntity);
        }

        public async Task Delete(int id)
        {
            var userToDelete = _userRepository.Get(id);
            _userRepository.Delete(userToDelete);
            await _worker.SaveIntoDbContextAsync();
        }

        public async Task<FamilyDTO> Update(UpdateFamilyDTO userDTO)
        {
            var user = _userRepository.Get(userDTO.Id);
            var userEntity = _mapper.Map(userDTO, user);
            _userRepository.Update(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<FamilyDTO>(userEntity);
        }

        public async Task<FamilyDTO> Get(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<FamilyDTO>(user);
        }

        public async Task<List<FamilyDTO>> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<FamilyDTO>>(users);
        }
    }
}

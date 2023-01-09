using AutoMapper;
using Buisness;
using Common.DTO.Product;
using Common.Model;
using DataAccess.Migrations;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _userRepository;
        private IRepository<Family> _familyRepository;
        private IRepository<Fournisseur> _fournisseurRepository;
        private IMapper _mapper;
        private IUnitOfWork _worker;
        
        public ProductService(IRepository<Product> userRepository, IRepository<Family> familyRepository, IRepository<Fournisseur> fournisseurRepository, IMapper mapper, IUnitOfWork worker)
        {
            _worker = worker;
            _mapper = mapper;
            _userRepository = userRepository;
            _familyRepository = familyRepository;
            _fournisseurRepository = fournisseurRepository;
        }

        public async Task<ProductDTO> Add(CreateProductDTO user)
        {


            var userEntity = _mapper.Map<Product>(user);
            userEntity.Fournisseur = _fournisseurRepository.Get(user.Fournisseur);
            userEntity.Family = _familyRepository.Get(user.Family);
            _userRepository.Add(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<ProductDTO>(userEntity);
        }

        public async Task Delete(int id)
        {
            var userToDelete = _userRepository.Get(id);
            _userRepository.Delete(userToDelete);
            await _worker.SaveIntoDbContextAsync();
        }

        public async Task<ProductDTO> Update(UpdateProductDTO userDTO)
        {
            var user = _userRepository.Get(userDTO.Id);
            var userEntity = _mapper.Map(userDTO, user);
            userEntity.Fournisseur = _fournisseurRepository.Get(userDTO.Fournisseur);
            userEntity.Family = _familyRepository.Get(userDTO.Family);
            _userRepository.Update(userEntity);
            await _worker.SaveIntoDbContextAsync();
            return _mapper.Map<ProductDTO>(userEntity);
        }

        public async Task<ProductDTO> Get(int id)
        {
            var user = _userRepository.Get(id);

            user.Family = _familyRepository.Get(user.FamilyId);
            user.Fournisseur = _fournisseurRepository.Get(user.FournisseurId);
            
            return _mapper.Map<ProductDTO>(user);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var users = _userRepository.GetAll();

            users.ForEach(e =>
            {
                e.Family = _familyRepository.Get(e.FamilyId);
                e.Fournisseur = _fournisseurRepository.Get(e.FournisseurId);
            });

            return _mapper.Map<List<ProductDTO>>(users);
        }
    }
}

using AutoMapper;
using Common.DTO.Fournisseur;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mapping
{
    public class FournisseurMapping : Profile
    {
        public FournisseurMapping()
        {
            CreateMap<Fournisseur, FournisseurDTO>();
            CreateMap<FournisseurDTO, Fournisseur>();


            CreateMap<Fournisseur, CreateFournisseurDTO>();
            CreateMap<CreateFournisseurDTO, Fournisseur>();

            CreateMap<Fournisseur, UpdateFournisseurDTO>();
            CreateMap<UpdateFournisseurDTO, Fournisseur>();
        }
    }
}

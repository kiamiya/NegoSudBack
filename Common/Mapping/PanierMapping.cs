using AutoMapper;
using Common.DTO.Panier;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mapping
{
    public class PanierMapping : Profile
    {

        public PanierMapping()
        {
            CreateMap<Panier, PanierDTO>();
            CreateMap<PanierDTO, Panier>();

            CreateMap<Panier, CreatePanierDTO>();
            CreateMap<CreatePanierDTO, Panier>();

            CreateMap<Panier, UpdatePanierDTO>();
            CreateMap<UpdatePanierDTO, Panier>();
        }
    }
}
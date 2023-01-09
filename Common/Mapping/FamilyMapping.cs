using AutoMapper;
using Common.DTO.Family;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mapping
{
    public class FamilyMapping : Profile
    {

        public FamilyMapping()
        {
            CreateMap<Family, FamilyDTO>();
            CreateMap<FamilyDTO, Family>();

            CreateMap<Family, CreateFamilyDTO>();
            CreateMap<CreateFamilyDTO, Family>();

            CreateMap<Family, UpdateFamilyDTO>();
            CreateMap<UpdateFamilyDTO, Family>();
        }
    }
}

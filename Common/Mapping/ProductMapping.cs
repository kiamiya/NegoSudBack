using AutoMapper;
using Common.DTO.Product;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Fournisseur, x => x.MapFrom(y => y.Fournisseur.Id))
                .ForMember(x => x.Family, x => x.MapFrom(y => y.Family.Id))
                .ReverseMap();
            CreateMap<ProductDTO, Product>()
                .ForMember(des => des.Id, opt => opt.Ignore())
                .ForMember(des => des.Fournisseur, opt => opt.Ignore())
                .ForMember(des => des.Family, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Fournisseur = new Fournisseur() { Id = src.Fournisseur };
                    dest.Family = new Family() { Id = src.Family };
                });


            CreateMap<Product, CreateProductDTO>();
            CreateMap<CreateProductDTO, Product>()
                .ForMember(des => des.Id, opt => opt.Ignore())
                .ForMember(des => des.Family, opt => opt.Ignore())
                .ForMember(des => des.Fournisseur, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Fournisseur = new Fournisseur() { Id = src.Fournisseur };
                    dest.Family = new Family() { Id = src.Family };
                });

            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>()
                .ForMember(des => des.Id, opt => opt.Ignore())
                .ForMember(des => des.Fournisseur, opt => opt.Ignore())
                .ForMember(des => des.Family, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Fournisseur = new Fournisseur() { Id = src.Fournisseur };
                    dest.Family = new Family() { Id = src.Family };
                });
        }
    }
}

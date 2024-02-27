using Application.Dtos.Product;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductIncomingDTO, Product>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.Price));

            CreateMap<Product, ProductOutgoingDTO>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.Price));
        }
    }
}

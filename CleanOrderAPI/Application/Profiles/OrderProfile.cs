using Application.Dtos.Order;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderIncomingDTO, Order>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => "Received"))
                .ForMember(dest => dest.Products,
                opt => opt.MapFrom(src => src.Products));
        }
    }
}

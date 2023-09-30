using AutoMapper;
using MicroservicesProject.Core.Entities.PostgreSQL;
using Ordering.Application.Common.Dtos;
using Ordering.Application.Orders.Commands.Create;
using Ordering.Application.Orders.Commands.Update;

namespace Ordering.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
        }
    }
}

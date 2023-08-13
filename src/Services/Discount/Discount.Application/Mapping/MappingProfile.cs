using AutoMapper;
using Discount.Application.Common.Dtos;
using MicroservicesProject.Core.Entities.PostgreSQL;

namespace Discount.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}

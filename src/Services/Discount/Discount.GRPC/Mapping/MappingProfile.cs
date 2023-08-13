using AutoMapper;
using Discount.GRPC.Protos;
using MicroservicesProject.Core.Entities.PostgreSQL;

namespace Discount.GRPC.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}

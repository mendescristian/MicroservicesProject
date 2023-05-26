using AutoMapper;
using Catalog.Application.Common.Dtos;
using MicroservicesProject.Core.Entities.Mongo;

namespace Catalog.Application.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

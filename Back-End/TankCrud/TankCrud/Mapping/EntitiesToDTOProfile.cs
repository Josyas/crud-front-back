using AutoMapper;
using TankCrud.DTOs;
using TankCrud.Models;

namespace TankCrud.Mapping
{
    public class EntitiesToDTOProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
            CreateMap<Tank, TankDTO>().ReverseMap();
        }
    }
}
using AutoMapper;
using SampleShop.ApplicationService.Contract.Dtos.BrandDto;
using SampleShop.Domain.Models;

namespace SampleShop.Domain.AutoMapperConfiguration
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}

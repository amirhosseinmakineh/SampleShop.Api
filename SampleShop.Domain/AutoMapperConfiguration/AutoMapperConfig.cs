using AutoMapper;
using SampleShop.ApplicationService.Contract.Dtos.BrandDto;
using SampleShop.ApplicationService.Contract.Dtos.OrderDto;
using SampleShop.Domain.Models;

namespace SampleShop.Domain.AutoMapperConfiguration
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            #region RegisterOrderMapping
            CreateMap<Order, AddOrderDto>().ReverseMap();
            #endregion
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}

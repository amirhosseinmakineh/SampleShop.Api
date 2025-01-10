using AutoMapper;
using SampleShop.ApplicationService.Contract.Dtos.BrandDto;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBaseRepository<int,Brand> repository;
        private readonly IMapper mapper;
        public BrandService(IBaseRepository<int, Brand> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<BrandDto> GetAllBrands()
        {
            var brands = repository.GetAll();

            var result = mapper.Map<List<BrandDto>>(brands);

            return result;
        }
    }
}

using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;

namespace SampleShop.ApplicationService.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository repository;

        public ProductDetailService(IProductDetailRepository repository)
        {
            this.repository = repository;
        }

        public List<ProductDetailDto> GetAll()
        {
            return repository.GetAll()
            .Select(x => new ProductDetailDto()
            {
                CreateObjectDate = x.CreateObjectDat,
                Description = x.Description,
                Id = x.Id,
                IsDelete = x.IsDelete,
                ProductId = x.ProductId
            }).ToList();
        }
    }
}

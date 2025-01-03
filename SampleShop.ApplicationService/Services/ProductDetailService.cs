using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository repository;

        public ProductDetailService(IProductDetailRepository repository)
        {
            this.repository = repository;
        }

        public void Add(ProductDetailAddDto dto)
        {
            var productDetail = new ProductDetail()
            {
                CreateObjectDat = dto.CreateObjectDate,
                Description = dto.Description,
                Id = dto.Id,
                IsDelete = dto.IsDelete,
                ProductId = dto.ProductId
            };
            repository.Add(productDetail);
            repository.SaveChanges();
        }

        public void Delete(long id)
        {
            repository.Delete(id);
            repository.SaveChanges();
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

        public void Update(ProductDetailUpdateDto dto)
        {
            var productDetail = repository.GetById(dto.Id);
            productDetail.Description = dto.Description;
            productDetail.IsDelete = dto.IsDelete;
            productDetail.CreateObjectDat = dto.CreateObjectDate;
            productDetail.ProductId = dto.ProductId;
        }
    }
}

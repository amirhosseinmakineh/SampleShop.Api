using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using ServiceStack;

namespace SampleShop.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly ICategoryRepository categoryRepository;
        private readonly DateConvertor dateConvertor;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository, DateConvertor dateConvertor)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
            this.dateConvertor = dateConvertor;
        }

        public List<ProductDto> GetNewsProduct()
        {
            var result = repository.GetAll()
                .Select(x => new ProductDto()
            {
                CategoryTitle = x.Category.Title,
                CreateObjectDate = x.CreateObjectDat,
                ImageName = x.ImageName,
                IsDelete = x.IsDelete,
                Price = x.Price,
                Title = x.Title,
                CategoryId = x.CategoryId,
                Id = x.Id
            }).OrderBy(x => x.CreateObjectDate)
            .ToList();
            return result;
        }

        public List<ProductDto> GetSpacialProducts()
        {
            var result = repository.GetAll()
               .Select(x => new ProductDto()
               {
                   CategoryTitle = x.Category.Title,
                   CreateObjectDate = x.CreateObjectDat,
                   ImageName = x.ImageName,
                   IsDelete = x.IsDelete,
                   Price = x.Price,
                   Title = x.Title,
                   CategoryId = x.CategoryId,
                   Id = x.Id
               }).OrderByDescending(x => x.Price)
               .ToList();
            return result;
        }
    }
}

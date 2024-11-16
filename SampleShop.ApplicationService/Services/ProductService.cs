using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;

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
            var products = repository.GetAll()
                .ToList();
            var categories = categoryRepository.GetAll().Select(x=> new CategoryDto()
            {
                Id = x.Id
            }).ToList();
            var result = (from p in products
                         join c in categories on p.CategoryId equals c.Id
                         select new ProductDto()
                         {
                             CategoryTitle = p.Category.Title,
                             CreateObjectDate = p.CreateObjectDat,
                             Id = p.Id,
                             ImageName = p.ImageName,
                             IsDelete = p.IsDelete,
                             Price = p.Price,
                             Title = p.Title
                         }).ToList();
            return result;
        }
    }
}

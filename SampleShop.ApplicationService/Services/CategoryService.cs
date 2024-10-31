using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;

namespace SampleShop.ApplicationService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public List<CategoryDto> GetAllCategory()
        {
            return repository
                .GetAll()
                .Select(x => new CategoryDto()
            {
                Description = x.Description,
                Id = x.Id,
                IsDelete = x.IsDelete,
                ParentId = x.ParentId,
                Title = x.Title,
            }).ToList();
        }
    }
}

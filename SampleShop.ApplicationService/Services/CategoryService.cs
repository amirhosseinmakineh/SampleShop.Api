using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void AddCategory(AddCategoryDto dto)
        {
            DateConvertor dateConvertor = new DateConvertor();
            var category = new Category()
            {
                Title = dto.Title,
                Description = dto.Description,
                IsDelete = false,
                ParentId = dto.ParentID,
                CreateObjectDat = dateConvertor.CreatePerisanDate(dto.CreateObjectDat, out string persianDate),
            };
            repository.Add(category);
            repository.SaveChanges();
        }
        public List<CategoryDto> GetAllCategoryForMenu ()
        {
            return repository
                .GetAll()
                .Select(x => new CategoryDto()
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Title = x.Title,
                }).ToList();
        }
    }
}

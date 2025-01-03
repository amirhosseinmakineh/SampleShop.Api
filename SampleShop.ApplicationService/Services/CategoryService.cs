using Microsoft.EntityFrameworkCore;
using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using ServiceStack;

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
        public List<CategoryDto> GetAllCategoryForMenu()
        {
            var categories = repository.GetAll().ToList(); 

            var result = categories
                .Where(x => x.ParentId == null) 
                .Select(x => new CategoryDto()
                {
                    CreateObjectDate = x.CreateObjectDat,
                    Description = x.Description,
                    Id = x.Id,
                    IsDelete = x.IsDelete,
                    ParentId = x.ParentId,
                    Title = x.Title,
                    SubCategories = categories
                        .Where(c => c.ParentId == x.Id) 
                        .Select(c => new CategoryDto()
                        {
                            CreateObjectDate = c.CreateObjectDat,
                            Description = c.Description,
                            Id = c.Id,
                            IsDelete = c.IsDelete,
                            ParentId = c.ParentId,
                            Title = c.Title
                        }).ToList()
                })
                .ToList();

            return result;

        }
        public List<CategoryDto> GetAll()
        {
            var result = (from c in repository.GetAll()
                          select new CategoryDto()
                          {
                              CreateObjectDate = c.CreateObjectDat,
                              Description = c.Description,
                              Id = c.Id,
                              IsDelete = c.IsDelete,
                              ParentId = c.ParentId,
                              Title = c.Title
                          }).OrderByDescending(x => x.CreateObjectDate)
                         .ToList();
            return result;
        }

        public void UpdateCategory(UpdateCategoryDto dto)
        {
            var category = repository.GetById(dto.Id);
            category.Title = dto.Title;
            category.CreateObjectDat = dto.CreateObjectDate;
            category.Description = dto.Description;
            category.IsDelete = dto.IsDelete;
            category.ParentId = dto.ParentID;
            repository.Update(category);
            repository.SaveChanges();
        }

        public void Delete(long id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }
    }
}

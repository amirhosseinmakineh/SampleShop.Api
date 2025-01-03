using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository repository;

        public ColorService(IColorRepository repository)
        {
            this.repository = repository;
        }

        public void Add(ColorAddDto dto)
        {
            var color = new Color()
            {
                CreateObjectDat = dto.CreateObjectDate,
                Id = dto.Id,
                IsDelete = dto.IsDelete,
                ProductId = dto.ProductId,
                Title = dto.Title
            };
            repository.Add(color);
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }

        public List<ColorDto> GetAll()
        {
            return repository.GetAll()
                .Select(x => new ColorDto()
            {
                CreateObjectDate = x.CreateObjectDat,
                Id = x.Id,
                IsDelete = x.IsDelete,
                Name = x.Title,
                ProductId = x.ProductId
            }).ToList();
        }

        public void Update(ColorAddDto dto)
        {
            var color = repository.GetById(dto.Id);
            color.IsDelete = dto.IsDelete;
            color.CreateObjectDat = dto.CreateObjectDate;
            color.Title = dto.Title;
            color.CreateObjectDat = dto.CreateObjectDate;
            color.ProductId = dto.ProductId;
            repository.Update(color);
            repository.SaveChanges();
        }
    }
}

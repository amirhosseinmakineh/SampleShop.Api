using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;

namespace SampleShop.ApplicationService.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository repository;

        public ColorService(IColorRepository repository)
        {
            this.repository = repository;
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
                ProductId = x.ProductI
            }).ToList();
        }
    }
}

using SampleShop.ApplicationService.Contract.Dtos.FeatureDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository repository;

        public FeatureService(IFeatureRepository repository)
        {
            this.repository = repository;
        }

        public void Add(FeatureAddDto dto)
        {
            var feature = new Featur()
            {
                CreateObjectDat = dto.CreateObjectDate,
                Id = dto.Id,
                IsDelete = dto.IsDelete,
                Name = dto.Title,
                ProductId = dto.ProductId
            };
        }

        public void Delete(long id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }

        public List<FeatureDto> GetAll()
        {
            return repository.GetAll()
                .Select(x => new FeatureDto()
            {
                CreateObjectDate = x.CreateObjectDat,
                Id = x.Id,
                IsDelete = x.IsDelete,
                ProductId = x.ProductId,
                Title = x.Name
            }).ToList();
        }

        public void Update(FeatureUpdateDto dto)
        {
            var feature = repository.GetById(dto.Id);
            feature.CreateObjectDat = dto.CreateObjectDate;
            feature.IsDelete = dto.IsDelete;
            feature.ProductId = dto.ProductId;
            feature.Name = dto.Title;
            repository.Update(feature);
            repository.SaveChanges();
        }
    }
}

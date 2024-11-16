using SampleShop.ApplicationService.Contract.Dtos.FeatureDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;

namespace SampleShop.ApplicationService.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository repository;

        public FeatureService(IFeatureRepository repository)
        {
            this.repository = repository;
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
    }
}

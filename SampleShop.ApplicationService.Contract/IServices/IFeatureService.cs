using SampleShop.ApplicationService.Contract.Dtos.FeatureDtos;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IFeatureService
    {
        List<FeatureDto> GetAll();
        void Add(FeatureAddDto dto);
        void Update(FeatureUpdateDto dto);
        void Delete(long id );
    }
}

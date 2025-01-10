using SampleShop.ApplicationService.Contract.Dtos.BrandDto;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IBrandService
    {
        List<BrandDto> GetAllBrands();
    }
}

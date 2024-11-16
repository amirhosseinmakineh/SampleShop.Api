using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IProductDetailService
    {
        List<ProductDetailDto> GetAll();
    }
}

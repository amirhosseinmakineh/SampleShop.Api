using SampleShop.ApplicationService.Contract.Dtos;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IProductService
    {
        List<ProductDto> GetNewsProduct();
        List<ProductDto> GetSpacialProducts();
    }
}

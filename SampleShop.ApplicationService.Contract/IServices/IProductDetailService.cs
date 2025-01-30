using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IProductDetailService
    {
        List<ProductDetailDto> GetAll();
        ProductDetailDto GetProductDetail(long productId);
        void Add(ProductDetailAddDto dto);
        void Update(ProductDetailUpdateDto dto);
        void Delete(long id);
    }
}

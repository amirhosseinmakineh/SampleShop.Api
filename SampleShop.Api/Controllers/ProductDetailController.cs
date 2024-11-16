using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;
        private readonly IRedisConfigurationService<ProductDetailDto> redisConfiguration;

        public ProductDetailController(IProductDetailService productDetailService, IRedisConfigurationService<ProductDetailDto> redisConfiguration)
        {
            this.productDetailService = productDetailService;
            this.redisConfiguration = redisConfiguration;
        }

        [HttpGet]
        public IActionResult GetNewsProduct()
        {
            var productDetailsCashData = redisConfiguration.GetData<List<ProductDetailDto>>(nameof(ProductDetailDto));

            if (productDetailsCashData != null)
                return Ok(productDetailsCashData);

            var productDetails = productDetailService.GetAll();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setProductDetailCashData = redisConfiguration.SetData(nameof(ProductDetailDto), productDetails, expireCashData);

            return Ok(productDetails);
        }
    }
}

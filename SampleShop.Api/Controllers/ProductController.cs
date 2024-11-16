using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRedisConfigurationService<ProductDto> redisConfiguration;
        public ProductController(IProductService productService, IRedisConfigurationService<ProductDto> redisConfiguration)
        {
            this.productService = productService;
            this.redisConfiguration = redisConfiguration;
        }

        [HttpGet]
        public IActionResult GetNewsProduct()
        {
            var productsCashData = redisConfiguration.GetData<List<ProductDto>>(nameof(ProductDto));

            if (productsCashData != null)
                return Ok(productsCashData);

            var products = productService.GetNewsProduct();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setProductCashData = redisConfiguration.SetData(nameof(ProductDto),products,expireCashData);

            return Ok(products); 
        }
    }
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

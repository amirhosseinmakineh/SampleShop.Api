using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos;
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

        [HttpGet("GetNewsProduct")]
        public IActionResult GetNewsProduct()
        {
            var productsCashData = redisConfiguration.GetData<List<ProductDto>>(nameof(ProductDto));

            if (productsCashData != null)
                return Ok(productsCashData);

            var products = productService.GetNewsProduct();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setProductCashData = redisConfiguration.SetData(nameof(ProductDto), products, expireCashData);

            return Ok(products);
        }
        [HttpGet("GetSpacialProducts")]
        public IActionResult GetSpacialProducts()
        {
            var productsCashData = redisConfiguration.GetData<List<ProductDto>>(nameof(ProductDto));

            if (productsCashData != null)
                return Ok(productsCashData);

            var spacialProducts = productService.GetSpacialProducts();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setProductCashData = redisConfiguration.SetData(nameof(ProductDto), spacialProducts, expireCashData);

            return Ok(spacialProducts);
        }
    }
}

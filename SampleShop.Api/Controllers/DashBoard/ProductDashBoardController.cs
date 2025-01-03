using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.GlobalEnums;
using SampleShop.ApplicationService.Contract.IServices;
using ServiceStack.Script;

namespace SampleShop.Api.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDashBoardController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRedisConfigurationService<List<ProductDto>> redisConfigurationService;
        public ProductDashBoardController(IProductService productService, IRedisConfigurationService<List<ProductDto>> redisConfigurationService)
        {
            this.productService = productService;
            this.redisConfigurationService = redisConfigurationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productsCashData = redisConfigurationService.GetData<List<ProductDto>>(nameof(ProductDto));

            if (productsCashData != null)
                return Ok(productsCashData);

            var products = productService.GetNewsProduct();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setProductCashData = redisConfigurationService.SetData(nameof(ProductDto), products, expireCashData);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(ProductAddDto dto)
        {
                productService.Add(dto);
                return Created("http://localhost:5086/", dto);
        }
        [HttpPut]
        public IActionResult Update(ProductUpdateDto dto)
        {
            productService.UpdateProduct(dto);
            return Created("http://localhost:5086/", dto);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            productService.DeleteProduct(id);
            return Ok();
        }
    }
}

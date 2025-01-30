using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            this.productDetailService = productDetailService;
        }

        [HttpGet]
        public IActionResult GetProductDetails(long productId)
        {
            var productDetail = productDetailService.GetProductDetail(productId);
            return Ok(productDetail);
        }
    }
}

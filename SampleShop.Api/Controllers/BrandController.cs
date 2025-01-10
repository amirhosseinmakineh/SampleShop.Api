using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetBrands()
        {
            var result = brandService.GetAllBrands();
            return Ok(result);
        }
    }
}

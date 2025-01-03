using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService service;

        public SlidersController(ISliderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sliders = service.GetSliders();
            return Ok(sliders);
        }
    }
}

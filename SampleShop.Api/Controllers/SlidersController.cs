using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.Dtos.Slider;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.ApplicationService.Services;
using SampleShop.Domain.Models;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService service;
        private readonly IRedisConfigurationService<List<SliderDto>> redisConfigurationService;
        public SlidersController(ISliderService service, IRedisConfigurationService<List<SliderDto>> redisConfigurationService)
        {
            this.service = service;
            this.redisConfigurationService = redisConfigurationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sliderCashData = redisConfigurationService.GetData<List<ProductDto>>(nameof(ProductDto));
            if(sliderCashData!=null)
                return Ok(sliderCashData);

            var sliders = service.GetSliders();

            var expireCashData = DateTimeOffset.Now
                .AddMinutes(1000);

            var setSliderCashData = redisConfigurationService
                .SetData(nameof(SliderDto), sliders, expireCashData);

            var sliderCashDatas = service
                .GetSliders();

            return Ok(sliderCashDatas);
        }
    }
}

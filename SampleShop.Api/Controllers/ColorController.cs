using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService colorService;
        private readonly IRedisConfigurationService<ColorDto> redisConfiguration;

        public ColorController(IColorService colorService, IRedisConfigurationService<ColorDto> redisConfiguration)
        {
            this.colorService = colorService;
            this.redisConfiguration = redisConfiguration;
        }

        [HttpGet]
        public IActionResult GetAllColors()
        {
            var colorsCashData = redisConfiguration.GetData<List<ColorDto>>(nameof(ColorDto));

            if (colorsCashData != null)
                return Ok(colorsCashData);

            var colors = colorService.GetAll();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setColorCashData = redisConfiguration.SetData(nameof(ColorDto), colors, expireCashData);

            return Ok(colors);
        }
    }

}

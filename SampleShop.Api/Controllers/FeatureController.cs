using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.FeatureDtos;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService featureService;
        private readonly IRedisConfigurationService<FeatureDto> redisConfiguration;

        public FeatureController(IFeatureService featureService, IRedisConfigurationService<FeatureDto> redisConfiguration)
        {
            this.featureService = featureService;
            this.redisConfiguration = redisConfiguration;
        }

        [HttpGet]
        public IActionResult GetNewsProduct()
        {
            var featursCashData = redisConfiguration.GetData<List<FeatureDto>>(nameof(FeatureDto));

            if (featursCashData != null)
                return Ok(featursCashData);

            var featurs = featureService.GetAll();

            var expireCashData = DateTimeOffset.Now.AddMinutes(1000);

            var setFeatursCashData = redisConfiguration.SetData(nameof(FeatureDto), featurs, expireCashData);

            return Ok(featurs);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.Models;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService services;
        private readonly IRedisConfigurationService<CategoryDto> redisConfiguration;
        public CategoryController(ICategoryService services, IRedisConfigurationService<CategoryDto> redisConfiguration)
        {
            this.services = services;
            this.redisConfiguration = redisConfiguration;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cashData = redisConfiguration.GetData<List<CategoryDto>>(nameof(CategoryDto));

            if (cashData != null)
            {
                return Ok(cashData);
            }

            var expirationTime = DateTimeOffset.Now.AddMinutes(1000);

            cashData = services.GetAllCategoryForMenu();

            redisConfiguration.SetData(nameof(CategoryDto), cashData, expirationTime);

            return Ok(cashData);
        }
        [HttpPost]
        public IActionResult Add(AddCategoryDto dto)
        {
            services.AddCategory(dto);
            return Ok(dto);
        }
    }
}

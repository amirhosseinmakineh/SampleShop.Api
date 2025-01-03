using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.Dtos.Slider;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.ApplicationService.Services;

namespace SampleShop.Api.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDashboardController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IRedisConfigurationService<List<CategoryDto>> redisConfigurationService;
        public CategoryDashboardController(ICategoryService categoryService, IRedisConfigurationService<List<CategoryDto>> redisConfigurationService)
        {
            this.categoryService = categoryService;
            this.redisConfigurationService = redisConfigurationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryCashData = redisConfigurationService.GetData<List<CategoryDto>>(nameof(CategoryDto));
            if (categoryCashData != null)
                return Ok(categoryCashData);

            var categories = categoryService.GetAll();

            var expireCashData = DateTimeOffset.Now
                .AddMinutes(1000);

            var setCategoryCashData = redisConfigurationService
                .SetData(nameof(CategoryDto), categories, expireCashData);

            var categoryCashDatas = categoryService
                .GetAll();
            return Ok(categoryCashDatas);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryDto dto)
        {
            categoryService.AddCategory(dto);
            return Created("http://localhost:5086/", dto);
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            categoryService.UpdateCategory(dto);
            return Created("http://localhost:5086/", dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}

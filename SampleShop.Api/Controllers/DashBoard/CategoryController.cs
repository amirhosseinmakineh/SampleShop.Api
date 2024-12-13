using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var result =  categoryService.GetAll();
            return Ok(result);
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

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}

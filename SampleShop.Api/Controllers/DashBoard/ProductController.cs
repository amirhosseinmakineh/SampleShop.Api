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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = productService.GetAllProducts();
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
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            productService.DeleteProduct(id);
            return Ok();
        }
    }
}

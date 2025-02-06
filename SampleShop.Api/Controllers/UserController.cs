using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleShop.ApplicationService.Contract.Dtos.UserDto;
using SampleShop.ApplicationService.Contract.IServices;

namespace SampleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Add(RegisterUserDto dto)
        {
            userService.Register(dto);
            return Ok(dto);
        }
    }
}

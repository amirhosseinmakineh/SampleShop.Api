using SampleShop.ApplicationService.Contract.Dtos.UserDto;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IUserService
    {
        void Register(RegisterUserDto dto);
        string Login(LoginUserDto dto);
    }
}

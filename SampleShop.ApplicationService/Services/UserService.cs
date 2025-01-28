using SampleApi.Security;
using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos.UserDto;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<Guid, User> repository;
        DateConvertor dateConvertor;
        private readonly ITokenGenerator tokenGenerator;
        public UserService(IBaseRepository<Guid, User> repository, ITokenGenerator tokenGenerator)
        {
            this.repository = repository;
            dateConvertor = new DateConvertor();
            this.tokenGenerator = tokenGenerator;
        }

        public string Login(LoginUserDto dto)
        {
            string result = "";
            var user = repository.GetById(dto.Id);
            if (user.Password == DataHasher.HashData(dto.Password))
                result = tokenGenerator.GenerateToken(user);

            return result;
        }

        public void Register(RegisterUserDto dto)
        {
            var user = new User()
            {
                Id = dto.Id,
                IsDelete = false,
                IsLock = false,
                MobileNumber = dto.MobileNumber,
                RoleId = dto.RoleId,
                Password = dto.Password,
                UserName = dto.UserName,
                CreateObjectDat = dateConvertor.CreatePerisanDate(dto.CreateObjectDate, out string persianDate)
            };

            try
            {
                if (user != null)
                {
                    throw new Exception("کاربر وجود دارد");
                }
                else
                {
                    repository.Add(user);
                    repository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

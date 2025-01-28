namespace SampleShop.ApplicationService.Contract.Dtos.UserDto
{
    public record LoginUserDto : BaseDto<Guid>
    {
        public Guid Id { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}

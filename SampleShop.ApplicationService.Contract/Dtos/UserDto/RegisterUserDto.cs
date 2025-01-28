namespace SampleShop.ApplicationService.Contract.Dtos.UserDto
{
    public record RegisterUserDto : BaseDto<Guid>
    {
        public Guid Id { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int MobileNumber { get; set; }
        public bool IsLock { get; set; }
        public DateTime CreateObjectDate { get; set; }
    }

}

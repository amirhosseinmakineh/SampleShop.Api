namespace SampleShop.ApplicationService.Contract.Dtos.ColorDtos
{
    public record ColorAddDto : BaseDto<int>
    {
        public string Title { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }

}

namespace SampleShop.ApplicationService.Contract.Dtos.ColorDtos
{
    public record ColorUpdateDto : BaseDto<int>
    {
        public string Name { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }

}

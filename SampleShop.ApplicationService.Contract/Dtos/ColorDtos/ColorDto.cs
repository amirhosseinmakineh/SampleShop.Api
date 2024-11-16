namespace SampleShop.ApplicationService.Contract.Dtos.ColorDtos
{
    public record ColorDto:BaseDto<int>
    {
        public string Name { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }
}

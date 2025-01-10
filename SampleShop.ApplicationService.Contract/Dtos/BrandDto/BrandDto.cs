namespace SampleShop.ApplicationService.Contract.Dtos.BrandDto
{
    public record BrandDto:BaseDto<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}

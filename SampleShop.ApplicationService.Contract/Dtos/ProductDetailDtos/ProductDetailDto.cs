namespace SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos
{
    public record ProductDetailDto:BaseDto<long>
    {
        public string Description { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }
}

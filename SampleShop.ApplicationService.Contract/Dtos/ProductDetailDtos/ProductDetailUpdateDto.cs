namespace SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos
{
    public record ProductDetailUpdateDto : BaseDto<long>
    {
        public string Description { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }
}

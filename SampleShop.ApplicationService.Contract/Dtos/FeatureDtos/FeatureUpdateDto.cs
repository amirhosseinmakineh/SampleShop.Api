namespace SampleShop.ApplicationService.Contract.Dtos.FeatureDtos
{
    public record FeatureUpdateDto : BaseDto<long>
    {
        public string Title { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }
}

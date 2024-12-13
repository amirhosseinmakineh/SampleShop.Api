namespace SampleShop.ApplicationService.Contract.Dtos
{
    public record ProductUpdateDto : BaseDto<long>
    {
        public long  Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CategoryTitle { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public double Price { get; set; }
        public long CategoryId { get; set; }
    }
}

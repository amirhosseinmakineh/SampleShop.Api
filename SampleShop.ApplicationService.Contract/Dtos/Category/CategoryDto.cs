namespace SampleShop.ApplicationService.Contract.Dtos.Category
{
    public record CategoryDto:BaseDto<long>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long? ParentId { get; set; }
        public List<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
    }
}

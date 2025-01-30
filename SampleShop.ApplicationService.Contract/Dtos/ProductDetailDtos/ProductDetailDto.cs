using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;
using SampleShop.ApplicationService.Contract.Dtos.FeatureDtos;

namespace SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos
{
    public record ProductDetailDto : BaseDto<long>
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductImageName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<ColorDto> Colors { get; set; } = new List<ColorDto>();
        public List<FeatureDto> Features { get; set; } = new List<FeatureDto>();
        public List<CommentDto.CommentDto> Comments { get; set; } = new List<CommentDto.CommentDto>();
        public long ProductId { get; set; }
        public string CategoryName { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;
using SampleShop.ApplicationService.Contract.Dtos.FeatureDtos;
using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;
using System.Drawing;

namespace SampleShop.ApplicationService.Contract.Dtos
{
    public record ProductAddDto:BaseDto<long>
    {
        public string Title { get; set; } = string.Empty;
        public string CategoryTitle { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public  ICollection<ProductDetailAddDto> ProductDetails { get; set; }
        public  ICollection<ColorAddDto> Colors { get; set; }
        public  ICollection<FeatureAddDto> Featurs { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}

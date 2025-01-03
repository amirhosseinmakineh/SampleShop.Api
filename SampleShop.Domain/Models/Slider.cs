namespace SampleShop.Domain.Models
{
    public class Slider : BaseEntity<long>
    {
        public string ImageName { get; set; } = string.Empty;
    }
}

namespace SampleShop.Domain.Models
{
    public class Brand : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}

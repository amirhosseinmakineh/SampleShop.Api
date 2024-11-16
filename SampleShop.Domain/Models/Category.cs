namespace SampleShop.Domain.Models
{
    public class Category:BaseEntity<long>
    {
        public Category()
        {
            Categories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }
        public string Title { get; set; } = string.Empty;
        public long? ParentId { get; set; }
        public string Description { get; set; } = string.Empty;
        #region Relations
        public Category? Parent { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
